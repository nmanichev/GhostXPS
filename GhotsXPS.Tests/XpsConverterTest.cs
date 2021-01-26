using GhostXPS;
using NUnit.Framework;
using System;
using System.ComponentModel;
using System.IO;

namespace GhotsXPS.Tests
{
    public class XpsConverterTest
    {
        [SetUp]
        public void Initialize()
        {
            File.Delete("Resources\\analysis.pdf");

            File.Delete("Resources\\tiger.pdf");

            File.Delete("Resources\\file with spaces.pdf");
        }

        [Test]
        public void TestConvertWithXpsOnly()
        {
            var xpsFilePath = "Resources\\analysis.xps";

            var pdfFilePath = "Resources\\analysis.pdf";

            var utilitiesPath = "Utilities\\";

            XpsConverter.Convert(xpsFilePath, utilitiesPath);

            Assert.That(pdfFilePath, Does.Exist);
        }

        [Test]
        public void TestConvertWithXpsAndPdf()
        {
            var xpsFilePath = "Resources\\tiger.xps";

            var pdfFilePath = "Resources\\tiger.pdf";

            var utilitiesPath = "Utilities\\";

            XpsConverter.Convert(xpsFilePath, pdfFilePath, utilitiesPath);

            Assert.That(pdfFilePath, Does.Exist);
        }

        [Test]
        public void TestConvertFileWithSpacesInPath()
        {
            var xpsFilePath = "Resources\\file with spaces.xps";

            var pdfFilePath = "Resources\\file with spaces.pdf";

            var utilitiesPath = "Utilities\\";

            XpsConverter.Convert(xpsFilePath, utilitiesPath);

            Assert.That(pdfFilePath, Does.Exist);
        }

        [Test]
        public void TestCantFindUtilities()
        {
            var xpsFilePath = "Resources\\analysis.xps";

            var exception = Assert.Throws<Win32Exception>(() => XpsConverter.Convert(xpsFilePath));

            StringAssert.Contains($"The system cannot find the file specified.", exception.Message);
        }

        [Test]
        public void TestFailedToOpenXps()
        {
            var xpsFilePath = "Resources\\wrong.xps";

            var utilitiesPath = "Utilities\\";

            var exception = Assert.Throws<XpsConverterException>(() => XpsConverter.Convert(xpsFilePath, utilitiesPath));

            StringAssert.Contains($"Failed to open file '{xpsFilePath}'", exception.Message);
        }

        [Test]
        public void TestXpsNotEmpty()
        {
            var utilitiesPath = "Utilities\\";

            var exception = Assert.Throws<ArgumentNullException>(() => XpsConverter.Convert(string.Empty, utilitiesPath));

            StringAssert.Contains("Xps file path can't be empty. Please, specify a valid xps file path.", exception.Message);
        }

        [Test]
        public void TestPdfNotEmpty()
        {
            var xpsFilePath = "Resources\\tiger.xps";

            var utilitiesPath = "Utilities\\";

            var exception = Assert.Throws<ArgumentNullException>(() => XpsConverter.Convert(xpsFilePath, null, utilitiesPath));

            StringAssert.Contains("Pdf file path can't be empty. Please, specify a valid pdf file path.", exception.Message);
        }
    }
}