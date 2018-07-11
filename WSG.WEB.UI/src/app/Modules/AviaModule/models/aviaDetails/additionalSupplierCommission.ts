import { IDeserializable } from '../../interfaces/IDesirializable';

export class AdditionalSupplierCommission implements IDeserializable {
  Amount: number;
  Mpe: number;
  Currency: string;
  AmountCash: number;

  desirialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
