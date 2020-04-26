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
            Response response = toDoService.GetAll();

            Assert.IsNotNull(response.Data);
        }

        [Test]
        public void GetByIdTest()
        {
            int id = 1;
            ToDoService toDoService = new ToDoService();
            Response response = toDoService.GetById(id);

            Assert.IsNotNull(response.Data);
        }
    }
}
 