using MessageReceiver.Listeners;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<MessageListener>();

var app = builder.Build();
app.Run();
