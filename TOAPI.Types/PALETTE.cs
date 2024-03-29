using System;
using System.Runtime.InteropServices;

namespace TOAPI.Types
{
    [Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct RGBQUAD
	{
		public byte rgbBlue;
		public byte rgbGreen;
		public byte rgbRed;
		public byte rgbReserved;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RGBTRIPLE
	{
		public byte rgbtBlue;
		public byte rgbtGreen;
		public byte rgbtRed;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct LOGPALETTE
	{
        /// WORD->unsigned short
        public UInt16 palVersion;
        /// WORD->unsigned short
        public UInt16 palNumEntries;
        /// PALETTEENTRY[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
        public PALETTEENTRY[] palPalEntry;
    }

	[StructLayout(LayoutKind.Sequential)]
	public struct PALETTEENTRY
	{
		public byte peRed;
		public byte peGreen;
		public byte peBlue;
		public byte peFlags;
	}

}