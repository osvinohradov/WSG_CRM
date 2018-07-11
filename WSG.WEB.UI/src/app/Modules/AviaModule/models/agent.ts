import { IDeserializable } from '../interfaces/IDesirializable';

export class Agent implements IDeserializable {
  Name: string;
  Id: string;

  desirialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
