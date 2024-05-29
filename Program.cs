using Azure.Communication.Email;
using EmailProvider.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()


    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddSingleton<EmailClient>(new EmailClient(Environment.GetEnvironmentVariable("CommunicationServices")));
        services.AddSingleton<IEmailService, EmailService>();
    })
    .Build();

host.Run();
