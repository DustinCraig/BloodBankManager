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
using BloodBankManager.Models;

namespace BloodBankManager
{
    public partial class NewDonor : Form
    {
        #region Items
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private Label donor_name_entry_label;
        private Label donor_name_label;
        private TextBox donor_name;
        private Label donor_date_label;
        private Label label1;
        private DateTimePicker donor_date;
        private RadioButton blood_a;
        private RadioButton blood_b;
        private RadioButton blood_ab;
        private RadioButton blood_o;
        private Label donor_age_label;
        private TextBox donor_age;
        private Label donor_sex_label;
        private Label donor_address_label;
        private TextBox donor_street_address;
        private Label donor_phonenumber_label;
        private TextBox donor_phonenumber;
        private Label donor_city_label;
        private Label donor_state_label;
        private ComboBox donor_state;
        private TextBox donor_city;
        private Label donor_zipcode_label;
        private TextBox donor_zipcode;
        private Label donor_email_label;
        private TextBox donor_email;
        private Button donor_cancel;
        private Button donor_save;
        private ComboBox donor_sex;
        private ComboBox donor_rh;
        private Label donor_rh_label;
        private Panel panel1;
        private Label donor_warning;
        private Button donor_clear;
        private ToolStripMenuItem exitToolStripMenuItem;
        #endregion

        public event EventHandler Saved;

        /// <summary>
        /// Make sure all entries are filled, then save the new donor to the database
        /// </summary>
        public void Save(object sender, EventArgs e)
        {
            bool allEntriesFilled = Utilities.AllEntriesFilled(this);
            
            if (allEntriesFilled == true)
            {
                var bloodGroup = BloodBankManager.Utilities.GetBloodGroup(this);
                var donor = new Donor
                {
                    Name = donor_name.Text,
                    Age = donor_age.Text,
                    BloodGroup = bloodGroup.Text,
                    Sex = donor_sex.SelectedItem.ToString(),
                    StreetAddress = donor_street_address.Text,
                    City = donor_city.Text,
                    State = donor_state.SelectedItem.ToString(),
                    Date = DateTime.Parse(donor_date.Text),
                    PhoneNumber = donor_phonenumber.Text,
                    Email = donor_email.Text,
                    Rh = donor_rh.SelectedItem.ToString(),

                    //This is a dummy value for @responseMessage to be assigned to if no error occurs
                    Error = "No Error"
                };
                donor.Save();
                Saved.Invoke(this, EventArgs.Empty);
                MessageBox.Show(donor.Name + " has been saved");
                Utilities.ResetAllControls(this);
            }
            else MessageBox.Show("Please fill out all entries before saving");
            
        }


        /// <summary>
        /// Clear all fields of the form
        /// </summary>
        public void Clear(object sender, EventArgs e)
        {
            Utilities.ResetAllControls(this);
        }

        /// <summary>
        /// Close the current form 
        /// </summary>
        public void Cancel(object sender, EventArgs e)
        {
            Utilities.ResetAllControls(this);
            this.Close(); 
        }
        

