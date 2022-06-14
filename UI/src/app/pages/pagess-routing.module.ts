import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompaniesComponent } from './company/companies/companies.component';
import { DepartmentsComponent } from './department/departments/departments.component';
import { EmployeesComponent } from './employee/employees/employees.component';

const routes: Routes = [
  {path: 'companies', component: CompaniesComponent},
  {path: 'departments', component: DepartmentsComponent},
  {path: 'employees', component: EmployeesComponent},
  {
    path: 'lookups',
    loadChildren: () => import('./lookups/lookups.module').then(m => m.LookupsModule)
  },
  {
    path: '',
    redirectTo: 'companies',
    pathMatch: 'full'
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
