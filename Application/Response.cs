using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Response<T>
    {
        public Response(object data)
        {
            
        }
        public Response(T? data, bool success=true, string? message=null, int? errorCode = null)
        {
            Data = data;
            Success = success; 
            Message = message;
            ErrorCode = errorCode;
        }

        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public int? ErrorCode { get; set; }
    }
}
