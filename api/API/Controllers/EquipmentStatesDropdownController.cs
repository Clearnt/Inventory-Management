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
    public class EquipmentStatesDropdownController : ControllerBase
    {
        private readonly EquipmentDBContext _context;

        public EquipmentStatesDropdownController(EquipmentDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentStateDropdownDTO>>> GetEquipmentStates()
        {
            return await _context.EquipmentStates.Select(x => new EquipmentStateDropdownDTO(x)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentStateDropdownDTO>> GetEquipmentState(int id)
        {
            var equipmentState = await _context.EquipmentStates.FindAsync(id);

            if (equipmentState == null)
            {
                return NotFound();
            }

            return new EquipmentStateDropdownDTO(equipmentState);
        }
    }
}
