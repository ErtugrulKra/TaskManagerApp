import { TestBed } from '@angular/core/testing';

import { TaskListServiceService } from './task-list-service.service';

describe('TaskListServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TaskListServiceService = TestBed.get(TaskListServiceService);
    expect(service).toBeTruthy();
  });
});
