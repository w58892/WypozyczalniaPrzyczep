using Caravans.Interfaces;
using Caravans.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caravans.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        // GET: reservation
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reservationRepository.GetAll());
        }

        // GET: reservation/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var reservation = await _reservationRepository.Get(id);

            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        // GET: reservation/id
        [HttpGet("PDF/{id}")]
        public async Task<IActionResult> GetPDF(Guid id)
        {
                string Filename = "faktura.pdf";
                return File(await _reservationRepository.GetPdf(id), "application/pdf", Filename);
        }

        // GET: reservation/GetByUser/userId
        [HttpGet("GetByUser/{userId}")]
        public async Task<IActionResult> GetByUser(Guid userId)
        {
                return Ok(await _reservationRepository.GetByUser(userId));
        }

        // POST: reservation/Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add(ReservationAdd reservation)
        {

            if (ModelState.IsValid)
            {
                if (reservation.Begin < DateTime.Now || reservation.End < reservation.Begin)
                    return BadRequest("Niepoprawna data");

                var caravanid = await _reservationRepository.AvailableCaravan(reservation);
                if(caravanid == Guid.Empty)
                    return NotFound("Brak przyczep tego modelu w podanym terminie");

                Reservation reser = new Reservation
                {
                    ReservationBegin = reservation.Begin,
                    ReservationEnd = reservation.End,
                    UserId = reservation.UserId,
                    CaravanId = caravanid,
                };
                return Ok(await _reservationRepository.Add(reser));
            }
            return BadRequest();
        }

        // POST: reservation/Update
        [HttpPost("Update")]
        public async Task<IActionResult> Update(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _reservationRepository.Update(reservation));
            }
            return BadRequest();
        }

        // GET: reservation/Delete/id
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var reservation = await _reservationRepository.Get(id);
            if (reservation == null)
            {
                return NotFound();
            }
            await _reservationRepository.Delete(reservation);
            return Ok("deleted");
        }

        // GET: reservation/ConfirmReservation/id
        [HttpGet("ConfirmReservation/{id}")]
        public async Task<IActionResult> ConfirmReservation(Guid id)
        {
            return Ok(await _reservationRepository.ConfirmReservation(id));
        }

        // GET: reservation/GetPdf/id
        [HttpGet("GetPdf/{id}")]
        public async Task<IActionResult> GetPdf(Guid id)
        {
            return File(await _reservationRepository.GetPdf(id), "application/pdf", "lol.pdf");
        }
    }
}
