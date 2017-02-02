using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using SimpleCrud.Models;
using System.Data.SqlClient;

namespace SimpleCrud.Repository
{
    public class PatientRepository
    {
        //connectionString - get this from config
        string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=PatientDb;Integrated Security=True";

       
        public List<Patient> GetAllRecords()
        {
            //SELECT
            string selectSql = "SELECT * FROM Patients";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var records = connection.Query<Patient>(selectSql);

                return records.ToList();
            }  
        }      

        public bool Update(Patient patient)
        {
            //UPDATE
            string updateSql = "UPDATE Patients SET PatientName=@PatientName,Height=@Height,DOB=@DOB WHERE Id=@Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Execute(updateSql, new { patient.PatientName,  patient.Height, patient.DOB, patient.Id }) > 0;
            }  
        }

        public int Insert(Patient patient)
        {
            //INSERT
            string insertSql = "INSERT INTO Patients(PatientName,Height,DOB) Values(@PatientName,@Height,@DOB);SELECT CAST(SCOPE_IDENTITY() as int)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<int>(insertSql, new {  patient.PatientName,  patient.Height, patient.DOB }).Single();
            }  
        }
       

        public bool Delete(int id)
        {
            //DELETE
            string deleteSql = "DELETE FROM Patients WHERE Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Execute(deleteSql, new { id }) > 0;
            }  
        }

    }
}