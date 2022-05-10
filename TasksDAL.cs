using SemiApprenticeship.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace SemiApprenticeship.DataAccessLayer
{
    public class TasksDAL
    {
        SqlConnection connection;
        SqlCommand cmd;
        public TasksDAL()
        {
            connection = new SqlConnection("Data Source=.;Initial Catalog=TaskUserDb;Integrated Security=True");
        }

        public List<Tasks> GetPendingTasks()
        {
            List<Tasks> tasks = new List<Tasks>();
            cmd = new SqlCommand("PendingRecords", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            connection.Open();
            da.Fill(dt);
            connection.Close();

            foreach(DataRow dr in dt.Rows)
            {
                tasks.Add(new Tasks
                {
                    taskId=Convert.ToInt32(dr["Task_Id"]),
                    description=Convert.ToString(dr["Task_Description"]),
                    dueDate=Convert.ToDateTime(dr["Due_Date"]),
                    requestedBy=Convert.ToString(dr["Requested_By"]),
                    requestedOn=Convert.ToDateTime(dr["Request_On"]),
                    remarks=Convert.ToString(dr["Remarks"]),
                    action=Convert.ToString(dr["Action"])
                });
            }
            return tasks;
        }

         public bool RejectTask(int id)
        {
            cmd = new SqlCommand("Reject", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Task_Id", id);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public bool ApproveTask(int id)
        {
            cmd = new SqlCommand("Approve", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Task_Id", id);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }
}
