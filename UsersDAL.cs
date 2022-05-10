using SemiApprenticeship.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SemiApprenticeship.DataAccessLayer
{
    public class UsersDAL
    {
        SqlConnection connection;
        SqlCommand cmd;
        public UsersDAL()
        {
            connection = new SqlConnection("Data Source=.;Initial Catalog=TaskUserDb;Integrated Security=True");
        }

        public List<Users> ActiveUsers()
        {
            List<Users> users = new List<Users>();
            cmd = new SqlCommand("activeUsers", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connection.Open();
            da.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                users.Add(new Users
                {
                    UserId = Convert.ToInt32(dr["User_Id"]),
                    UserFullName = Convert.ToString(dr["User_FullName"]),
                    LoginName = Convert.ToString(dr["Login_Name"]),
                    CreatedBy = Convert.ToString(dr["Created_By"]),
                    CreateOn = Convert.ToDateTime(dr["Created_On"]),
                    Remarks = Convert.ToString(dr["Remarks"])
                });
            }
            return users;
        }

        public bool AddUsers(Users users)
        {
            Users user = new Users();
            cmd = new SqlCommand("insertUsers", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User_FullName", users.UserFullName);
            cmd.Parameters.AddWithValue("@Login_Name", users.LoginName);
            cmd.Parameters.AddWithValue("@Created_By", users.CreatedBy);
            cmd.Parameters.AddWithValue("@Remarks", users.Remarks);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool EditUsers(Users users)
        {
            Users user = new Users();
            cmd = new SqlCommand("updateUsers", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User_Id", users.UserId);
            cmd.Parameters.AddWithValue("@User_FullName", users.UserFullName);
            cmd.Parameters.AddWithValue("@Login_Name", users.LoginName);
            cmd.Parameters.AddWithValue("@Remarks", users.Remarks);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool DeleteUsers(int id)
        {
            cmd = new SqlCommand("deleteUsers",connection);
            cmd.Parameters.AddWithValue("@User_Id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }
}
