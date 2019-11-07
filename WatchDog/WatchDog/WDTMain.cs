using System;
using System.Windows.Forms;

namespace WatchDog
{
    public partial class WDTMain : Form
    {
        private WatchDogUtils watchdog = null;
        private FileStreamUtils fsu = null;
        private ExitForm exitForm = null;
        private static ushort Timeout = 60; //default feed dog time out
        private static Double TimerInterval = (UInt16)(Timeout - 2);
        private static string TimePath = Application.StartupPath + "\\timeout.txt";

        public System.Timers.Timer feedtimer = null;

        public WDTMain()
        {
            Console.WriteLine("Form1!!!!!!!");
            InitializeComponent();

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Form_Load!!!!!!!");
            watchdog = new WatchDogUtils();
            fsu = new FileStreamUtils();
            InitWatchDogDriver();

            exitForm = new ExitForm();
            exitForm.closeform_event += new ExitForm.closeForm(CloseExitForm);
        }

        void CloseExitForm()
        {
            Console.WriteLine("CloseExitForm!!!!!!!!!!!!");
            LogHelper.WriteLog("Close ExitForm!");
            exitForm.Close();
        }

        private void InitWatchDogDriver()
        {
            bool initResult = watchdog.Initialize();
            if (!initResult)
            {
                loadDrive.Text = "Driver Load failed!";
                loadDrive.ForeColor = System.Drawing.Color.Red;
                timeBox.Enabled = false;
                updateBtn.Enabled = false;
            }
            else
            {
                watchdog.InitSuperIO();
                String chipname = watchdog.GetChipName();
                chipName.Text = chipname;
                watchdog.ExitSuperIo();

                LogHelper.WriteLog("SuperIO Type:"+chipname);
                InitWatchDog();
            }
        }

        private void InitWatchDog()
        {
            string timeouttxt = fsu.FileStreamReadTimeout(TimePath, Timeout);
            Console.WriteLine("InitWatchDog-------Time-out Path" + TimePath + 
                " Default Feed Time:" + Timeout);

            if (!ushort.TryParse(timeouttxt, out ushort temp))
            {
                timeouttxt = "60";
                fsu.FileStreamWriteTimeout(TimePath, Timeout);
                LogHelper.WriteLog("timeout format error, reset to "+ timeouttxt + "s.");
            }
            current.Text = timeouttxt;
            timeBox.Text = timeouttxt;
            Timeout = Convert.ToUInt16(timeouttxt);

            watchdog.InitSuperIO();
            watchdog.WatchDogInit();
            watchdog.EnableWatchDog();
            watchdog.ExitSuperIo();

            watchdog.FeedDog(Timeout);
            LogHelper.WriteLog("feed dog start Time-out:"+ Timeout);

            if (Timeout == 0)
            {
                TimerInterval = 0;
            }
            else if (Timeout == 1)
            {
                TimerInterval = 0.5;
            }
            else if (Timeout == 2)
            {
                TimerInterval = 1;
            }
            else
            {
                TimerInterval = (ushort)(Timeout - 2);
            }

            if (feedtimer == null)
            {
                Console.WriteLine("feed dog timer start:" +
                    DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") +
                    " TimerInterval:"+ TimerInterval);
                GetTimer(TimerInterval);
                LogHelper.WriteLog("feed dog timer start TimerInterval:" + TimerInterval);
            }
        }

        private void GetTimer(double time_interval)
        {
            feedtimer = new System.Timers.Timer();
            feedtimer.Enabled = true;
            feedtimer.AutoReset = true;
            feedtimer.Elapsed += Timer_Elapsed;
            if(time_interval > 0)
            {
                feedtimer.Interval = time_interval * 1000;
                feedtimer.Start();
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateFeedDog(UpdateFeedDogTimeOut));
            }
        }
        private delegate void UpdateFeedDog();
        private void UpdateFeedDogTimeOut()
        {
            Console.WriteLine("timer feed dog:" +
                        DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") +
                        " TimerInterval:" + TimerInterval + " Timeout:" + Timeout);
            watchdog.FeedDog(Timeout);
            LogHelper.WriteLog("timer feed dog TimerInterval:" + TimerInterval + " Timeout:" + Timeout);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            String time_box = timeBox.Text;
            if (!ushort.TryParse(time_box, out ushort temp))
            {
                MessageBox.Show("Please enter 0 ~ 65535");
                return;
            }
            else
            {
                Timeout = Convert.ToUInt16(time_box);
                current.Text = time_box;
                Console.WriteLine("update time out val:" + Timeout);
                LogHelper.WriteLog("Update Time-out val:" + Timeout);
            }

            watchdog.StopWatchDog();
            feedtimer.Stop();

            watchdog.InitSuperIO();
            watchdog.EnableWatchDog();
            watchdog.ExitSuperIo();

            if (Timeout == 0)
            {
                TimerInterval = 0;
            }
            else if (Timeout == 1)
            {
                TimerInterval = 0.5;
            }
            else if (Timeout == 2)
            {
                TimerInterval = 1;
            }
            else
            {
                TimerInterval = (ushort)(Timeout - 2);
            }

            watchdog.FeedDog(Timeout);
            fsu.FileStreamWriteTimeout(TimePath, Timeout);

            Console.WriteLine("update feed dog:"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
                + ";TimerInterval:" + TimerInterval);
            LogHelper.WriteLog("update feed dog:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
                + ";TimerInterval:" + TimerInterval);
            if (TimerInterval > 0) {
                feedtimer.Interval = TimerInterval * 1000;
                feedtimer.Start();
            }
             
        }

        private void About_Click_1(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            HelpForm reademe = new HelpForm();
            reademe.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            ExitMainForm();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                
                this.Hide();
                this.MynotifyIcon.Visible = true;
            }
        }
        private void ExitMainForm()
        {
            if (exitForm == null)
            {
                exitForm = new ExitForm();
            }
            exitForm.ShowDialog();
        }

        private void ShowMainForm()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
                this.MynotifyIcon.Visible = false;
            }
        }

        private void MynotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowMainForm();
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitMainForm();
        }
    }
}
