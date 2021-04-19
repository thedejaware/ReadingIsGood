﻿using Microsoft.AspNetCore.Http;
using RIG.API.Exceptions;
using RIG.API.Model;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RIG.API.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (ex)
                {
                    case BusinessException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var errorResponse = new ResponseModel
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                    StatusCode = response.StatusCode
                };

                var errorJson = JsonSerializer.Serialize(errorResponse);

                await response.WriteAsync(errorJson);
                throw;
            }
        }
    }
}
