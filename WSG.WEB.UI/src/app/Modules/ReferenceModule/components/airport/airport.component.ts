import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AviaPrintInvoicePopupComponent } from './../../../../Components/printInvoice/printInvoice.component';
import { AviaPrintActPopupComponent } from './../../../../Components/printAct/printAct.component';
import { AviaPrintScorePopupComponent } from './../../../../Components/printScore/printScore.component';
import { AviaPrintScoreWithStampPopupComponent } from './../../../../Components/printScoreWithStamp/printScoreWithStamp.component';

@Component({
  selector: 'airport-ref',
  templateUrl: './airport.component.html',
  styleUrls: ['./airport.component.css']
})
export class AirportReferencesComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  ngOnInit() {
  }

  openPrintInvoice(): void {
    let dialogRef = this.dialog.open(AviaPrintInvoicePopupComponent, {
      width: '98%',
      height: '98%'
    });

  }
  openPrintAct(): void {
    let dialogRef = this.dialog.open(AviaPrintActPopupComponent, {
      width: '98%',
      height: '98%'
    });

  }
  openPrintScore(): void {
    let dialogRef = this.dialog.open(AviaPrintScorePopupComponent, {
      width: '98%',
      height: '98%'
    });

  }
  openPrintScoreWithStamp(): void {
    let dialogRef = this.dialog.open(AviaPrintScoreWithStampPopupComponent, {
      width: '98%',
      height: '98%'
    });

  }
}
