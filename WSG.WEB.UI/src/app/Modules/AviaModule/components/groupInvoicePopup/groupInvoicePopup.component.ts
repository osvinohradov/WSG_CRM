import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';


@Component({
  selector: 'avia-group-invoice-popup',
  templateUrl: './groupInvoicePopup.component.html',
  styleUrls: ['./groupInvoicePopup.component.css']
})
export class AviaGroupInvoicePopupComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<AviaGroupInvoicePopupComponent>
  ) { }

  ngOnInit() {
  }

  closePopup(): void {
    this.dialogRef.close();
  }
}
