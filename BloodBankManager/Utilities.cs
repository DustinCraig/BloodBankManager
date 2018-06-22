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

namespace BloodBankManager
{
    public class Utilities
    {
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
    }
}
