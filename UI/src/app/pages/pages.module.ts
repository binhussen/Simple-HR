import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LookupsModule } from './lookups/lookups.module';
import { CompanyformComponent } from './company/companyform/companyform.component';
import { CompaniesComponent } from './company/companies/companies.component';
import { PagesRoutingModule } from './pagess-routing.module';


import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDialogModule } from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatTableModule} from '@angular/material/table';
import {MatMenuModule} from '@angular/material/menu';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatSelectModule} from '@angular/material/select';
import { DepartmentsComponent } from './department/departments/departments.component';
import { DepartmentformComponent } from './department/departmentform/departmentform.component';

@NgModule({
  declarations: [CompanyformComponent,CompaniesComponent, DepartmentsComponent, DepartmentformComponent],
  imports: [
    CommonModule,
    LookupsModule,
    PagesRoutingModule,
    MatCardModule,
    MatIconModule,
    MatToolbarModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressSpinnerModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatMenuModule,
    MatSelectModule
  ]
})
export class PagesModule { }
