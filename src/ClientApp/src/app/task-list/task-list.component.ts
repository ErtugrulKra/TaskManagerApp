import { Component, OnInit } from "@angular/core";
import { TaskModel, TaskStatus } from "../models/TaskModel";
import { TaskListServiceService } from "../services/task-list-service.service";

@Component({
  selector: "task-list",
  templateUrl: "./task-list.component.html",
  styleUrls: ["./task-list.component.css"],
})
export class TaskListComponent implements OnInit {
  taskList: TaskModel[];
  TaskStatus = TaskStatus;

  constructor(private taskListService: TaskListServiceService) {}

  ngOnInit() {
    this.taskListService.getTaskList().subscribe((tasks) => {
      this.taskList = tasks;
    });
  }

  deleteTask(task: TaskModel) {
    this.taskListService.deleteTask(task).subscribe((s) => {
      this.taskList = this.taskList.filter((t) => t.name !== task.name);
    });
  }
}
