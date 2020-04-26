using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dionazani.WebApplication.Dto;
using DionAzani.WebApplication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dionazani.WebApplication.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        // GET api/todo/
        [HttpGet]
        public ActionResult<Response> GetAllToDo()
        {
            ToDoService toDoService = new ToDoService();
            return toDoService.GetAll();
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public ActionResult<Response> Get(int id)
        {
            ToDoService toDoService = new ToDoService();
            return toDoService.GetById(id);
        }
    }
}