import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { AviaGroupInvoicePopupComponent } from './../groupInvoicePopup/groupInvoicePopup.component';

@Component({
  selector: 'avia-group-invoice',
  templateUrl: './groupInvoice.component.html',
  // styleUrls: ['./groupInvoice.component.css', './../../styles/invoicePopup.css', './../../styles/invoice.css']
  styleUrls: ['./groupInvoice.component.css']
})
export class AviaGroupInvoiceComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  openDialog(): void {
    let dialogRef = this.dialog.open(AviaGroupInvoicePopupComponent, {
      width: '90%',
      height: '90vh'
    });

  }

  ngOnInit() {
  }
}
