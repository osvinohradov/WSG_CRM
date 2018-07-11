import { TicketInfo } from './ticketInfo';
import { FlightInfo } from './flightInfo';
import { Agent } from './agent';
import { CheckingAccount } from './checkingAccount';
import { GroupInvoice } from './groupInvoice';
import { AviaDetail } from './aviaDetail';
import { IDeserializable } from '../interfaces/IDesirializable';

export class AviaInvoice implements IDeserializable {
  constructor() {
    this.ResponsibleAgent = new Agent();
    this.Agent = new Agent();
    this.GroupInvoice = new GroupInvoice();
    this.CheckingAccount = new CheckingAccount();
    this.AviaDetail = new AviaDetail();
  }

  Number: number;
  Date: Date;
  PaymentForm: string;
  PaymentDate: Date;
  TotalAmount: number;
  Client: string;
  ServiceDate: Date;
  Paid: boolean;
  GroupInvoice: GroupInvoice;
  TotalCurrency: string;
  Provider: string;
  Curator: string;
  CurrencyExchange: string;
  OnDate: Date;
  ServiceType: string;
  CheckingAccount: CheckingAccount;
  Comment: string;
  ResponsibleAgent: Agent;
  Agent: Agent;
  Description: string;

  // ---------
  TicketsCount: number;
  Returned: boolean;
  IsImplementation: boolean;
  OfferCurrency: string;
  TaxesPayment: string;
  BookingCode: string;
  PMCode: string;
  Void: boolean;
  AviaDetail: AviaDetail;
  FlightsInfo: Array<FlightInfo>;
  TicketInfo: Array<TicketInfo>;

  Organization: string
  ReturnedDocument: string;
  DateOfPurchaseFromSupplier: Date;
  Processed: boolean;
  MPE: number;

  desirialize(input: any): this {
    Object.assign(this, input);
    this.GroupInvoice = new GroupInvoice().desirialize(input.GroupInvoice);
    this.CheckingAccount = new CheckingAccount().desirialize(input.CheckingAccount);
    this.ResponsibleAgent = new Agent().desirialize(input.ResponsibleAgent);
    this.Agent = new Agent().desirialize(input.Agent);
    // this.AviaDetail = new AviaDetail().desirialize(input.AviaDetail);
    this.FlightsInfo = input.FlightsInfo.map((elem) => new FlightInfo().desirialize(elem));
    this.TicketInfo = input.TicketInfo.map((elem) => new TicketInfo().desirialize(elem));

    return this;
  }
}
