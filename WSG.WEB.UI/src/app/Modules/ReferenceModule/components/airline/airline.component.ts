import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
// import { AviaPrintInvoicePopupComponent } from './../../../../Components/printInvoice/printInvoice.component';
// import { AviaPrintActPopupComponent } from './../../../../Components/printAct/printAct.component';
// import { AviaPrintScorePopupComponent } from './../../../../Components/printScore/printScore.component';
// import { AviaPrintScoreWithStampPopupComponent } from './../../../../Components/printScoreWithStamp/printScoreWithStamp.component';
import { AirlinePopupReferencesComponent } from './../airlinePopup/airlinePopup.component';

@Component({
  selector: 'airline-ref',
  templateUrl: './airline.component.html',
  styleUrls: ['./airline.component.css']
})
export class AirlineReferencesComponent implements OnInit {

  public nomencaltureAirline:string = 'ADRIA AIRWAYS';

  constructor(public dialog: MatDialog) { }

  ngOnInit() {
  }

  openDialog(): void {
    let dialogRef = this.dialog.open(AirlinePopupReferencesComponent, {
      panelClass: 'my-centered-dialog',
      width: '50%',
    });

  }

}
