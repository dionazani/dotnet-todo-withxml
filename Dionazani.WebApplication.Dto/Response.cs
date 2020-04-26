using System;
using System.Collections.Generic;
using System.Text;

namespace Dionazani.WebApplication.Dto
{
    public class Response
    {
        public String ResponseCode { get; set; }
        public String ResponseMessage { get; set; }
        public Object Data { get; set; }
    }
}
