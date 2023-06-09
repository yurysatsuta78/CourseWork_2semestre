﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurs
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }
        MainForm f1 = new MainForm();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            string userlogin = LoginAuth.Text;
            string userpassword = PasswordAuth.Text;
            bool success = false;
            Database DB = new Database();
            string usrs = "SELECT * FROM Users WHERE Login = @userlogin AND Password collate Cyrillic_General_CS_AS = @userpassword";
            try
            {
                SqlCommand cmd = new SqlCommand(usrs, DB.getConnection());
                cmd.Parameters.AddWithValue("@userlogin", userlogin);
                cmd.Parameters.AddWithValue("@userpassword", userpassword);
                DB.openConnection();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    success = reader.Read();
                }
            }
            finally 
            {
                DB.closeConnection();
            }
            if (success)
            {
                SqlCommand cmd = new SqlCommand(usrs, DB.getConnection());
                cmd.Parameters.AddWithValue("@userlogin", userlogin);
                cmd.Parameters.AddWithValue("@userpassword", userpassword);
                DB.openConnection();
                using (SqlDataReader reader2 = cmd.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        User.userid = reader2.GetInt32(0);
                        User.login = reader2.GetString(3);
                        User.balance = reader2.GetDouble(5);
                    }
                }
                DB.closeConnection();
                MainForm f1 = new MainForm();
                f1.Show();
                Hide();
            }
            else 
            {
                if (LoginAuth.Text == String.Empty || PasswordAuth.Text == String.Empty)
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.ShowDialog();           
        }
    }
}
