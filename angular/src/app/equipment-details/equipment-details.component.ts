import { Component, OnInit, ViewChild } from '@angular/core';
import { EquipmentService } from '../shared/services/equipment.service';
import { DropDownsService } from '../shared/services/drop-downs.service';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { EquipmentModel } from '../shared/models/equipment.model';
import { DepartamentModel } from '../shared/models/departament.model';
import { EmployeeModel } from '../shared/models/employee.model';
import { EquipmentStateModel } from '../shared/models/equipment-state.model';
import { EquipmentTypeModel } from '../shared/models/equipment-type.model';
import { DatePipe } from '@angular/common';
import { EquipmentTypePipe } from '../shared/pipes/equipment-type.pipe';
import { EquipmentStatePipe } from '../shared/pipes/equipment-state.pipe';
import { EmployeePipe } from '../shared/pipes/employee.pipe';
import { DepartametPipe } from '../shared/pipes/departamet.pipe';


@Component({
  selector: 'app-equipment-details',
  standalone: true,
  imports: [
    MatTableModule, 
    MatCheckboxModule, 
    MatPaginatorModule, 
    DatePipe, 
    EquipmentTypePipe, 
    EquipmentStatePipe,
    EmployeePipe,
    DepartametPipe
  ],
  templateUrl: './equipment-details.component.html',
  styleUrl: './equipment-details.component.scss'
})
export class EquipmentDetailsComponent implements OnInit {
  constructor(public equipmentService: EquipmentService, public dropDownsService: DropDownsService) {

  }
  equipmentList: EquipmentModel[] = [];
  equipmentTypeList:  EquipmentTypeModel[] = [];
  equipmentStateList: EquipmentStateModel[] = [];
  employeeList: EmployeeModel[] = [];
  departamentList: DepartamentModel[] = [];

  displayedColumns: string[] = [
    'select', 
    'typeId', 
    'name',
    'accountingCode', 
    'purchaseDate',
    'cost', 
    'ownerEmployeeId',
    'ownerDepartamentId', 
    'stateId'
  ];
  dataSource = new MatTableDataSource(this.equipmentList);
  selection = new SelectionModel(true, []);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  async ngOnInit() {
    this.equipmentService.getEquipment().subscribe({
      next: res => {
        this.equipmentList = res as EquipmentModel[];

        this.dataSource.data = this.equipmentList;        
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        // console.log(this.paginator);
      },
      error: err => {
        console.log(err);
      }
    });
    
    this.dropDownsService.getDepartaments().subscribe({
      next: res => {
        this.departamentList = res as DepartamentModel[];
      },
      error: err => {
        console.log(err);
      }
    })

    this.dropDownsService.getEmployees().subscribe({
      next: res => {
        this.employeeList = res as EmployeeModel[];
      },
      error: err => {
        console.log(err);
      }
    })

    this.dropDownsService.getEquipmentStates().subscribe({
      next: res => {
        this.equipmentStateList = res as EquipmentStateModel[];
      },
      error: err => {
        console.log(err);
      }
    })

    this.dropDownsService.getEquipmentTypes().subscribe({
      next: res => {
        this.equipmentTypeList = res as EquipmentTypeModel[];
      },
      error: err => {
        console.log(err);
      }
    })
  }  

  selectHandler(row: EquipmentModel) {
    this.selection.toggle(row as never);
  }

  currentPage = 0;

  handlePageEvent(event: PageEvent) {
    console.log(event, this.currentPage);
  }
}
