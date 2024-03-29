﻿
using TOAPI.Types;

namespace TOAPI.AviCap32
{
    public partial class Vfw
    {
        /* Values for dwFlags of ICOpen() */
        public const int ICMODE_COMPRESS        = 1;
        public const int ICMODE_DECOMPRESS	    = 2;
        public const int ICMODE_FASTDECOMPRESS  = 3;
        public const int ICMODE_QUERY           = 4;
        public const int ICMODE_FASTCOMPRESS    = 5;
        public const int ICMODE_DRAW            = 8;

        public static uint ICTYPE_VIDEO  =  FOURCC.MakeFourCC('v', 'i', 'd', 'c');
        public static uint ICTYPE_AUDIO = FOURCC.MakeFourCC('a', 'u', 'd', 'c');

        // dwFlags field of VIDEOHDR
        public const int VHDR_DONE      = 0x00000001;  /* Done bit */
        public const int VHDR_PREPARED  = 0x00000002;  /* Set if this header has been prepared */
        public const int VHDR_INQUEUE   = 0x00000004;  /* Reserved for driver */
        public const int VHDR_KEYFRAME  = 0x00000008;  /* Key Frame */
        public const int VHDR_VALID     = 0x0000000F;  /* valid flags */

        //  CapControlCallback states
        public const int CONTROLCALLBACK_PREROLL      =   1; /* Waiting to start capture */
        public const int CONTROLCALLBACK_CAPTURING = 2; /* Now capturing */

         // Defines start of the message range
        public const int WM_CAP_START                   = (int)WinMsg.WM_USER;

        // start of unicode messages
        public const int WM_CAP_UNICODE_START           = (int)WinMsg.WM_USER + 100;

        public const int WM_CAP_GET_CAPSTREAMPTR        = (WM_CAP_START+  1);

        public const int WM_CAP_SET_CALLBACK_ERRORW     = (WM_CAP_UNICODE_START+  2);
        public const int WM_CAP_SET_CALLBACK_STATUSW    = (WM_CAP_UNICODE_START+  3);
        public const int WM_CAP_SET_CALLBACK_ERRORA     = (WM_CAP_START+  2);
        public const int WM_CAP_SET_CALLBACK_STATUSA    = (WM_CAP_START+  3);
        public const int WM_CAP_SET_CALLBACK_ERROR      =  WM_CAP_SET_CALLBACK_ERRORW;
        public const int WM_CAP_SET_CALLBACK_STATUS     =  WM_CAP_SET_CALLBACK_STATUSW;


        public const int WM_CAP_SET_CALLBACK_YIELD       = (WM_CAP_START+  4);
        public const int WM_CAP_SET_CALLBACK_FRAME       = (WM_CAP_START+  5);
        public const int WM_CAP_SET_CALLBACK_VIDEOSTREAM = (WM_CAP_START+  6);
        public const int WM_CAP_SET_CALLBACK_WAVESTREAM  = (WM_CAP_START+  7);
        public const int WM_CAP_GET_USER_DATA		= (WM_CAP_START+  8);
        public const int WM_CAP_SET_USER_DATA		= (WM_CAP_START+  9);

        public const int WM_CAP_DRIVER_CONNECT           = (WM_CAP_START+  10);
        public const int WM_CAP_DRIVER_DISCONNECT        = (WM_CAP_START+  11);

        public const int WM_CAP_DRIVER_GET_NAMEA        = (WM_CAP_START+  12);
        public const int WM_CAP_DRIVER_GET_VERSIONA     = (WM_CAP_START+  13);
        public const int WM_CAP_DRIVER_GET_NAMEW        = (WM_CAP_UNICODE_START+  12);
        public const int WM_CAP_DRIVER_GET_VERSIONW     = (WM_CAP_UNICODE_START+  13);
        public const int WM_CAP_DRIVER_GET_NAME          = WM_CAP_DRIVER_GET_NAMEW;
        public const int WM_CAP_DRIVER_GET_VERSION       = WM_CAP_DRIVER_GET_VERSIONW;

        public const int WM_CAP_DRIVER_GET_CAPS          = (WM_CAP_START+  14);

        public const int WM_CAP_FILE_SET_CAPTURE_FILEA  = (WM_CAP_START+  20);
        public const int WM_CAP_FILE_GET_CAPTURE_FILEA  = (WM_CAP_START+  21);
        public const int WM_CAP_FILE_SAVEASA            = (WM_CAP_START+  23);
        public const int WM_CAP_FILE_SAVEDIBA           = (WM_CAP_START+  25);
        public const int WM_CAP_FILE_SET_CAPTURE_FILEW  = (WM_CAP_UNICODE_START+  20);
        public const int WM_CAP_FILE_GET_CAPTURE_FILEW  = (WM_CAP_UNICODE_START+  21);
        public const int WM_CAP_FILE_SAVEASW            = (WM_CAP_UNICODE_START+  23);
        public const int WM_CAP_FILE_SAVEDIBW           = (WM_CAP_UNICODE_START+  25);
        public const int WM_CAP_FILE_SET_CAPTURE_FILE    = WM_CAP_FILE_SET_CAPTURE_FILEW;
        public const int WM_CAP_FILE_GET_CAPTURE_FILE    = WM_CAP_FILE_GET_CAPTURE_FILEW;
        public const int WM_CAP_FILE_SAVEAS              = WM_CAP_FILE_SAVEASW;
        public const int WM_CAP_FILE_SAVEDIB             = WM_CAP_FILE_SAVEDIBW;

