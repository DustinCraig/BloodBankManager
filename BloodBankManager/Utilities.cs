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
