using AppLogic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IPatientManager, PatientManager>();
builder.Services.AddSingleton<IRHConnector, RHConnectorHttpClient>();
builder.Services.AddSingleton<IEmployeeManager, EmployeeManager>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowUI",
        policy =>
        {
            policy.WithOrigins("https://localhost:7255")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowUI");

app.UseAuthorization();

app.MapControllers();

app.Run();
