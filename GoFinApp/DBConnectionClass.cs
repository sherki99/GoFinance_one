
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GoFinApp
{
    class DBConnectionClass // this is ht ec lass where we put all our the methods that have to communicate to the DB  // belong to the backend  // is like a bridge beetween the fornt end gui and the the database 

    {
        //
        // what this classs does?  it has estabilished a connection to the database,
        // to store the connection to the database, and showed that it has all the component ready
        // create the connection, open the connection, send the quert, wate for the DB to send the response back
        // close the connection, these are the steps
        // the main reason becasue i have created a new class is becaseue I want to separate the  beckand and front and
        // this file is in the middle between th edaatbase and all the other backend filesb
        //


        // attributes

        // private object of the class itself 
        // an object of the class inside the class
        // made this class private to do not let in other  class to create an object based on this class
        //

        private static DBConnectionClass _instance;

        // connection string
        private string connStr;

        // sql coonnetion to the db 
        private SqlConnection connToDB;

        // private constructor
        // create a constructor// if dont write any constructor there is default constructor
        private DBConnectionClass()
        {
            // DBConnectionString stores the link to the database
            connStr = Properties.Settings.Default.DBConnectionString;
            // this is the stage where nobody has access to the class but in this way we let other class to
            //to come in and call the method
        }


        // now we giving access to our constructor through a static method
        // becasue static method go straight to the class without creating an object

        //getInstanceOfDBConnectio
        // this is the method  that gives access to the object
        public static DBConnectionClass getInstanceDBConnectionClass()
        {
            if (_instance == null)

                _instance = new DBConnectionClass();
            return _instance;
            // 
            // the object is goign be created only once 
            // if the object is not already created is going ot cretad 


        }


        public DataSet getDataSet(string sqlQuery) // this methodis public and retutrns the dataset for a given query// and we can use it whenever we need it to get the dataset
        {

            //from this method we get the dataset we send sql query as parametery 
            // CREATE THE DATASET OBJECT AND  then return it
            DataSet dataset = new DataSet();

            // cretae an objetc that is instance of the sql connection  so we have onther class that is called sql connection, we have to send to the class sql connetion this string
            // here it is going to estabilist a connection// this connection is only for limited scope 


            using (connToDB = new SqlConnection(connStr))// define the connection // create a new object of sqlconnetion class 
            {
                // open connection // and we do not need to close it
                connToDB.Open();

                // sedn sql query to the databse 
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connToDB); // first parameter is the quey itself and connToDB(connection with the database)

                // fill in the dataset 
                adapter.Fill(dataset);


            }
            return dataset;// return the  dataset 

        }

        public bool getUsurnamPass(string sqlQuery, string email, string password) // get the username and password from the database 
        {
            // this method retrun true or false to  the login button if it is true the username and passowrd exist 
            // howeve r
            bool flag = false;


            // 
            using (connToDB = new SqlConnection(connStr))// define the connection // create a new object of sqlconnetion class 
            {

                connToDB.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connToDB);
                //SqlCommand sqlCommand = new SqlCommand();
                //sqlCommand.CommandText = "SELECT * FROM[RM]";
                //sqlCommand.Connection = connToDB;

                SqlDataReader datareader = sqlCommand.ExecuteReader();


                while (datareader.Read())
                {
                    if (datareader[1].ToString() == email && datareader[1].ToString() == password)
                    {
                        flag = true;
                        break;

                    }

                }
                if (flag == true)
                {
                    return true;

                }
                else
                {
                    return false;
                }



            }


        }



        public void saveToDB(string sqlQuery, string FirstName, string LastName, string Email, string Password)// method the insert the data into the database 
        {
            using (connToDB = new SqlConnection(connStr))// define the connection // create a new object of sqlconnetion class 
            {

                connToDB.Open();

                // sqlcommand will be in charge of taking the query and sending it to the database 
                SqlCommand sqlCommmand = new SqlCommand(sqlQuery, connToDB); // 

                //we will use  the conntodb connection to database to create an sql command objetc
                // set the sqlCommand propreties
                sqlCommmand.CommandType = CommandType.Text; // first thing is to set the command type


                // the ADD // we have to convert te sting parameter into sql parameter these is the reason because  // becseu takes two paramater 
                sqlCommmand.Parameters.Add(new SqlParameter("FirstName", FirstName));
                sqlCommmand.Parameters.Add(new SqlParameter("LastName", LastName));
                sqlCommmand.Parameters.Add(new SqlParameter("Password", Password));
                sqlCommmand.Parameters.Add(new SqlParameter("Email", Email));



                // execute th ecommand 
                sqlCommmand.ExecuteNonQuery();

            }



        }


        public List<String> getProductInformation()
        {
            using (connToDB = new SqlConnection(connStr))
            {


                connToDB.Open();
                string sqlQuery = "SELECT * FROM[Idea_Product]";
                List<String> spero = new List<string>();



                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connToDB);
                SqlDataReader datareader = sqlCommand.ExecuteReader();



                while (datareader.Read())
                {

                    var mystr = datareader[0].ToString();
                    spero.Add(mystr);

                }

                return spero;
            }
        }


        public DataTable getIdea_Product_Data(string sqlQuery)
        {
            using (connToDB = new SqlConnection(connStr))
            {

                connToDB.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, connToDB);
                DataTable datatbl = new DataTable();
                sqlDa.Fill(datatbl);


                return datatbl;

            }

        }
    }
}
