import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';

@Component({
  selector: 'app-airport-popup',
  templateUrl: './airportPopup.component.html',
  styleUrls: ['./airportPopup.component.css', './../airport/airport.component.css']

  //  styleUrls: ['./invoicePopup.component.css', './../invoice/invoice.component.css']

})
export class AirportPopupReferencesComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<AirportPopupReferencesComponent>) { }

  ngOnInit() {
  }

  closePopup(): void {
    this.dialogRef.close();
  }

}
