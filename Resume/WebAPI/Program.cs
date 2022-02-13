var builder = WebApplication.CreateBuilder(args);
var MyAllowAllOrigins = "_myAllowAllOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowAllOrigins,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseCors(MyAllowAllOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
