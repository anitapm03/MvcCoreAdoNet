using MvcCoreAdoNet.Models;
using System.Data.SqlClient;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryHospital
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryHospital() 
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;

        }

        public List<Hospital> GetHospitales()
        {
            string sql = "select * from HOSPITAL";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Hospital> hospitalesList = new List<Hospital>();

            while (this.reader.Read())
            {
                Hospital hospital = new Hospital();
                hospital.IdHospital = 
                    int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["TELEFONO"].ToString();
                hospital.Camas =
                    int.Parse(this.reader["NUM_CAMA"].ToString());

                hospitalesList.Add(hospital);
            }
            this.reader.Close();
            this.cn.Close();

            return hospitalesList;
        }

        public Hospital FindHospitalById(int idhospital)
        {
            string sql = "SELECT * FROM HOSPITAL WHERE HOSPITAL_COD = @IDHOSPITAL";
            SqlParameter pamId = new SqlParameter("@IDHOSPITAL", idhospital);
            this.com.Parameters.Add(pamId);

            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;    
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Read();

            Hospital hospital = new Hospital();
            hospital.IdHospital =
                int.Parse(this.reader["HOSPITAL_COD"].ToString());
            hospital.Nombre = this.reader["NOMBRE"].ToString();
            hospital.Direccion = this.reader["DIRECCION"].ToString();
            hospital.Telefono = this.reader["TELEFONO"].ToString();
            hospital.Camas =
                int.Parse(this.reader["NUM_CAMA"].ToString());

            this.com.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();

            return hospital;
        }

        public void InsertHospital
            (int idhospital, string nombre, string direccion,
            string telefono, int camas)
        {
            string sql = "INSERT INTO HOSPITAL VALUES " +
                "(@ID, @NOMBRE, @DIR, @TELF, @CAMAS)";
            SqlParameter pamid = new SqlParameter("@ID", idhospital);
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            SqlParameter pamdir = new SqlParameter("@DIR", direccion);
            SqlParameter pamtelf = new SqlParameter("@TELF", telefono);
            SqlParameter pamcamas = new SqlParameter("@CAMAS", camas);
            this.com.Parameters.Add(pamid);
            this.com.Parameters.Add(pamnombre);
            this.com.Parameters.Add(pamdir);
            this.com.Parameters.Add(pamtelf);
            this.com.Parameters.Add(pamcamas);

            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int af = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void UpdateHospital
            (int idhospital, string nombre, string direccion,
            string telefono, int camas)
        {
            string sql = "UPDATE HOSPITAL SET NOMBRE = @NOMBRE, DIRECCION = @DIR," +
                "TELEFONO = @TELF, NUM_CAMA = @CAMAS " +
                "WHERE HOSPITAL_COD = @ID";
            //CREAMOS Y AÑADIMOS LOS PARAM, VAMOS A CREARLO 
            //TODO EN UNO, AÑADIR Y CREAR 
            this.com.Parameters.AddWithValue("@ID", idhospital);
            this.com.Parameters.AddWithValue("@NOMBRE", nombre);
            this.com.Parameters.AddWithValue("@DIR", direccion);
            this.com.Parameters.AddWithValue("@TELF", telefono);
            this.com.Parameters.AddWithValue("@CAMAS", camas);
            
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int af = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void DeleteHospital(int idhospital)
        {
            string sql = "DELETE FROM HOSPITAL WHERE HOSPITAL_COD = @ID";
            this.com.Parameters.AddWithValue("@ID", idhospital);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int af = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }
    }
}
