import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ENumAsStringPipe } from './enum-pipe/EnumAsStringPipe'
import { TaskListComponent } from './task-list/task-list.component';
import { TaskItemComponent } from './task-item/task-item.component';
import { TaskListServiceService } from './services/task-list-service.service';
import { NewTaskComponent } from './new-task/new-task.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TaskListComponent,
    TaskItemComponent,
    NewTaskComponent,
    ENumAsStringPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'new-task', component: NewTaskComponent },
      { path: 'task-list', component: TaskListComponent },
    ])
  ],
  providers: [TaskListServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
