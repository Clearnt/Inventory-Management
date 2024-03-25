import { Pipe, PipeTransform } from '@angular/core';
import { EquipmentStateModel } from '../models/equipment-state.model';
import { DropDownsService } from '../services/drop-downs.service';

@Pipe({
  name: 'equipmentState',
  standalone: true
})
export class EquipmentStatePipe implements PipeTransform {
  constructor(public dropDownsService: DropDownsService) {

  }

  list: EquipmentStateModel[] = [];

  transform(value: Number): string {
      this.dropDownsService.getEquipmentStates().subscribe({
      next: res => {
        this.list = res as EquipmentStateModel[];
      }
    });
    return this.list.find(e => e.id === value)?.name ?? "";
  }
}