        // out of order to save on ifdefs
        public const int WM_CAP_FILE_ALLOCATE            = (WM_CAP_START+  22);
        public const int WM_CAP_FILE_SET_INFOCHUNK       = (WM_CAP_START+  24);

        public const int WM_CAP_EDIT_COPY                = (WM_CAP_START+  30);

        public const int WM_CAP_SET_AUDIOFORMAT          = (WM_CAP_START+  35);
        public const int WM_CAP_GET_AUDIOFORMAT          = (WM_CAP_START+  36);

        public const int WM_CAP_DLG_VIDEOFORMAT          = (WM_CAP_START+  41);
        public const int WM_CAP_DLG_VIDEOSOURCE          = (WM_CAP_START+  42);
        public const int WM_CAP_DLG_VIDEODISPLAY         = (WM_CAP_START+  43);
        public const int WM_CAP_GET_VIDEOFORMAT          = (WM_CAP_START+  44);
        public const int WM_CAP_SET_VIDEOFORMAT          = (WM_CAP_START+  45);
        public const int WM_CAP_DLG_VIDEOCOMPRESSION     = (WM_CAP_START+  46);

        public const int WM_CAP_SET_PREVIEW              = (WM_CAP_START+  50);
        public const int WM_CAP_SET_OVERLAY              = (WM_CAP_START+  51);
        public const int WM_CAP_SET_PREVIEWRATE          = (WM_CAP_START+  52);
        public const int WM_CAP_SET_SCALE                = (WM_CAP_START+  53);
        public const int WM_CAP_GET_STATUS               = (WM_CAP_START+  54);
        public const int WM_CAP_SET_SCROLL               = (WM_CAP_START+  55);

        public const int WM_CAP_GRAB_FRAME               = (WM_CAP_START+  60);
        public const int WM_CAP_GRAB_FRAME_NOSTOP        = (WM_CAP_START+  61);

        public const int WM_CAP_SEQUENCE                 = (WM_CAP_START+  62);
        public const int WM_CAP_SEQUENCE_NOFILE          = (WM_CAP_START+  63);
        public const int WM_CAP_SET_SEQUENCE_SETUP       = (WM_CAP_START+  64);
        public const int WM_CAP_GET_SEQUENCE_SETUP       = (WM_CAP_START+  65);

        public const int WM_CAP_SET_MCI_DEVICEA         = (WM_CAP_START+  66);
        public const int WM_CAP_GET_MCI_DEVICEA         = (WM_CAP_START+  67);
        public const int WM_CAP_SET_MCI_DEVICEW         = (WM_CAP_UNICODE_START+  66);
        public const int WM_CAP_GET_MCI_DEVICEW         = (WM_CAP_UNICODE_START+  67);
        public const int WM_CAP_SET_MCI_DEVICE           = WM_CAP_SET_MCI_DEVICEW;
        public const int WM_CAP_GET_MCI_DEVICE           = WM_CAP_GET_MCI_DEVICEW;



        public const int WM_CAP_STOP                     = (WM_CAP_START+  68);
        public const int WM_CAP_ABORT                    = (WM_CAP_START+  69);

        public const int WM_CAP_SINGLE_FRAME_OPEN        = (WM_CAP_START+  70);
        public const int WM_CAP_SINGLE_FRAME_CLOSE       = (WM_CAP_START+  71);
        public const int WM_CAP_SINGLE_FRAME             = (WM_CAP_START+  72);

        public const int WM_CAP_PAL_OPENA               = (WM_CAP_START+  80);
        public const int WM_CAP_PAL_SAVEA               = (WM_CAP_START+  81);
        public const int WM_CAP_PAL_OPENW               = (WM_CAP_UNICODE_START+  80);
        public const int WM_CAP_PAL_SAVEW               = (WM_CAP_UNICODE_START+  81);
        public const int WM_CAP_PAL_OPEN                 = WM_CAP_PAL_OPENW;
        public const int WM_CAP_PAL_SAVE                 = WM_CAP_PAL_SAVEW;

        public const int WM_CAP_PAL_PASTE                = (WM_CAP_START+  82);
        public const int WM_CAP_PAL_AUTOCREATE           = (WM_CAP_START+  83);
        public const int WM_CAP_PAL_MANUALCREATE         = (WM_CAP_START+  84);

        // Following added post VFW 1.1
        public const int WM_CAP_SET_CALLBACK_CAPCONTROL  = (WM_CAP_START+  85);


        // Defines end of the message range
        public const int WM_CAP_UNICODE_END              = WM_CAP_PAL_SAVEW;
        public const int WM_CAP_END = WM_CAP_UNICODE_END;
    }
}
