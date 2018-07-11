import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ReferenceRoutingModule } from './reference-routing.module';

import { AirlineReferencesComponent } from './components/airline/airline.component';
import { AirlinePopupReferencesComponent } from './components/airlinePopup/airlinePopup.component';
import { AirportReferencesComponent } from './components/airport/airport.component';
import { AirportPopupReferencesComponent } from './components/airportPopup/airportPopup.component';

import { CityReferencesComponent } from './components/city/city.component';
import { CounterpartiesContractReferencesComponent } from './components/counterpartiesContract/counterpartiesContract.component';
import { CounterpartyReferencesComponent } from './components/counterparty/counterparty.component';
import { CuratorReferencesComponent } from './components/curator/curator.component';
import { NomenclatureReferencesComponent } from './components/nomenclature/nomenclature.component';
import { CurrencyExchangeReferencesComponent } from './components/currencyExchange/currencyExchange.component';
import { IndividualCounterpartiesReferencesComponent } from './components/individualCounterparties/individualCounterparties.component';
import { ServiceReferencesComponent } from './components/service/service.component';

// materials modules
import { MatTabsModule, MatNativeDateModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatDialogModule} from '@angular/material/dialog';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatMenuModule} from '@angular/material/menu';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatListModule} from '@angular/material/list';

// print components
// import { AviaPrintInvoicePopupComponent } from './../AviaModule/components/printInvoice/printInvoice.component';
// import { AviaPrintActPopupComponent } from './../AviaModule/components/printAct/printAct.component';
// import { AviaPrintScorePopupComponent } from './../AviaModule/components/printScore/printScore.component';
// import { AviaPrintScoreWithStampPopupComponent } from './../AviaModule/components/printScoreWithStamp/printScoreWithStamp.component';


@NgModule({
  declarations: [
    AirlineReferencesComponent,
    AirlinePopupReferencesComponent,
    AirportReferencesComponent,
    AirportPopupReferencesComponent,
    CityReferencesComponent,
    CounterpartiesContractReferencesComponent,
    CounterpartyReferencesComponent,
    CuratorReferencesComponent,
    NomenclatureReferencesComponent,
    CurrencyExchangeReferencesComponent,
    IndividualCounterpartiesReferencesComponent,
    ServiceReferencesComponent
    

    // AviaPrintInvoicePopupComponent,
    // AviaPrintActPopupComponent,
    // AviaPrintScorePopupComponent,
    // AviaPrintScoreWithStampPopupComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ReferenceRoutingModule,
    MatTabsModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatButtonModule,
    MatCheckboxModule,
    MatSlideToggleModule,
    MatDialogModule,
    MatGridListModule,
    MatTooltipModule,
    MatMenuModule,
    MatSelectModule,
    MatFormFieldModule,
    MatListModule
  ],
  entryComponents: [
    AirlinePopupReferencesComponent,
    AirportPopupReferencesComponent
  ],
  exports: [
    AirlineReferencesComponent,
    AirlinePopupReferencesComponent,
    AirportReferencesComponent,
    AirportPopupReferencesComponent,
    CityReferencesComponent,
    CounterpartiesContractReferencesComponent,
    CounterpartyReferencesComponent,
    CuratorReferencesComponent,
    NomenclatureReferencesComponent,
    CurrencyExchangeReferencesComponent,
    IndividualCounterpartiesReferencesComponent,
    ServiceReferencesComponent,
    ReferenceRoutingModule
  ],
  providers: [],
  bootstrap: []
})
export class ReferenceModule { }
