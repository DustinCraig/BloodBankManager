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

        public static bool AllEntriesFilled(Control form)
        {
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
                    if(radioButton.Checked == false)
                    {
                        return false; 
                    }
                }
            }
            return true; 
        }
    }
}
