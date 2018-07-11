import { IDeserializable } from '../../interfaces/IDesirializable';

export class AgencyServices implements IDeserializable {
  Amount: number;
  Mpe: number;
  Currency: string;
  Percent: number;
  BankPercent: number;

  desirialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
