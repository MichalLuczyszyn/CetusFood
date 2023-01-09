using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

AddAuthentication(builder);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void AddAuthentication(WebApplicationBuilder webApplicationBuilder)
{
    const string authenticationSection = "Keycloak";
    var authenticationOptions = webApplicationBuilder.Configuration
        .GetSection(authenticationSection)
        .Get<KeycloakAuthenticationOptions>();


    webApplicationBuilder.Services.AddKeycloakAuthentication(authenticationOptions!);
}