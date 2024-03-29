﻿using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles; 

using TOAPI.Types;

namespace TOAPI.Kernel32
{
    //FileIOCompletionRoutine Callback function used with the ReadFileEx and WriteFileEx functions, called when the asynchronous input and output (I/O) operation is completed or canceled. 
    public delegate void FileIOCompletionRoutine(uint dwErrorCode, uint dwNumberOfBytesTransfered, ref OVERLAPPED lpOverlapped);

    //The following callback functions are used in file I/O.Function Description 
    // Delegates used in file manipulation
    /// <summary>
    /// Callback function used with the CopyFileEx and MoveFileWithProgress functions, called when a portion of a copy or move operation is completed.  
    /// </summary>
    /// <param name="TotalFileSize"></param>
    /// <param name="TotalBytesTransferred"></param>
    /// <param name="StreamSize"></param>
    /// <param name="StreamBytesTransferred"></param>
    /// <param name="dwStreamNumber"></param>
    /// <param name="dwCallbackReason"></param>
    /// <param name="hSourceFile"></param>
    /// <param name="hDestinationFile"></param>
    /// <param name="lpData"></param>
    /// <returns></returns>
    public delegate uint CopyProgressRoutine(long TotalFileSize, long TotalBytesTransferred,
        long StreamSize, long StreamBytesTransferred, uint dwStreamNumber,
        uint dwCallbackReason,
        IntPtr hSourceFile,
        IntPtr hDestinationFile,
        IntPtr lpData);


    public partial class Kernel32
    {
        public const Int16 FILE_SHARE_READ = 0X1;
        public const Int16 FILE_SHARE_WRITE = 0X2;
        /// <summary>CreateFile : Open handle for overlapped operations</summary>
        public const Int32 FILE_FLAG_OVERLAPPED = 0X40000000;
        /// <summary>CreateFile : Resource will be "created" or existing will be used</summary>
        public const uint OPEN_ALWAYS = 4;
        /// <summary>CreateFile : Resource to be "created" must exist</summary>
        public const Int16 OPEN_EXISTING = 3;

        //public const UInt32 GENERIC_READ = 0X80000000; // unchecked((int)0X80000000);
        //public const UInt32 GENERIC_WRITE = 0X40000000;

        public const uint
            GENERIC_READ    = 0x80000000,
            GENERIC_WRITE   = 0x40000000,
            GENERIC_EXECUTE = 0x20000000,
            GENERIC_ALL     = 0x10000000;

        /// <summary>Purges Win32 transmit buffer by aborting the current transmission.</summary>
        protected const uint PURGE_TXABORT = 0x01;
        /// <summary>Purges Win32 receive buffer by aborting the current receive.</summary>
        protected const uint PURGE_RXABORT = 0x02;
        /// <summary>Purges Win32 transmit buffer by clearing it.</summary>
        protected const uint PURGE_TXCLEAR = 0x04;
        /// <summary>Purges Win32 receive buffer by clearing it.</summary>
        protected const uint PURGE_RXCLEAR = 0x08;

        public const Int32 WAIT_TIMEOUT = 0X102;
        public const Int16 WAIT_OBJECT_0 = 0;

        public static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1); //((HANDLE)(LONG_PTR) - 1);
        public const uint INVALID_FILE_SIZE         = (0xFFFFFFFF);
        public const int  INVALID_SET_FILE_POINTER  = (-1);
        public const int  INVALID_FILE_ATTRIBUTES   = (-1);
        

        /// <summary>ReadFile/WriteFile : Overlapped operation is incomplete.</summary>
        protected const uint ERROR_IO_PENDING = 0x03E5; // 997

        /// <summary>Infinite timeout</summary>
        protected const uint INFINITE = 0xFFFFFFFF;

        /// <summary>Simple representation of a null handle : a closed stream will get this handle. Note it is public for comparison by higher level classes.</summary>
        public static IntPtr NullHandle = IntPtr.Zero;
        /// <summary>Simple representation of the handle returned when CreateFile fails.</summary>
        protected static IntPtr InvalidHandleValue = new IntPtr(-1);





        //ExportCallback Callback function used with ReadEncryptedFileRaw, called one or more times, each time with a block of the encrypted file's data, until it has received all of the file data.  
        //ImportCallback Callback function used with WriteEncryptedFileRaw, called one or more times, each time to retrieve a portion of a backup  




