import * as internal from "assert";

export class TaskModel {
  name: string;
  taskContent:string;
  priority: number;
  status: TaskStatus;
}

export enum TaskStatus {
  NotStarted = 1,
  InProgres = 2,
  Completed = 3,
}
