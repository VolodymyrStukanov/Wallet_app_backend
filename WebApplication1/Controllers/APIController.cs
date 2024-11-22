﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebApplication1.Controllers
{
    public class APIController : ControllerBase
    {
        protected const string ConstJsonContentType = "application/json; charset=utf-8";

        protected readonly JsonSerializerOptions JsonSerializerOptions;
        public APIController()
        {
            JsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        }

        protected ContentResult BuildSuccessResult(object? data, string? message, int httpCode = 200)
        {
            var dataJSON = JsonSerializer.Serialize(data, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return Content("{" +
                           $"    \"code\":{httpCode}," +
                           $"    \"message\":\"Success\"," +
                           $"    \"data\":{dataJSON ?? "null"}" +
                           "}", ConstJsonContentType);

        }

        protected ContentResult BuildErrorResult(string? message, int httpCode)
        {
            Response.StatusCode = httpCode;
            return Content("{" +
                           $"    \"code\":{httpCode}," +
                           $"    \"message\":\"{message}\"" +
                           "}", ConstJsonContentType);
        }
    }
}
