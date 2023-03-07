using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosCMU.Domain.Utils
{
    public class APIMessage
    {
        public HttpStatusCode StatusCode
        {
            get;
            set;
        }

        public object Content
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public APIMessage()
        {
        }

        public APIMessage(HttpStatusCode statusCode, object content)
        {
            StatusCode = statusCode;
            Content = content;
        }

        public APIMessage(HttpStatusCode statusCode, object content, string message)
        {
            StatusCode = statusCode;
            Content = content;
            Message = message;
        }



    }
}
