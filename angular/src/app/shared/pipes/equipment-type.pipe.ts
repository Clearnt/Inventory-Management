import { Pipe, PipeTransform } from '@angular/core';
import { EquipmentTypeModel } from '../models/equipment-type.model';
import { DropDownsService } from '../services/drop-downs.service';

@Pipe({
  name: 'equipmentType',
  standalone: true
})
export class EquipmentTypePipe implements PipeTransform {
  constructor(public dropDownsService: DropDownsService) {

  }

  list: EquipmentTypeModel[] = [];

  transform(value: Number): string {
      this.dropDownsService.getEquipmentTypes().subscribe({
      next: res => {
        this.list = res as EquipmentTypeModel[];
      }
    });
    return this.list.find(e => e.id === value)?.name ?? "";
  }
}
