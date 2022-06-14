import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddressComponent } from './address/address/address.component';
import { SalariesComponent } from './salary/salaries/salaries.component';
import { TaxLookupsComponent } from './tax-lookup/tax-lookups/tax-lookups.component';

const routes: Routes = [
  {path: 'address', component: AddressComponent},
  {path: 'salaries', component: SalariesComponent},
  {path: 'taxlookups', component: TaxLookupsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LookupsRoutingModule { }
