// Add services to the container.
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using todo_server.Data;
using todo_server.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<TodoListContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoListContext")
        ?? throw new InvalidOperationException("Connection string 'TodoListContext' not found.")));

// Config for Identity
builder.Services
    .AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 5;
    })
    .AddEntityFrameworkStores<TodoListContext>()
    .AddDefaultTokenProviders();

//Config CORS
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Config for Google Authentication
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = "115101565115-qjcf011naddj5c4pt8lo22iivkmulo3s.apps.googleusercontent.com";
        options.ClientSecret = "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";
    });

// Config for Facebook Authentication
builder.Services.AddAuthentication()
    .AddFacebook(options =>
    {
        options.AppId = "892260179364657";
        options.AppSecret = "e18c53a48f67fcb93e1b97721f41ec40";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors();

app.UseRouting();

app.UseAuthentication(); // Enable authentication middleware

app.UseAuthorization();

app.MapControllers();

app.Run();
