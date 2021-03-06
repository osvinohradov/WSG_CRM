import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

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

const routes: Routes = [
  {
    path: 'reference', children: [
      { path: 'airline', component: AirlineReferencesComponent },
      { path: 'airport', component: AirportReferencesComponent },
      { path: 'city', component: CityReferencesComponent },
      { path: 'counterparties-contracts', component: CounterpartiesContractReferencesComponent },
      { path: 'counterparty', component: CounterpartyReferencesComponent },
      { path: 'curator', component: CuratorReferencesComponent },
      { path: 'nomenclature', component: NomenclatureReferencesComponent },
      { path: 'currency-exchange', component: CurrencyExchangeReferencesComponent },
      { path: 'individual-counterparties', component: IndividualCounterpartiesReferencesComponent },
      { path: 'service', component: ServiceReferencesComponent },
    ]
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ReferenceRoutingModule { }
