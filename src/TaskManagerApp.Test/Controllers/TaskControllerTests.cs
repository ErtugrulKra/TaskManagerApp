using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TaskManagerApp.Controllers;
using TaskManagerApp.Data;
using Xunit;

namespace TaskManagerApp.Test.Controllers
{
    public class TaskControllerTests
    {
        [Fact]
        public void Get_Returns_Collections()
        {
            // Arrange
            var givenCount = 4;
            var givenFirstTaskName = "Sample Task 1";
            var givenFirstPriority = 1;
            var taskController = new TaskController();

            // Act
            var result = taskController.Get().Result;

            // Assert
            Assert.Equal(givenCount, result.Count());
            Assert.Equal(givenFirstTaskName, result.First().Name);
            Assert.Equal(givenFirstPriority, result.First().Priority);
        }

        [Fact]
        public void Get_Returns_ValidTask()
        {
            // Arrange
            var taskController = new TaskController();
            string taskName = "Sample Task 1";

            // Act
            var result = taskController.Get(taskName).Result;

            // Assert
            Assert.Equal(taskName, result.Value.Name);
        }

        [Fact]
        public void Get_Returns_NotFound()
        {
            // Arrange
            var taskController = new TaskController();
            string taskName = "Sample Task 5";

            // Act
            var result = taskController.Get(taskName).Result;
            var notFound = result.Result as NotFoundResult;
            // Assert
            Assert.Equal(404, notFound.StatusCode);
        }

        [Fact]
        public void Post_Saves_NewTask()
        {
            // Arrange
            var taskController = new TaskController();
            TaskModel taskModel = new TaskModel()
            {
                Name = "test purpose task",
                Priority = 1,
                Status = 1,
                TaskContent = "test "
            };

            // Act
            var result = taskController.Post(taskModel);
            var okResult = result.Result as CreatedResult;

            // Assert
            Assert.Equal(201, okResult.StatusCode);
            Assert.Equal(taskModel.Name, ((TaskModel)okResult.Value).Name);
        }


        [Fact]
        public void Post_Returns_ExistError()
        {
            // Arrange
            var taskController = new TaskController();
            TaskModel taskModel = new TaskModel()
            {
                Name = "Sample Task 3",
                Priority = 3,
                Status = 1,
                TaskContent = "test"
            };

            // Act
            var result = taskController.Post(taskModel);
            var badRequestResult = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal($"Task named {taskModel.Name} exists", badRequestResult.Value.ToString());
        }

        [Fact]
        public void Delete_Deletes_ExistingTask()
        {
            // Arrange
            var taskController = new TaskController();
            string taskName = "Sample Task 4";

            // Act
            var result = taskController.Delete(taskName);
            var okResult = result.Result as OkResult;

            // Assert
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void Delete_Returns_TaskName_Required()
        {
            // Arrange
            var taskController = new TaskController();
            string taskName =string.Empty;

            // Act
            var result = taskController.Delete(taskName);
            var badRequestResult = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal($"Task name can not be empty", badRequestResult.Value.ToString());
        }

        [Fact]
        public void Delete_Returns_Not_ExistError()
        {
            // Arrange
            var taskController = new TaskController();
            string taskName = "Sample Task 5";

            // Act
            var result = taskController.Delete(taskName);
            var badRequestResult = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal($"Task named {taskName} not exist", badRequestResult.Value.ToString());
        }

        [Fact]
        public void Put_Updates_ExitstingTask()
        {
            // Arrange
            var taskController = new TaskController();
            TaskModel taskModel = new TaskModel()
            {
                Name = "Sample Task 4",
                Priority = 1,
                Status = 3,
                TaskContent = "test content completed"
            };

            // Act
            var result = taskController.Put(taskModel);
            var okResult = result.Result as OkObjectResult;

            // Assert
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(taskModel.Status, ((TaskModel)okResult.Value).Status);
        }

        [Fact]
        public void Put_Returns_Not_ExistError()
        {
            // Arrange
            var taskController = new TaskController();
            TaskModel taskModel = new TaskModel()
            {
                Name = "Sample Task 5",
                Priority = 1,
                Status = 3,
                TaskContent = "test content completed"
            };

            // Act
            var result = taskController.Put(taskModel);
            var okResult = result.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal(400, okResult.StatusCode);
            Assert.Equal($"Task named {taskModel.Name} not exist", okResult.Value.ToString());
        }
    }
}
