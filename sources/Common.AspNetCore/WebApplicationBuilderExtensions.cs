using MadWorldNL.Common.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorldNL.Common.AspNetCore;

public static class WebApplicationBuilderExtensions
{
    public static void AddCommonMadWorldNL(this WebApplicationBuilder app)
    {
        app.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    }
    
    public static string BuildConnectionString(this WebApplicationBuilder builder, string connectionStringName)
    {
        var connectionString = builder.Configuration.GetValue<string>($"DbContext:{connectionStringName}")!;
        var password = builder.Configuration.GetValue<string>("DbContext:Password")!;
        return connectionString.Replace("{password}", password);
    }
}