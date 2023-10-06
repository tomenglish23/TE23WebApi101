
// launchSettings.json:
//    iisExpress            http://localhost:34110, sslPort: 44387
//    http: applicationUrl: http://localhost:5112
//    https:applicationUrl: http://localhost:5112   https://localhost:7076

// https://learn.microsoft.com/en-us/dotnet/api
// /microsoft.aspnetcore.builder.webapplication.createbuilder?view=aspnetcore-7.0
// #microsoft-aspnetcore-builder-webapplication-createbuilder
// (microsoft-aspnetcore-builder-webapplicationoptions)

var builder = WebApplication.CreateBuilder(args);

// Add services to the container (The container is the fully-configured app)
//   WebApplication
//     > Create a Builder(services)
//       > Build to create the configured WebApplication.
//         > Add to the app.
//           > Run the app

#region Builder Services

builder.Services.AddControllers();  // Controller services

#region builder Services for Swagger
                                            // Configuring Swagger/OpenAPI: https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // returns IServiceCollection of Providers:
                                            //    Singletons: DefaultAction        Descriptor        Collection Provider,
                                            //                                 Api Description Group Collection Provider
                                            //    Transient:  EndpointMetadata Api Description                  Provider
builder.Services.AddSwaggerGen();
#endregion

#endregion // Builder Services

#region app

var app = builder.Build();

#region app UseSwagger
// HTTP request pipeline configuration:
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#endregion

app.UseHttpsRedirection();

#region Authorization
// When authorizing endpoint-routed resources, call in order: UseRouting, UseAuthorization, UseEndpoints.
app.UseAuthorization();
#endregion

app.MapControllers();                // App Controllers

app.Run();

#endregion // app