using System;
using System.Diagnostics;
using System.IO;

namespace GhostXPS
{
    /// <summary>
    /// Converts XPS into PDF.
    /// </summary>
    public static class XpsConverter
    {
        /// <summary>
        /// Gets XPS file converts into PDF file at the same location.
        /// </summary>
        /// <param name="xpsFilePath">XPS file path.</param>
        public static void Convert(string xpsFilePath)
        {
            if (string.IsNullOrEmpty(xpsFilePath))
            {
                throw new ArgumentNullException(nameof(xpsFilePath), "Xps file path can't be empty. Please, specify a valid xps file path.");
            }

            var pdfFilePath = Path.Combine(Path.GetDirectoryName(xpsFilePath), $"{Path.GetFileNameWithoutExtension(xpsFilePath)}.pdf");

            Convert(xpsFilePath, pdfFilePath);
        }

        /// <summary>
        /// Converts XPS file to PDF using provided pathes.
        /// </summary>
        /// <param name="xpsFilePath">XPS file path.</param>
        /// <param name="pdfFilePath">PDF file path.</param>
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
                FileName = Environment.Is64BitOperatingSystem ? "Utilities\\gxpswin64.exe" : "Utilities\\gxpswin32.exe",
                Arguments = $"-dNOPAUSE -dBATCH -dSAFER -sOutputFile=\"{pdfFilePath}\" -sDEVICE=pdfwrite \"{xpsFilePath}\"",
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
