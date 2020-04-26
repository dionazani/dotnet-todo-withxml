using Dionazani.WebApplication.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DionAzani.WebApplication.Service
{
    public interface IToDoService
    {
        Response GetAll();
        Response GetById(int id);
        ToDoDto GetIncomingByDate(DateTime incomingDate);
        Response Create(ToDoDto toDoDto);
        int Update(ToDoDto toDoDto);
        int PercentComplete(double percent);
        int Delete(int id);
        int MarkAsComplete(int id);
    }
}
