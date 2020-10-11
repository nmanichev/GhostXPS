using System;
using System.Diagnostics;
using System.IO;

namespace GhostXPS
{
    public static class XpsConverter
    {
        public static void Convert(string xpsFilePath)
        {
            if (string.IsNullOrEmpty(xpsFilePath))
            {
                throw new ArgumentNullException(nameof(xpsFilePath), "Xps file path can't be empty. Please, specify a valid xps file path.");
            }

            var pdfFilePath = Path.Combine(Path.GetDirectoryName(xpsFilePath), $"{Path.GetFileNameWithoutExtension(xpsFilePath)}.pdf");

            Convert(xpsFilePath, pdfFilePath);
        }

        public static void Convert(string xpsFilePath, string pdfFilePath)
        {
            if (string.IsNullOrEmpty(xpsFilePath))
            {
                throw new ArgumentNullException(nameof(xpsFilePath), "Xps file path can't be empty. Please, specify a valid xps file path.");
            }

            if (string.IsNullOrEmpty(pdfFilePath))
            {
                throw new ArgumentNullException(nameof(pdfFilePath), "Pdf file path can't be empty. Please, specify a valid pdf file path.");
            }

            var ghostStartInfo = new ProcessStartInfo
            {
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Environment.Is64BitOperatingSystem ?  "Utilities\\gxpswin64.exe" : "Utilities\\gxpswin32.exe",
                Arguments = $"-dNOPAUSE -dBATCH -dSAFER -sOutputFile={pdfFilePath} -sDEVICE=pdfwrite  {xpsFilePath}",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true
            };

            using (var ghostProcess = Process.Start(ghostStartInfo))
            {
                ghostProcess.WaitForExit();

                if(ghostProcess.ExitCode != 0)
                {
                    var message = ghostProcess.StandardError.ReadToEnd();

                    throw new XpsConverterException(message);
                }
            }
        }
    }
}
