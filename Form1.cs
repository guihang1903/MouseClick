using System.Runtime.InteropServices;

namespace MouseClick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mesg.Text = "";
            startTime.Text = "";
            lastEndTime.Text = "";
            clickNumber.Text = "0";
            // 设置键盘钩子
            _keyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookCallback, IntPtr.Zero, 0);
        }

        // 导入 Windows API 函数
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

        // 导入 user32.dll 中的方法
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        // 导入 user32.dll 中的方法
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        // 导入 user32.dll 中的方法
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        // 委托类型 HookProc
        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        // 鼠标事件常量
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;
        // 键盘事件常量
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        // 全局变量，存储鼠标是否正在连续点击
        private bool isRunning = false, isStart = false;
        // 键盘钩子句柄
        private IntPtr _keyboardHook;
        //语言设置
        private string language = "chinese";
        private long clickNum = 0;

        // 键盘钩子回调函数
        private static IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                if (keyCode == (int)Keys.F9)
                {
                    // 按下 F9 键开始连续点击鼠标
                    ((Form1)Application.OpenForms[0]).StartClick.PerformClick();
                }
                else if (keyCode == (int)Keys.F10)
                {
                    // 按下 F10 键停止连续点击鼠标
                    ((Form1)Application.OpenForms[0]).EndClick.PerformClick();
                }
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (isStart == false)
            {
                bool start_or_end = false;
                uint downFlag = MOUSEEVENTF_LEFTDOWN,
                     upFlag = MOUSEEVENTF_LEFTUP;
                if (radioLeft.Checked)
                {
                    start_or_end = true;
                    downFlag = MOUSEEVENTF_LEFTDOWN;
                    upFlag = MOUSEEVENTF_LEFTUP;
                }
                if (radioRgiht.Checked)
                {
                    start_or_end = true;
                    downFlag = MOUSEEVENTF_RIGHTDOWN;
                    upFlag = MOUSEEVENTF_RIGHTUP;
                }
                if (start_or_end && IntervalTime.Text.Length > 0)
                {
                    isStart = true;
                    mesg.Text = "";
                    clickNum = 0;
                    startTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    radioLeft.Enabled = false;
                    radioRgiht.Enabled = false;
                    IntervalTime.Enabled = false;
                    clickCount.Enabled = false;
                    EndClick.Enabled = true;
                    StartClick.Enabled = false;

                    int delay = int.Parse(IntervalTime.Text);

                    isRunning = true;
                    if (clickCount.Text.Length > 0)
                    {
                        int count = int.Parse(clickCount.Text);
                        Task.Run(() =>
                        {
                            while (isRunning && count > 0)
                            {
                                mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                                mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                                Task.Delay(delay).Wait();
                                count--;
                                clickNumber.Text = (++clickNum).ToString();
                            }
                            EndClick.PerformClick();
                        });
                    }
                    else
                    {
                        Task.Run(() =>
                        {
                            while (isRunning)
                            {
                                mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                                mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                                Task.Delay(delay).Wait();
                                clickNumber.Text = (++clickNum).ToString();
                            }
                        });
                    }
                }
                else
                {
                    switch (language)
                    {
                        case "chinese":
                            mesg.Text = "请输入点击间隔或点击方法!";
                            break;
                        case "english":
                            mesg.Text = "Input interval or method!";
                            break;
                        default:
                            mesg.Text = "请输入点击间隔或点击方法!";
                            break;
                    }
                }
            }
        }

        private void EndClick_Click(object sender, EventArgs e)
        {
            if (isStart)
            {
                isStart = false;
                startTime.Text = "";
                radioLeft.Enabled = true;
                radioRgiht.Enabled = true;
                IntervalTime.Enabled = true;
                clickCount.Enabled = true;
                EndClick.Enabled = false;
                StartClick.Enabled = true;
                isRunning = false;
                lastEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 关闭键盘钩子
            UnhookWindowsHookEx(_keyboardHook);
        }

        private void ChineseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            language = "chinese";
            label1.Text = "点击间隔";
            label2.Text = "点击次数";
            label3.Text = "点击方式";
            label4.Text = "开始时间";
            label5.Text = "点击次数";
            label6.Text = "上次结束时间";
            radioLeft.Text = "左键";
            radioRgiht.Text = "右键";
            StartClick.Text = "开始点击(F9)";
            EndClick.Text = "停止点击(F10)";
            settingsToolStripMenuItem.Text = "设置";
            languageToolStripMenuItem.Text = "语言";

        }

        private void EnglishToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            language = "english";
            label1.Text = "interval";
            label2.Text = "Number";
            label3.Text = "method";
            label4.Text = "Start time";
            label5.Text = "Click number";
            label6.Text = "Last stoptime";
            radioLeft.Text = "Left";
            radioRgiht.Text = "Right";
            StartClick.Text = "Start(F9)";
            EndClick.Text = "Stop(F10)";
            settingsToolStripMenuItem.Text = "Settings";
            languageToolStripMenuItem.Text = "Language";
        }
    }
}