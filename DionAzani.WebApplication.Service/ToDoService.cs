using Dionazani.WebApplication.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DionAzani.WebApplication.Service
{
    public class ToDoService : IToDoService
    {
        public int Create(ToDoDto toDoDto)
        {
            int result = 0;

            try
            {
                XDocument xmldoc = XDocument.Load("xml/file01.xml");   //add xml document  
                XElement emp = new XElement("ToDo",
                                    new XElement("id", toDoDto.Id),
                                    new XElement("title", toDoDto.Title),
                                    new XElement("description", toDoDto.Description),
                                    new XElement("dateAt", Convert.ToString(toDoDto.DateAt)),
                                    new XElement("expireAt", Convert.ToString(toDoDto.ExpireAt)),
                                    new XElement("complete", toDoDto.Complete),
                                    new XElement("completeAt", Convert.ToString(toDoDto.CompleteAt)));

                xmldoc.Root.Add(emp);
                xmldoc.Save("xml/file01.xml");

                result = 1;
            }
            catch(Exception ex)
            {
                // do nothing
            }

            return result;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Response GetAll()
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

            Response response = new Response();
            response.ResponseCode = "000";
            response.ResponseMessage = "Success";
            response.Data = dtoList;

            return response;
        }

        public Response GetById(int id)
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

            Response response = new Response();
            response.ResponseCode = "000";
            response.ResponseMessage = "Success";
            response.Data = dto;

            return response;
           
        }

        public ToDoDto GetIncomingByDate(DateTime incomingDate)
        {
            ToDoDto dto = new ToDoDto();

            XDocument xmldoc;
            xmldoc = XDocument.Load("xml/file01.xml");   //add xml document  
            XElement emp = xmldoc.Descendants("ToDo").FirstOrDefault(p => p.Element("dateAt").Value == Convert.ToString(incomingDate));
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

        public int MarkAsComplete(int id)
        {
            throw new NotImplementedException();
        }

        public int PercentComplete(double percent)
        {
            throw new NotImplementedException();
        }

        public int Update(ToDoDto toDoDto)
        {
            throw new NotImplementedException();
        }
    }
}
