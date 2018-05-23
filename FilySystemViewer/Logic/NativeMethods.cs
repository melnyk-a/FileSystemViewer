﻿using System.Runtime.InteropServices;

namespace FilySystemViewer.Logic
{
    internal static class NativeMethods
    {
        private const string DllPath = @"..\..\..\Debug\VirtualFolder.dll";

        [DllImport(DllPath, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static extern string GetComputerFolderName();
    }
}