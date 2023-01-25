using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace DataTableSample
{
    public class DBLayer
    {
        public DataTable GetBoligAndOwnersByTelefon(string tlf)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligEier"].ConnectionString;
            DataTable dt=new DataTable();
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //den samme sql queryen her som dere allerede har testet i sql manager - her med et parameter, som er telefonnummeret
                SqlCommand cmd = new SqlCommand("select BoligEier.bid,Bolig.adr,Bolig.postnr,BoligEier.eid, Eiere.navn,Eiere.etternavn,Tlf.Tlf FROM BoligEier INNER JOIN Eiere ON Eiere.eid = BoligEier.eid INNER JOIN Tlf ON Eiere.eid = Tlf.eid INNER JOIN Bolig ON Bolig.bid = BoligEier.bid where Tlf.Tlf = @tlf", conn);
                cmd.CommandType = CommandType.Text;

                //params here
                param = new SqlParameter("@tlf", SqlDbType.NChar);
                param.Value = tlf; //variabel som blir sendt inn til metoden. Kommer fra bruker som tastet dette inn i et tekstfelt.
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
               
                reader.Close();
                conn.Close();
            }
            return dt; //hele datasettet returneres. skal da kobles til feks en gridview
        }

        public DataTable GetBoligAndOwnersByMail(string epost)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligEier"].ConnectionString;
            DataTable dt = new DataTable();
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //den samme sql queryen her som dere allerede har testet i sql manager - her med et parameter, som er telefonnummeret
                SqlCommand cmd = new SqlCommand("select BoligEier.bid,Bolig.adr,Bolig.postnr,BoligEier.eid, Eiere.navn,Eiere.etternavn,Eiere.epost,Tlf.Tlf \r\nFROM BoligEier INNER JOIN Eiere \r\nON Eiere.eid = BoligEier.eid INNER JOIN Tlf \r\nON Eiere.eid = Tlf.eid INNER JOIN Bolig \r\nON Bolig.bid = BoligEier.bid \r\nwhere Eiere.epost = @epost", conn);
                cmd.CommandType = CommandType.Text;

                //params here
                param = new SqlParameter("@epost", SqlDbType.NChar);
                param.Value = epost; //variabel som blir sendt inn til metoden. Kommer fra bruker som tastet dette inn i et tekstfelt.
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
            return dt; //hele datasettet returneres. skal da kobles til feks en gridview
        }

        /// <summary>
        /// Returnerer alt fra tabellen boliger. Ikke hensiktsmessig om det er mange boliger.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBoligs()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligEier"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Bolig", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
            return dt;
        }
    }
}