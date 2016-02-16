using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace DAI
{
    
    public class ProductOrder_DAL
    {
        public int UpdateInfoByOrderId(ProductOrderInfo info)
        {
            string sql = "update [ProductOrder] set IsSend=1 where OrderID=@orderId";
            SqlParameter[] ps = new SqlParameter[] { new SqlParameter("@orderId", info.OrderID) };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
    }
        
    public static class SqlHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddRange(ps);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static int ExecuteNonQuery(string sql, CommandType ct, params SqlParameter[] ps)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                if ((ps != null) && (ps.Length > 0))
                {
                    command.Parameters.AddRange(ps);
                }
                command.CommandType = ct;
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddRange(ps);
                connection.Open();
                return command.ExecuteScalar();
            }
        }

        public static DataTable GetList(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                if (ps.Length > 0)
                {
                    adapter.SelectCommand.Parameters.AddRange(ps);
                }
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        }

    public class UserInfo_DAL
    {
        public UserInfo CheckUserInfoByUserNameAndPassword(UserInfo info)
        {
            string sql = "select UserID, FirstName, LastName, UserName, Email, Password, Address, Mobile, HomePhone, WorkPhone, OrderID  from UserInfo  where [UserName]=@UserName and  [Password]=@Password";
            SqlParameter[] ps = new SqlParameter[] { new SqlParameter("@UserName", info.UserName), new SqlParameter("@Password", info.Password) };
            DataTable table = SqlHelper.GetList(sql, ps);
            if ((table != null) && (table.Rows.Count > 0))
            {
                List<UserInfo> list = new List<UserInfo>();
                foreach (DataRow row in table.Rows)
                {
                    list.Add(this.DtataRowToUserInfo(row));
                }
                if (list.Count > 0)
                {
                    return list[0];
                }
            }
            return null;
        }

        private UserInfo DtataRowToUserInfo(DataRow dr)
        {
            return new UserInfo { UserName = (dr["UserName"] != DBNull.Value) ? dr["UserName"].ToString() : string.Empty, Password = (dr["Password"] != DBNull.Value) ? dr["Password"].ToString() : string.Empty, FirstName = (dr["FirstName"] != DBNull.Value) ? dr["FirstName"].ToString() : string.Empty, LastName = (dr["LastName"] != DBNull.Value) ? dr["LastName"].ToString() : string.Empty, Address = (dr["Address"] != DBNull.Value) ? dr["Address"].ToString() : string.Empty, Email = (dr["Email"] != DBNull.Value) ? dr["Email"].ToString() : string.Empty, HomePhone = (dr["HomePhone"] != DBNull.Value) ? dr["HomePhone"].ToString() : string.Empty, Mobile = (dr["Mobile"] != DBNull.Value) ? dr["Mobile"].ToString() : string.Empty, WorkPhone = (dr["WorkPhone"] != DBNull.Value) ? dr["WorkPhone"].ToString() : string.Empty, OrderID = (dr["OrderID"] != DBNull.Value) ? Convert.ToInt32(dr["OrderID"]) : 0, UserID = (dr["UserID"] != DBNull.Value) ? Convert.ToInt32(dr["UserID"]) : 0 };
        }
    }

}

