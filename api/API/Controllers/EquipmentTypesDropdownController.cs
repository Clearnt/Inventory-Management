using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeFirst;
using CodeFirst.Models;
using API.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentTypesDropdownController : ControllerBase
    {
        private readonly EquipmentDBContext _context;

        public EquipmentTypesDropdownController(EquipmentDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentTypeDropdownDTO>>> GetEquipmentTypes()
        {
            return await _context.EquipmentTypes.Select(x => new EquipmentTypeDropdownDTO(x)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentTypeDropdownDTO>> GetEquipmentType(int id)
        {
            var equipmentType = await _context.EquipmentTypes.FindAsync(id);

            if (equipmentType == null)
            {
                return NotFound();
            }

            return new EquipmentTypeDropdownDTO(equipmentType);
        }
    }
}
