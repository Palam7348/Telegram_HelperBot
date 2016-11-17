using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotApplication
{
    public partial class AutoLoadForm : Form
    {
        private const string name = "BotApplication";

        public AutoLoadForm()
        {
            InitializeComponent();
        }

        public void SetAutorunValue(bool autorun)
        {
            //string ExePath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string ExePath = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(name, ExePath);
                else
                    reg.DeleteValue(name);

                reg.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.Hide();
            }
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            SetAutorunValue(true);
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            SetAutorunValue(false);
        }
    }
}
