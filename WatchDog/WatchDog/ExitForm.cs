using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchDog
{
    public partial class ExitForm : Form
    {
        private WatchDogUtils watchdog = null;
        public delegate void closeForm();
        public event closeForm closeform_event;
        public ExitForm()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            watchdog = new WatchDogUtils();
        }

        private void YBtn_Click(object sender, EventArgs e)
        {
            if (checkBox.CheckState == CheckState.Checked)
            {
                watchdog.StopWatchDog();
                LogHelper.WriteLog("Watch Dog Disable!!!");
            }
            
            Console.WriteLine("Application Exit!!!");
            LogHelper.WriteLog("Application Exit!!!");
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        private void NBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("close exit form !!!!!!!!!!!!");
            closeform_event();
        }
    }
}
