
using API;
using API.Endpoints;
using API.Middleware;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceExtensions(builder.Configuration);

builder.Services.AddInterfaceAdaptersExtensions(builder.Configuration);


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.ConfigureEndpoints();

app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

