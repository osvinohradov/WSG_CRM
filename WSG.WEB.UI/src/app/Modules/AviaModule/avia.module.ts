import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AviaInvoiceComponent } from './components/invoice/invoice.component';
import { AviaGroupInvoiceComponent } from './components/groupInvoice/groupInvoice.component';
import { AviaRoutingModule } from './avia-routing.module';

@NgModule({
  declarations: [
    AviaInvoiceComponent,
    AviaGroupInvoiceComponent    
  ],
  imports: [
    FormsModule,
    CommonModule,
    AviaRoutingModule
  ],
  exports: [
    AviaInvoiceComponent,
    AviaGroupInvoiceComponent,
    AviaRoutingModule
  ],
  providers: [],
  bootstrap: []
})
export class AviaModule { }
