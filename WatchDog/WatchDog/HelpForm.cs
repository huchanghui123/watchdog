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
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            this.richTextBox1.Text = "Directions\n\n\n" +
                "Default Time-out:60s\n\n" +
                "Time-out range:0-65535s\n\n" +
                "Time-out set to 0 equal to turning off the watchdog function.\n\n" +
                "Note：If you exit the program, do not check the stop watchdog." +
                "The system will automatically restart when the set timeout is reached.";

        }
    }
}
