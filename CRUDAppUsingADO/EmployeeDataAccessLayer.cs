using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CRUDAppUsingADO.Models;

namespace CRUDAppUsingADO
{
    public class EmployeeDataAccessLayer
    {
        private string cs = ConnectionString.Dbcs;

        public string Cs
        {
            get => cs;
            set => cs = value;
        }

        public List<Employees> GetAllEmployees()
        {
            List<Employees> employees = new List<Employees>();
            using (SqlConnection con = new SqlConnection(Cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, Name, Gender, Age, Designation, City FROM Employees ORDER BY Id", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employees emp = new Employees
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString() ?? "",
                        Gender = reader["Gender"].ToString() ?? "",
                        Age = Convert.ToInt32(reader["Age"]),
                        Designation = reader["Designation"].ToString() ?? "",
                        City = reader["City"].ToString() ?? ""
                    };
                    employees.Add(emp);
                }
            }
            return employees;
        }


        public Employees getEmployeesById(int? id)
        {
            Employees emp = new Employees();
            using (SqlConnection con = new SqlConnection(Cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Employees where id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.City = reader["City"].ToString() ?? "";

                }
            }
            return emp;
        }

        public void AddEmployee(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Employees (name, gender, age, designation, city) VALUES (@name, @gender, @age, @designation, @city)", con);
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@designation", emp.Designation);
                cmd.Parameters.AddWithValue("@city", emp.City);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void UpdateEmployeeById(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Employees set name = @name, gender = @gender, age = @age, designation = @designation, city = @city where id = @Id", con);
                cmd.Parameters.AddWithValue("@id", emp.Id);
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@designation", emp.Designation);
                cmd.Parameters.AddWithValue("@city", emp.City);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteRecord(int? i)
        {
            Employees employees = new Employees();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Delete from Employees where id = @Id", con);
                cmd.Parameters.AddWithValue("@id", i);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}
