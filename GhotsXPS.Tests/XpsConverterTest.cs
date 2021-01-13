using GhostXPS;
using NUnit.Framework;
using System;
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

            XpsConverter.Convert(xpsFilePath);

            Assert.That(pdfFilePath, Does.Exist);
        }

        [Test]
        public void TestConvertWithXpsAndPdf()
        {
            var xpsFilePath = "Resources\\tiger.xps";

            var pdfFilePath = "Resources\\tiger.pdf";

            XpsConverter.Convert(xpsFilePath, pdfFilePath);

            Assert.That(pdfFilePath, Does.Exist);
        }

        [Test]
        public void TestConvertFileWithSpacesInPath()
        {
            var xpsFilePath = "Resources\\file with spaces.xps";

            var pdfFilePath = "Resources\\file with spaces.pdf";

            XpsConverter.Convert(xpsFilePath);

            Assert.That(pdfFilePath, Does.Exist);
        }

        [Test]
        public void TestFailedToOpenXps()
        {
            var xpsFilePath = "Resources\\wrong.xps";

            var exception = Assert.Throws<XpsConverterException>(() => XpsConverter.Convert(xpsFilePath));

            StringAssert.Contains($"Failed to open file '{xpsFilePath}'", exception.Message);
        }

        [Test]
        public void TestXpsNotEmpty()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => XpsConverter.Convert(string.Empty));

            StringAssert.Contains("Xps file path can't be empty. Please, specify a valid xps file path.", exception.Message);
        }

        [Test]
        public void TestPdfNotEmpty()
        {
            var xpsFilePath = "Resources\\tiger.xps";

            var exception = Assert.Throws<ArgumentNullException>(() => XpsConverter.Convert(xpsFilePath, null));

            StringAssert.Contains("Pdf file path can't be empty. Please, specify a valid pdf file path.", exception.Message);
        }
    }
}