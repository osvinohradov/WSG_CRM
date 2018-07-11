import { IDeserializable } from '../../interfaces/IDesirializable';


export class Forfeit implements IDeserializable {
  Amount: number;
  Mpe: number;
  Currency: string;

  desirialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
