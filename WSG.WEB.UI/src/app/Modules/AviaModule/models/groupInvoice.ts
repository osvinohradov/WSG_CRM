import { IDeserializable } from '../interfaces/IDesirializable';

export class GroupInvoice implements IDeserializable {
  Id: string;
  Name: string = "";

  desirialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
