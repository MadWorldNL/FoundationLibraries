using MadWorldNL.Common.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorldNL.Common.AspNetCore;

public static class WebApplicationBuilderExtensions
{
    public static void AddCommonMadWorldNL(this WebApplicationBuilder app)
    {
        app.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    }
}