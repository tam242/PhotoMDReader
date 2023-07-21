using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace PhotoOrganizer
{
    class DbAccess
    {
        public static List<Photo> GetPhotos()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PhotoOrgDB")))
            {
                var output = connection.Query<Photo>("select * from Photos").ToList();
                return output;
            }
        }

        public static void InsertPhoto(Photo photo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PhotoOrgDB")))
            {
                connection.Execute("dbo.InsertPhotoData @path, @location, @dateTaken, @people, @imageName", photo);
            }
        }

        public static DataTable PullData()
        {
            DataTable dataTable = new DataTable();
            string connString = Helper.CnnVal("PhotoOrgDB");
            string query = "select id, path, location, dateTaken from Photos";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
            return dataTable;
        }
    }
}
