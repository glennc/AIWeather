using Microsoft.Extensions.AI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //This adds an API testing UI and makes it the default when you launch the app.
    //This will allow you to test the endpoints easily when you run, but we also have the .http file if you prefer that.
    app.UseSwaggerUI(c=>
    {
        c.SwaggerEndpoint("/openapi/v1.json", "Weather API");
        c.RoutePrefix="";
    });

    app.MapOpenApi();
}

app.UseHttpsRedirection();

//TASK1: Use a ChatClient to generate a Joke.
app.MapGet("/joke", () =>
{
    return "Implement this method to use AI to generate a joke about the weather.";
})
.WithName("GetWeatherJoke");

//TASK2: Use a ChatClient to generate a description of the weather in the given location.
app.MapGet("/description", (string location) =>
{
    return "Implement this method to use AI to describe the weather at the location specified, this requires tools to allow the AI to find out what the weather is in that location so it can describe it.";
})
.WithName("GetWeatherDescription");

app.Run();
