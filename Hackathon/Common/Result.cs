using System.Collections.Generic;

namespace Hackathon.Common
{
    public class Result
    {
        public StatusCode statusCode { get; set; }
        public bool isSucces { get; set; }
        public Dictionary<string, List<string>> errors { get; set; }

        public Result(bool isSucces,StatusCode statusCode, Dictionary<string, List<string>> errors)
        {
            this.statusCode = statusCode;
            this.isSucces = isSucces;
            this.errors = errors;
        }

        public static Result OK()
        {
            return new Result(true, StatusCode.OK, new Dictionary<string, List<string>>());
        }

        public static Result<T> OK<T>(T data)
        {
            return new Result<T>(data,true, StatusCode.OK, new Dictionary<string, List<string>>());
        }

        public static Result BadRequest()
        {
            return new Result(false, StatusCode.BadRequest, new Dictionary<string, List<string>>());
        }

        public static Result<T> BadRequest<T>(T data = default(T))
        {
            return new Result<T>(data,true, StatusCode.BadRequest, new Dictionary<string, List<string>>());
        }

        public static Result Created()
        {
            return new Result(false, StatusCode.Created, new Dictionary<string, List<string>>());
        }

        public static Result<T> Created<T>(T data)
        {
            return new Result<T>(data, true, StatusCode.Created, new Dictionary<string, List<string>>());
        }

        public static Result NotFound()
        {
            return new Result(false, StatusCode.NotFound, new Dictionary<string, List<string>>());
        }

        public static Result<T> NotFound<T>(T data = default(T))
        {
            return new Result<T>(data, false, StatusCode.NotFound, new Dictionary<string, List<string>>());
        }

        public static Result Conflict()
        {
            return new Result(false, StatusCode.Conflict, new Dictionary<string, List<string>>());
        }

        public static Result<T> Conflict<T>(T data = default(T))
        {
            return new Result<T>(data, false, StatusCode.Conflict, new Dictionary<string, List<string>>());
        }

        public static Result InternalServerError()
        {
            return new Result(false, StatusCode.InternalServerError, new Dictionary<string, List<string>>());
        }

        public static Result<T> InternalServerError<T>(T data = default(T))
        {
            return new Result<T>(data, false, StatusCode.InternalServerError, new Dictionary<string, List<string>>());
        }
    }

    public class Result<T>:Result
    {
        public T data { get; set; }

        public Result(T data, bool isSucces, StatusCode statusCode, Dictionary<string, List<string>> errors) 
            : base(isSucces, statusCode, errors)
        {
            this.data = data;
        }
    }
}
