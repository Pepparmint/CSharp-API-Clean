using API.Auth;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanApiTestsOnSwagger", Version = "v1" });
    c.OperationFilter<AuthorizeCheckOperationFilter>();
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{   
    options.Authority = "https://localhost:7230";
    // Configure JWT Bearer Authentication
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Specify token validation parameters (issuer, audience, etc.)
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        // ValidateAudience = true, // Set to true to validate the "audience" claim
        // ValidAudience = "your-api-resource", // Specify the expected audience value
    };
    // Handle events like OnTokenValidated, OnAuthenticationFailed, etc.
    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            // Your logic when the token is successfully validated
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            // Your logic when authentication fails
            return Task.CompletedTask;
        },
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sheesh v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
