namespace AGCGM.Internal.XMLDB
{
    internal partial class TDBDatabase
    {
        public const string DB_NAME = "WiiTDB";
        public const string DB_ATTR_VERSION = "version";

        public const string ITEM_GAME = "game";
        public const string ITEM_COMPANY = "company";
        public const string ITEM_COMPANY_CODE = "code";
        public const string ITEM_COMPANY_NAME = "name";
    }

    internal partial class TDBGame
    {
        public const string F_ID = "id";
        public const string F_TYPE = "type";
        public const string F_REGION = "region";
        public const string F_LANGUAGE = "languages";
        public const string F_LOCALE = "locale";
        public const string A_LANG = "lang";
        public const string F_TITLE = "title";
        public const string F_SYNOPSIS = "synopsis";
        public const string F_DEVELOPER = "developer";
        public const string F_PUBLISHER = "publisher";
        public const string F_DATE = "date";
        public const string A_YEAR = "year";
        public const string A_MONTH = "month";
        public const string A_DAY = "day";
        public const string F_WIFI = "wi-fi";
        public const string A_PLAYERS = "players";
        public const string F_WIFI_FEATURE = "feature";
        public const string F_INPUT = "input";
        public const string F_INPUT_CONTROL = "control";
        public const string F_INPUT_CONTROL_ATTR_TYPE = "type";
        public const string F_INPUT_CONTROL_ATTR_REQUIRED = "required";
    }
}
