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
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentRecordsController : ControllerBase
    {
        private readonly EquipmentDBContext _context;

        public EquipmentRecordsController(EquipmentDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentRecordDTO>>> GetEquipmentRecords()
        {
            var eq_recs = await _context.EquipmentRecords.ToListAsync();
            var eq_rec_dtos = new List<EquipmentRecordDTO>();

            foreach (var eq_rec in eq_recs)
            {
                EquipmentRecordDTO eq_rec_dto = new (eq_rec)
                {
                    TypeId = (await _context.Equipment.FindAsync(eq_rec.EquipmentId))?.TypeId ?? 0,
                    Name = (await _context.Equipment.FindAsync(eq_rec.EquipmentId))?.Name ?? ""
                };
                eq_rec_dtos.Add(eq_rec_dto);
            }

            return Ok(eq_rec_dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentRecordDTO>> GetEquipmentRecord(int id)
        {
            var equipmentRecord = await _context.EquipmentRecords.FindAsync(id);

            if (equipmentRecord == null)
            {
                return NotFound();
            }

            return new EquipmentRecordDTO(equipmentRecord)
            {
                TypeId = (await _context.Equipment.FindAsync(equipmentRecord.EquipmentId))?.TypeId ?? 0,
                Name = (await _context.Equipment.FindAsync(equipmentRecord.EquipmentId))?.Name ?? ""
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentRecord(int id, EquipmentRecordDTO equipmentRecordDTO)
        {
            if (id != equipmentRecordDTO.Id)
            {
                return BadRequest();
            }

            var equipmentRecord = await _context.EquipmentRecords.FindAsync(id); 
            if (equipmentRecord == null)
            {
                return NotFound();
            }

            equipmentRecordDTO.UpdateEquipmentRecord(equipmentRecord, _context);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentRecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<EquipmentRecord>> PostEquipmentRecord(EquipmentRecordDTO equipmentRecordDTO)
        {
            EquipmentRecord equipmentRecord = equipmentRecordDTO.GetEquipmentRecord(_context);

            _context.EquipmentRecords.Add(equipmentRecord);

            _context.Database.ExecuteSqlRaw("DROP TRIGGER EquipmentRecord_Insert");

            await _context.SaveChangesAsync();

            _context.Database.ExecuteSqlRaw("CREATE OR ALTER TRIGGER EquipmentRecord_Insert \r\nON EquipmentRecords\r\nINSTEAD OF INSERT\r\nAS\r\nBEGIN\r\n\tSET NOCOUNT ON;\r\n\t\r\n\tDECLARE @EquipmentId INT,\r\n\t\t\t@PurchaseDate DATE,\r\n\t\t\t@Cost MONEY, \r\n\t\t\t@OwnerEmployeeId INT,\r\n\t\t\t@OwnerDepartamentId INT,\r\n\t\t\t@StateId INT;\r\n\r\n\tDECLARE InsertedCursor CURSOR FOR\r\n\t\tSELECT equipment_id, purchase_date, cost, owner_employee_id, owner_departament_id, state_id\r\n\t\tFROM inserted\r\n    \r\n    OPEN InsertedCursor\r\n    FETCH NEXT FROM InsertedCursor INTO @EquipmentId, @PurchaseDate, @Cost, @OwnerEmployeeId, @OwnerDepartamentId, @StateId\r\n    WHILE @@FETCH_STATUS = 0\r\n    BEGIN\r\n\t\tINSERT INTO EquipmentRecords (equipment_id, accounting_code, purchase_date, cost, owner_employee_id, owner_departament_id, state_id)\r\n\t\tVALUES\r\n\t\t\t(@EquipmentId, dbo.EquipmentRecord_AccountingCode(@EquipmentId), @PurchaseDate, @Cost, @OwnerEmployeeId, @OwnerDepartamentId, @StateId)\r\n\r\n\t\tFETCH NEXT FROM InsertedCursor INTO @EquipmentId, @PurchaseDate, @Cost, @OwnerEmployeeId, @OwnerDepartamentId, @StateId\r\n    END\r\n    CLOSE InsertedCursor\r\n    DEALLOCATE InsertedCursor\r\nEND");

            return CreatedAtAction(nameof(GetEquipmentRecord), 
                new { id = equipmentRecord.EquipmentRecordId }, 
                new EquipmentRecordDTO(equipmentRecord)
                {
                    TypeId = (await _context.Equipment.FindAsync(equipmentRecord.EquipmentId))?.TypeId ?? 0,
                    Name = (await _context.Equipment.FindAsync(equipmentRecord.EquipmentId))?.Name ?? ""
                }
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentRecord(int id)
        {
            var equipmentRecord = await _context.EquipmentRecords.FindAsync(id);
            if (equipmentRecord == null)
            {
                return NotFound();
            }

            _context.EquipmentRecords.Remove(equipmentRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentRecordExists(int id)
        {
            return _context.EquipmentRecords.Any(e => e.EquipmentRecordId == id);
        }
    }
}
