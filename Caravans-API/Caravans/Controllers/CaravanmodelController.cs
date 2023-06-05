using Caravans.Interfaces;
using Caravans.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caravans.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CaravanmodelController : ControllerBase
    {
        private readonly ICaravanmodelRepository _caravanmodelRepository;

        public CaravanmodelController(ICaravanmodelRepository caravanmodelRepository)
        {
            _caravanmodelRepository = caravanmodelRepository;
        }

        // GET: caravanmodel
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _caravanmodelRepository.GetAll());
        }

        // GET: caravanmodel/id
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var model = await _caravanmodelRepository.Get(id);

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        // POST: caravanmodel/Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add(Caravanmodel caravanmodel)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _caravanmodelRepository.Add(caravanmodel));
            }
            return BadRequest();
        }

        // POST: caravanmodel/Update
        [HttpPost("Update")]
        public async Task<IActionResult> Update(Caravanmodel caravanmodel)
        {
            var model = await _caravanmodelRepository.Get(caravanmodel.ModelId);
            if (model != null)
            {
                return Ok(await _caravanmodelRepository.Update(caravanmodel));
            }
            return NotFound();
           
        }

        // GET: caravanmodel/Delete/id
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _caravanmodelRepository.Get(id);
            if (model == null)
            {
                return NotFound();
            }
            await _caravanmodelRepository.Delete(model);
            return Ok("deleted");
        }
    }
}
