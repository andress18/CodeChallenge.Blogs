var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
       builder => {
           builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
       });
});
builder.Services.AddHttpClient("gnews", httpClient => { httpClient.BaseAddress = new Uri("https://gnews.io/"); });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
