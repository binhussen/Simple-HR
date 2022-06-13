import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'lookups',
    loadChildren: () => import('./pages/lookups/lookups.module').then(m => m.LookupsModule)
  },
  {
    path: '',
    redirectTo: 'lookups',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
