import { Injectable, Inject } from "@angular/core";
import { TaskModel, TaskStatus } from "../models/TaskModel";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

const httpHeaderValues = {
  headers: new HttpHeaders({ "content-type": "application/json" }),
};

@Injectable({
  providedIn: "root",
})
export class TaskListServiceService {
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  //Get Tasks
  getTaskList(): Observable<TaskModel[]> {
    return this.http.get<TaskModel[]>(`${this.baseUrl}/Task`);
  }

  //UpdateTask
  updateTask(task: TaskModel): Observable<any> {
    return this.http.put(`${this.baseUrl}/Task`, task, httpHeaderValues);
  }

  deleteTask(task: TaskModel): Observable<any> {
    return this.http.delete(`${this.baseUrl}/Task/${task.name}`);
  }

  createTask(task: TaskModel): Observable<any> {
    return this.http.post<TaskModel>(
      `${this.baseUrl}/Task`,
      task,
      httpHeaderValues
    );
  }
}
