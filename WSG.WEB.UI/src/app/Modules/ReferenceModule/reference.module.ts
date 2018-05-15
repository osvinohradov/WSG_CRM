import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ReferenceRoutingModule } from './reference-routing.module';

import { AirlineReferencesComponent } from './components/airline/airline.component';
import { AirportReferencesComponent } from './components/airport/airport.component';
import { CityReferencesComponent } from './components/city/city.component';
import { CounterpartiesContractReferencesComponent } from './components/counterpartiesContract/counterpartiesContract.component';
import { CounterpartyReferencesComponent } from './components/counterparty/counterparty.component';
import { CuratorReferencesComponent } from './components/curator/curator.component';
import { NomenclatureReferencesComponent } from './components/nomenclature/nomenclature.component';
import { CurrencyExchangeReferencesComponent } from './components/currencyExchange/currencyExchange.component';
import { IndividualCounterpartiesReferencesComponent } from './components/individualCounterparties/individualCounterparties.component';
import { ServiceReferencesComponent } from './components/service/service.component';

@NgModule({
  declarations: [
    AirlineReferencesComponent,
    AirportReferencesComponent,
    CityReferencesComponent,
    CounterpartiesContractReferencesComponent,
    CounterpartyReferencesComponent,
    CuratorReferencesComponent,
    NomenclatureReferencesComponent,
    CurrencyExchangeReferencesComponent,
    IndividualCounterpartiesReferencesComponent,
    ServiceReferencesComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ReferenceRoutingModule
  ],
  exports: [
    AirlineReferencesComponent,
    AirportReferencesComponent,
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
