import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { FormControl, FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';
import { EquipmentModel } from '../shared/models/equipment.model';
import { DepartamentModel } from '../shared/models/departament.model';
import { EmployeeModel } from '../shared/models/employee.model';
import { EquipmentStateModel } from '../shared/models/equipment-state.model';
import { EquipmentTypeModel } from '../shared/models/equipment-type.model';
import { EquipmentService } from '../shared/services/equipment.service';
import { DropDownsService } from '../shared/services/drop-downs.service';
import { NgIf } from '@angular/common';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-equipment-form',
  standalone: true,
  imports: [
    MatCardModule, 
    FormsModule, 
    MatFormFieldModule, 
    MatSelectModule, 
    NgIf, 
    MatInputModule, 
    MatDatepickerModule, 
    MatNativeDateModule,
    MatRippleModule,
    MatButtonModule
  ],
  templateUrl: './equipment-form.component.html',
  styleUrl: './equipment-form.component.scss'
})
export class EquipmentFormComponent implements OnInit {
  constructor(public equipmentService: EquipmentService, public dropDownsService: DropDownsService, private router: Router) {

  }
  myControl = new FormControl();

  equipmentTypesList:  EquipmentTypeModel[] = [];
  equipmentStatesList: EquipmentStateModel[] = [];
  employeesList: EmployeeModel[] = [];
  departamentsList: DepartamentModel[] = [];

  selectedEquipmentType: Number = 0;
  selectedEquipmentState: Number = 0;
  selectedEmployee: Number = 0;
  selectedDepartament: Number = 0;

  equipmentTypesLoaded: boolean = false;
  equipmentStatesLoaded: boolean = false;
  employeesLoaded: boolean = false;
  departamentsLoaded: boolean = false;

  newEquipment: EquipmentModel = {
    id: 0,
    typeId: 3,
    name: "name",
    accountingCode: "",
    purchaseDate: Date(),
    cost: 1000,
    ownerEmployeeId: 1,
    ownerDepartamentId: 0,
    stateId: 1,
  }

  async ngOnInit() {   
    this.dropDownsService.getDepartaments().subscribe({
      next: res => {
        this.departamentsList = res as DepartamentModel[];
        this.departamentsLoaded = true;
      },
      error: err => {
        console.log(err);
      }
    })

    this.dropDownsService.getEmployees().subscribe({
      next: res => {
        this.employeesList = res as EmployeeModel[];
        this.employeesLoaded = true;
      },
      error: err => {
        console.log(err);
      }
    })

    this.dropDownsService.getEquipmentStates().subscribe({
      next: res => {
        this.equipmentStatesList = res as EquipmentStateModel[];
        this.equipmentStatesLoaded = true
      },
      error: err => {
        console.log(err);
      }
    })

    this.dropDownsService.getEquipmentTypes().subscribe({
      next: res => {
        this.equipmentTypesList = res as EquipmentTypeModel[];
        this.equipmentTypesLoaded = true;
      },
      error: err => {
        console.log(err);
      }
    })
  }

  saveEquipment() {
    console.log(this.newEquipment)  ;
    this.equipmentService.createEquipment(this.newEquipment).subscribe(data => {
      console.log(data)  ;
      this.router.navigate(['../'])
    }
    )
  }
}

