using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Text;
using Caravans.Interfaces;
using Caravans.Models;

namespace Caravans.Repositories
{
    public class Pdf
    {

        private ICaravanRepository _caravanRepository;
        private ICaravanmodelRepository _caravanmodelRepository;
        private IUserRepository _userRepository;

        public Pdf(DatabaseContext context)
        {
            _caravanRepository = new CaravanRepository(context);
            _caravanmodelRepository = new CaravanmodelRepository(context);
            _userRepository = new UserRepository(context);
        }

        public async Task<byte[]> CreatePdf(Reservation reser)
        {
            Reservation reservation = reser;
            Caravan caravan = await _caravanRepository.Get(reservation.CaravanId);
            Caravanmodel caravanmodel = await _caravanmodelRepository.Get(caravan.ModelId);
            User user = await _userRepository.Get(reservation.UserId);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 16, XFontStyle.Bold);
            XBrush brush = XBrushes.Black;

            int days = (reservation.ReservationEnd - reservation.ReservationEnd).Days + 1;

            gfx.DrawString($"Imię: {user.FirstName}", font, brush, new XRect(50, 50, page.Width - 100, page.Height - 100), XStringFormats.TopLeft);
            gfx.DrawString($"Nazwisko: {user.LastName}", font, brush, new XRect(50, 70, page.Width - 100, page.Height - 100), XStringFormats.TopLeft);
            gfx.DrawString($"Email: {user.Email}", font, brush, new XRect(50, 90, page.Width - 100, page.Height - 100), XStringFormats.TopLeft);
            gfx.DrawString($"Model przyczepy: {caravanmodel.Producer} {caravanmodel.Model}", font, brush, new XRect(50, 110, page.Width - 100, page.Height - 100), XStringFormats.TopLeft);
            gfx.DrawString($"Data: {reservation.ReservationBegin.ToString("dd/MM/yyyy")} - {reservation.ReservationEnd.ToString("dd/MM/yyyy")}", font, brush, new XRect(50, 130, page.Width - 100, page.Height - 100), XStringFormats.TopLeft);
            gfx.DrawString($"Cena: {caravanmodel.Price * days}PLN", font, brush, new XRect(50, 150, page.Width - 100, page.Height - 100), XStringFormats.TopLeft);

            byte[]? pdfFile = null;
            MemoryStream stream = new MemoryStream();
            await using (stream)
            {
                document.Save(stream);
                pdfFile = stream.ToArray();
            }

            return pdfFile;
        }
    }
}
