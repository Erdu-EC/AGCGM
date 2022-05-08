using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.XMLDB
{
    public static class TDBEnums
    {
        public enum GameType : short
        {
            Unknown = 0,
            WiiGame,
            WiiWare,
            Homebrew,
            Channel,
            VC_NES,
            VC_SNES,
            VC_N64,
            VC_SMS,
            VC_MD,
            VC_PCE,
            VC_NEOGEO,
            VC_Arcade,
            VC_C64,
            VC_MSX,
            CUSTOM,
            GameCube
        }

        public enum GameRegion : short
        {
            Unknown = 0,
            PAL,
            PAL_R,
            NTSC_U,
            NTSC_J,
            NTSC_K,
            NTSC_T,
            FREE,
        }

        public enum GameLanguage : short
        {
            Unknown = 0,
            EN, //Ingles
            JA, //Japones
            FR, //Frances
            DE, //Aleman
            ES, //Español
            IT, //Italiano
            NL,
            PT,
            ZHTW,
            ZHCN,
            KO
        }

        public enum WifiFeature : short
        {
            Unknown = 0,
            online,
            download,
            score,
            nintendods
        }

        public enum InputControl
        {
            Unknown = 0,
            wiimote,
            nunchuk,
            motionplus,
            gamecube,
            nintendods,
            classiccontroller,
            wheel,
            zapper,
            balanceboard,
            wiispeak,
            microphone,
            guitar,
            drums,
            dancepad,
            keyboard,
            udraw
        }
    }
}
