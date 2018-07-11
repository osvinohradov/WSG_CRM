import { IDeserializable } from '../interfaces/IDesirializable';

export class FlightInfo implements IDeserializable {
  FlightNumber: string;
  ArrivalPlace: string;
  DeparturePlace: string;
  Place: string;
  ServiceType: string;
  DepartureDateTime: Date;
  ArrivalDateTime: Date;

  desirialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
