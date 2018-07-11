import { IDeserializable } from "../../interfaces/IDesirializable";

export class UsedSupplierRate implements IDeserializable {
  Tariff: number;
  Mpe: number;
  Currency: string;

  desirialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
