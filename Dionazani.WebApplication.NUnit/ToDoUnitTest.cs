using Dionazani.WebApplication.Dto;
using DionAzani.WebApplication.Service;
using NUnit.Framework;
using System.Collections.Generic;

namespace Dionazani.WebApplication.NUnit
{
    public class ToDoUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllTest()
        {
            ToDoService toDoService = new ToDoService();
            List<ToDoDto> dtoList = toDoService.getAll();

            Assert.IsNotNull(dtoList);
        }

        [Test]
        public void GetByIdTest()
        {
            int id = 1;
            ToDoService toDoService = new ToDoService();
            ToDoDto todoDto = toDoService.getById(id);

            Assert.IsNotNull(todoDto);
        }
    }
}
 