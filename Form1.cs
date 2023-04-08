using System.Runtime.InteropServices;

namespace MouseClick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 设置键盘钩子
            _keyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookCallback, IntPtr.Zero, 0);
        }

        // 导入 Windows API 函数
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

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

        private void Start_Click(object sender, EventArgs e)
        {
            if (isStart == false)
            {
                isStart = true;
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
                    startTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    radioLeft.Enabled = false;
                    radioRgiht.Enabled = false;
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
                            }
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
                            }
                        });
                    }
                }
                else
                {
                    mesg.Text = "未选择点击方式或未输入点击间隔!";
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
                EndClick.Enabled = false;
                StartClick.Enabled = true;
                isRunning = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 关闭键盘钩子
            UnhookWindowsHookEx(_keyboardHook);
        }
    }
}