using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfSharp.Xps.Test
{
  class Program
  {
    static void Main(string[] args)
    {
      PdfSharp.Xps.XpsConverter.Convert(@"C:\Users\lzabik\AppData\Local\PTGMS Reports\temp\ad6d1afd-7f1b-4522-87b2-3048af27ec96.xps");

      var dir = Path.GetDirectoryName(Process.GetCurrentProcess().ProcessName);
      var sampleDir = Path.Combine(dir, "SampleXpsDocs");
      var targetDir = Path.Combine(dir, "ConvertedDocs");
      Directory.CreateDirectory(targetDir);
      var xpsFiles = Directory.GetFiles(sampleDir, "*.xps", SearchOption.TopDirectoryOnly);
      foreach (var xps in xpsFiles)
      {
        var targetFile = Path.Combine(targetDir, Path.GetFileNameWithoutExtension(xps) + ".pdf");
        PdfSharp.Xps.XpsConverter.Convert(xps, targetFile, 0);
      }
      Process.Start(targetDir);
    }
  }
}
