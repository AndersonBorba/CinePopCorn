using CinePopCorn.Domain.DTOs;
using CinePopCorn.infrastructure.AuxDao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCorn.infrastructure.Loggers
{
    public class LoggerDAO
    {
        private string _connectionString;
        public LoggerDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string AddLog(LoggerDTO logger)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"insert into Logger(Action, Description) values (@Action, @Description);";
                cmd.Parameters.AddWithValue("@Action", logger.Action);
                cmd.Parameters.AddWithValue("@Description", logger.Description);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                return "Erro ao registrar o log!!";
            }
            return "";
        }

        public async Task Logger(LoggerDTO logger)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = AuxDAO.GetUrlApiLog();
                    StringContent sc = new StringContent(JsonConvert.SerializeObject(logger), Encoding.UTF8, "application/json");

                    var r = httpClient.PostAsync(url + "RegiterLogger", sc).Result;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
