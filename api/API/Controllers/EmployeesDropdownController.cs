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
    public class EmployeesDropdownController : ControllerBase
    {
        private readonly EquipmentDBContext _context;

        public EmployeesDropdownController(EquipmentDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDropdownDTO>>> GetEmployees()
        {
            return await _context.Employees.Select(x => new EmployeeDropdownDTO(x)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDropdownDTO>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return new EmployeeDropdownDTO(employee);
        }
    }
}
