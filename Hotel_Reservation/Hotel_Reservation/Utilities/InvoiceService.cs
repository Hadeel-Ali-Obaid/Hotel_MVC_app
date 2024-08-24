using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
namespace Hotel_Reservation.Models
{
    public class InvoiceService
    {
        public byte[] GenerateInvoicePdf(Invoice invoice)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new PdfWriter(memoryStream))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);

                        // Add content to the PDF
                        document.Add(new Paragraph("Invoice"));
                        document.Add(new Paragraph($"Invoice ID: {invoice.Id}"));
                        document.Add(new Paragraph($"Amount: {invoice.Amount}"));
                        document.Add(new Paragraph($"Date: {invoice.Date}"));

                        // Add more invoice details here

                        document.Close();
                    }
                }
                return memoryStream.ToArray();
            }
        }
    }
}