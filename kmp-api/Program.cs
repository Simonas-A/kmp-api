using kmp_api;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                          policy.WithMethods("GET", "POST", "PUT", "DELETE");
						  policy.AllowAnyHeader();
					  });
});

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    //options.AddPolicy("CorsAllowAll",
    //    builder =>
    //    {
    //        builder
    //        .AllowAnyOrigin()
    //        .AllowAnyMethod()
    //        .AllowAnyHeader()
    //        .AllowCredentials();
    //    });

    //options.AddPolicy("CorsAllowSpecific",
    //    p => p.WithHeaders("Content-Type", "Accept", "Auth-Token")
    //        .WithMethods("POST", "PUT", "DELETE")
    //        .SetPreflightMaxAge(new TimeSpan(1728000))
    //        .AllowAnyOrigin()
    //        .AllowCredentials()
    //    );
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ImageService>();
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

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();
