import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompaniesComponent } from './company/companies/companies.component';

const routes: Routes = [
  {path: 'companies', component: CompaniesComponent},
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
