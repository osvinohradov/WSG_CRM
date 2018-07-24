import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { AviaModule } from '../AviaModule/avia.module';
import {MatIconModule} from '@angular/material/icon';

const routes: Routes = [];


@NgModule({
  declarations: [
    HomeComponent,
    RouterModule
  ],
  imports: [
    FormsModule,
    CommonModule,
    MatIconModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    HomeComponent
  ],
  providers: [],
  bootstrap: [HomeComponent]
})
export class HomeModule { }
