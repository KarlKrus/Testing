﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace PresentationLayer
{
    /// <summary>
    /// Summary description for FilteredBrand
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class FilteredBrand : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet Select_ProdByBrand(string BRAND)
        {
            Product Prod = new Product();
            SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["CnnctSrngUserDB"].ConnectionString);
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT PRODID, BRAND, MODEL, PRICE FROM PRODUCT WHERE BRAND=@BRAND", Con);
            SDA.SelectCommand.Parameters.AddWithValue("@BRAND", BRAND);
            DataSet DS = new DataSet();
            SDA.Fill(DS);
            return DS;
        }
    }
}
