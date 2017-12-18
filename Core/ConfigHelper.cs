using System;
using System.Configuration;
using System.Data.Common;

namespace Core
{
    public static class ConfigHelper
    {
        /// <summary>
        /// Config dosyasindan istenen bir degeri dondurur.
        /// </summary>
        /// <remarks>
        /// Eger dosya bulunamazsa, bos string dondurur.
        /// </remarks>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string ReadConfigAsString(string key)
        {
            string result = string.Empty;
            try
            {
                result = ConfigurationManager.AppSettings[key];
            }
            catch (Exception)
            {
            }

            return result;
        }


        public static string ReadConfigKDV()
        {
            string result = string.Empty;
            try
            {
                string key = "KDV";
                result = ReadConfigAsString(key);
                float temp = float.Parse(key);
            }
            catch (Exception)
            {

                result = "0.08";
            }
            return result;

        }


        /// <summary>
        /// connectionString'i, string olarak dondurur.
        /// </summary>
        /// <remarks>
        /// Hata olmasi durumunda, bos string dondurur.
        /// </remarks>
        /// <param name="connectionStringName">connection string adi. Eger verilmezse, "DefaultConnection" olarak kullanilir.</param>
        public static string ReadConfigConnectionString(string connectionStringName = "DefaultConnection")
        {
            //// <connectionStrings>
            //// <add name="DefaultConnection" connectionString="Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aspnet-ProjectDB.mdf;Initial Catalog=aspnet-ProjectDB;Integrated Security=True" providerName="System.Data.SqlClient" />
            ////  </connectionStrings>

            if (connectionStringName == null)
            {
                connectionStringName = "DefaultConnection";
            }

            string result = string.Empty;
            try
            {
                result = ConfigurationManager.ConnectionStrings[connectionStringName].ToString();
            }
            catch (ApplicationException)
            {
                result = string.Empty;
            }
            return result;
        }


        public static string ReadConfigFromConnectionString(string connectionString, string key)
        {
            var builder = new DbConnectionStringBuilder();
            builder.ConnectionString = connectionString;
            return (string)builder[key];
        }
    }
}
