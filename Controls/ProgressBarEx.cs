using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GCGM.Controls
{
    [Description("Barra de progreso extendida")]
    [ToolboxBitmap(typeof(ProgressBar))]
    public partial class ProgressBarEx : ProgressBar
    {
        #region Miembros privados. . .

        //Comportamiento
        private ProgressBarState _State;

        //Apariencia (Texto)
        private ContentAlignment _TextAlign;
        private StringFormat _StringFormat;
        private Color _TextColor;

        //Apariencia (Borde)
        private Color _BorderColor = SystemColors.ActiveBorder;
        private int _BorderWidth = 1;

        //Brush y pens.
        private LinearGradientBrush BrushBar;
        private SolidBrush BrushText;
        private Pen PenBorder;

        //Miembros de control de animacion
        private Timer Animation_timer;
        public int _AnimationSpeed = 4000;
        private bool isAnimationTime = false;
        private int AnimatedBarWidth = 0, AnimatedBarFlag = 0;

        #endregion


        #region Propiedades publicas. . .

        //Texto de la PB.
        [Category("Apariencia (Texto)")]
        [Description("Fuente del texto mostrado en la barra de progresos.")]
        public Font TextFont { get; set; }

        [Category("Apariencia (Texto)")]
        [Description("Texto literal o formato en que sera mostrado el texto (Porcentage) sobre la barra de progresos.")]
        [RefreshProperties(RefreshProperties.All)]
        public string TextFormat { get; set; } = "{0}%";

        [Category("Apariencia (Texto)")]
        [Description("Forma en que se agregaran puntos suspensivos cuando el texto se desborde del control.")]
        [RefreshProperties(RefreshProperties.All)]
        public StringTrimming TextEllipsis { get => _StringFormat.Trimming; set => _StringFormat.Trimming = value; }

        [Category("Apariencia (Texto)")]
        [Description("Alineacion del texto (Porcentage) mostrado sobre la barra de progresos.")]
        [Editor("System.Drawing.Design.ContentAlignmentEditor, System.Drawing.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public ContentAlignment TextAlign
        {
            get { return _TextAlign; }
            set {
                _TextAlign = value;

                //Alineacion vertical
                switch (value) {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.TopRight:
                        _StringFormat.LineAlignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.MiddleRight:
                        _StringFormat.LineAlignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomRight:
                        _StringFormat.LineAlignment = StringAlignment.Far;
                        break;
                }

                //Alineacion horizontal
                switch (value) {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.BottomLeft:
                        _StringFormat.Alignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.BottomCenter:
                        _StringFormat.Alignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.TopRight:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.BottomRight:
                        _StringFormat.Alignment = StringAlignment.Far;
                        break;
                }
            }
        }

        [Category("Apariencia (Texto)")]
        [Description("Color del texto (Porcentage) mostrado sobre la barra de progresos.")]
        public Color TextColor { get => _TextColor; set { _TextColor = value; BrushText = new SolidBrush(value); } }

        //Borde de la PB.
        [Category("Apariencia (Borde y padding)")]
        [Description("Color del borde de la barra de progresos.")]
        public Color BorderColor { get => _BorderColor; set { _BorderColor = value; PenBorder.Color = value; } }

        [Category("Apariencia (Borde y padding)")]
        [Description("Ancho del borde de la barra de progresos.")]
        public int BorderWidth { get => _BorderWidth; set { _BorderWidth = value; PenBorder.Width = value; } }

        [Category("Apariencia (Borde y padding)")]
        [Description("Distancia entre el borde y la barra de la ProgressBar.")]
        public int BorderPadding { get; set; } = 1;

        //Barra de la PB.
        [Category("Colores EX")]
        [Description("Color de la barra de progreso en su estado \"normal\"")]
        public Color NormalColor { get; set; } = Color.FromArgb(0, 192, 0);

        [Category("Colores EX")]
        [Description("Color de la barra de progreso cuando se encuentra en estado \"Pausado\"")]
        public Color PausedColor { get; set; } = Color.FromArgb(192, 192, 0);

        [Category("Colores EX")]
        [Description("Color de la barra de progreso cuando se encuentra en estado de \"error\"")]
        public Color ErrorColor { get; set; } = Color.FromArgb(192, 0, 0);

        //Comportamiento de la PB.
        [Category("Comportamiento EX")]
        [Description("Estado de la barra de progreso.")]
        public ProgressBarState State
        {
            get => _State; set {
                _State = value;

                BrushBar = GetLinearBrush(BarColor);
            }
        }

        [Category("Comportamiento EX")]
        [Description("Estilo de la barra de progreso.")]
        public new ProgressBarStyle Style { get; set; }

        [Category("Comportamiento EX")]
        [Description("Intervalo entre cada ocurrencia de la animacion de la barra de progreso.")]
        public int AnimationInterval
        {
            get => _AnimationSpeed;
            set {
                _AnimationSpeed = value;
                Animation_timer.Interval = value;
            }
        }

        #endregion

        //Propiedades privadas
        private Color BarColor
        {
            get {
                switch (State) {
                    case ProgressBarState.Normal:
                        return NormalColor;
                    case ProgressBarState.Paused:
                        return PausedColor;
                    case ProgressBarState.Error:
                        return ErrorColor;
                    default:
                        return Color.Empty;
                }
            }
        }

        //Propiedades ocultas
        [Browsable(false)]
        public override Color ForeColor { get; set; }

        [Browsable(false)]
        public new int MarqueeAnimationSpeed { get; set; }

        //Enumeraciones
        public enum ProgressBarState
        {
            Normal,
            Paused,
            Error
        }

        public enum ProgressBarStyle
        {
            Continuous,
            Marquee
        }

        public enum ContentAlignment
        {
            TopLeft = 1,
            TopCenter = 2,
            TopRight = 4,
            MiddleLeft = 16,
            MiddleCenter = 32,
            MiddleRight = 64,
            BottomLeft = 256,
            BottomCenter = 512,
            BottomRight = 1024
        }

        //Constructores
        public ProgressBarEx()
        {
            InitializeComponent();
            Initialize();
        }

        public ProgressBarEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            //Flags nativos
            SetStyle(
                ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw,
                true);

            //Estableciendo estado inicial de PB.
            State = ProgressBarState.Normal;

            //Inicializando animacion de ProgressBar
            Animation_timer = new Timer() {
                Interval = AnimationInterval
            };
            Animation_timer.Tick += AnimationTimerAction;
            Animation_timer.Start();

            //Estableciendo fuente por defecto.
            TextFont = new Font(DefaultFont, FontStyle.Regular);

            //Color del texto sobre PB.
            TextColor = Color.Black;

            //Inicializando formatstring
            _StringFormat = new StringFormat() {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            };

            //Especificando alineacion del texto mostrado sobre la barra de progresos.
            TextAlign = ContentAlignment.MiddleCenter;

            //Inicializando borde de la barra de progreso.
            PenBorder = new Pen(BorderColor, BorderWidth);
        }

        //Funciones de dibujo
        protected override void OnPaint(PaintEventArgs e)
        {
            //Calculando modificacion del rectangulo
            //Rectangle rectangle_mod = e.ClipRectangle;
            Rectangle rectangle_mod = this.ClientRectangle;

            rectangle_mod.Y += BorderWidth;
            rectangle_mod.X += BorderWidth;
            rectangle_mod.Height -= (BorderWidth * 2) + (BorderPadding * 2);
            rectangle_mod.Width -= (BorderWidth * 2) + (BorderPadding * 2);

            //Controlando posible error
            if (rectangle_mod.Width != 0 && rectangle_mod.Height != 0) {
                //Dibujando barra de progreso con rectangulo modificado
                if (Style == ProgressBarStyle.Continuous)
                    DrawContinuousBar(e.Graphics, rectangle_mod);
                else
                    DrawMarqueeBar(e.Graphics, rectangle_mod);
            }

            //Dibujando texto con rectangulo original
            DrawText(e.Graphics, this.ClientRectangle);

            //Dibujando borde con rectangulo original
            DrawBorder(e.Graphics, this.ClientRectangle);
        }

        protected void DrawContinuousBar(Graphics graphic, Rectangle rectangle)
        {
            //Calculando ancho de la barra de progreso.
            rectangle.Width = (int)(rectangle.Width * ((double)Value / Maximum));
            if (rectangle.Width == 0) return;

            //Dibujando barra de progreso
            graphic.FillRectangle(BrushBar, rectangle.X + BorderPadding, rectangle.Y + BorderPadding, rectangle.Width, rectangle.Height);

            //Comprobando el intervalo de la animacion
            if (!isAnimationTime) return;

            //Desactivando temporalmente el timer.
            Animation_timer.Stop();

            //Calculando el ancho de la ProgressBar animada
            AnimatedBarWidth = (AnimatedBarWidth += ((5 * rectangle.Width) / 100));
            if (AnimatedBarWidth > rectangle.Width) AnimatedBarWidth = rectangle.Width;

            //Obteniendo brush para ProgressBar animada
            LinearGradientBrush anim_brush = GetLinearBrush(BarColor, rectangle);

            //Dibujando animacion
            switch (AnimatedBarFlag) {
                case 0:
                    graphic.FillRectangle(anim_brush, rectangle.X + BorderPadding, rectangle.Y + BorderPadding, AnimatedBarWidth, rectangle.Height);
                    break;
                case 1:
                    graphic.FillRectangle(anim_brush, rectangle.X + AnimatedBarWidth + BorderPadding, rectangle.Y + BorderPadding, rectangle.Width - AnimatedBarWidth, rectangle.Height);
                    break;
                default:
                    isAnimationTime = false;
                    AnimatedBarFlag = 0;

                    //Activando nuevamente el Timer.
                    Animation_timer.Start();
                    break;
            }

            //Calculando ancho 2
            if (AnimatedBarWidth >= rectangle.Width) {
                AnimatedBarWidth = 0;
                AnimatedBarFlag++;
            }
        }

        protected void DrawMarqueeBar(Graphics graphic, Rectangle rectangle)
        {
            //Comprobando el intervalo de la animacion
            if (!isAnimationTime) return;

            //Desactivando temporalmente el timer.
            Animation_timer.Stop();

            //Calculando el ancho de la ProgressBar animada
            AnimatedBarWidth = (AnimatedBarWidth += ((5 * rectangle.Width) / 100));
            if (AnimatedBarWidth > rectangle.Width) AnimatedBarWidth = rectangle.Width;

            //Dibujando animacion
            switch (AnimatedBarFlag) {
                case 0:
                    graphic.FillRectangle(BrushBar, rectangle.X + BorderPadding, rectangle.Y + BorderPadding, AnimatedBarWidth, rectangle.Height);
                    break;
                case 1:
                    graphic.FillRectangle(BrushBar, rectangle.X + AnimatedBarWidth + BorderPadding, rectangle.Y + BorderPadding, rectangle.Width - AnimatedBarWidth, rectangle.Height);
                    break;
                default:
                    isAnimationTime = false;
                    AnimatedBarFlag = 0;

                    //Activando nuevamente el Timer.
                    Animation_timer.Start();
                    break;
            }

            //Calculando ancho 2
            if (AnimatedBarWidth >= rectangle.Width) {
                AnimatedBarWidth = 0;
                AnimatedBarFlag++;
            }
        }

        protected void DrawBorder(Graphics graphic, Rectangle rectangle)
        {
            //Si no es necesario dibujar el borde.
            if (BorderWidth == 0) return;

            //Calculando modificacion de area
            int border = BorderWidth / 2;
            if (border < 0) border = 0;

            rectangle.Y += border;
            rectangle.X += border;
            rectangle.Height -= BorderWidth;
            rectangle.Width -= BorderWidth;

            //Dibujando borde
            graphic.DrawRectangle(PenBorder, rectangle);
        }

        protected void DrawText(Graphics graphic, Rectangle rectangle)
        {
            graphic.DrawString(string.Format(TextFormat, Value), TextFont, BrushText, rectangle, _StringFormat);
        }

        //Metodos privados
        private void AnimationTimerAction(object a, EventArgs i) { if (!isAnimationTime) isAnimationTime = true; }

        private LinearGradientBrush GetLinearBrush(Color BaseColor) => GetLinearBrush(BaseColor, ClientRectangle);
        private LinearGradientBrush GetLinearBrush(Color BaseColor, Rectangle rectangle) => new LinearGradientBrush(rectangle, ControlPaint.Light(BaseColor), BaseColor, LinearGradientMode.Vertical);
    }
}
