import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { DepartamentModel } from '../models/departament.model';
import { EmployeeModel } from '../models/employee.model';
import { EquipmentStateModel } from '../models/equipment-state.model';
import { EquipmentTypeModel } from '../models/equipment-type.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DropDownsService {
  constructor(private http: HttpClient) { }

  getDepartaments() : Observable<DepartamentModel[]> {
    return this.http.get<DepartamentModel[]>(`${environment.apiUrlBase}/DepartamentsDropdown`);
  }

  getEquipmentStates() : Observable<EquipmentStateModel[]> {
    return this.http.get<EquipmentStateModel[]>(`${environment.apiUrlBase}/EquipmentStatesDropdown`);
  }

  getEquipmentTypes() : Observable<EquipmentTypeModel[]> {
    return this.http.get<EquipmentTypeModel[]>(`${environment.apiUrlBase}/EquipmentTypesDropdown`);
  }

  getEmployees() : Observable<EmployeeModel[]> {
    return this.http.get<EmployeeModel[]>(`${environment.apiUrlBase}/Employees`);
  }
}
