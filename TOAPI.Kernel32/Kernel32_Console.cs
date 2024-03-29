﻿using System;
using System.Runtime.InteropServices;
using System.Text;

using TOAPI.Types;

namespace TOAPI.Kernel32
{
    public partial class Kernel32
    {
        // Console related functions
        //AddConsoleAlias Defines a console alias for the specified executable. 
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddConsoleAlias(string Source, string Target, string ExeName);
        
        //AllocConsole Allocates a new console for the calling process. 
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();

        //AttachConsole Attaches the calling process to the console of the specified process. 
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AttachConsole(int dwProcessId);

        //CreateConsoleScreenBuffer Creates a console screen buffer. 
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateConsoleScreenBuffer(int dwDesiredAccess, int dwShareMode,
            ref SECURITY_ATTRIBUTES lpSecurityAttributes,
            int dwFlags, IntPtr lpScreenBufferData);

        //FillConsoleOutputAttribute Sets the text and background color attributes for a specified number of character cells. 
        [DllImport("kernel32.dll", SetLastError=true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FillConsoleOuputAttribute(IntPtr ConsoleOutput, ushort wAttribute, uint nLength,
            COORD dwWriteCoord, out uint NumberofAttrsWritten);

        //FillConsoleOutputCharacter Writes a character to the console screen buffer a specified number of times. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FillConsoleOutputCharacter(IntPtr ConsoleOutput, char Character, uint Length, 
            COORD WriteCoord, out uint NumberOfCharsWritten);
        
        //FlushConsoleInputBuffer Flushes the console input buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlushConsoleInputBuffer(IntPtr ConsoleInput);

        //FreeConsole Detaches the calling process from its console. 
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeConsole();

        //GenerateConsoleCtrlEvent Sends a specified signal to a console process group that shares the console associated with the calling process. 
//GetConsoleAlias Retrieves the specified alias for the specified executable. 
//GetConsoleAliases Retrieves all defined console aliases for the specified executable.  
//GetConsoleAliasesLength Returns the size, in bytes, of the buffer needed to store all of the console aliases for the specified executable.  
//GetConsoleAliasExes Retrieves the names of all executables with console aliases defined. 
//GetConsoleAliasExesLength Returns the size, in bytes, of the buffer needed to store the names of all executables that have console aliases defined. 

        //GetConsoleCP Retrieves the input code page used by the console associated with the calling process. 
        [DllImport("kernel32.dll", EntryPoint = "GetConsoleCP")]
        public static extern uint GetConsoleCP();

        //GetConsoleCursorInfo Retrieves information about the size and visibility of the cursor for the specified console screen buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleCursorInfo(IntPtr hConsoleOutput, ref CONSOLE_CURSOR_INFO lpConsoleCursorInfo);

        //GetConsoleDisplayMode Retrieves the display mode of the current console. 
        [DllImport("kernel32.dll", EntryPoint = "GetConsoleDisplayMode")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleDisplayMode(ref int lpModeFlags);

        //GetConsoleFontSize Retrieves the size of the font used by the specified console screen buffer. 
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern COORD GetConsoleFontSize(IntPtr hConsoleOutput, int nFont);


        //GetConsoleMode Retrieves the current input mode of a console's input buffer or the current output mode of a console screen buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleMode(IntPtr ConsoleHandle, ref int lpMode);

        //GetConsoleOriginalTitle Retrieves the original title for the current console window. 

        //GetConsoleOutputCP Retrieves the output code page used by the console associated with the calling process. 
        [DllImport("kernel32.dll", EntryPoint = "GetConsoleOutputCP")]
        public static extern uint GetConsoleOutputCP();

        //GetConsoleProcessList Retrieves a list of the processes attached to the current console. 
        // the IntPtr needs to be a buffer of 64K
        // ms-help://MS.VSCC.v90/MS.MSDNQTR.v90.en/dllproc/base/getconsoleprocesslist.htm
        //[DllImport("kernel32.dll", EntryPoint = "GetConsoleProcessList")]
        //public static extern int GetConsoleProcessList(ref IntPtr lpdwProcessList, int dwProcessCount);

        //GetConsoleScreenBufferInfo Retrieves information about the specified console screen buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleScreenBufferInfo(IntPtr hConsoleOutput, 
            ref CONSOLE_SCREEN_BUFFER_INFO consoleScreenBufferInfo);


        //GetConsoleSelectionInfo Retrieves information about the current console selection. 
        [DllImport("kernel32.dll", EntryPoint = "GetConsoleSelectionInfo")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleSelectionInfo(ref CONSOLE_SELECTION_INFO lpConsoleSelectionInfo);

        //GetConsoleTitle Retrieves the title for the current console window. 
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GetConsoleTitle([Out] StringBuilder consoleTitle, int size);

        //GetConsoleWindow Retrieves the window handle used by the console associated with the calling process. 
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern IntPtr GetConsoleWindow();

        //GetCurrentConsoleFont Retrieves information about the current console font. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCurrentConsoleFont(IntPtr ConsoleOutput, 
            [MarshalAs(UnmanagedType.Bool)]bool bMaximumWindow, 
            ref CONSOLE_FONT_INFO lpConsoleCurrentFont);


        //GetLargestConsoleWindowSize Retrieves the size of the largest possible console window. 
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern COORD GetLargestConsoleWindowSize(IntPtr ConsoleOutput);

        //GetNumberOfConsoleInputEvents Retrieves the number of unread input records in the console's input buffer. 
        [DllImport("kernel32.dll", EntryPoint = "GetNumberOfConsoleInputEvents")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNumberOfConsoleInputEvents(IntPtr hConsoleInput, ref uint lpNumberOfEvents);

        //GetNumberOfConsoleMouseButtons Retrieves the number of buttons on the mouse used by the current console. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNumberOfConsoleMouseButtons(ref int numberOfMouseButtons);

        //GetStdHandle Retrieves a handle for the standard input, standard output, or standard error device. 
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern IntPtr GetStdHandle(int whichStdHandle);

        //HandlerRoutine An application-defined function used with the SetConsoleCtrlHandler function. 

        //PeekConsoleInput Reads data from the specified console input buffer without removing it from the buffer. 
        [DllImport("kernel32.dll", EntryPoint="PeekConsoleInputW")]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern  bool PeekConsoleInputW(IntPtr hConsoleInput, ref INPUT_RECORD lpBuffer, uint nLength, 
            ref uint lpNumberOfEventsRead) ;

        //ReadConsole Reads character input from the console input buffer and removes it from the buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadConsole(IntPtr consoleInput, [Out]StringBuilder builder,
            int numCharsToRead, out int numCharsRead, IntPtr reserved);

        //ReadConsoleInput Reads data from a console input buffer and removes it from the buffer. 
        [DllImport("kernel32.dll", EntryPoint = "ReadConsoleInputW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadConsoleInputW(IntPtr hConsoleInput, ref INPUT_RECORD lpBuffer, uint nLength, 
            ref uint lpNumberOfEventsRead);

        //ReadConsoleOutput Reads character and color attribute data from a rectangular block of character cells in a console screen buffer. 

        //ReadConsoleOutputAttribute Copies a specified number of foreground and background color attributes from consecutive cells of a console screen buffer. 

        //ReadConsoleOutputCharacter Copies a number of characters from consecutive cells of a console screen buffer. 

        //ScrollConsoleScreenBuffer Moves a block of data in a screen buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool ScrollConsoleScreenBuffer(IntPtr hConsoleOutput, 
            ref SMALL_RECT lpScrollRectangle, ref SMALL_RECT lpClipRectangle, 
            COORD dwDestinationOrigin, ref CHAR_INFO lpFill);

        // This one allows for an empty clip rectangle
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool ScrollConsoleScreenBuffer(IntPtr hConsoleOutput,
            ref SMALL_RECT lpScrollRectangle, IntPtr lpClipRectangle,
            COORD dwDestinationOrigin, ref CHAR_INFO lpFill);


        //SetConsoleActiveScreenBuffer Sets the specified screen buffer to be the currently displayed console screen buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleActiveScreenBuffer(IntPtr ConsoleOutput);

        //SetConsoleCP Sets the input code page used by the console associated with the calling process. 
        [DllImport("kernel32.dll", EntryPoint = "SetConsoleCP")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleCP(uint wCodePageID);

        //SetConsoleCtrlHandler Adds or removes an application-defined HandlerRoutine from the list of handler functions for the calling process. 

        //SetConsoleCursorInfo Sets the size and visibility of the cursor for the specified console screen buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int SetConsoleCursorInfo(IntPtr hConsoleOutput, ref CONSOLE_CURSOR_INFO ConsoleCursorInfo);

        //SetConsoleCursorPosition Sets the cursor position in the specified console screen buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleCursorPosition(IntPtr hConsOutput, COORD cursorPosition);

        //SetConsoleDisplayMode Sets the display mode of the specified console screen buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleDisplayMode(IntPtr ConsoleOut, int displayMode);


        //SetConsoleMode Sets the input mode of a console's input buffer or the output mode of a console screen buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetConsoleMode(IntPtr ConsHandle, uint dwMode);

        //SetConsoleOutputCP Sets the output code page used by the console associated with the calling process. 
        [DllImport("kernel32.dll", EntryPoint = "SetConsoleOutputCP")]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool SetConsoleOutputCP(uint wCodePageID);


        //SetConsoleScreenBufferSize Changes the size of the specified console screen buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleScreenBufferSize(IntPtr hConsHandle, COORD dwSize);

        //SetConsoleTextAttribute Sets the foreground (text) and background color attributes of characters written to the console screen buffer. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleTextAttribute(IntPtr hConsHandle, ushort wAttributes);

        //SetConsoleTitle Sets the title for the current console window. 
        [DllImport("kernel32.dll", SetLastError=true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleTitle(string aTitle);

        //SetConsoleWindowInfo Sets the current size and position of a console screen buffer's window. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleWindowInfo(IntPtr hConsoleOutput, 
            [MarshalAs(UnmanagedType.Bool)]bool bAbsolute, 
            ref SMALL_RECT lpConsoleWindow);


        //SetStdHandle Sets the handle for the standard input, standard output, or standard error device. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetStdHandle(uint nStdHandle, IntPtr hHandle);

        //WriteConsole Writes a character string to a console screen buffer beginning at the current cursor location. 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteConsole(IntPtr ConsoleOutput, string Buffer,
            int charsToWrite, out int charsWritten, IntPtr reserved);

//WriteConsoleInput Writes data directly to the console input buffer. 
//WriteConsoleOutput Writes character and color attribute data to a specified rectangular block of character cells in a console screen buffer. 
//WriteConsoleOutputAttribute Copies a number of foreground and background color attributes to consecutive cells of a console screen buffer. 
//WriteConsoleOutputCharacter Copies a number of characters to consecutive cells of a console screen buffer. 


        // VISTA Supported
        //GetCurrentConsoleFontEx Retrieves extended information about the current console font. 
        //GetConsoleScreenBufferInfoEx Retrieves extended information about the specified console screen buffer. 

        //SetCurrentConsoleFontEx Sets extended information about the current console font. 
        //SetConsoleScreenBufferInfoEx Sets extended information about the specified console screen buffer. 

        //SetConsoleHistoryInfo Sets the history settings for the calling process's console. 
        //GetConsoleHistoryInfo Retrieves the history settings for the calling process's console. 

    }
}
