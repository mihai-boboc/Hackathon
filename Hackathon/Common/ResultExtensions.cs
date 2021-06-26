using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Common
{
    public static class ResultExtensions
    {
        public static Result AddErrors(this Result result,string key, params string[] errors)
        {
            result.errors.Add(key, new List<string>());
            foreach (var error in errors)
            {
                result.errors[key].Add(error);
            }

            return result;
        }

        public static Result AddErrors(this Result result, Dictionary<string,List<string>> errors)
        {
            foreach(var key in errors.Keys)
            {
                if(!errors.ContainsKey(key))
                    result.errors.Add(key, new List<string>());

                foreach (var error in errors[key])
                {
                    result.errors[key].Add(error);
                }
            }
            return result;
        }

        public static Result<T> AddErrors<T>(this Result<T> result, string key, params string[] errors)
        {
            result.errors.Add(key, new List<string>());
            foreach (var error in errors)
            {
                result.errors[key].Add(error);
            }

            return result;
        }

        public static Result<T> AddErrors<T>(this Result<T> result, Dictionary<string, List<string>> errors)
        {
            foreach (var key in errors.Keys)
            {
                if (!result.errors.ContainsKey(key))
                    result.errors.Add(key, new List<string>());

                foreach (var error in errors[key])
                {
                    result.errors[key].Add(error);
                }
            }
            return result;
        }

        public static ObjectResult ToActionResult<T>(this Result<T> result)
        {
            return new ObjectResult(result) {
                StatusCode = (int)result.statusCode,
            };
        }
    }
}
