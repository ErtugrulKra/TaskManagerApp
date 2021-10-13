import { Component, OnInit, Input, Output } from "@angular/core";
import { TaskModel, TaskStatus } from "../models/TaskModel";
import { ENumAsStringPipe } from "../enum-pipe/EnumAsStringPipe";
import { TaskListServiceService } from "../services/task-list-service.service";
import { EventEmitter } from "@angular/core";

@Component({
  selector: "app-task-item",
  templateUrl: "./task-item.component.html",
  styleUrls: ["./task-item.component.css"],
})
export class TaskItemComponent implements OnInit {
  TaskStatus = TaskStatus;
  @Input() task: TaskModel;
  @Output() deleteTaskEvent: EventEmitter<TaskModel> = new EventEmitter();

  constructor(private taskService: TaskListServiceService) {}

  ngOnInit() {}

  setClasses() {
    switch (this.task.status) {
      case TaskStatus.Completed:
        return { "bg-success": true, " text-light": true };
      case TaskStatus.InProgres:
        return { "bg-info": true, " text-light": true };
      case TaskStatus.NotStarted:
        return { "bg-warning": true };
    }
  }

  startTask(task: TaskModel) {
    //Update In UI
    task.status = TaskStatus.InProgres;
    //Update In Server
    this.taskService.updateTask(task).subscribe((s) => console.log(s));
  }

  completeTask(task: TaskModel) {
    task.status = TaskStatus.Completed;
    this.taskService.updateTask(task).subscribe((s) => console.log(s));
  }

  deleteTask(task: TaskModel) {
    this.deleteTaskEvent.emit(task);

  }
}
