using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static AGCGM.Internal.XMLDB.TDBEnums;
using static AGCGM.Internal.XMLDB.TDBUtil;

namespace AGCGM.Internal.XMLDB
{
    internal partial class TDBGame
    {
        //Propiedades publicas.
        public string Code { get; private set; }
        public GameType Type { get; private set; }
        public GameRegion Region { get; private set; }
        public GameLanguage[] Languages { get; private set; }
        public KeyValuePair<GameLanguage, string>[] Titles { get; private set; }
        public KeyValuePair<GameLanguage, string>[] Synopsis { get; private set; }
        public string Developer { get; private set; }
        public string Publisher { get; private set; }
        public DateTime Date { get; private set; }
        public int WifiPlayers { get; private set; }
        public WifiFeature[] WifiFeatures { get; private set; }
        public int Players { get; private set; }
        public InputControl[] ControlsRequired { get; private set; }
        public InputControl[] ControlsOptional { get; private set; }

        public new string GetType()
        {
            switch (Type)
            {
                case GameType.WiiGame:
                    return "Wii";
                case GameType.WiiWare:
                    return "Wii Ware";
                case GameType.Homebrew:
                    return "Homebrew";
                case GameType.Channel:
                    return "Canal Wii";
                case GameType.VC_NES:
                    return "VC NES";
                case GameType.VC_SNES:
                    return "VC SNES";
                case GameType.VC_N64:
                    return "VC N64";
                case GameType.VC_SMS:
                    return "VC SMS";
                case GameType.VC_MD:
                    return "VC MD";
                case GameType.VC_PCE:
                    return "VC PCE";
                case GameType.VC_NEOGEO:
                    return "VC NEOGEO";
                case GameType.VC_Arcade:
                    return "VC Arcade";
                case GameType.VC_C64:
                    return "VC C64";
                case GameType.VC_MSX:
                    return "VC MSX";
                case GameType.CUSTOM:
                    return "Personalizado";
                case GameType.GameCube:
                    return "Game Cube";
                default:
                    return "Desconocido";
            }
        }

        public string GetRegion()
        {
            switch (Region)
            {
                case GameRegion.PAL:
                    return "PAL";
                case GameRegion.PAL_R:
                    return "PAL";
                case GameRegion.NTSC_U:
                    return "NTSC-U";
                case GameRegion.NTSC_J:
                    return "NTSC-J";
                case GameRegion.NTSC_K:
                    return "NTSC-K";
                case GameRegion.NTSC_T:
                    return "NTSC-T";
                case GameRegion.FREE:
                    return "Libre";
                default:
                    return "Desconocido";
            }
        }

        public string GetLanguages()
        {
            return string.Join(", ", Languages.Select(lang =>
            {
                switch (lang)
                {
                    case GameLanguage.EN:
                        return "Ingles";
                    case GameLanguage.JA:
                        return "Japones";
                    case GameLanguage.FR:
                        return "Frances";
                    case GameLanguage.DE:
                        return "Aleman";
                    case GameLanguage.ES:
                        return "Español";
                    case GameLanguage.IT:
                        return "Italiano";
                    case GameLanguage.NL:
                        return "NL";
                    case GameLanguage.PT:
                        return "PT";
                    case GameLanguage.ZHTW:
                        return "ZHTW";
                    case GameLanguage.ZHCN:
                        return "ZHCN";
                    case GameLanguage.KO:
                        return "Koreano";
                    default:
                        return "Desconocido";
                }
            }));
        }

        public static TDBGame CreateFrom(XElement node)
        {
            TDBUtil TDB = new TDBUtil(node);

            //Datos opcionales
            var locales = node.Elements(F_LOCALE).Select((locale) => new
            {
                Lang = TDB.EnumOf(locale, A_LANG, T.ATTR, GameLanguage.Unknown, optional: true),
                Title = TDB.StringOf(locale, F_TITLE, T.VAL, optional: true),
                Synopsis = TDB.StringOf(locale, F_SYNOPSIS, T.VAL, optional: true)
            }
            ).Where((locale) => locale.Lang != GameLanguage.Unknown);

            var input_controls = node.Element(F_INPUT).Elements(F_INPUT_CONTROL).Select(item => new {
                Required = item.Attribute(F_INPUT_CONTROL_ATTR_REQUIRED).Value == "true",
                Type = TDB.EnumOf(item, F_INPUT_CONTROL_ATTR_TYPE, T.ATTR, InputControl.Unknown, true)
            });

            //Creando objeto.
            TDBGame game = new TDBGame
            {
                Code = TDB.String(F_ID, T.VAL, optional: false),
                Type = TDB.Enum(F_TYPE, T.VAL, GameType.WiiGame, GameType.Unknown, optional: false),
                Region = TDB.Enum(F_REGION, T.VAL, GameRegion.FREE, GameRegion.Unknown, optional: false),
                Languages = TDB.EnumsArray(F_LANGUAGE, T.VAL, GameLanguage.Unknown, optional: true).Where(lang => lang != GameLanguage.Unknown).ToArray(),
                Titles = (locales.Where(local => !string.IsNullOrEmpty(local.Title)).Select(local => GetPair(local.Lang, local.Title))).ToArray(),
                Synopsis = (locales.Where(local => !string.IsNullOrEmpty(local.Synopsis)).Select(local => GetPair(local.Lang, local.Synopsis))).ToArray(),
                Developer = TDB.String(F_DEVELOPER, T.VAL, optional: true),
                Publisher = TDB.String(F_PUBLISHER, T.VAL, optional: true),
                WifiPlayers = TDB.IntOf(node.Element(F_WIFI), A_PLAYERS, T.ATTR, optional: true),
                WifiFeatures = TDB.EnumsArray(node.Element(F_WIFI), F_WIFI_FEATURE, WifiFeature.Unknown).Where(feature => feature != WifiFeature.Unknown).ToArray(),
                Players = TDB.IntOf(node.Element(F_INPUT), A_PLAYERS, T.ATTR, optional: true),
                ControlsRequired = input_controls.Where(input => input.Required).Select(input => input.Type).ToArray(),
                ControlsOptional = input_controls.Where(input => !input.Required).Select(input => input.Type).ToArray()
            };

            //Tratando fecha.
            int year = TDB.IntOf(node.Element(F_DATE), A_YEAR, T.ATTR, optional: true);
            int month = TDB.IntOf(node.Element(F_DATE), A_MONTH, T.ATTR, optional: true);
            int day = TDB.IntOf(node.Element(F_DATE), A_DAY, T.ATTR, optional: true);

            game.Date = default;
            if (year > 0) game.Date = game.Date.AddYears(year - 1);
            if (month > 0) game.Date = game.Date.AddMonths(month - 1);
            if (day > 0) game.Date = game.Date.AddDays(day - 1);

            return game;
        }
    }

