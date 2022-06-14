import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { LookupsRoutingModule } from './lookups-routing.module';

import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDialogModule } from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatTableModule} from '@angular/material/table';
import {MatMenuModule} from '@angular/material/menu';

import { AddressComponent } from './address/address/address.component';
import { AddressformComponent } from './address/addressform/addressform.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CrudHttpService } from './services/crudHttp.service';

@NgModule({
  declarations: [
    AddressComponent,
    AddressformComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatToolbarModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressSpinnerModule,
    LookupsRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatMenuModule
  ],
  providers:[CrudHttpService]
})
export class LookupsModule { }
