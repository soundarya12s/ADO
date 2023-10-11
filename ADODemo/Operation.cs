using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODemo
{
    public class Operation
    {
        public static void createcon()
        {
            SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog=master; integrated security=true");
            try
            {
                string query = "create database PersonDetails";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Database created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
            finally
            {
                con.Close();
            }
        }




       public static SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog=PersonDetails; integrated security=true");
        public static bool ReadFromDataBase()
        {
            try
            {
                using (con)
                {
                    Person model = new Person();
                    string query = "Select * from Description";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine("------Data-----");
                        while (reader.Read())
                        {
                            model.Id = Convert.ToInt32(reader["ID"]);
                            model.Id = Convert.ToInt32(reader["Name"]);
                            model.Id = Convert.ToInt32(reader["Salary"]);
                            model.Id = Convert.ToInt32(reader["Address"]);
                            model.Id = Convert.ToInt32(reader["Phone"]);

                            
                            Console.WriteLine("Id : {0}\n Name: {1}\n Salary: {2}\n Address: {3}\n Phone: {4}", model.Id, model.Name, model.Salary, model.Address, model.Phone);

                        }
                        return true;
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Something went wrong" + ex);
            }
            finally
            {
                con.Close();
            }
            return false;

        }

        public static void CreateTable()
        {
            try
            {
                string query = "create table DemoTable (Id bigint identity(1,1) primary key, Name varchar(max), Salary varchar(max), Address varchar(max), Phone varchar(10))";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Created successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong"+ ex);
            }
            finally
            {
                con.Close();
            }
        }

        public static void InsertTable()
        {
            try
            {
                string query = "insert into DemoTable(Name, Salary, Address, Phone) values ('Soundarya', 1234,'chennai', '1234567890');";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        public static void UpdateTable()
        {
            try
            {
                string query = "update DemoTable set Phone=0987654321 where Id=1";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        public static void DeleteTable()
        {
            try
            {
                string query = "delete from Description where Id=3";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex);
            }
            finally
            {
                con.Close();
            }
        }

     
    }
}
