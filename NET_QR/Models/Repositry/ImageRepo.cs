using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NET_QR.Data;
using NET_QR.Models;
using NET_QR.Models.Interface;

namespace NET_QR.Models.Repositry
{
    public class ImageRepo :Imagepath
    {
        NET_QRContext _context;

        public ImageRepo(NET_QRContext contxt)
        {
            _context = contxt;

        }

        public void getpath(Imagepath path)
        {
            string constring = @"Data Source=(localdb)/MSSQLLocalDB;Initial Catalog=NET_QR.Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
            
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = $"select imagepathth from Imagespath ";

            SqlCommand cmd = new SqlCommand(query, con);



            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                path.imagepath = dr[0].ToString();
            }
            con.Close();
        }
    }
}