        public NewDonor()
        {

            InitializeComponent();

            //Controls
            this.donor_save.Click += new EventHandler(this.Save);
            this.donor_clear.Click += new EventHandler(this.Clear);
            this.donor_cancel.Click += new EventHandler(this.Cancel);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donor_name_entry_label = new System.Windows.Forms.Label();
            this.donor_name_label = new System.Windows.Forms.Label();
            this.donor_name = new System.Windows.Forms.TextBox();
            this.donor_date_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.donor_date = new System.Windows.Forms.DateTimePicker();
            this.blood_a = new System.Windows.Forms.RadioButton();
            this.blood_b = new System.Windows.Forms.RadioButton();
            this.blood_ab = new System.Windows.Forms.RadioButton();
            this.blood_o = new System.Windows.Forms.RadioButton();
            this.donor_age_label = new System.Windows.Forms.Label();
            this.donor_age = new System.Windows.Forms.TextBox();
            this.donor_sex_label = new System.Windows.Forms.Label();
            this.donor_address_label = new System.Windows.Forms.Label();
            this.donor_street_address = new System.Windows.Forms.TextBox();
            this.donor_phonenumber_label = new System.Windows.Forms.Label();
            this.donor_phonenumber = new System.Windows.Forms.TextBox();
            this.donor_city_label = new System.Windows.Forms.Label();
            this.donor_state_label = new System.Windows.Forms.Label();
            this.donor_state = new System.Windows.Forms.ComboBox();
            this.donor_city = new System.Windows.Forms.TextBox();
            this.donor_zipcode_label = new System.Windows.Forms.Label();
            this.donor_zipcode = new System.Windows.Forms.TextBox();
            this.donor_email_label = new System.Windows.Forms.Label();
            this.donor_email = new System.Windows.Forms.TextBox();
            this.donor_cancel = new System.Windows.Forms.Button();
            this.donor_save = new System.Windows.Forms.Button();
            this.donor_sex = new System.Windows.Forms.ComboBox();
            this.donor_rh = new System.Windows.Forms.ComboBox();
            this.donor_rh_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.donor_warning = new System.Windows.Forms.Label();
            this.donor_clear = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 1;
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Cancel);
            // 
            // donor_name_entry_label
            // 
            this.donor_name_entry_label.AutoSize = true;
            this.donor_name_entry_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_name_entry_label.Location = new System.Drawing.Point(12, 42);
            this.donor_name_entry_label.Name = "donor_name_entry_label";
            this.donor_name_entry_label.Size = new System.Drawing.Size(105, 20);
            this.donor_name_entry_label.TabIndex = 2;
            this.donor_name_entry_label.Text = "Donor Entry";
            // 
            // donor_name_label
            // 
            this.donor_name_label.AutoSize = true;
            this.donor_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_name_label.Location = new System.Drawing.Point(64, 73);
            this.donor_name_label.Name = "donor_name_label";
            this.donor_name_label.Size = new System.Drawing.Size(45, 17);
            this.donor_name_label.TabIndex = 3;
            this.donor_name_label.Text = "Name";
            // 
            // donor_name
            // 
            this.donor_name.Location = new System.Drawing.Point(116, 73);
            this.donor_name.Name = "donor_name";
            this.donor_name.Size = new System.Drawing.Size(154, 20);
            this.donor_name.TabIndex = 4;
            // 
            // donor_date_label
            // 
            this.donor_date_label.AutoSize = true;
            this.donor_date_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_date_label.Location = new System.Drawing.Point(354, 73);
            this.donor_date_label.Name = "donor_date_label";
            this.donor_date_label.Size = new System.Drawing.Size(38, 17);
            this.donor_date_label.TabIndex = 5;
            this.donor_date_label.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Blood Group";
            // 
            // donor_date
            // 
            this.donor_date.Location = new System.Drawing.Point(398, 73);
            this.donor_date.Name = "donor_date";
            this.donor_date.Size = new System.Drawing.Size(200, 20);
            this.donor_date.TabIndex = 8;
            // 
            // blood_a
            // 
            this.blood_a.AutoSize = true;
            this.blood_a.Location = new System.Drawing.Point(116, 107);
            this.blood_a.Name = "blood_a";
            this.blood_a.Size = new System.Drawing.Size(32, 17);
            this.blood_a.TabIndex = 9;
            this.blood_a.Text = "A";
            this.blood_a.UseVisualStyleBackColor = true;
            // 
            // blood_b
            // 
            this.blood_b.AutoSize = true;
            this.blood_b.Location = new System.Drawing.Point(154, 107);
            this.blood_b.Name = "blood_b";
            this.blood_b.Size = new System.Drawing.Size(32, 17);
            this.blood_b.TabIndex = 10;
            this.blood_b.TabStop = true;
            this.blood_b.Text = "B";
            this.blood_b.UseVisualStyleBackColor = true;
            // 
            // blood_ab
            // 
            this.blood_ab.AutoSize = true;
            this.blood_ab.Location = new System.Drawing.Point(192, 107);
            this.blood_ab.Name = "blood_ab";
            this.blood_ab.Size = new System.Drawing.Size(39, 17);
            this.blood_ab.TabIndex = 11;
            this.blood_ab.TabStop = true;
            this.blood_ab.Text = "AB";
            this.blood_ab.UseVisualStyleBackColor = true;
            // 
            // blood_o
            // 
            this.blood_o.AutoSize = true;
            this.blood_o.Location = new System.Drawing.Point(237, 107);
            this.blood_o.Name = "blood_o";
            this.blood_o.Size = new System.Drawing.Size(33, 17);
            this.blood_o.TabIndex = 12;
            this.blood_o.TabStop = true;
            this.blood_o.Text = "O";
            this.blood_o.UseVisualStyleBackColor = true;
            // 
            // donor_age_label
            // 
            this.donor_age_label.AutoSize = true;
            this.donor_age_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_age_label.Location = new System.Drawing.Point(64, 136);
            this.donor_age_label.Name = "donor_age_label";
            this.donor_age_label.Size = new System.Drawing.Size(33, 17);
            this.donor_age_label.TabIndex = 13;
            this.donor_age_label.Text = "Age";
            // 
            // donor_age
            // 
            this.donor_age.Location = new System.Drawing.Point(116, 136);
            this.donor_age.Name = "donor_age";
            this.donor_age.Size = new System.Drawing.Size(70, 20);
            this.donor_age.TabIndex = 14;
            // 
            // donor_sex_label
            // 
            this.donor_sex_label.AutoSize = true;
            this.donor_sex_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_sex_label.Location = new System.Drawing.Point(64, 168);
            this.donor_sex_label.Name = "donor_sex_label";
            this.donor_sex_label.Size = new System.Drawing.Size(31, 17);
            this.donor_sex_label.TabIndex = 15;
            this.donor_sex_label.Text = "Sex";
            // 
            // donor_address_label
            // 
            this.donor_address_label.AutoSize = true;
            this.donor_address_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_address_label.Location = new System.Drawing.Point(7, 212);
            this.donor_address_label.Name = "donor_address_label";
            this.donor_address_label.Size = new System.Drawing.Size(102, 17);
            this.donor_address_label.TabIndex = 17;
            this.donor_address_label.Text = "Street Address";
            // 
            // donor_street_address
            // 
            this.donor_street_address.Location = new System.Drawing.Point(115, 209);
            this.donor_street_address.Name = "donor_street_address";
            this.donor_street_address.Size = new System.Drawing.Size(155, 20);
            this.donor_street_address.TabIndex = 18;
            // 
            // donor_phonenumber_label
            // 
            this.donor_phonenumber_label.AutoSize = true;
            this.donor_phonenumber_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_phonenumber_label.Location = new System.Drawing.Point(289, 107);
            this.donor_phonenumber_label.Name = "donor_phonenumber_label";
            this.donor_phonenumber_label.Size = new System.Drawing.Size(103, 17);
            this.donor_phonenumber_label.TabIndex = 19;
            this.donor_phonenumber_label.Text = "Phone Number";
            // 
            // donor_phonenumber
            // 
            this.donor_phonenumber.Location = new System.Drawing.Point(398, 107);
            this.donor_phonenumber.Name = "donor_phonenumber";
            this.donor_phonenumber.Size = new System.Drawing.Size(200, 20);
            this.donor_phonenumber.TabIndex = 20;
            // 
            // donor_city_label
            // 
            this.donor_city_label.AutoSize = true;
            this.donor_city_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_city_label.Location = new System.Drawing.Point(78, 241);
            this.donor_city_label.Name = "donor_city_label";
            this.donor_city_label.Size = new System.Drawing.Size(31, 17);
            this.donor_city_label.TabIndex = 21;
            this.donor_city_label.Text = "City";
            // 
            // donor_state_label
            // 
            this.donor_state_label.AutoSize = true;
            this.donor_state_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_state_label.Location = new System.Drawing.Point(68, 309);
            this.donor_state_label.Name = "donor_state_label";
            this.donor_state_label.Size = new System.Drawing.Size(41, 17);
            this.donor_state_label.TabIndex = 22;
            this.donor_state_label.Text = "State";
            // 
            // donor_state
            // 
            this.donor_state.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.donor_state.FormattingEnabled = true;
            this.donor_state.Items.AddRange(new object[] {
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.donor_state.Location = new System.Drawing.Point(116, 305);
            this.donor_state.Name = "donor_state";
            this.donor_state.Size = new System.Drawing.Size(49, 21);
            this.donor_state.TabIndex = 24;
            // 
            // donor_city
            // 
            this.donor_city.Location = new System.Drawing.Point(115, 241);
            this.donor_city.Name = "donor_city";
            this.donor_city.Size = new System.Drawing.Size(155, 20);
            this.donor_city.TabIndex = 25;
            // 
            // donor_zipcode_label
            // 
            this.donor_zipcode_label.AutoSize = true;
            this.donor_zipcode_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_zipcode_label.Location = new System.Drawing.Point(58, 275);
            this.donor_zipcode_label.Name = "donor_zipcode_label";
            this.donor_zipcode_label.Size = new System.Drawing.Size(59, 17);
            this.donor_zipcode_label.TabIndex = 26;
            this.donor_zipcode_label.Text = "Zipcode";
            // 
            // donor_zipcode
            // 
            this.donor_zipcode.Location = new System.Drawing.Point(115, 274);
            this.donor_zipcode.Name = "donor_zipcode";
            this.donor_zipcode.Size = new System.Drawing.Size(155, 20);
            this.donor_zipcode.TabIndex = 27;
            // 
            // donor_email_label
            // 
            this.donor_email_label.AutoSize = true;
            this.donor_email_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_email_label.Location = new System.Drawing.Point(350, 139);
            this.donor_email_label.Name = "donor_email_label";
            this.donor_email_label.Size = new System.Drawing.Size(42, 17);
            this.donor_email_label.TabIndex = 28;
            this.donor_email_label.Text = "Email";
            // 
            // donor_email
            // 
            this.donor_email.Location = new System.Drawing.Point(398, 139);
            this.donor_email.Name = "donor_email";
            this.donor_email.Size = new System.Drawing.Size(200, 20);
            this.donor_email.TabIndex = 29;
            // 
            // donor_cancel
            // 
            this.donor_cancel.Location = new System.Drawing.Point(523, 309);
            this.donor_cancel.Name = "donor_cancel";
            this.donor_cancel.Size = new System.Drawing.Size(75, 29);
            this.donor_cancel.TabIndex = 30;
            this.donor_cancel.Text = "Cancel";
            this.donor_cancel.UseVisualStyleBackColor = true;
            // 
            // donor_save
            // 
            this.donor_save.Location = new System.Drawing.Point(361, 309);
            this.donor_save.Name = "donor_save";
            this.donor_save.Size = new System.Drawing.Size(75, 29);
            this.donor_save.TabIndex = 31;
            this.donor_save.Text = "Save";
            this.donor_save.UseVisualStyleBackColor = true;
            // 
            // donor_sex
            // 
            this.donor_sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.donor_sex.FormattingEnabled = true;
            this.donor_sex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.donor_sex.Location = new System.Drawing.Point(116, 168);
            this.donor_sex.Name = "donor_sex";
            this.donor_sex.Size = new System.Drawing.Size(71, 21);
            this.donor_sex.TabIndex = 32;
            // 
            // donor_rh
            // 
            this.donor_rh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.donor_rh.FormattingEnabled = true;
            this.donor_rh.Items.AddRange(new object[] {
            "+",
            "-"});
            this.donor_rh.Location = new System.Drawing.Point(398, 179);
            this.donor_rh.Name = "donor_rh";
            this.donor_rh.Size = new System.Drawing.Size(50, 21);
            this.donor_rh.TabIndex = 33;
            // 
            // donor_rh_label
            // 
            this.donor_rh_label.AutoSize = true;
            this.donor_rh_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_rh_label.Location = new System.Drawing.Point(322, 180);
            this.donor_rh_label.Name = "donor_rh_label";
            this.donor_rh_label.Size = new System.Drawing.Size(70, 17);
            this.donor_rh_label.TabIndex = 34;
            this.donor_rh_label.Text = "Rh Factor";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(16, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 5);
            this.panel1.TabIndex = 35;
            // 
            // donor_warning
            // 
            this.donor_warning.AutoSize = true;
            this.donor_warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donor_warning.ForeColor = System.Drawing.Color.Red;
            this.donor_warning.Location = new System.Drawing.Point(395, 276);
            this.donor_warning.Name = "donor_warning";
            this.donor_warning.Size = new System.Drawing.Size(0, 18);
            this.donor_warning.TabIndex = 36;
            // 
            // donor_clear
            // 
            this.donor_clear.Location = new System.Drawing.Point(442, 309);
            this.donor_clear.Name = "donor_clear";
            this.donor_clear.Size = new System.Drawing.Size(75, 29);
            this.donor_clear.TabIndex = 37;
            this.donor_clear.Text = "Clear";
            this.donor_clear.UseVisualStyleBackColor = true;
            // 
            // NewDonor
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(624, 361);
            this.Controls.Add(this.donor_clear);
            this.Controls.Add(this.donor_warning);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.donor_rh_label);
            this.Controls.Add(this.donor_rh);
            this.Controls.Add(this.donor_sex);
            this.Controls.Add(this.donor_save);
            this.Controls.Add(this.donor_cancel);
            this.Controls.Add(this.donor_email);
            this.Controls.Add(this.donor_email_label);
            this.Controls.Add(this.donor_zipcode);
            this.Controls.Add(this.donor_zipcode_label);
            this.Controls.Add(this.donor_city);
            this.Controls.Add(this.donor_state);
            this.Controls.Add(this.donor_state_label);
            this.Controls.Add(this.donor_city_label);
            this.Controls.Add(this.donor_phonenumber);
            this.Controls.Add(this.donor_phonenumber_label);
            this.Controls.Add(this.donor_street_address);
            this.Controls.Add(this.donor_address_label);
            this.Controls.Add(this.donor_sex_label);
            this.Controls.Add(this.donor_age);
            this.Controls.Add(this.donor_age_label);
            this.Controls.Add(this.blood_o);
            this.Controls.Add(this.blood_ab);
            this.Controls.Add(this.blood_b);
            this.Controls.Add(this.blood_a);
            this.Controls.Add(this.donor_date);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.donor_date_label);
            this.Controls.Add(this.donor_name);
            this.Controls.Add(this.donor_name_label);
            this.Controls.Add(this.donor_name_entry_label);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "NewDonor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blood Bank Management";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
    }
}
