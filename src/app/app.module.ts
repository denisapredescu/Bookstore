import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BasketComponent } from './modules/basket/basket.component';
import { ReactiveFormsModule } from '@angular/forms';
import { PopupModule } from './modules/popup/popup.module';
import { MaterialModule } from './modules/material/material.module';
import { OrderComponent } from './modules/order/order.component';

@NgModule({
  declarations: [
    AppComponent,
    BasketComponent,
    OrderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    PopupModule,
    MaterialModule
  ],
  exports:[
  ],
  providers: [],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
