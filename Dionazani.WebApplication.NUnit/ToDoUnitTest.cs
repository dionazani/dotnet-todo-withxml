using Dionazani.WebApplication.Dto;
using DionAzani.WebApplication.Service;
using NUnit.Framework;
using System;
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

        [Test]
        public void Create()
        {
            ToDoDto toDoDto = new ToDoDto();
            toDoDto.Id = 3;
            toDoDto.Title = "Coding Perl";
            toDoDto.Description = "Coding Perl";
            toDoDto.DateAt = Convert.ToDateTime("2020-04-26");
            toDoDto.ExpireAt = Convert.ToDateTime("2020-04-30");
            toDoDto.Complete = 0;
            toDoDto.CompleteAt = Convert.ToDateTime("1900-01-01");

            ToDoService toDoService = new ToDoService();
            Response response = toDoService.Create(toDoDto);

            Assert.AreEqual("200", response.ResponseMessage);
        }
    }
}
 