import { SupplierCost } from './aviaDetails/supplierCost';
import { SupplierCommission } from './aviaDetails/supplierCommission';
import { Forfeit } from './aviaDetails/forfeit';
import { UsedSupplierRate } from './aviaDetails/usedSupplierRate';
import { AdditionalSupplierCommission } from './aviaDetails/additionalSupplierCommission';
import { UsedRates } from './aviaDetails/usedRates';
import { AgencyServices } from './aviaDetails/agencyServices';
import { OtherServices } from './aviaDetails/otherServices';
import { TotalAmount } from './aviaDetails/totalAmount';
import { IDeserializable } from '../interfaces/IDesirializable';


export class AviaDetail implements IDeserializable {

  constructor() {
    this.SupplierCost = new SupplierCost();
    this.SupplierCommission = new SupplierCommission();
    this.Forfeit = new Forfeit();
    this.UsedSupplierRate = new UsedSupplierRate();
    this.AdditionalSupplierCommission = new AdditionalSupplierCommission();
    this.UsedRates = new UsedRates();
    this.AgencyServices = new AgencyServices();
    this.OtherServices = new OtherServices();
    this.TotalAmount = new TotalAmount();
  }

  Name: string;
  TicketNumber: string;
  PurchaseDate: Date;
  Description: string;
  SupplierCost: SupplierCost;
  SupplierCommission: SupplierCommission;
  Forfeit: Forfeit;
  UsedSupplierRate: UsedSupplierRate;
  AdditionalSupplierCommission: AdditionalSupplierCommission;
  UsedRates: UsedRates;
  AgencyServices: AgencyServices;
  OtherServices: OtherServices;
  TotalAmount: TotalAmount;

  desirialize(input: any): this {
    Object.assign(this, input);
    this.SupplierCost = new SupplierCost().desirialize(input.SupplierCost);
    this.SupplierCommission = new SupplierCommission().desirialize(input.SupplierCommission);
    this.Forfeit = new Forfeit().desirialize(input.Forfeit);
    this.UsedSupplierRate = new UsedSupplierRate().desirialize(input.UsedSupplierRate);
    this.AdditionalSupplierCommission = new AdditionalSupplierCommission().desirialize(input.AdditionalSupplierComission);
    this.UsedRates = new UsedRates().desirialize(input.UsedRates);
    this.AgencyServices = new AgencyServices().desirialize(input.AgencyServices);
    this.OtherServices = new OtherServices().desirialize(input.OtherServices);
    this.TotalAmount = new TotalAmount().desirialize(input.TotalAmount);

    return this;
  }
}
