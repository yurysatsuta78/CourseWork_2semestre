﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace kurs
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            Database DB = new Database();
            if (Name1.Text == String.Empty || Surname.Text == String.Empty || Login.Text == String.Empty || Password.Text == String.Empty || PasswordRep.Text == String.Empty)
            {
                return;
            }
            else if (Password.Text != PasswordRep.Text)
            {
                return;
            }
            else if (Login.ForeColor == Color.Red) 
            {
                MessageBox.Show("Логин занят");
            }
            else
            {
                try
                {
                    string name = Name1.Text;
                    string surname = Surname.Text;
                    string login = Login.Text;
                    string password = Password.Text;
                    double balance = 0;
                    string newuser = string.Format("INSERT INTO Users VALUES ('{0}','{1}','{2}','{3}','{4}')", name, surname, login, password, balance);
                    SqlCommand cmd = new SqlCommand(newuser, DB.getConnection());
                    DB.openConnection();
                    cmd.ExecuteNonQuery();
                    DB.closeConnection();
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка при регистрации!");
                }
                finally 
                {
                    MessageBox.Show("Аккаунт зарегистрирован!");
                }
                Close();
            }
        }

        private void Login_TextChanged(object sender, EventArgs e)
        {
            string userlogin = Login.Text;
            bool same = false;
            Database DB = new Database();
            string usrs = "SELECT * FROM Users WHERE Login = @userlogin";
            try
            {
                SqlCommand cmd = new SqlCommand(usrs, DB.getConnection());
                cmd.Parameters.AddWithValue("@userlogin", userlogin);
                DB.openConnection();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    same = reader.Read();
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка!");
            }
            finally
            {
                DB.closeConnection();
                if (same)
                {
                    Login.ForeColor = Color.Red;
                }
                else 
                {
                    Login.ForeColor = Color.Green;
                }
            }
        }

        private void Name1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void Surname_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
