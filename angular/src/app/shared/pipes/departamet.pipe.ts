import { Pipe, PipeTransform } from '@angular/core';
import { DepartamentModel } from '../models/departament.model';
import { DropDownsService } from '../services/drop-downs.service';

@Pipe({
  name: 'departamet',
  standalone: true
})
export class DepartametPipe implements PipeTransform {
  constructor(public dropDownsService: DropDownsService) {

  }

  list: DepartamentModel[] = [];

  transform(value: Number): string {
      this.dropDownsService.getDepartaments().subscribe({
      next: res => {
        this.list = res as DepartamentModel[];
      }
    });
    return this.list.find(e => e.id === value)?.name ?? "";
  }
}
