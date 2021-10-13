using TaskManagerApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private static readonly List<TaskModel> taskList = new List<TaskModel>() {
            new TaskModel() { Name = "Sample Task 1", TaskContent="lorem impsum task content some data", Priority = 1, Status = 1 },
            new TaskModel() { Name = "Sample Task 2", TaskContent="lorem impsum task content some data", Priority = 3, Status = 2 },
            new TaskModel() { Name = "Sample Task 3", TaskContent="lorem impsum task content some data", Priority = 2, Status = 3 },
            new TaskModel() { Name = "Sample Task 4", TaskContent="lorem impsum task content some data", Priority = 5, Status = 1 },
        };

        public TaskController()
        {
        }

        [HttpGet]
        public async Task<IEnumerable<TaskModel>> Get()
        {
            return await Task.FromResult(taskList.ToList());
        }

        [HttpGet("{taskName}")]
        public async Task<ActionResult<TaskModel>> Get(string taskName)
        {
            if (!taskList.Any(s => s.Name == taskName))
                return NotFound();

            return await Task.FromResult(taskList.Where(s => s.Name == taskName).FirstOrDefault());
        }

        [HttpPost]
        public async Task<IActionResult> Post(TaskModel taskModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (taskList.Any(s => s.Name == taskModel.Name))
                    return BadRequest($"Task named {taskModel.Name} exists");

                taskList.Add(taskModel);

                return await Task.FromResult(Created("", taskModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{taskName}")]
        public async Task<IActionResult> Delete(string taskName)
        {
            try
            {
                if (string.IsNullOrEmpty(taskName))
                    return BadRequest($"Task name can not be empty");

                if (!taskList.Any(s => s.Name == taskName))
                    return BadRequest($"Task named {taskName} not exist");

                taskList.Remove(taskList.FirstOrDefault(s => s.Name == taskName));

                return await Task.FromResult(Ok());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put(TaskModel taskModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!taskList.Any(s => s.Name == taskModel.Name))
                    return BadRequest($"Task named {taskModel.Name} not exist");

                taskList.Remove(taskList.FirstOrDefault(s => s.Name == taskModel.Name));

                taskList.Add(taskModel);

                return await Task.FromResult(Ok(taskModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
