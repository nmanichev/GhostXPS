# GhostXPS
.NET Standard simple XPS to PDF converter using GhostXPS utility.

## Table of contents
* [Table of Contents](#table-of-contents)
* [Installation](#installation)
* [Usage](#usage)

## Installation

Grab the latest [GhostXPS NuGet](https://www.nuget.org/packages/GhostXPS/) package and install it into your project.

> Install-Package GhostXPS

## Usage

After successful installation of [GhostXPS NuGet](https://www.nuget.org/packages/GhostXPS/) package you could convert your `XPS` files by using `XpsConverter` static class from `GhostXPS` namespace.

First import `GhostXPS` namespace:
```C#
using GhostXPS;
```
Then use `XpsConverter` static class methods for convertion:
```C#
// The path to your XPS file.
 var xpsFilePath = "Ghost.xps"

// Converts you XPS file to the PDF file at the same location.
 XpsConverter.Convert(xpsFilePath);

// The path for saving PDF file.
 var pdfFilePath = "Ghost.pdf"

// Converts you XPS file to the PDF file at the provided location.
XpsConverter.Convert(xpsFilePath, pdfFilePath);
```