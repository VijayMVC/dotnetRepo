using DvdLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models;
using System.Data.SqlClient;
using System.Data;

namespace DvdLibrary.Data.ADO
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void AddDvd(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("AddDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DvdId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();

                dvd.DvdId = (int)param.Value;
            }
        }

        public void DeleteDvd(int dvdId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("DeleteDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdID", dvdId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void EditDvd(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("EditDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdID", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Dvd> GetAllDvds()
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("DvdsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);

                    }
                }
                cn.Close();
            }
            return dvds;


        }

        public Dvd GetDvd(int dvdId)
        {
            Dvd dvd = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("GetDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    if (dr.Read())
                    {
                        dvd = new Dvd();

                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();

                        if (dr["Director"] != DBNull.Value)
                        {
                            dvd.Director = dr["Director"].ToString();
                        }

                        if (dr["ReleaseYear"] != DBNull.Value)
                        {
                            dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        }

                        if (dr["Rating"] != DBNull.Value)
                        {
                            dvd.Rating = dr["Rating"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }
                    }
                }
                cn.Close();
            }
            return dvd;
        }

        public List<Dvd> GetDvdsByTitle(string dvdTitle)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("GetDvdsByTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", dvdTitle);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);

                    }
                }
                cn.Close();
            }
            return dvds;
        }

        public List<Dvd> GetDvdsByDate(int year)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("GetDvdsByDate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ReleaseYear", year);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);

                    }
                }
                cn.Close();
            }
            return dvds;
        }

        public List<Dvd> GetDvdsByDirector(string directorName)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("GetDvdsByDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Director", directorName);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);

                    }
                }
                cn.Close();
            }
            return dvds;
        }

        public List<Dvd> GetDvdsByRating(string rating)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("GetDvdsByRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Rating", rating);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
                cn.Close();
            }
            return dvds;
        }
    }
}
