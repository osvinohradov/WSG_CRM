import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


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



import { AviaInvoiceComponent } from './components/invoice/invoice.component';
import { AviaGroupInvoiceComponent } from './components/groupInvoice/groupInvoice.component';
import { AviaGroupInvoicePopupComponent } from './components/groupInvoicePopup/groupInvoicePopup.component';
import { AviaRoutingModule } from './avia-routing.module';

@NgModule({
  declarations: [
    AviaInvoiceComponent,
    AviaGroupInvoiceComponent ,
    AviaGroupInvoicePopupComponent   
  ],
  imports: [
    FormsModule,
    CommonModule,
    AviaRoutingModule,
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
    MatSelectModule
  ],
  entryComponents: [
    AviaGroupInvoicePopupComponent
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
