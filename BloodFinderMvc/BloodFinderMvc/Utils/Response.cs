using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodFinderMvc.Utils
{
    public class Response
    {
        public String Result { get; set; }

        public Response(String Result)
        {
            this.Result = Result;
        }
    }
}