using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web_CRUD_Demo.Models {
  public class Model_EmployeeNumber {
    public string strConnectionString = "Data Source=(local);Initial Catalog=AdventureWorksDW2017;Integrated Security=false;User ID=Andy;Password=8885;";

    public int InsertEmployeeNumber(int number = 0, string name = "") {
      var effected_num = 0;
      var objConnection = new SqlConnection(strConnectionString);
      var objCommand = new SqlCommand() {
        CommandText = @"
          INSERT INTO EmployeeNumber (
        	  Number
        	  ,Name
          ) VALUES (
        	  @Number
        	  ,@Name
          )
        "
,
        CommandTimeout = 60
,
        CommandType = CommandType.Text
,
        Connection = objConnection
      };
      objCommand.Parameters.Add(new SqlParameter("@Number", number));
      objCommand.Parameters.Add(new SqlParameter("@Name", name));
      objConnection.Open();
      effected_num = objCommand.ExecuteNonQuery();
      objConnection.Close();
      objConnection.Dispose();
      objCommand.Dispose();
      return effected_num;
    }

    public DataTable GetEmployeeNumber(int number = 0) {
      var dtEmployeeNumber = new DataTable();
      var objConnection = new SqlConnection(strConnectionString);
      var objCommand = new SqlCommand() {
        CommandText = @"
          SELECT *
          FROM EmployeeNumber
          WHERE 1=1
          AND (
            @Number = 0
            OR
            Number = @Number
          )
        "
        ,
        CommandTimeout = 60
        ,
        CommandType = CommandType.Text
        ,
        Connection = objConnection
      };
      objCommand.Parameters.Clear();
      objCommand.Parameters.Add(new SqlParameter("@Number", number));
      objConnection.Open();
      dtEmployeeNumber.Load(objCommand.ExecuteReader());
      objConnection.Close();
      objConnection.Dispose();
      objCommand.Dispose();
      return dtEmployeeNumber;
    }

    public int UpdateEmployeeNumber(int number = 0, string name = "") {
      var effected_num = 0;
      var objConnection = new SqlConnection(strConnectionString);
      var objCommand = new SqlCommand() {
        CommandText = @"
          UPDATE EmployeeNumber
          SET Name = @Name
          WHERE 1=1
          AND Number = @Number
        "
,
        CommandTimeout = 60
,
        CommandType = CommandType.Text
,
        Connection = objConnection
      };
      objCommand.Parameters.Clear();
      objCommand.Parameters.Add(new SqlParameter("@Name", name));
      objCommand.Parameters.Add(new SqlParameter("@Number", number));
      objConnection.Open();
      effected_num = objCommand.ExecuteNonQuery();
      objConnection.Close();
      objConnection.Dispose();
      objCommand.Dispose();
      return effected_num;
    }

    public int DeteleEmployeeNumber(int number = 0) {
      var effected_num = 0;
      var objConnection = new SqlConnection(strConnectionString);
      var objCommand = new SqlCommand() {
        CommandText = @"
          DELETE FROM EmployeeNumber
          WHERE 1=1
          AND Number = @Number
        "
,
        CommandTimeout = 60
,
        CommandType = CommandType.Text
,
        Connection = objConnection
      };
      objCommand.Parameters.Clear();
      objCommand.Parameters.Add(new SqlParameter("@Number", number));
      objConnection.Open();
      effected_num = objCommand.ExecuteNonQuery();
      objConnection.Close();
      objConnection.Dispose();
      objCommand.Dispose();
      return effected_num;
    }
  }
}