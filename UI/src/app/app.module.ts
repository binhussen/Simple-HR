import { NgModule } from '@angular/core';
import { CoreModule } from '@angular/flex-layout';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HrCommonModule } from './hr-common/hr-common.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CoreModule,
    HrCommonModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
