using Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ResponseExtensions
    {
        public static Response<T> ConvertToResponse<T>(this Exception ex)
        {
            var exceptionType  = ex.GetType().ToString().Split('.').Last();
            Enum.TryParse(exceptionType, out ErrorCodeEnum exceptionErrorCode);
            var domainType = typeof(T).ToString().Split('.').Skip(1).First();
            Enum.TryParse(domainType, out DomainEnum domainCode);
            int.TryParse($"{(int)domainCode}{(int)exceptionErrorCode}", out int code);
            return new Response<T>(data: default(T), success: false, message: ex.Message, errorCode: code);
        }
    }
}