        // File Management
        //AreFileApisANSI Determines whether the file I/O functions are using the ANSI or OEM character set code page. 
        
        //CheckNameLegalDOS8Dot3 Determines whether a specified name can be used to create a file on a FAT file system. 
                
        //CopyFile Copies an existing file to a new file. 
        
        //CopyFileEx Copies an existing file to a new file, and notifies an application of the progress through a callback function. 
        [DllImport("kernel32.dll", EntryPoint="CopyFileExW")]
        public static extern  int CopyFileExW([MarshalAsAttribute(UnmanagedType.LPWStr)] string lpExistingFileName, 
            [MarshalAs(UnmanagedType.LPWStr)] string lpNewFileName,
            CopyProgressRoutine lpProgressRoutine, 
            IntPtr lpData, 
            IntPtr pbCancel, 
            uint dwCopyFlags);
     
        
        //CreateFile Creates or opens a file, directory, physical disk, volume, console buffer, tape drive, communications resource, mailslot, or named pipe. 
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeFileHandle CreateFile(string lpFileName,
            uint dwDesiredAccess, 
            uint dwShareMode,
            ref SECURITY_ATTRIBUTES lpSecurityAttributes,
            uint dwCreationDisposition, 
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeFileHandle CreateFile(string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        //[DllImport("kernel32.dll", SetLastError = true)]
        //public static extern SafeFileHandle CreateFileW([MarshalAs(UnmanagedType.LPWStr)] string lpFileName, 
        //    uint dwDesiredAccess, 
        //    uint dwShareMode, 
        //    IntPtr lpSecurityAttributes, 
        //    uint dwCreationDisposition, 
        //    uint dwFlagsAndAttributes, 
        //    IntPtr hTemplateFile);


        //DeleteFile Deletes an existing file. 
        [DllImport("kernel32.dll", CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteFile([In] string lpFileName);

        //CreateHardLink Establishes a hard link between an existing file and a new file. 

        //CreateSymbolicLink Creates a symbolic link. 
        

        //FindClose Closes a file search handle that the FindFirstFile, FindFirstFileEx, or FindFirstStreamW function opens. 
        [DllImport("kernel32.dll", EntryPoint = "FindClose")]
        public static extern int FindClose(IntPtr hFindFile);

        //FindFirstFile Searches a directory for a file or subdirectory name that matches a specified name. 
        [DllImport("kernel32.dll", EntryPoint = "FindFirstFileW")]
        public static extern IntPtr FindFirstFileW([In] [MarshalAs(UnmanagedType.LPWStr)] string lpFileName, 
            out WIN32_FIND_DATAW lpFindFileData);

        //FindFirstFileEx Searches a directory for a file or subdirectory name and attributes that match those that are specified. 
        
        //FindNextFile Continues a file search. 
        [DllImport("kernel32.dll", EntryPoint = "FindNextFileW")]
        public static extern int FindNextFileW(IntPtr hFindFile, [Out] out WIN32_FIND_DATAW lpFindFileData);

        //FindFirstStreamW Enumerates the first stream in a specified file or directory. 
        [DllImport("kernel32.dll", EntryPoint = "FindFirstStreamW", SetLastError = true)]
        public static extern IntPtr FindFirstStreamW([MarshalAs(UnmanagedType.LPWStr)] string lpFileName, 
            STREAM_INFO_LEVELS InfoLevel, IntPtr lpFindStreamData, uint dwFlags);

        //FindNextStreamW Continues a stream search. 
        
        //GetBinaryType Determines whether a file is executable. If the file is executable, this function determines the type of executable file. 
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int GetBinaryType(string lpApplicationName,  out uint lpBinaryType);

        //GetCompressedFileSize Retrieves the actual number of disk storage bytes that are used to store a specified file. 
        //GetFileAttributes Retrieves a set of FAT file system attributes for a specified file or directory. 
        //GetFileAttributesEx Retrieves attributes for a specified file or directory. 
        //GetFileBandwidthReservation Retrieves the bandwidth reservation properties of the volume on which the specified file resides. 
        //GetFileInformationByHandle Retrieves file information for a specified file. 
        //GetFileInformationByHandleEx Retrieves file information for the specified file. 
        //GetFileSize Retrieves the size of a specified file. The file size that can be reported by this function is limited to a DWORD value. 
        //GetFileSizeEx Retrieves the size of a specified file. 
        //GetFileType Retrieves the file type of a specified file. 
        //GetFinalPathNameByHandle Retrieves the final filesystem path for the specified file. 
        //GetFullPathName Retrieves the full path and file name of a specified file. 
        //GetLongPathName Converts a specified path to its long form. 
        //GetShortPathName Retrieves the short path form of a specified path. 
        //GetTempFileName Creates a name for a temporary file. 
        //GetTempPath Retrieves the path of the directory that is designated for temporary files. 
        
        //MoveFile Moves an existing file or directory and its children. 
        //MoveFileEx Moves an existing file or directory. 
        //MoveFileWithProgress Moves a file or directory. You can provide a callback function that receives progress notifications. 
        
        //OpenFile Creates, opens, reopens, or deletes a file. 
        // Use only with 16-bit versions of Windows
        // Use CreateFile instead
        //[DllImport("kernel32.dll", EntryPoint = "OpenFile")]
        //public static extern int OpenFile([In][MarshalAs(UnmanagedType.LPStr)] string lpFileName, 
        //    ref OFSTRUCT lpReOpenBuff, uint uStyle);

        //OpenFileById Opens the file that matches the specified identifier. 
        //ReOpenFile Reopens a specified file system object with different access rights, a different sharing mode, and different flags than it was previously opened with.  
        //ReplaceFile Replaces one file with a different file, and optionally creates a backup copy of the original file. 
        //RtlIsNameLegalDOS8Dot3 Determines whether or not a specified name can be used to create a file on the FAT file system.  
        
        //SearchPath Searches for a specified file in a specified path. 
        //SetFileApisToANSI Indicates that the file I/O functions must use the ANSI character set code page. 
        //SetFileApisToOEM Causes the file I/O functions to use the OEM character set code page. 
        //SetFileAttributes Sets the attributes of a file. 
        //SetFileBandwidthReservation Requests that bandwidth for the specified file stream be reserved. 
        //SetFileInformationByHandle Sets the information for the specified file. 
        //SetFileShortName Sets the short name for a specified file. 
        //SetFileValidData Sets the valid data length of a specified file. 



        //The following functions are used with file I/O.

        //Function Description 
        //CancelIo Cancels all pending I/O operations that are issued by the calling thread for a specified file handle. 
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 CancelIo(SafeFileHandle hFile);
        
        //CancelIoEx Marks all pending I/O operations for the specified file handle in the current process as canceled, regardless of which thread created the I/O operation. 
        //CancelSynchronousIo Marks pending synchronous I/O operations that are issued by the specified thread as canceled. 

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern SafeWaitHandle CreateEvent(SECURITY_ATTRIBUTES SecurityAttributes, Int32 bManualReset, Int32 bInitialState, String lpName);        
        
        //FlushFileBuffers Flushes the buffers for a specified file, and causes all buffered data to be written to the file. 

        //CreateIoCompletionPort Associates an I/O completion port with one or more file handles, or creates an I/O completion port that is not associated with a file handle. 
        //GetQueuedCompletionStatus Attempts to dequeue an I/O completion packet from a specified I/O completion port. 
        //GetQueuedCompletionStatusEx Retrieves multiple completion port entries simultaneously. 
        //PostQueuedCompletionStatus Posts an I/O completion packet to an I/O completion port. 
        //SetFileCompletionNotificationModes Sets the notification modes for a file handle. 
        

        // File Locking routines
        //LockFile Locks a specified file for exclusive access by the calling process. 
        [DllImport("kernel32.dll", EntryPoint = "LockFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LockFile(SafeFileHandle hFile, uint dwFileOffsetLow, uint dwFileOffsetHigh, 
            uint nNumberOfBytesToLockLow, uint nNumberOfBytesToLockHigh);
        
        //LockFileEx Locks a specified file for exclusive access by the calling process. This function can operate synchronously or asynchronously. 
        [DllImport("kernel32.dll", EntryPoint = "LockFileEx")]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool LockFileEx(SafeFileHandle hFile, uint dwFlags, uint dwReserved, uint nNumberOfBytesToLockLow, uint nNumberOfBytesToLockHigh, ref OVERLAPPED lpOverlapped);

        //UnlockFile Unlocks a region in an open file. 
        [DllImport("kernel32.dll", EntryPoint = "UnlockFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnlockFile(SafeFileHandle hFile, uint dwFileOffsetLow, uint dwFileOffsetHigh, uint nNumberOfBytesToUnlockLow, uint nNumberOfBytesToUnlockHigh);

        //UnlockFileEx Unlocks a region in an open file. This function can operate synchronously or asynchronously. 
        [DllImport("kernel32.dll", EntryPoint = "UnlockFileEx")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnlockFileEx(SafeFileHandle hFile, uint dwReserved, uint nNumberOfBytesToUnlockLow, uint nNumberOfBytesToUnlockHigh, ref OVERLAPPED lpOverlapped);

        
        //ReadFile Reads data from a file, starting at the position that is indicated by a file pointer. This function can operate synchronously and asynchronously. 
        [DllImport("kernel32.dll", EntryPoint = "ReadFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadFile(SafeFileHandle hFile, 
            IntPtr lpBuffer, uint nNumberOfBytesToRead, 
            IntPtr lpNumberOfBytesRead, ref OVERLAPPED lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 ReadFile(SafeFileHandle hFile, 
            ref Byte lpBuffer, Int32 nNumberOfBytesToRead, 
            ref Int32 lpNumberOfBytesRead, 
            ref OVERLAPPED lpOverlapped);        

        //ReadFileEx Reads data from a file asynchronously. 
        [DllImport("kernel32.dll", EntryPoint = "ReadFileEx")]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool ReadFileEx(SafeFileHandle hFile, 
            IntPtr lpBuffer, uint nNumberOfBytesToRead,
            ref OVERLAPPED lpOverlapped,
            FileIOCompletionRoutine lpCompletionRoutine);

        //ReadFileScatter Reads data from a file and stores it in an array of buffers. 
        
        //SetEndOfFile Moves the end-of-file position for a specified file to the current position of a file pointer. 
        [DllImport("kernel32.dll", EntryPoint = "SetEndOfFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetEndOfFile(SafeFileHandle hFile);

        
        
        //SetFilePointer Moves the file pointer of an open file. 
        [DllImport("kernel32.dll", EntryPoint = "SetFilePointer")]
        public static extern uint SetFilePointer(SafeFileHandle hFile, int lDistanceToMove, 
            IntPtr lpDistanceToMoveHigh, FileSeekPosition dwMoveMethod);

        //SetFilePointerEx Moves the file pointer of a specified file. 
        [DllImport("kernel32.dll", EntryPoint = "SetFilePointerEx")]
        public static extern int SetFilePointerEx(SafeFileHandle hFile, long liDistanceToMove, 
            IntPtr lpNewFilePointer, FileSeekPosition dwMoveMethod);

        
        //WriteFile Writes data to a file at a position that a file pointer specifies. This function can operate synchronously and asynchronously. 
        [DllImport("kernel32.dll", EntryPoint = "WriteFile", SetLastError = true)]
        public static extern int WriteFile(SafeFileHandle hFile, IntPtr lpBuffer, uint nNumberOfBytesToWrite, IntPtr lpNumberOfBytesWritten, IntPtr lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean WriteFile(SafeFileHandle hFile, ref Byte lpBuffer, Int32 nNumberOfBytesToWrite, ref Int32 lpNumberOfBytesWritten, Int32 lpOverlapped);        

        //WriteFileEx Writes data to a file. This function reports the completion status asynchronously by calling a specified completion routine when writing is completed or canceled and when the calling thread is in an alertable wait state. 
        [DllImport("kernel32.dll", EntryPoint = "WriteFileEx")]
        public static extern int WriteFileEx(SafeFileHandle hFile, IntPtr lpBuffer, uint nNumberOfBytesToWrite, 
            ref OVERLAPPED lpOverlapped, FileIOCompletionRoutine lpCompletionRoutine);
        
        //WriteFileGather Retrieves data from an array of buffers, and then writes the data to a file. 
        [DllImport("kernel32.dll", EntryPoint = "WriteFileGather")]
        public static extern int WriteFileGather(SafeFileHandle hFile, [In] ref FILE_SEGMENT_ELEMENT[] aSegmentArray, 
            uint nNumberOfBytesToWrite, IntPtr lpReserved, ref OVERLAPPED lpOverlapped);



        //The following functions are used with the encrypted file system.

        //Function Description 
        //AddUsersToEncryptedFile Adds user keys to a specified encrypted file. 
        //CloseEncryptedFileRaw Closes an encrypted file after a backup or restore operation, and frees the associated system resources. 
        //DecryptFile Decrypts an encrypted file or directory. 
        //DuplicateEncryptionInfoFile Copies the EFS metadata from one file or directory to another. 
        //EncryptFile Encrypts a file or directory. 
        //EncryptionDisable Disables or enables encryption of a specified directory and the files in the directory. 
        //FileEncryptionStatus Retrieves the encryption status of a specified file. 
        //FreeEncryptionCertificateHashList Frees a certificate hash list. 
        //OpenEncryptedFileRaw Opens an encrypted file to backup (export) or restore (import) the file. 
        //QueryRecoveryAgentsOnEncryptedFile Retrieves a list of recovery agents for a specified file. 
        //QueryUsersOnEncryptedFile Retrieves a list of users for a specified file. 
        //ReadEncryptedFileRaw Backs up (exports) encrypted files. 
        //RemoveUsersFromEncryptedFile Removes specified certificate hashes from a specified file. 
        //SetUserFileEncryptionKey Sets a current user key to a specified certificate. 
        //WriteEncryptedFileRaw Restores (imports) encrypted files. 


        //The following functions are used to decompress files that are compressed by the Lempel-Ziv algorithm.

        //Function Description 
        //GetExpandedName Retrieves the original name of a compressed file, only if the file is compressed by the Lempel-Ziv algorithm. 
        //LZClose Closes a file that was opened by using the LZOpenFile function. 
        //LZCopy Copies a source file to a destination file. 
        //LZInit Allocates memory for the internal data structures that are required to decompress files, and then creates and initializes the files. 
        //LZOpenFile Creates, opens, reopens, or deletes a specified file. 
        //LZRead Reads a specified number of bytes from a file and copies them into a buffer. 
        //LZSeek Moves a file pointer a specified number of bytes from a starting position. 



        // The following are related to transacted operations in the Vista file system.

        //CopyFileTransacted Copies an existing file to a new file as a transacted operation, notifying the application of its progress through a callback function. 
        //CreateFileTransacted Creates or opens a file, file stream, directory, physical disk, volume, console buffer, tape drive, communications resource, mailslot, or named pipe as a transacted operation. 
        //CreateHardLinkTransacted Establishes a hard link between an existing file and a new file as a transacted operation. 
        //CreateSymbolicLinkTransacted Creates a symbolic link as a transacted operation. 
        //DeleteFileTransacted Deletes an existing file as a transacted operation. 
        //FindFirstFileNameTransactedW Creates an enumeration of all the hard links to the specified file as a transacted operation. The function returns a handle to the enumeration that can be used on subsequent calls to the FindNextFileNameW function. 
        //FindFirstFileTransacted Searches a directory for a file or subdirectory with a name that matches a specific name as a transacted operation. 
        //FindFirstStreamTransactedW Enumerates the first stream in the specified file or directory as a transacted operation. 
        //GetCompressedFileSizeTransacted Retrieves the actual number of bytes of disk storage used to store a specified file as a transacted operation. 
        //GetFileAttributesTransacted Retrieves a set of FAT file system attributes for a specified file or directory as a transacted operation. 
        //GetFullPathNameTransacted Retrieves the full path and file name of a specified file as a transacted operation. 
        //GetLongPathNameTransacted Converts the specified path to its long form as a transacted operation. 
        //MoveFileTransacted Moves an existing file or a directory, including its children, as a transacted operation. 
        //SetFileAttributesTransacted Sets the attributes for a file or directory as a transacted operation. 

        //SetFileIoOverlappedRange Associates a virtual address range with a file handle. 
        //FindFirstFileNameW Creates an enumeration of all the hard links to the specified file. The FindFirstFileNameW function returns a handle to the enumeration that can be used on subsequent calls to the FindNextFileNameW function. 

    }
}
