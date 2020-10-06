using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SSIDocumentControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace SSIDocumentControl.Repositories.System
{
    public class SystemRepository : ISystemRepository
    {
        private readonly DocumentContext _documentContext;
      //  static HttpClient client = new HttpClient();
        public SystemRepository(DocumentContext documentContext)
        {
            _documentContext = documentContext;
        }

        public async Task LogSignIn(string url, int userId)
        {
            try
            {
                var log = JsonConvert.SerializeObject(new
                {
                    DomainName = "docs.supreme.int",
                    Route = url != null ? url : "/",
                    UserId = userId
                });
                using (var stringContent = new StringContent(log, Encoding.UTF8, "application/json"))
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri("http://rentapi.supreme.int/");
                        var response = await client.PostAsync("api/System/LogSignIn", stringContent);
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(result);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                }
            }

            catch (Exception ex)
            {

                throw;
            }
        }

        public string GetUploadPath()
        {
            var flag = new SqlParameter("@SysFlagValue", "DocControlLocation");
            string path = "";
            var conn = _documentContext.Database.GetDbConnection();
            try
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    string query = "exec sp_Sys_GetSysFlagValue @SysFlagValue";
                    command.Parameters.Add(flag);
                    command.CommandText = query;
                    DbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        path = reader["SysFlagValue"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
                
            }
            return path;
        }
    }
}
