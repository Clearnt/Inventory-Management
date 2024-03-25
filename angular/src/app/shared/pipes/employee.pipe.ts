import { Pipe, PipeTransform } from '@angular/core';
import { EmployeeModel } from '../models/employee.model';
import { DropDownsService } from '../services/drop-downs.service';

@Pipe({
  name: 'employee',
  standalone: true
})
export class EmployeePipe implements PipeTransform {
  constructor(public dropDownsService: DropDownsService) {

  }

  list: EmployeeModel[] = [];

  transform(value: Number): string {
      this.dropDownsService.getEmployees().subscribe({
      next: res => {
        this.list = res as EmployeeModel[];
      }
    });
    const emp = this.list.find(e => e.id === value);
    return `${emp?.name ?? ""} ${emp?.surname ?? ""}`;
  }
}
