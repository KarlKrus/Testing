﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class DAL_Product
    {
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["CnnctSrngUserDB"].ConnectionString);

        public DataSet Select_Prod()
        {
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT PRODID, BRAND, MODEL, PRICE FROM PRODUCT", Con);
            DataSet DS = new DataSet();
            SDA.Fill(DS);
            return DS;
        }

        public DataSet Select_Brand()
        {
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT DISTINCT BRAND FROM PRODUCT", Con);
            DataSet DS = new DataSet();
            SDA.Fill(DS);
            return DS;
        }

        public void Insert_Prod(SqlCommand Cmd)
        {
            Con.Open();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO [PRODUCT] ([BRAND], [MODEL], [PRICE]) VALUES (@BRAND, @MODEL, @PRICE)";
            Cmd.CommandType = CommandType.Text;
            Cmd.ExecuteNonQuery();
        }

        public void Update_Prod(SqlCommand Cmd)
        {
            Con.Open();
            Cmd.Connection = Con;
            Cmd.CommandText = "UPDATE [PRODUCT] SET [BRAND] = @BRAND, [MODEL] = @MODEL, [PRICE] = @PRICE WHERE [PRODID] = @PRODID";
            Cmd.CommandType = CommandType.Text;
            Cmd.ExecuteNonQuery();
        }

        public void Delete_Prod(SqlCommand Cmd)
        {
            Con.Open();
            Cmd.Connection = Con;
            Cmd.CommandText = "DELETE FROM [PRODUCT] WHERE [PRODID] = @PRODID";
            Cmd.CommandType = CommandType.Text;
            Cmd.ExecuteNonQuery();
        }

    }
}
