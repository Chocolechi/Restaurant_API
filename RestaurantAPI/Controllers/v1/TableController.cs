using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Table;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TableController : BaseApiController
    {
        private readonly ITableService _tableSvc;
        public TableController(ITableService tableSvc)
        {
            _tableSvc = tableSvc;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var tables = await _tableSvc.GetAllVm();
            if (tables == null || tables.Count == 0)
            {
                return NotFound();
            }
            return Ok(tables);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var table = await _tableSvc.GetbyIdVM(id);
            if (table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(TableViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(TableSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tableSvc.Add(vm);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, TableSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _tableSvc.Update(vm, id);

            return Ok(vm);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await _tableSvc.Delete(id);
            return NoContent();
        }

    }
}
