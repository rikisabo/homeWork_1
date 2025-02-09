using FileService.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using FileService;
using FileService.Interfaces;
namespace תשתית_לניהול_חנות_פיצה_חני_גולדברג.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ActionLogMiddleWare
    {
        string path=@"H:\webApi\חדש\actionLog.txt";
        private readonly RequestDelegate _next;
        IFileService<string> _ifileservice;
        public ActionLogMiddleWare(RequestDelegate next,IFileService<string> ifileservice)
        {
            _next = next;
             _ifileservice=ifileservice;
        }

        public async Task Invoke(HttpContext context)
        {
        context.Request.EnableBuffering();
        using (var requestBody = new StreamReader(context.Request.Body).ReadToEndAsync())
            {
            var request = context.Request;
            context.Request.Body.Position = 0;
            _ifileservice.Write("start",path);
            _ifileservice.Write("Request time: "+DateTime.Now.ToString(),path);
            _ifileservice.Write("httpMethod:" +request.Method.ToString(),path);
            _ifileservice.Write("Body-parameters: "+request.Body.ToString(),path);
            _ifileservice.Write("reqest headers "+request.Headers.ToString(),path);
            await _next(context);
             var task=_next(context);
             _ifileservice.Write("date and hour of the response "+DateTime.Now.ToString(),path);
             _ifileservice.Write("response headers "+context.Response.Headers.ToString(),path);
             _ifileservice.Write("response status code "+context.Response.StatusCode.ToString(),path);
             _ifileservice.Write("                   enddddd\n\n",path);
        // return task;
        }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustom(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ActionLogMiddleWare>();
        }
    }
}
