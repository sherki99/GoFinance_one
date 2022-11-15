using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFinApp
{
    public partial class Loginpage : Form
    {
        public Loginpage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegisterPage().Show();
            this.Hide();
        }

        private void textUsarname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
          
        private void button1_Click(object sender, EventArgs e)
        {

            DBConnectionClass dbConn = DBConnectionClass.getInstanceDBConnectionClass();



            string emailLogin = textUsarname.Text;
            string passwordLogin = textPassword.Text;


            bool ValueLogin = dbConn.getUsurnamPass("SELECT * FROM [RelationManager] ", emailLogin, passwordLogin);

            if (ValueLogin == true)
            {

                // if the valuelogin is true e message is shows and opens a dashboard page
                MessageBox.Show("Welcome back!");
                var OpenMenu = new Menu();
                OpenMenu.Show();

            }
            else
            {
                MessageBox.Show("The User name or password you entered is incorrect, try again!");
            }


            // get the username and the password and then send to the backend to be validate
            //String result = (new LoginBE()).login(textUsarname.Text);

            //returns the object of the DBConnectionClass // Important: we dont crete the object we get the object
            //DBConnectionClass dbConn = DBConnectionClass.getInstanceDBConnectionClass();
            //DataSet datasetRM = dbConn.getDataSet("SELECT * FROM RM"); // RM is the name of the table // now we have the dataset
            // we need to attach it with element in the examole qith datagridview
            // dgvPerson.Datasorce  =  datasetRM.Tables[0]   from THE DATSETRM THE FIRST ELEMENT   

            // DBConnectionClass dbconn = DBConnectionClass.getInstanceDBConnectionClass();
            // DataSet datasetRM = dbconn.getDataSet("SELECT * FROM RM");
            // datasetRM table = datasetRM.Tables[0];
            //for(datasetRM.Tables[O])








            // if (textUsarname.Text == "cherki99" && textPassword.Text == "cherkibello")
            //{
            //   new RegisterPage().Show();
            //  this.Hide();

            //}
            //else
            //{
            //in caso RM mette il nume utente o la password, apparira una finesta che dice cha ha messo codice sbalgato


            //  MessageBox.Show("The User name or password you entered is incorrect, try again!");
            // textUsarname.Clear(); // questo comando elemina username sbagliato lasciando la finestra vuota 
            //textPassword.Clear();
            //textUsarname.Focus(); // mette il focus sulla finestra text

            //}

        }

        private void label1_Click(object sender, EventArgs e)
        {

            DBConnectionClass dbConn = DBConnectionClass.getInstanceDBConnectionClass();
            DataSet dataProdocut = dbConn.getDataSet("SELECT  * FROM[Product]");
            gridProduct.DataSource = dataProdocut.Tables[0];


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            textUsarname.Clear();
            textPassword.Clear();
            textUsarname.Focus();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
