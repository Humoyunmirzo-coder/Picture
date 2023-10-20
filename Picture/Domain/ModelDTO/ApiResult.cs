using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelDTO
{
    public  class ApiResult <T>
    {
        public T?  Data { get; set; }
        public int? StatusCode { get; set; }
        public string Message { get; set; }
        public static implicit operator ApiResult<T>((T? data, int statusCode) payload) => new ApiResult<T>
        {
            Data = payload.data,
            StatusCode = payload.statusCode
        };
        public static implicit operator ApiResult<T>((string message, int statusCode) error) => new ApiResult<T>()
        {
            Message = error.message,
            StatusCode = error.statusCode
        };

        public static ApiResult<IEnumerable<T>> FromIEnumerable(IEnumerable<T> data, string message = null)
        {
            return new ApiResult<IEnumerable<T>>
            {
                Data = data,
                Message = message,
                StatusCode = 200
            };
        }
        public static implicit operator ApiResult<T>(T data) => new ApiResult<T>()
        {
            Data = data,
            StatusCode = 200
        };

    }
}
