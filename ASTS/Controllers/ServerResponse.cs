using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Controllers
{
    public class ServerResponse
    {
        public ServerResponse(StatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public StatusCode StatusCode { get; set; }
    }


    public class ServerResponse<T> : ServerResponse
    {
        public ServerResponse(StatusCode statusCode, T data) : base(statusCode)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
    public enum StatusCode
    {
        Ok
    }
}
