using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace MimumuToolkit.Extended
{
    public class SqlUtil
    {
        private static DbConnectionStringBuilder? m_connection { get; set; } = null;

        public static void SetConnection(string database, string userId, string password)
        {
            m_connection = new SqlConnectionStringBuilder()
            {
                DataSource = database,
                UserID = userId,
                Password = password,
                TrustServerCertificate = true,
            };
        }

        public static DbConnection? Open()
        {
            if (m_connection == null)
            {
                return null;
            }

            DbConnection result;
            try
            {
                result = new SqlConnection(m_connection.ConnectionString);
                result.Open();
            }
            catch
            {
                return null;
            }

            return result;
        }
    }
}
