using . in the connection string.

if you want to see the apis comment the following line:

Startup.cs -> Register method->
app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);

for the services to work uncomment the ninject dependancy resolver line or it will throw exception because there won't be a parameterless constructor in the BaseApiController.