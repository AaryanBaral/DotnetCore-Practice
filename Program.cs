String MyAllowedOrigins = "_myAllowSpecificOrigins";


// Cors Configuration
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(option=>{
    option.AddPolicy(name:MyAllowedOrigins, builder=>{
        builder.WithOrigins("http://localhost:3000","*");
    });
})

;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Cors implementation
app.UseCors(MyAllowedOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
