import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EquipmentDetailsComponent } from './equipment-details/equipment-details.component';
import { EquipmentFormComponent } from './equipment-form/equipment-form.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterLink } from '@angular/router';
import { RouterLinkActive } from '@angular/router';
import { RouterOutlet } from '@angular/router';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule, 
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    EquipmentDetailsComponent, 
    EquipmentFormComponent,
    MatIconModule, 
    MatButtonModule, 
    MatToolbarModule,
    MatListModule,
    MatCardModule
    ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent {
  title = 'angular-kpz-Ivan-Zhuk';
}
