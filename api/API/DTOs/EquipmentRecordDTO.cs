using CodeFirst;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DTOs
{
    public class EquipmentRecordDTO
    {
        public EquipmentRecordDTO() 
        {
            Name = string.Empty;
            AccountingCode = string.Empty;
        }

        public EquipmentRecordDTO(EquipmentRecord equipmentRecord)
        {
            Id = equipmentRecord.EquipmentRecordId;
            AccountingCode = equipmentRecord.AccountingCode;
            PurchaseDate = equipmentRecord.PurchaseDate;
            Cost = equipmentRecord.Cost;
            OwnerEmployeeId = equipmentRecord.OwnerEmployeeId;
            OwnerDepartamentId = equipmentRecord.OwnerDepartamentId;
            StateId = equipmentRecord.StateId;
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string AccountingCode { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Cost { get; set; }
        public int? OwnerEmployeeId { get; set; }
        public int? OwnerDepartamentId { get; set; }
        public int StateId { get; set; }

        public EquipmentRecord GetEquipmentRecord(EquipmentDBContext context)
        {
            EquipmentRecord equipmentRecord = new()
            {
                EquipmentRecordId = Id,
                AccountingCode = "0",
                PurchaseDate = PurchaseDate,
                Cost = Cost,
                OwnerEmployeeId = OwnerEmployeeId,
                OwnerDepartamentId = OwnerDepartamentId,
                StateId = StateId
            };

            var equipmentId = context.Equipment.Where(e => e.Name == Name).FirstOrDefault()?.EquipmentId;
            if (equipmentId != null)
            {
                equipmentRecord.EquipmentId = equipmentId.Value;
            }
            else
            {
                Equipment equipment = new()
                {
                    Name = Name,
                    TypeId = TypeId
                };
                context.Equipment.Add(equipment);
                context.SaveChanges();
                equipmentRecord.EquipmentId = equipment.EquipmentId;
            }

            var typeId = context.Equipment.Where(e => e.EquipmentId == equipmentRecord.EquipmentId).FirstOrDefault()?.TypeId;
            var eqCount = context.EquipmentRecords.Where(er => er.EquipmentId == equipmentRecord.EquipmentId).Count() + 1;
            equipmentRecord.AccountingCode = string.Format($"{typeId:00}{equipmentRecord.EquipmentId:000}{eqCount:000}");

            return equipmentRecord;
        }

        public void UpdateEquipmentRecord(EquipmentRecord equipmentRecord, EquipmentDBContext context)
        {
            equipmentRecord.PurchaseDate = PurchaseDate;
            equipmentRecord.Cost = Cost;
            equipmentRecord.OwnerEmployeeId = OwnerEmployeeId;
            equipmentRecord.OwnerDepartamentId = OwnerDepartamentId;
            equipmentRecord.StateId = StateId;

            var equipmentId = context.Equipment.Where(e => e.Name == Name).FirstOrDefault()?.EquipmentId;
            if (equipmentId != null)
            {
                equipmentRecord.EquipmentId = equipmentId.Value;
            }
            else
            {
                Equipment equipment = new()
                {
                    Name = Name,
                    TypeId = TypeId
                };
                context.Equipment.Add(equipment);
                equipmentRecord.EquipmentId = equipment.EquipmentId;
            }
        }
    }
}
