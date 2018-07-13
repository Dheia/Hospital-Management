using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace HospitalMgmt
{
    class Database
    {
        MySqlConnection conn;
        public Database()
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = "server=127.0.0.1;uid=root;database=Hospital;";
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public string InsertDoc(String id, String name, String specialization)
        {
            try
            {
                MySqlCommand command = this.conn.CreateCommand();
                command.CommandText = "INSERT INTO doctor VALUES (" + id + ",\"" + name + "\",\"" + specialization + "\");";
                Console.WriteLine(command.CommandText);
                this.conn.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                return "Choose a different ID";
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return "Successfully Added";
        }

        public string InsertPatient(String id, String name, String disease, String docid)
        {
            try
            {
                MySqlCommand command = this.conn.CreateCommand();
                command.CommandText = "INSERT INTO patient VALUES (" + id + ",'" + name
                    + "','" + disease + "'," + id + ");";
                this.conn.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                return "Choose a different ID";
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return "Successfully Added";
        }

        public string getDocId(String name)
        {
            String res;
            try
            {
                MySqlCommand command = this.conn.CreateCommand();
                command.CommandText = "SELECT id FROM doctor WHERE name = '" + name + "';";
                this.conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                res = reader.GetString(0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return res;
        }

        public string getDocName(String id)
        {
            String res;
            try
            {
                MySqlCommand command = this.conn.CreateCommand();
                command.CommandText = "SELECT name FROM doctor WHERE id = " + id + ";";
                this.conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                res = reader.GetString(0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return res;
        }

        public string getDocSpec(String id)
        {
            String res;
            try
            {
                MySqlCommand command = this.conn.CreateCommand();
                command.CommandText = "SELECT specialization FROM doctor WHERE id = " + id + ";";
                this.conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                res = reader.GetString(0);
            }
            catch
            {
                throw new Exception("ID does not exist");
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return res;
        }

        public string getPatientName(String id)
        {
            String res;
            try
            {
                MySqlCommand command = this.conn.CreateCommand();
                command.CommandText = "SELECT patName FROM patient WHERE patId = " + id + ";";
                this.conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                res = reader.GetString(0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return res;
        }

        public string getPatientDisease(String id)
        {
            String res;
            try
            {
                MySqlCommand command = this.conn.CreateCommand();
                command.CommandText = "SELECT disease FROM patient WHERE patId = " + id + ";";
                this.conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                res = reader.GetString(0);
            }
            catch
            {
                throw new Exception("ID does not exist");
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return res;
        }

        public List<String> getDocs()
        {
            List<String> docs = new List<String>();
            try
            {
                MySqlCommand command = this.conn.CreateCommand();
                command.CommandText = "SELECT distinct name FROM doctor;";
                this.conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    docs.Add(reader.GetString(0));
            }
            catch
            {
                throw new Exception("ID does not exist");
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return docs;
        }

        public List<String> getDiseases()
        {
            List<String> diseases = new List<String>();
            try
            {
                MySqlCommand command = this.conn.CreateCommand();
                command.CommandText = "select distinct disease from patient;";
                this.conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    diseases.Add(reader.GetString(0));
            }
            catch
            {
                throw new Exception("Some error");
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return diseases;
        }

        public List<String> getPatients(String docname)
        {
            List<String> patients = new List<String>();
            try
            {
                MySqlCommand command = this.conn.CreateCommand();
                command.CommandText = "select patName from doctor, patient WHERE id = docid AND name = '" + docname + "' ;";
                this.conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    patients.Add(reader.GetString(0));
            }
            catch
            {
                throw new Exception("Some error");
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return patients;
        }

        public List<String> getPatientsWithDisease(String disease)
        {
            List<String> patients = new List<String>();
            try
            {
                MySqlCommand command = this.conn.CreateCommand();
                command.CommandText = "select patName from patient where disease = '" + disease + "'";
                this.conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    patients.Add(reader.GetString(0));
            }
            catch
            {
                throw new Exception("Some error");
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return patients;
        }

        public string getDisease(String name) //Name of patient
        {
            String disease;
            try
            {
                MySqlCommand command = this.conn.CreateCommand();
                command.CommandText = "SELECT disease FROM patient WHERE patName = '" + name + "';";
                this.conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                disease = reader.GetString(0);
            }
            catch
            {
                throw new Exception("Patient with such name does not exist");
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return disease;
        }
    }
}
