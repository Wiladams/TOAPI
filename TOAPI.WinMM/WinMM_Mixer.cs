﻿using System;
using System.Runtime.InteropServices;

namespace TOAPI.WinMM
{
    public partial class winmm
    {
        // Functions related to the mixer on the audio device
        // mixerClose
        [DllImport("winmm.dll", EntryPoint = "mixerClose")]
        public static extern int mixerClose(IntPtr hmx);

        // mixerGetControlDetails
        //[DllImport("winmm.dll", EntryPoint = "mixerGetControlDetailsA", CharSet=CharSet.Auto)]
        //public static extern uint mixerGetControlDetailsA(System.IntPtr hmxobj, ref MIXERCONTROLDETAILS pmxcd, uint fdwDetails);

        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mixerGetControlDetails(System.IntPtr hmxobj, ref MIXERCONTROLDETAILS pmxcd, int fdwDetails);

        // mixerGetDevCaps
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mixerGetDevCaps(IntPtr uMxId, ref MIXERCAPS pmxcaps, int cbmxcaps);


        // mixerGetID
        [DllImport("winmm.dll", EntryPoint = "mixerGetID")]
        public static extern int mixerGetID(IntPtr hmxobj, ref IntPtr puMxId, int fdwId);

        // mixerGetLineControls
        [System.Runtime.InteropServices.DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mixerGetLineControls(IntPtr hmxobj, ref MIXERLINECONTROLS pmxlc, int fdwControls);

        // mixerGetLineInfo
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        public static extern int mixerGetLineInfo(IntPtr hmxobj, ref MIXERLINE pmxl, int fdwInfo);

        // mixerGetNumDevs
        [DllImport("winmm.dll", EntryPoint = "mixerGetNumDevs")]
        public static extern int mixerGetNumDevs();

        // mixerMessage
        [DllImport("winmm.dll", EntryPoint = "mixerMessage")]
        public static extern int mixerMessage(IntPtr hmx, int uMsg, IntPtr dwParam1, IntPtr dwParam2);

        // mixerOpen
        [DllImport("winmm.dll", EntryPoint = "mixerOpen")]
        public static extern int mixerOpen(ref IntPtr phmx, IntPtr uMxId, IntPtr dwCallback, IntPtr dwInstance, int fdwOpen);

        // mixerSetControlDetails
        [DllImport("winmm.dll", EntryPoint = "mixerSetControlDetails")]
        public static extern int mixerSetControlDetails(IntPtr hmxobj, ref MIXERCONTROLDETAILS pmxcd, int fdwDetails);
    }
}
