﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesMate
{
    public partial class frmLogin : Form
    {
        MessageBoxIcon icon = MessageBoxIcon.Error;
        MessageBoxButtons btn = MessageBoxButtons.OK;
        private const string loginpop = "Database Could not be Established!";
        private const string caption = "Login";
        DialogResult result;

        public static User currentUser;
        public static User User {
            get
            {
                return currentUser;
            }
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void KeyEnterLogin()
        {
            User u = new User(txtBoxCashierUser.Text);
            try
            {
                if (u.isAuth(txtBoxCashierUser.Text.Trim(), txtBoxPass.Text.Trim()))
                {
                    currentUser = u;
                    this.Hide();
                    frmMain fm = new frmMain();
                    if (u.isAdmin())
                    {
                        fm.isnotAdmin();
                    }
                    fm.Show();
                }
                else
                    result = MessageBox.Show("Username and Password Incorrect or Not Completed", "Login Error", btn, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                result = MessageBox.Show(loginpop, caption, btn, icon);
            }
        }

        public void clearText()
        {
            txtBoxCashierUser.Text = "";
            txtBoxPass.Text = "";
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            KeyEnterLogin();
        }

        private void txtBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KeyEnterLogin();
            }
        }

        private void txtBoxCashierUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxPass.Focus();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("There is nothing in Here!");
        }
    }
}