using BloodBankManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BloodBankManager
{
    public partial class SearchDonor : Form
    {
        private DataGridViewTextBoxColumn _Name;
        private DataGridViewTextBoxColumn BloodGroup;
        private DataGridViewTextBoxColumn Age;
        private DataGridViewTextBoxColumn Sex;
        private DataGridViewTextBoxColumn StreetAddress;
        private DataGridViewTextBoxColumn City;
        private DataGridViewTextBoxColumn State;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Rh;
        private Button search_button;
        private TextBox search_box;
        private ComboBox search_category;
        private Label label1;
        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem newDonorToolStripMenuItem1;
        private DataGridView donor_data;

        public SearchDonor()
        {
            InitializeComponent();
            FillRows();
        }

        public void NewDonor(object sender, EventArgs e)
        {
            var Donor = new NewDonor();

            Donor.Show();
        }

        public void Cancel(object sender, EventArgs e)
        {
            Utilities.ResetAllControls(this);
            this.Close();
        }

        public void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.donor_data = new System.Windows.Forms.DataGridView();
            this._Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BloodGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StreetAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.search_button = new System.Windows.Forms.Button();
            this.search_box = new System.Windows.Forms.TextBox();
            this.search_category = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDonorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.donor_data)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // donor_data
            // 
            this.donor_data.AllowUserToAddRows = false;
            this.donor_data.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.donor_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.donor_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Name,
            this.BloodGroup,
            this.Age,
            this.Sex,
            this.StreetAddress,
            this.City,
            this.State,
            this.Date,
            this.PhoneNumber,
            this.Email,
            this.Rh});
            this.donor_data.Location = new System.Drawing.Point(12, 121);
            this.donor_data.Name = "donor_data";
            this.donor_data.ReadOnly = true;
            this.donor_data.Size = new System.Drawing.Size(960, 442);
            this.donor_data.TabIndex = 0;
            // 
            // _Name
            // 
            this._Name.HeaderText = "Name";
            this._Name.Name = "_Name";
            this._Name.ReadOnly = true;
            // 
            // BloodGroup
            // 
            this.BloodGroup.HeaderText = "BloodGroup";
            this.BloodGroup.Name = "BloodGroup";
            this.BloodGroup.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.Width = 50;
            // 
            // Sex
            // 
            this.Sex.HeaderText = "Sex";
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            this.Sex.Width = 75;
            // 
            // StreetAddress
            // 
            this.StreetAddress.HeaderText = "StreetAddress";
            this.StreetAddress.Name = "StreetAddress";
            this.StreetAddress.ReadOnly = true;
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // Date
            // 
            dataGridViewCellStyle7.Format = "D";
            dataGridViewCellStyle7.NullValue = null;
            this.Date.DefaultCellStyle = dataGridViewCellStyle7;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.HeaderText = "PhoneNumber";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Rh
            // 
            this.Rh.HeaderText = "Rh";
            this.Rh.Name = "Rh";
            this.Rh.ReadOnly = true;
            this.Rh.Width = 50;
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(897, 88);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 27);
            this.search_button.TabIndex = 1;
            this.search_button.Text = "Search";
            this.search_button.UseVisualStyleBackColor = true;
            // 
            // search_box
            // 
            this.search_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_box.Location = new System.Drawing.Point(681, 88);
            this.search_box.Name = "search_box";
            this.search_box.Size = new System.Drawing.Size(210, 23);
            this.search_box.TabIndex = 2;
            this.search_box.Text = "Dustin Craig";
            // 
            // search_category
            // 
            this.search_category.FormattingEnabled = true;
            this.search_category.Location = new System.Drawing.Point(554, 88);
            this.search_category.Name = "search_category";
            this.search_category.Size = new System.Drawing.Size(121, 21);
            this.search_category.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(554, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Category to search by:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(881, 602);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Cancel);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Cancel);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDonorToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // newDonorToolStripMenuItem1
            // 
            this.newDonorToolStripMenuItem1.Name = "newDonorToolStripMenuItem1";
            this.newDonorToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.newDonorToolStripMenuItem1.Text = "New Donor";
            this.newDonorToolStripMenuItem1.Click += new System.EventHandler(this.NewDonor);
            // 
            // SearchDonor
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(984, 644);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search_category);
            this.Controls.Add(this.search_box);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.donor_data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SearchDonor";
            this.Text = "Donor List";
            ((System.ComponentModel.ISupportInitialize)(this.donor_data)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FillRows()
        {
            string connString = BloodBankManager.Utilities.GetConnectionString();
            string commandString = "SELECT * FROM [dbo].[Donors]";
            var donors = new List<Donor>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandString, connection); 

                using(SqlDataReader read = command.ExecuteReader())
                {
                    while(read.Read())
                    {
                        Donor next = new Donor()
                        {
                            Name = read["Name"].ToString(),
                            BloodGroup = read["BloodGroup"].ToString(),
                            Age = read["Age"].ToString(),
                            Sex = read["Sex"].ToString(),
                            StreetAddress = read["StreetAddress"].ToString(),
                            City = read["City"].ToString(),
                            State = read["State"].ToString(),
                            Date = DateTime.Parse(read["Date"].ToString()),
                            PhoneNumber = read["PhoneNumber"].ToString(),
                            Email = read["Email"].ToString(),
                            Rh = read["Rh"].ToString()

                        };
                        donors.Add(next);
                    }
                }
            }
            foreach (Donor d in donors)
            {
                AddRow(d);
            }
        }

        private void AddRow(Donor donor)
        {
            var index = donor_data.Rows.Add();
            donor_data.Rows[index].Cells["_Name"].Value = donor.Name;
            donor_data.Rows[index].Cells["BloodGroup"].Value = donor.BloodGroup;
            donor_data.Rows[index].Cells["Age"].Value = donor.Age;
            donor_data.Rows[index].Cells["Sex"].Value = donor.Sex;
            donor_data.Rows[index].Cells["StreetAddress"].Value = donor.StreetAddress;
            donor_data.Rows[index].Cells["City"].Value = donor.City;
            donor_data.Rows[index].Cells["State"].Value = donor.State;
            donor_data.Rows[index].Cells["Date"].Value = donor.Date;
            donor_data.Rows[index].Cells["PhoneNumber"].Value = donor.PhoneNumber;
            donor_data.Rows[index].Cells["Email"].Value = donor.Email;
            donor_data.Rows[index].Cells["Rh"].Value = donor.Rh;

        }
    }
}
