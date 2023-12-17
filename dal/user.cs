using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using bo;
namespace dal
{
   public class user
    {
        bo.user bo = new bo.user();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        public DataSet getstate()
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_getstate", con);
            DataSet ds = new DataSet();
            da.Fill(ds,"sname");
            return ds;
        }

        public DataSet getcity(string state)
        {
            SqlCommand cmd = new SqlCommand("proc_getcity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", state);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "cname");
            return ds;
        }
        public int adduser(bo.user v)
        {
            SqlCommand cmd = new SqlCommand("proc_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", v.uid);
            cmd.Parameters.AddWithValue("@b", v.uname);
            cmd.Parameters.AddWithValue("@c", v.password);
            cmd.Parameters.AddWithValue("@d", v.gender);
            cmd.Parameters.AddWithValue("@e", v.hobbies);
            cmd.Parameters.AddWithValue("@f", v.state);
            cmd.Parameters.AddWithValue("@g", v.city);
            cmd.Parameters.AddWithValue("@h", v.phno);
            cmd.Parameters.AddWithValue("@i", v.email);
            cmd.Parameters.AddWithValue("@j", v.address);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
         }
       public int Delete(bo.user v)
        {
            SqlCommand cmd = new SqlCommand("proc_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", v.uid);
            con.Open();
            int i=cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataSet GetData()
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_getdata", con);
            DataSet ds = new DataSet();
            da.Fill(ds,"user");
            return ds;
        }
        public int Update(bo.user v)
        {
            SqlCommand cmd = new SqlCommand("proc_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", v.uid);
            cmd.Parameters.AddWithValue("@b", v.uname);
            cmd.Parameters.AddWithValue("@c", v.password);
            cmd.Parameters.AddWithValue("@d", v.gender);
            cmd.Parameters.AddWithValue("@e", v.hobbies);
            cmd.Parameters.AddWithValue("@f", v.state);
            cmd.Parameters.AddWithValue("@g", v.city);
            cmd.Parameters.AddWithValue("@h", v.phno);
            cmd.Parameters.AddWithValue("@i", v.email);
            cmd.Parameters.AddWithValue("@j", v.address);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