    public class TDBUtil
    {
        public XElement Node;
        public TDBUtil(XElement node) => Node = node;

        public enum T
        {
            ATTR,
            VAL
        }

        public string String(string ID, T type, bool optional) => StringOf(Node, ID, type, optional);
        public string StringOf(XElement node, string ID, T type, bool optional)
        {
            if (type == T.ATTR)
                return optional ? node?.Attribute(ID)?.Value : node.Attribute(ID).Value;
            else
                return optional ? node?.Element(ID)?.Value : node.Element(ID).Value;
        }

        public int Int(string ID, T type, bool optional) => IntOf(Node, ID, type, optional);
        public int IntOf(XElement node, string ID, T type, bool optional)
        {
            string value = StringOf(node, ID, type, optional);
            return optional ? int.TryParse(value, out int result) ? result : -1 : int.Parse(value);
        }

        public TEnum Enum<TEnum>(string ID, T type, TEnum onInvalid, bool optional) where TEnum : struct => EnumOf(Node, ID, type, onInvalid, optional);
        public TEnum Enum<TEnum>(string ID, T type, TEnum onEmpty, TEnum onInvalid, bool optional) where TEnum : struct => EnumOf(Node, ID, type, onEmpty, onInvalid, optional);

        public TEnum EnumOf<TEnum>(XElement node, string ID, T type, TEnum onInvalid, bool optional) where TEnum : struct => EnumOf(node, ID, type, onInvalid, onInvalid, optional);
        public TEnum EnumOf<TEnum>(XElement node, string ID, T type, TEnum onEmpty, TEnum onInvalid, bool optional) where TEnum : struct => EnumOfValue(StringOf(node, ID, type, optional), onEmpty, onInvalid);

        public TEnum EnumOfValue<TEnum>(string value, TEnum onInvalid) where TEnum : struct => EnumOfValue(value, onInvalid, onInvalid);
        public TEnum EnumOfValue<TEnum>(string value, TEnum onEmpty, TEnum onInvalid) where TEnum : struct
        {
            if (value is null) return onInvalid;
            else if (value.Trim() == "") return onEmpty;
            else return System.Enum.TryParse(value.Replace('-', '_'), out TEnum result) ? result : onInvalid;
        }

        public TEnum[] EnumsArray<TEnum>(XElement node, string ID, TEnum onInvalid) where TEnum : struct => EnumsArray(node, ID, onInvalid, onInvalid);
        public TEnum[] EnumsArray<TEnum>(XElement node, string ID, TEnum onEmpty, TEnum onInvalid) where TEnum : struct
        {
            return node.Elements(ID).Select(subnode => EnumOfValue(subnode.Value, onEmpty, onInvalid)).ToArray();
        }

        public TEnum[] EnumsArray<TEnum>(string ID, T type, TEnum onInvalid, bool optional) where TEnum : struct
        {
            return EnumsArray(Node, ID, type, onInvalid, onInvalid, optional);
        }
        public TEnum[] EnumsArray<TEnum>(string ID, T type, TEnum onEmpty, TEnum onInvalid, bool optional) where TEnum : struct
        {
            return EnumsArray(Node, ID, type, onEmpty, onInvalid, optional);
        }
        public TEnum[] EnumsArray<TEnum>(XElement node, string ID, T type, TEnum onEmpty, TEnum onInvalid, bool optional) where TEnum : struct
        {
            return StringOf(node, ID, type, optional)?.Split(',').Where(val => !string.IsNullOrWhiteSpace(val)).Select(val => EnumOfValue(val, onEmpty, onInvalid)).ToArray();
        }

        public static KeyValuePair<T, T2> GetPair<T, T2>(T key, T2 value) => new KeyValuePair<T, T2>(key, value);
    }
}
