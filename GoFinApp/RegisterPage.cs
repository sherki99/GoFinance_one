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
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void RegisterPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnectionClass dbConn = DBConnectionClass.getInstanceDBConnectionClass();
            // capture the string taht the user will type
            string FirstName = textFirstName.Text;// text is an attribute of the textBox, which gives as back an stiing 
            string LastName = textLastName.Text;
            string Email = textnewEmail.Text;
            string Password = textNewPassord.Text;
            // int age = Convert.ToInt32(textAge.Text);

            // call  amethod that insert these data into the database from DBconnectionClass is called saveTpDB 

            //DataSet datasetRM = dbConn.getDataSet("SELECT * FROM RM"); // RM is the name of the table // now we have the dataset

            dbConn.saveToDB("INSERT INTO RelationManager (FirstName, LastName, Email , Password) VALUES (@FirstName, @LastName, @Email , @Password)", FirstName, LastName, Email, Password);
            // we have 6 parameter + insert  = 7  // remember we do not send the values directlry this why used values AND WE WRITE HTE OTHER 6 PARAMETER 
            // 

            new Loginpage().Show();
            MessageBox.Show("You are registered");
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
