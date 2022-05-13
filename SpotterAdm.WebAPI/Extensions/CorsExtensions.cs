using Microsoft.AspNetCore.Builder;

namespace SpotterAdm.WebAPI.Extensions
{

    public static class CorsExtensions
    {

        public static void UseCorsPolicy(this IApplicationBuilder app)
        {

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials() // allow credentials
            );

        }

    }

}
