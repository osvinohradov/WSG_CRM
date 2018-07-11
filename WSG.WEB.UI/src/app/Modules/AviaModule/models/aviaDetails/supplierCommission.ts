import { IDeserializable } from "../../interfaces/IDesirializable";

export class SupplierCommission implements IDeserializable{
  Amount: number;
  Mpe: number;
  Currency: string;
  Percant: number;

  desirialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
