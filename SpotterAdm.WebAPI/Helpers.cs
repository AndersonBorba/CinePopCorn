using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotterAdm.WebAPI
{
    public static class Helpers
    {
        public static IConfiguration Configuration { get; set; }

        private static string GetValue(string pChave)
        {
            var url = Configuration.GetValue<string>(pChave);

            if (url.Contains("localhost"))
                url = url.Replace("https", "http");

            return url;
        }

        public static string GetConnectionString(string pChave)
        {
            string connection = Configuration.GetConnectionString(pChave);
            return connection;
        }

        public static string Ambiente => GetValue("Ambiente");
        public static string ConnectionString => GetValue("Ambiente");

    }
}
