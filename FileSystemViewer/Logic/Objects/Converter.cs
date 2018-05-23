using System;

namespace FileSystemViewer.Logic.Objects
{
    internal static class Converter
    {
        private static string[] suffix = { "B", "Kb", "Mb", "Gb" };

        public static string BytesToString(
            long byteCount, 
            int decimalPlaces = 1)
        {
            int i = 0;
            while (Math.Round((double)byteCount, decimalPlaces) >= 1024)
            {
                byteCount /= 1024;
                i++;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", byteCount, suffix[i]);
        }
    }
}