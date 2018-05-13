import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { InvoiceComponent } from './components/invoice/invoice.component';
import { GroupInvoiceComponent } from './components/groupInvoice/groupInvoice.component';

@NgModule({
  declarations: [
    InvoiceComponent,
    GroupInvoiceComponent
  ],
  imports: [
    FormsModule,
    CommonModule
  ],
  exports: [
    InvoiceComponent,
    GroupInvoiceComponent
  ],
  providers: [],
  bootstrap: []
})
export class AviaModule { }
