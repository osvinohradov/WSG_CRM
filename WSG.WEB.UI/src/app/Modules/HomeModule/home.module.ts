import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { AviaModule } from '../AviaModule/avia.module';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent }
    ])
  ],
  exports: [
    HomeComponent
  ],
  providers: [],
  bootstrap: [HomeComponent]
})
export class HomeModule { }
