import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';

@Component({
  selector: 'airline-popup-ref',
  templateUrl: './airlinePopup.component.html',
  styleUrls: ['./airlinePopup.component.css', './../airline/airline.component.css']

  //  styleUrls: ['./invoicePopup.component.css', './../invoice/invoice.component.css']

})
export class AirlinePopupReferencesComponent implements OnInit {

  public nomencaltureAirlinePopup:string = 'ADRIA AIRWAYS';

  constructor(public dialogRef: MatDialogRef<AirlinePopupReferencesComponent>) { }

  ngOnInit() {
  }

  closePopup(): void {
    this.dialogRef.close();
  }

}
