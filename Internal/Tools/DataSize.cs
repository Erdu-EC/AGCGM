using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AGCGM.Internal.Tools
{
    internal static class DataSize
    {
        public enum Unit
        {
            Null = -1,
            Byte = 0,
            KB,
            MB,
            GB,
            TB,
            PT,
            EX,
            ZB,
            YB
        }

        /*public static int Compare(string valueA, string valueB)
        {
            return valueA > valueB;
        }*/

        private const int BASEN = 1024;

        public static long Parse(string length)
        {
            string[] splitted = length.Split(' ');
            if (splitted.Length > 0 && splitted.Length <= 2)
            {
                //Obteniendo numero.
                double number = double.Parse(splitted[0]);

                //Obteniendo unidad de medida.
                Unit unit = Unit.Byte;
                if (splitted.Length == 2) Enum.TryParse(splitted[1].ToString(), out unit);

                //Realizando calculos.
                switch (unit)
                {
                    case Unit.Byte:
                        return (long)number;
                    default:
                        return (long)(number * Math.Pow(BASEN, (int)unit));
                }
            }

            /*var result = Regex.Match(length, @"(\d*(?:(?:\.|\,)\d*)?) (Byte|Bytes|KB|MB|GB|TB|PT|EX|ZB|YB)", RegexOptions.IgnoreCase);
            if (result.Success)
            {
                if (result.Groups.Count == 3)
                {
                    float number = float.Parse(result.Groups[1].Value);
                    float potencia = result.Groups[1].Value == "Bytes";
                    return number * Math.Pow(BASEN, (int)Enum.Parse(typeof(Unit), result.Groups[1].Value));
                }
            }*/
            return -1;
        }

        public static string ToString(long length, Unit unit = Unit.Null)
        {
            //Si es negativo, no devolver nada.
            if (length < 0) return null;

            //Variables
            int potencia;
            double data;

            //Calculando potencia o Estableciendo potencia pasada como parametro
            potencia = (unit == Unit.Null) ? (int)Math.Log(length, BASEN) : (int)unit;

            //Verificando la potencia limite
            if (potencia > (int)Unit.YB) potencia = (int)Unit.YB;

            //Si es potencia negativa (length == 0)
            if (potencia < 0) potencia = 0;

            //Calculando nuevo valor
            switch ((Unit)potencia)
            {
                case Unit.Byte:
                    data = length;
                    break;
                default:
                    data = Math.Round(length / Math.Pow(BASEN, potencia), 2);
                    break;
            }

            //Obteniendo unidad de medida (texto)
            string unidad = Enum.GetName(typeof(Unit), potencia);

            if (potencia == (int)Unit.Byte && data != 1) unidad += "s";

            //Devolviendo cadena segun formato especificado
            return string.Format("{0} {1}", data, unidad);
        }

        public static int Compare(long x, long y)
        {
            if (x > y) return 1;
            else if (x < y) return -1;
            else return 0;
        }
    }
}
