import { IDeserializable } from '../interfaces/IDesirializable';

export class TicketInfo implements IDeserializable {
  Name: string;
  TicketNumber: string;

  desirialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
