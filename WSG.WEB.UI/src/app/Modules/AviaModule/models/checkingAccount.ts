import { IDeserializable } from '../interfaces/IDesirializable';

export class CheckingAccount implements IDeserializable {
  Name: string = "";

  desirialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
