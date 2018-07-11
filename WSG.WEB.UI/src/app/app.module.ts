import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import { AviaModule } from './Modules/AviaModule/avia.module';
import { TrainModule } from './Modules/TrainModule/train.module';
import { InsuranceModule } from './Modules/InsuranceModule/insurance.module';
import { TourismModule } from './Modules/TourismModule/tourism.module';
import { ReferenceModule } from './Modules/ReferenceModule/reference.module';

const routes : Routes = []

@NgModule({
  declarations: [
    AppComponent        
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AviaModule,
    TrainModule,
    InsuranceModule,
    TourismModule,
    ReferenceModule,
    RouterModule.forRoot(routes),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
