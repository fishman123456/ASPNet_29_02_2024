//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics.CodeAnalysis;
//using System.Net;

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//// привязка обработчиков

//// реализация обработчиков с синтаксическим сахаром
//app.MapGet("/", () => "server is running");
//app.MapGet("/ping", () => "pong");

//// WITHOUT SYNTAX SUGAR

//// get-params
//app.MapGet("get-params", async (HttpContext context) =>
//{
//    try
//    {
//        string? getParams = context.Request.QueryString.Value;
//        int a = Convert.ToInt32(context.Request.Query["a"][0]);
//        string? b = context.Request.Query["b"][0];
//        await context.Response.WriteAsync($"received query string: {getParams}\n");
//        await context.Response.WriteAsync($"received a = {a}; b = {b}");
//    } catch (Exception ex)
//    {
//        context.Response.StatusCode = StatusCodes.Status400BadRequest;
//        await context.Response.WriteAsync($"error during reading http params: {ex.Message}");
//    }
//});

//// post-params
//app.MapPost("post-params", async (HttpContext context) =>
//{
//    try
//    {
//        double p1 = Convert.ToDouble(context.Request.Form["p1"][0]);
//        string? p2 = context.Request.Form["p2"][0];
//        await context.Response.WriteAsync($"received p1 = {p1}; p2 = {p2}");
//    } catch (Exception ex)
//    {
//        context.Response.StatusCode = StatusCodes.Status400BadRequest;
//        await context.Response.WriteAsync($"error during reading http params: {ex.Message}");
//    }
//});

//// WITH SYNTAX SUGAR

//// get-params
//app.MapGet("sugar/get-params", (int a, string b) =>
//{
//    return $"received params a = {a}; b = {b};";
//});

//// post-params
//app.MapPost("sugar/post-params", ([FromForm] double p1, [FromForm] string p2) =>
//{
//    return $"received params p1 = {p1}; p2 = {p2};";
//}).DisableAntiforgery();

//// запуск сервера
//app.Run();
