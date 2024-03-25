import { Routes } from '@angular/router';
import { EquipmentDetailsComponent } from './equipment-details/equipment-details.component';
import { EquipmentFormComponent } from './equipment-form/equipment-form.component';

export const routes: Routes = [
  {
    path: 'equipment',
    loadComponent: () => import('./equipment-details/equipment-details.component').then(c => c.EquipmentDetailsComponent)
  },
  {
    path: 'equipment/add',
    loadComponent: () => import('./equipment-form/equipment-form.component').then(c => c.EquipmentFormComponent)
  },
  {
    path: 'equipment/edit',
    loadComponent: () => import('./equipment-form/equipment-form.component').then(c => c.EquipmentFormComponent)
  },
  {
    path: 'employees',
    loadComponent: () => import('./equipment-details/equipment-details.component').then(c => c.EquipmentDetailsComponent)
  },
  { 
    path: '',   
    redirectTo: '/equipment', pathMatch: 'full' 
  },
  {
    path: '**',
    redirectTo: '/equipment', pathMatch: 'full',
  }
];
