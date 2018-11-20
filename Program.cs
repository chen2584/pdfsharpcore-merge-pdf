using System;
using System.IO;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;

namespace MergePdf
{
    class Program
    {
        static void Main(string[] args)
        {
            MergePdf();
            Console.WriteLine("Merged Success!");
        }

        static void MergePdf()
        {
            // Get some file names
            string[] files = new string[] { "pdf1.pdf", "pdf2.pdf", "pdf3.pdf" };

            // Open the output document
            PdfDocument outputDocument = new PdfDocument();

            // Iterate files
            foreach (string file in files)
            {
                // Open the document to import pages from it.
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);

                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    // Get the page from the external document...
                    PdfPage page = inputDocument.Pages[idx];
                    // ...and add it to the output document.
                    outputDocument.AddPage(page);
                }
            }

            // Save the document...
            const string filename = "mergePdf.pdf";
            outputDocument.Save(filename);
        }
    }
}
