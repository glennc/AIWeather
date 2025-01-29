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
    app.UseSwaggerUI(c=>
    {
        c.SwaggerEndpoint("/openapi/v1.json", "Weather API");
        c.RoutePrefix="";
    });

    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/joke", () =>
{
    return "Implement this method to use AI to generate a joke about the weather.";
})
.WithName("GetWeatherJoke");

app.MapGet("/description", (string location) =>
{
    return "Implement this method to use AI to describe the weather at the location specified, this requires tools to allow the AI to find out what the weather is in that location so it can describe it.";
})
.WithName("GetWeatherDescription");

app.Run();