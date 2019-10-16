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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            this.richTextBox1.Text = "WatchDog\n\nRelease 1.00\n\nBuild platform: 64-bit Windows 10\nVisual Studio 2017/Net." +
    "Framework 4\n\nCopyright 2019-2025 Qotom Software\nAll Rights Reserved\n";
        }

        
    }
}
