using Dionazani.WebApplication.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DionAzani.WebApplication.Service
{
    public class ToDoService
    {
        public List<ToDoDto> getAll()
        {
            List<ToDoDto> dtoList = new List<ToDoDto>();
            DataSet ds = new DataSet();
            ds.ReadXml("xml/file01.xml");

            DataView dvPrograms;
            dvPrograms = ds.Tables[0].DefaultView;
            dvPrograms.Sort = "Id";
            foreach (DataRowView dr in dvPrograms)
            {
                ToDoDto dto = new ToDoDto();
                dto.Id = Convert.ToInt32(dr[0]);
                dto.Title = Convert.ToString(dr[1]);
                dto.Description = Convert.ToString(dr[2]);
                dto.DateAt = Convert.ToDateTime(dr[3]);
                dto.ExpireAt = Convert.ToDateTime(dr[4]);
                dto.Complete = Convert.ToInt32(dr[5]);
                dto.CompleteAt = Convert.ToDateTime(dr[6]);

                dtoList.Add(dto);
            }

            return dtoList;
        }

        public ToDoDto getById(int id)
        {
            ToDoDto dto = new ToDoDto();

            XDocument xmldoc;
            xmldoc = XDocument.Load("xml/file01.xml");   //add xml document  
            XElement emp = xmldoc.Descendants("ToDo").FirstOrDefault(p => p.Element("id").Value == id.ToString());
            if (emp != null)
            {
                dto.Id = Convert.ToInt32(emp.Element("id").Value);
                dto.Title = Convert.ToString(emp.Element("title").Value);
                dto.Description = Convert.ToString(emp.Element("description").Value);
                dto.DateAt = Convert.ToDateTime(emp.Element("dateAt").Value);
                dto.ExpireAt = Convert.ToDateTime(emp.Element("expireAt").Value);
                dto.Complete = Convert.ToInt32(emp.Element("complete").Value);
                dto.CompleteAt = Convert.ToDateTime(emp.Element("completeAt").Value);

            }

            return dto;
           
        }
    }
}
