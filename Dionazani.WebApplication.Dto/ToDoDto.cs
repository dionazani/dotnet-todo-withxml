using System;
using System.ComponentModel;

namespace Dionazani.WebApplication.Dto
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime DateAt { get; set; }
        public DateTime ExpireAt { get; set; }
        public int Complete { get; set; }
        public DateTime CompleteAt { get; set; }
    }
}
