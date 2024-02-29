using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Сервер запущен");
app.MapGet("/ping", () => "pong");
// реализация обработчика без синтаксического сахара
app.MapGet("/custom", async (HttpContext context) =>
{
    context.Response.StatusCode = StatusCodes.Status202Accepted;
    await context.Response.WriteAsync("go next");
});

app.Map("/http-info", async (HttpContext context) =>
{
   context.Response.StatusCode = StatusCodes.Status200OK;
    Console.WriteLine($"Host: {context.Request.Host}\n");

    using StreamReader sr = new StreamReader(context.Request.Body);
    string bodystring = await sr.ReadToEndAsync();
    Console.WriteLine($"Body {bodystring}");
    await context.Response.WriteAsync($"Body {bodystring}");
});

// post -params
app.MapPost("sugar/post-params", ([FromForm] double a, [FromForm] double b,[FromForm] double c) =>
{
    double polyp = (a+b+c)/2;
    double plosh = Math.Sqrt(polyp*(polyp-a) * (polyp - b) * (polyp - c));
    return $"received params p1 = {a}; p2 = {b}; p3 = {c}; Площадь равна = {plosh}";
}).DisableAntiforgery();
app.Run();
