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
    public class DepartamentsDropdownController : ControllerBase
    {
        private readonly EquipmentDBContext _context;

        public DepartamentsDropdownController(EquipmentDBContext context)
        {
            _context = context;
        }

        // GET: api/DepartamentsDropdown
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentDropdownDTO>>> GetDepartaments()
        {
            return await _context.Departaments.Select(x => new DepartamentDropdownDTO(x)).ToListAsync();
        }

        // GET: api/DepartamentsDropdown/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentDropdownDTO>> GetDepartament(int id)
        {
            var departament = await _context.Departaments.FindAsync(id);

            if (departament == null)
            {
                return NotFound();
            }

            return new DepartamentDropdownDTO(departament);
        }
    }
}
