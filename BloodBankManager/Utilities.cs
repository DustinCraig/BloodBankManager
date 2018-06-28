/*  Dustin Craig
 *  Utilities class to handle some control of forms
 *  06/22/2018
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace BloodBankManager
{
    public class Utilities
    {
        public Form ThreadForm; 

        /// <summary>
        /// Get the connection string
        /// </summary>
        /// <returns>If return value isnt null, the connection string has been found</returns>
        internal static string GetConnectionString()
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["BloodBankManager.Properties.Settings.connString"];

            if(settings != null)
            {
                returnValue = settings.ConnectionString;
            }

            return returnValue;
        }
        /// <summary>
        /// Reset all of the fields of a form 
        /// </summary>
        /// <param name="form">The form that will be reset</param>
        public static void ResetAllControls(Control form)
        {
            foreach(Control control in form.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = null;
                }
                if (control is ComboBox comboBox)
                {
                    if (comboBox.Items.Count > 0)
                    {
                        comboBox.SelectedIndex = -1;
                    }
                }
                if(control is RadioButton radioButton)
                {
                    radioButton.Checked = false; 
                }
            }
        }

        /// <summary>
        /// Function to check whether all relevant items are not empty or left unchecked. This is to prevent saving a patient's data with 
        /// empty fields
        /// </summary>
        /// <param name="form">The form that will be checked</param>
        /// <returns>A false result indicates that there is a field left empty. A true result indicates that all fields are properly filled out.</returns>
        public static bool AllEntriesFilled(Control form)
        {
            bool radioExist = false; 
            bool radioBtnCheck = false; 

            foreach(Control control in form.Controls)
            {
                if (control is TextBox textBox)
                {
                    if(String.IsNullOrEmpty(textBox.Text))
                    {
                        return false; 
                    }
                }
                if (control is ComboBox comboBox)
                {
                    if(comboBox.SelectedItem == null)
                    {
                        return false; 
                    }
                }
                if (control is RadioButton radioButton)
                {
                    radioExist = true;
                    if(radioButton.Checked == true)
                    {
                        radioBtnCheck = true; 
                    }
                }
            }
            if ((radioBtnCheck == false) && (radioExist == true)) return false; 

            return true; 
        }
        /// <summary>
        /// This function should only be used on the NewDonor form. It will find the checked radio button that indicates the blood group of the donor.
        /// </summary>
        /// <param name="form">NewDonor form</param>
        public static Control GetBloodGroup(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Checked == true)
                    {
                        return radioButton;
                    }
                }
            }
            return null; 
        }
    }
}
