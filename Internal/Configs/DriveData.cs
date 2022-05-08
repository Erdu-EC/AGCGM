using AGCGM.Internal.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.Configs
{
    public class DriveData
    {
        public DriveData() { }
        public DriveData(Drive data)
        {
            Name = data.Name;
            Label = data.Label;
        }
        public DriveData(string name, string label)
        {
            Name = name;
            Label = label;
        }

        //Constantes.
        public const string GCRoot = "games";
        public const string WiiRoot = "wbfs";

        //Propiedades publicas.
        public string Name { get; set; } = null;
        public string Label { get; set; } = null;
        public string Alias { get; set; } = null;
        public bool Hidden { get; set; } = false;
        public bool Automount { get; set; } = true;

        //Metodos para comprobaciones
        public bool IsEmpty() => Alias == null && Hidden == false && Automount == true;

        //Metodos para obtener datos.
        public string GetID() => $"<{Name}|{Label}>";
        public string GetLabel() => Alias ?? Label;
        public string GetName() => Name.TrimEnd(new char[] { '\\', '/' });
        public string GetGCRoot() => GetGCRoot(Name);
        public string GetWiiRoot() => GetWiiRoot(Name);

        //public string GetFormatedName() => string.Format(Lang.strings.CONST_DRIVE_FULLNAME, Label, GetName());
        public string GetFormatedLabel() => string.Format(Lang.strings.CONST_DRIVE_FULLNAME, GetLabel(), GetName());

        //Metodos estaticos para obtener datos.
        public static string GetGCRoot(string Name) => Path.Combine(Name, GCRoot);
        public static string GetWiiRoot(string Name) => Path.Combine(Name, WiiRoot);
    }
}
