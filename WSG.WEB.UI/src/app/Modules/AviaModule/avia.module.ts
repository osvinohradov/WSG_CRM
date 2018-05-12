import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { InvoiceComponent } from './components/invoice/invoice.component';

@NgModule({
  declarations: [
    InvoiceComponent
  ],
  imports: [
    FormsModule,
    CommonModule
  ],
  exports: [
    InvoiceComponent
  ],
  providers: [],
  bootstrap: []
})
export class AviaModule { }
