import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { HomeComponent } from './components/home/home.component';
import { AviaModule } from '../AviaModule/avia.module';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    AviaModule
  ],
  exports: [
    HomeComponent
  ],
  providers: [],
  bootstrap: [HomeComponent]
})
export class HomeModule { }
