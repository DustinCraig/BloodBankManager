using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace BloodBankManager
{
    public partial class LogIn : Form
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Button exit_button;
        StringBuilder errorMessages = new StringBuilder();

        /// <summary>
        /// The login attempt. If all entries are filled it will attempt to log the user into the system 
        /// </summary>
        public void Login_Attempt(object sender, EventArgs e)
        {
            string userNameText = this.username.Text;
            string passWordText = this.password.Text;
            string connString = BloodBankManager.Utilities.GetConnectionString();
            bool allEntriesFilled = Utilities.AllEntriesFilled(this.panel1);
            if (allEntriesFilled == true)
            {
                SqlConnection connection = new SqlConnection(connString);
                try
                {
                    connection.Open();
                    string command = @"
                    EXEC dbo.uspLogin
                    @pLoginName=@login,
                    @pPassword=@pass
                    ";

                    SqlCommand sqlCommand = new SqlCommand(command, connection);
                    sqlCommand.Parameters.AddWithValue("@login", userNameText);
                    sqlCommand.Parameters.AddWithValue("@pass", passWordText);


                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        this.Hide();
                        var newDonor = new NewDonor();
                        newDonor.FormClosed += (s, args) => this.Close();
                        newDonor.Show(); 
                    }
                    else MessageBox.Show("Invalid Username or Password");

                }
                catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    Console.WriteLine(errorMessages.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }
        /// <summary>
        /// The function to handle a login attempt
        /// </summary>
        public LogIn()
        {
            InitializeComponent();
            this.login_button.Click += new EventHandler(this.Login_Attempt);
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.login_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.username);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 117);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(101, 71);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(186, 20);
            this.password.TabIndex = 2;
            this.password.UseSystemPasswordChar = true;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(101, 31);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(186, 20);
            this.username.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Please enter your information:";
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(216, 221);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(75, 28);
            this.login_button.TabIndex = 2;
            this.login_button.Text = "Log In";
            this.login_button.UseVisualStyleBackColor = true;
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(297, 221);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(75, 28);
            this.exit_button.TabIndex = 3;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.Cancel);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
