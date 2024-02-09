using MvcCoreAdoNet.Models;
using System.Data.SqlClient;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryDoctores
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryDoctores()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Doctor> GetDoctores()
        {
            string sql = "SELECT * FROM DOCTOR";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctoresList = new List<Doctor>();

            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());

                doctoresList.Add(doctor);
            }

            this.reader.Close();
            this.cn.Close();
            return doctoresList;
        }

        public List<Doctor> GetDoctoresEspecialidad(string especialidad)
        {
            string sql = "SELECT * FROM DOCTOR WHERE ESPECIALIDAD = @ESP";
            this.com.Parameters.AddWithValue("@ESP", especialidad);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctoresEspecialidad = new List<Doctor>();

            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());

                doctoresEspecialidad.Add(doctor);
            }

            this.reader.Close();
            this.cn.Close();
            return doctoresEspecialidad;
        }
    
        public List<string> GetEspecialidades()
        {
            string sql = "SELECT DISTINCT ESPECIALIDAD FROM DOCTOR";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<string> especialidades = new List<string>();
            while (this.reader.Read())
            {
                string e = this.reader["ESPECIALIDAD"].ToString();
                especialidades.Add(e);
            }
            this.reader.Close();
            this.cn.Close();
            return especialidades;
        }
    
    }
}
