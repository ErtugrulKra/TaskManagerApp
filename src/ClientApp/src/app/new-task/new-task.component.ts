import { Component, OnInit, EventEmitter, Output } from "@angular/core";
import { TaskModel, TaskStatus } from "../models/TaskModel";
import { TaskListServiceService } from "../services/task-list-service.service";
import { Router } from "@angular/router";
import { FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: "app-new-task",
  templateUrl: "./new-task.component.html",
  styleUrls: ["./new-task.component.css"],
})
export class NewTaskComponent implements OnInit {
  showAlert: boolean = false;
  alertText: string;

  taskForm: FormGroup;

  constructor(
    private taskService: TaskListServiceService,
    private router: Router
  ) {}

  ngOnInit() {
    this.taskForm = new FormGroup({
      taskName: new FormControl("", Validators.required),
      taskContent: new FormControl(null, Validators.required),
      taskPriority: new FormControl(1, [Validators.max(5), Validators.min(1)]),
    });
  }

  submitTask() {
    let task: TaskModel = {
      name: this.taskForm.value.taskName,
      taskContent: this.taskForm.value.taskContent,
      priority: this.taskForm.value.taskPriority,
      status: TaskStatus.NotStarted,
    };
    console.log(task);
    this.taskService.createTask(task).subscribe(
      (s) => {
        this.taskForm.reset();
        this.router.navigateByUrl("/task-list");
      },
      (err) => {
        this.showAlert = true;
        this.alertText = "";
        err.error.errors.Name.forEach((element) => {
          this.alertText += `${element}`;
        });
      }
    );
  }
}
