using DIPractical;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IOperatorTransient, Dependancy>(a => new Dependancy(Guid.NewGuid()));
builder.Services.AddScoped<IOperatorScope, Dependancy>(a => new Dependancy(Guid.NewGuid()));
builder.Services.AddSingleton<IOperatorSingleton>(a => new Dependancy(Guid.NewGuid()));

var app = builder.Build();

app.MapGet("/", () =>
{
    var servicesTransient = app.Services.GetService<IOperatorTransient>();
    var servicesScope = app.Services.GetService<IOperatorScope>();
    var serviceSingleton = app.Services.GetService<IOperatorSingleton>();
    
    servicesTransient?.Write();
    servicesScope?.Write();
    serviceSingleton?.Write();
    
    return "Hello World";
});

app.Run();