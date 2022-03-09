using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.models;
using Microsoft.Data.SqlClient;
using Microsoft.Data;

namespace DataAccessLayer
{
    public class EmployeeDataAccessDb
    {
        private dbConnection db = new dbConnection();


        public Employees GetEmployeesById(int id)
        {


            string query = "select*from employees where Id="+id+"";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = db.Cnn;
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            
                Employees emp = new Employees();
                emp.Id = (int)reader["id"];
                emp.Name = reader["Name"].ToString();
                emp.Salary = reader["Salary"].ToString();
                emp.mobile = reader["mobile"].ToString();
                
            db.Cnn.Close();
            return emp;




        }


        public List<Employees> GetEmployees()
        {


            string query = "select*from employees";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = db.Cnn;
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Employees> employees = new List<Employees>();
            while (reader.Read())
            {
                Employees emp = new Employees();
                emp.Id = (int)reader["id"];
                emp.Name = reader["Name"].ToString();
                emp.Salary = reader["Salary"].ToString();
                emp.mobile = reader["mobile"].ToString();
                employees.Add(emp);
            }
            db.Cnn.Close();
            return employees;




        }

        public bool CreateEmployee(Employees employees)
        {
            string query = "insert into Employees values('" + employees.Name + "','"
                + employees.Salary + "','" + employees.mobile + "')";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);

            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }

        public bool DeleteEmployee(int id)
        {
            string query = "delete from Employees where id ="+id+"";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);

            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);

        }


        public bool UpdateEmployee(Employees employees)
        {
            string query = "update Employees set Name=" + employees.Name +  " , Salary=" + employees.Salary + " ,mobile="
                + employees.mobile + " where Id =" + employees.Id + "";
               

            SqlCommand cmd = new SqlCommand(query, db.Cnn);

            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }

    }



    }


