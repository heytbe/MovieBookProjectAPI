using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services.API.ResponseService
{
    public class Response<T> 
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool isSuccessFull { get; set; }

        public Error Error { get; set; }

        public static Response<T> Success(T data,int statusCode)
        {
           return new Response<T>
            {
               Data = data,
               StatusCode = statusCode,
               isSuccessFull = true
            };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T>
            {
                Data = default(T),
                StatusCode = statusCode,
                isSuccessFull = true
            };
        }

        public static Response<T> Fail(Error error,int statusCode)
        {
            return new Response<T>
            {
                Error = error,
                StatusCode = statusCode,
                isSuccessFull = false
            };
        }

        public static Response<T> Fail(string message,int statusCode)
        {
            var error = new Error(message, true);
            return new Response<T>
            {
                Error = error,
                StatusCode = statusCode,
                isSuccessFull = false
            };
        }

    }
}
