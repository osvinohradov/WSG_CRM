import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatTabsModule, MatNativeDateModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';

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
    AviaRoutingModule,
    MatTabsModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule
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
