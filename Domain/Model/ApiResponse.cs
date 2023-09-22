using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ApiResponse<T>
    {
        public T Value { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public static ApiResponse<T> Fail(string errorMessage)
        {
            return new ApiResponse<T> { Succeeded = false, Message = errorMessage };
        }

        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T> { Succeeded = true, Value = data };
        }
    }

    public class Result
    {
        public int ErrorCode { get; set; }
        public bool ErrorStatus { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ResultError
    {
        public Result result(int messageCode, bool messageStatus, string messageString)
        {
            Result result = new Result();
            result.ErrorCode = messageCode;
            result.ErrorStatus = messageStatus;
            result.ErrorMessage = messageString;
            return result;
        }
    }
    public class ResultUpdate
    {
        public string Action { get; set; }
        public Movie Value { get; set; }
    }

}
