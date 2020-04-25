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
        public ActionResult<IEnumerable<ToDoDto>> GetAllToDo()
        {
            ToDoService toDoService = new ToDoService();
            return toDoService.getAll();
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public ActionResult<ToDoDto> Get(int id)
        {
            ToDoService toDoService = new ToDoService();
            ToDoDto todoDto = toDoService.getById(id);

            return todoDto;
        }
    }
}