using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using System.Configuration;
using ClientENns;
using BookingENns;

namespace ClientCADNS{
    public class ClientCAD {

      private string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString ();
      private ClientEN client;
      private SqlConnection c;

      public ClientCAD(){
        c = new SqlConnection(s);
      }




      public DataSet getAllClients(){
        try{
          DataSet bdvirtual = new DataSet();
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_User", c);
          sql.Fill(bdvirtual,"user");
          return bdvirtual;
        }finally{
          c.Close();
        }
      }

      public ClientEN getClient(String email){
            ClientEN aux = null;
            try {
                DataSet bdvirtual = new DataSet();
                SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_User WHERE email='"+email+"'", c);
                sql.Fill(bdvirtual,"user");
                DataTable t = new DataTable();
                t = bdvirtual.Tables["user"];
                DataRow dr = t.Rows[0];

                //int[] date = new int[3];
                String birthDate = dr[9].ToString();
                String dLIss = dr[11].ToString();  // Añadidos datos de carnet
                String dLExp = dr[12].ToString();
                /*int j = 0;
                for (int i = 0; i < birthDate.Length; i++)
                {
                    String s = "";
                    while (birthDate[i] != '-')
                    {
                        s += birthDate[i];
                    }
                    date[j] = int.Parse(s);
                    j++;
                }
                Date bd = new Date(date[0], date[1], date[2]);*/

                int dayB = Int32.Parse(birthDate.Substring(0, 2));
                int monthB = Int32.Parse(birthDate.Substring(3, 2));
                int yearB = Int32.Parse(birthDate.Substring(6, 4));
                Date bd = new Date(dayB, monthB, yearB);

                int dayI = Int32.Parse(dLIss.Substring(0, 2));   // Añadidos datos de carnet
                int monthI = Int32.Parse(dLIss.Substring(3, 2));
                int yearI = Int32.Parse(dLIss.Substring(6, 4));
                Date Iss = new Date(dayI, monthI, yearI);

                int dayE = Int32.Parse(dLExp.Substring(0, 2));   // Añadidos datos de carnet
                int monthE = Int32.Parse(dLExp.Substring(3, 2));
                int yearE = Int32.Parse(dLExp.Substring(6, 4));
                Date Exp = new Date(dayE, monthE, yearE);

                aux = new ClientEN(dr[0].ToString(), dr[1].ToString(), (bool)dr[2], dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), (int)dr[6], dr[7].ToString(), dr[8].ToString(), bd, (bool)dr[10], Iss, Exp);  // Añadidos datos de carnet
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not find a User for this Email-Adress");
            }
            finally {
              c.Close();
            }
            return aux;
      }


      public bool updateClient(ClientEN cl){
        try{
          DataSet bdvirtual = new DataSet();
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_User WHERE email='"+cl.Email+"'", c);
          sql.Fill(bdvirtual,"user");
          DataTable t = new DataTable();
          t = bdvirtual.Tables["user"];
          DataRow nuevafila = t.Rows[0];
          nuevafila[0] = cl.Email;
          nuevafila[1] = cl.Pass;
          nuevafila[2] = cl.Premium;
          nuevafila[3] = cl.DNI;
          nuevafila[4] = cl.Name;
          nuevafila[5] = cl.Surname;
          nuevafila[6] = cl.Phone;
          nuevafila[7] = cl.Address;
          nuevafila[8] = cl.City;
          nuevafila[9] = cl.BirthDate;
          nuevafila[10] = cl.DrivingLicence;
          nuevafila[11] = cl.DLIss;        // Añadidos datos de carnet
          nuevafila[12] = cl.DLExp;
          t.Rows.Add(nuevafila);
          SqlCommandBuilder cbuilder = new SqlCommandBuilder(sql);
          sql.Update(bdvirtual, "user");
          return true;
        }catch (Exception e) {
            return false;
        }finally{
          c.Close();
        }
      }

      public void deleteClient(String email){
        try{
          DataSet bdvirtual = new DataSet();
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_User WHERE email='"+email+"'", c);
          sql.Fill(bdvirtual,"user");
          DataTable t = new DataTable();
          t = bdvirtual.Tables["user"];
          t.Rows[0].Delete();
          SqlCommandBuilder cbuilder = new SqlCommandBuilder(sql);
          sql.Update(bdvirtual, "user");
        }finally{
          c.Close();
        }
      }

        public bool insertCliente(ClientEN cl)
        {
            try {
                /*DataSet dataSet = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM T_User", c);
                dataAdapter.Fill(dataSet,"user");
                DataTable t = new DataTable();
                t = dataSet.Tables["user"];
                DataRow nuevafila = t.NewRow();
                nuevafila[0] = cl.Email;
                nuevafila[1] = cl.Pass;
                nuevafila[2] = cl.Premium;
                nuevafila[3] = cl.DNI;
                nuevafila[4] = cl.Name;
                nuevafila[5] = cl.Surname;
                nuevafila[6] = cl.Phone;
                nuevafila[7] = cl.Address;
                nuevafila[8] = cl.City;

                DateTime birth = new DateTime(cl.BirthDate.GetYear(), cl.BirthDate.GetMonth(), cl.BirthDate.GetDay());
                nuevafila[9] = birth;

                nuevafila[10] = cl.DrivingLicence;
                t.Rows.Add(nuevafila);
                SqlCommandBuilder cbuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataSet, "user"); */

                DataTable dataTable = new DataTable ();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM T_User", c);
                dataAdapter.Fill(dataTable);
                DataRow nuevafila = dataTable.NewRow();
                nuevafila[0] = cl.Email;
                nuevafila[1] = cl.Pass;
                nuevafila[2] = cl.Premium;
                nuevafila[3] = cl.DNI;
                nuevafila[4] = cl.Name;
                nuevafila[5] = cl.Surname;
                nuevafila[6] = cl.Phone;
                nuevafila[7] = cl.Address;
                nuevafila[8] = cl.City;

                DateTime birth = new DateTime(cl.BirthDate.GetYear(), cl.BirthDate.GetMonth(), cl.BirthDate.GetDay());
                nuevafila[9] = birth;

                nuevafila[10] = cl.DrivingLicence;
                dataTable.Rows.Add(nuevafila);

                DateTime Iss = new DateTime(cl.DLIss.GetYear(), cl.DLIss.GetMonth(), cl.DLIss.GetDay()); // Añadidos datos de carnet
                nuevafila[11] = ISs;


                DateTime Exp = new DateTime(cl.DLExp.GetYear(), cl.DLExp.GetMonth(), cl.DLExp.GetDay()); // Añadidos datos de carnet
                nuevafila[12] = Exp;

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update((DataTable)dataTable);

                return true;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }finally{
              c.Close();
            }
          }
            /*try
            {
                c.Open();
                SqlCommand sql = new SqlCommand("INSERT INTO T_User VALUES (" + cl.Email + ", '" + cl.Pass + "', " + cl.Premium + ", '" + cl.DNI + "', '" + cl.Name + "', " + cl.Surname + ", " + cl.Phone + ", " + cl.Address + ", " + cl.City + ", " + cl.BirthDate + ", " + cl.DrivingLicence + ", " + ")", c);
                sql.ExecuteNonQuery();
                return true;
            } catch (Exception e)
            {
                return false;
            }
            finally
            {
                c.Close();
            }*/

        }
  }
