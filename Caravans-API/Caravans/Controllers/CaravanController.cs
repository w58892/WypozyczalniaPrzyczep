using Microsoft.AspNetCore.Mvc;
using Caravans.Models;
using Caravans.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Caravans.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CaravanController : ControllerBase
    {
        private readonly ICaravanRepository _caravanRepository;

        public CaravanController(ICaravanRepository caravanRepository)
        {
            _caravanRepository = caravanRepository;
        }

        // GET: caravan
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _caravanRepository.GetAll());
        }

        // GET: caravan/id
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var caravan = await _caravanRepository.Get(id);

            if (caravan == null)
            {
                return NotFound();
            }
            return Ok(caravan);
        }

        // POST: caravan/Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add(Caravan caravan)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _caravanRepository.Add(caravan));
            }
            return BadRequest();
        }

        // POST: caravan/Update
        [HttpPost("Update")]
        public async Task<IActionResult> Update(Caravan caravan)
        {
            if (ModelState.IsValid)
            {
                var c = await _caravanRepository.Get(caravan.CaravanId);
                if (c != null)
                {
                    return Ok(await _caravanRepository.Update(caravan));
                }
                return NotFound();
            }
            return BadRequest();
        }

        // GET: caravan/Delete/id
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var caravan = await _caravanRepository.Get(id);
            if (caravan == null)
            {
                return NotFound();
            }
            await _caravanRepository.Delete(caravan);
            return Ok("deleted");
        }
    }
}
