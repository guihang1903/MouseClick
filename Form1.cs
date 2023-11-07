using System.Runtime.InteropServices;
using System.Text;

namespace MouseClick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label9.Text = "";
            startTime.Text = "";
            lastEndTime.Text = "";
            clickNumber.Text = "";
            // 设置键盘钩子 
            _keyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookCallback, IntPtr.Zero, 0);
        }

        // 导入 Windows API 函数
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

        // 导入 user32.dll 中的方法
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        //获取当前焦点窗口的句柄
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        //获取窗口标题
        [DllImport("user32", SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        //使用 ScreenToClient() 函数将屏幕坐标转换为窗口内坐标
        [DllImport("user32.dll")]
        static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        //使用 GetCursorPos() 函数获取当前鼠标的屏幕坐标
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpPoint);

        // 委托类型 HookProc
        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        struct RECT
        {
            public int Left;        //最左坐标
            public int Top;         //最上坐标
            public int Right;       //最右坐标
            public int Bottom;      //最下坐标
        }
        // 定义一个 POINT 结构体，用于存储坐标
        struct POINT
        {
            public int x;
            public int y;
        }
        // 鼠标事件常量
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;
        // 键盘事件常量
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        // 当前焦点窗口句柄
        private IntPtr targetHandle;
        // 全局变量，存储鼠标是否正在连续点击
        private bool isRunning = false, isStart = false;
        // 键盘钩子句柄
        private IntPtr _keyboardHook;
        // 语言设置
        private string language = "chinese";
        // 统计点击次数
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
                if (randomX.Text.Length == 0 || randomX.Text.Length == 0)
                {
                    string msg = language switch
                    {
                        "chinese" => "X和Y不能为空",
                        "english" => "X and Y cannot be empty",
                        _ => "error",
                    };
                    MessageBox.Show(msg, "提示");
                    return;
                }
                lastEndTime.Text = "";
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
                    clickNum = 0;
                    clickNumber.Text = "";
                    startTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    radioLeft.Enabled = false;
                    radioRgiht.Enabled = false;
                    IntervalTime.Enabled = false;
                    clickCount.Enabled = false;
                    EndClick.Enabled = true;
                    StartClick.Enabled = false;
                    //获取点击间隔时间
                    int delay = int.Parse(IntervalTime.Text);

                    isRunning = true;

                    //如果开启了锁定模式的话
                    if (lockCheckBox.Checked)
                    {
                        //获取当前焦点所在窗口的句柄
                        targetHandle = GetForegroundWindow();
                        StringBuilder title = new StringBuilder(256);
                        GetWindowText(targetHandle, title, title.Capacity);//得到窗口的标题 
                        label9.Text = title.Append($"（{targetHandle.ToString()}）").ToString();
                        if (targetHandle == IntPtr.Zero)
                        {
                            string msg = language switch
                            {
                                "chinese" => "请选择一个窗口后再开始!",
                                "english" => "Please select a target window first.",
                                _ => "error",
                            };
                            MessageBox.Show(msg, "提示");
                            return;
                        }
                        // 获取窗口位置
                        RECT rect;
                        GetWindowRect(targetHandle, out rect);
                        // 获取当前鼠标的屏幕坐标
                        GetCursorPos(out POINT p);
                        // 将屏幕坐标转换为窗口内坐标
                        //ScreenToClient(hWnd, ref p);


                        int x = Convert.ToInt32(randomX.Text);
                        int y = Convert.ToInt32(randomY.Text);

                        //判断是否限制点击次数
                        if (clickCount.Text.Length > 0)
                        {
                            int count = int.Parse(clickCount.Text);
                            //判断是否开启数字统计
                            if (clickNumCheckBox.Checked)
                            {
                                //是否开启随机移动鼠标
                                if (randomMoveCheckBox.Checked)
                                {
                                    Start_MouseClick(downFlag, upFlag, delay, count, clickNum, p, x, y);
                                }
                                else
                                {
                                    //限制次数并计数
                                    Start_MouseClick(downFlag, upFlag, delay, count, clickNum, p);
                                }
                            }
                            else
                            {
                                //是否开启随机移动鼠标
                                if (randomMoveCheckBox.Checked)
                                {
                                    Start_MouseClick(downFlag, upFlag, delay, count, p, x, y);
                                }
                                else
                                {
                                    //限制次数模式
                                    Start_MouseClick(downFlag, upFlag, delay, count, p);
                                }
                            }
                        }
                        else
                        {
                            //判断是否开启数字统计
                            if (clickNumCheckBox.Checked)
                            {
                                //是否开启随机移动鼠标
                                if (randomMoveCheckBox.Checked)
                                {
                                    Start_MouseClick(downFlag, upFlag, delay, clickNum, p, x, y);
                                }
                                else
                                {
                                    //计数
                                    Start_MouseClick(downFlag, upFlag, delay, clickNum, p);
                                }
                            }
                            else
                            {
                                //是否开启随机移动鼠标
                                if (randomMoveCheckBox.Checked)
                                {

                                    //正常模式，并随机移动
                                    Start_MouseClick(downFlag, upFlag, delay, p, x, y);
                                }
                                else
                                {
                                    //正常模式
                                    Start_MouseClick(downFlag, upFlag, delay, p);
                                }
                            }
                        }
                    }
                    else
                    {
                        //判断是否限制点击次数
                        if (clickCount.Text.Length > 0)
                        {
                            int count = int.Parse(clickCount.Text);
                            //判断是否开启数字统计
                            if (clickNumCheckBox.Checked)
                            {
                                //限制次数并计数
                                Start_MouseClick(downFlag, upFlag, delay, count, clickNum);
                            }
                            else
                            {
                                //限制次数模式
                                Start_MouseClick(downFlag, upFlag, delay, count);
                            }
                        }
                        else
                        {
                            //判断是否开启数字统计
                            if (clickNumCheckBox.Checked)
                            {
                                //计数
                                Start_MouseClick(downFlag, upFlag, delay, clickNum);
                            }
                            else
                            {
                                //正常模式
                                Start_MouseClick(downFlag, upFlag, delay);
                            }
                        }
                    }
                }
                else
                {
                    string msg = language switch
                    {
                        "chinese" => "请输入点击间隔或点击方法!",
                        "english" => "Input interval or method!",
                        _ => "请输入点击间隔或点击方法!",
                    };
                    MessageBox.Show(msg, "提示");
                }
            }
        }

        #region 正常模式
        /// <summary>
        /// 正常点击模式
        /// </summary>
        private void Start_MouseClick(uint downFlag, uint upFlag, int delay)
        {
            Task.Run(() =>
            {
                while (isRunning)
                {
                    mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                    mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                    //Task.Delay(delay).Wait();
                    Thread.Sleep(delay);
                }
            });
        }
        /// <summary>
        /// 正常点击模式，增加计数
        /// </summary>
        private void Start_MouseClick(uint downFlag, uint upFlag, int delay, long clickNum)
        {
            Task.Run(() =>
            {
                while (isRunning)
                {
                    mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                    mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                    //Task.Delay(delay).Wait();
                    Thread.Sleep(delay);
                    clickNumber.Text = (++clickNum).ToString();
                }
            });
        }
        /// <summary>
        /// 限制次数模式
        /// </summary>
        private void Start_MouseClick(uint downFlag, uint upFlag, int delay, int count)
        {
            Task.Run(() =>
            {
                while (isRunning && count > 0)
                {
                    mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                    mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                    //Task.Delay(delay).Wait();
                    Thread.Sleep(delay);
                    count--;
                }
                EndClick.PerformClick();
            });
        }
        /// <summary>
        /// 限制次数模式，增加计数
        /// </summary>
        private void Start_MouseClick(uint downFlag, uint upFlag, int delay, int count, long clickNum)
        {
            Task.Run(() =>
            {
                while (isRunning && count > 0)
                {
                    mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                    mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                    //Task.Delay(delay).Wait();
                    Thread.Sleep(delay);
                    clickNumber.Text = (++clickNum).ToString();
                    count--;
                }
                EndClick.PerformClick();
            });
        }
        #endregion

        #region 锁定模式
        /// <summary>
        /// 正常点击，锁定模式
        /// </summary>
        private void Start_MouseClick(uint downFlag, uint upFlag, int delay, POINT p)
        {
            Task.Run(() =>
            {
                while (isRunning)
                {
                    SetCursorPos(p.x, p.y);
                    mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                    mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                    //Task.Delay(delay).Wait();
                    Thread.Sleep(delay);
                }
            });
        }
        /// <summary>
        /// 正常点击，增加计数，锁定模式
        /// </summary>
        private void Start_MouseClick(uint downFlag, uint upFlag, int delay, long clickNum, POINT p)
        {
            Task.Run(() =>
            {
                while (isRunning)
                {
                    SetCursorPos(p.x, p.y);
                    mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                    mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                    //Task.Delay(delay).Wait();
                    Thread.Sleep(delay);
                    clickNumber.Text = (++clickNum).ToString();
                }
            });
        }
        /// <summary>
        /// 限制次数，锁定模式
        /// </summary>
        private void Start_MouseClick(uint downFlag, uint upFlag, int delay, int count, POINT p)
        {
            Task.Run(() =>
            {
                while (isRunning && count > 0)
                {
                    SetCursorPos(p.x, p.y);
                    mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                    mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                    //Task.Delay(delay).Wait();
                    Thread.Sleep(delay);
                    count--;
                }
                EndClick.PerformClick();
            });
        }
        /// <summary>
        /// 限制次数，增加计数，锁定模式
        /// </summary>
        private void Start_MouseClick(uint downFlag, uint upFlag, int delay, int count, long clickNum, POINT p)
        {
            Task.Run(() =>
            {
                while (isRunning)
                {
                    SetCursorPos(p.x, p.y);
                    mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                    mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                    //Task.Delay(delay).Wait();
                    Thread.Sleep(delay);
                    count--;
                    clickNumber.Text = (++clickNum).ToString();
                }
                EndClick.PerformClick();
            });
        }
        #endregion

        #region 锁定模式，随机移动
        /// <summary>
        /// 正常点击，锁定模式
        /// </summary>
        private void Start_MouseClick(uint downFlag, uint upFlag, int delay, POINT p, int rectX, int rectY)
        {
            Task.Run(() =>
            {
                while (isRunning)
                {
                    SetCursorPos(p.x + Random.Shared.Next(1, rectX), p.y + Random.Shared.Next(1, rectY));
                    mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                    mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                    //Task.Delay(delay).Wait();
                    Thread.Sleep(delay);
                }
            });
        }
        /// <summary>
        /// 正常点击，增加计数，锁定模式
        /// </summary>
        private void Start_MouseClick(uint downFlag, uint upFlag, int delay, long clickNum, POINT p, int rectX, int rectY)
        {
            Task.Run(() =>
            {
                while (isRunning)
                {
                    SetCursorPos(p.x + Random.Shared.Next(1, rectX), p.y + Random.Shared.Next(1, rectY));
                    mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                    mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                    //Task.Delay(delay).Wait();
                    Thread.Sleep(delay);
                    clickNumber.Text = (++clickNum).ToString();
                }
            });
        }
        /// <summary>
        /// 限制次数，锁定模式
        /// </summary>
        private void Start_MouseClick(uint downFlag, uint upFlag, int delay, int count, POINT p, int rectX, int rectY)
        {
            Task.Run(() =>
            {
                while (isRunning && count > 0)
                {
                    SetCursorPos(p.x + Random.Shared.Next(1, rectX), p.y + Random.Shared.Next(1, rectY));
                    mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                    mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                    //Task.Delay(delay).Wait();
                    Thread.Sleep(delay);
                    count--;
                }
                EndClick.PerformClick();
            });
        }
        /// <summary>
        /// 限制次数，增加计数，锁定模式
        /// </summary>
        private void Start_MouseClick(uint downFlag, uint upFlag, int delay, int count, long clickNum, POINT p, int rectX, int rectY)
        {
            Task.Run(() =>
            {
                while (isRunning && count > 0)
                {
                    SetCursorPos(p.x + Random.Shared.Next(1, rectX), p.y + Random.Shared.Next(1, rectY));
                    mouse_event(downFlag, 0, 0, 0, (IntPtr)0);
                    mouse_event(upFlag, 0, 0, 0, (IntPtr)0);
                    //Task.Delay(delay).Wait();
                    Thread.Sleep(delay);
                    count--;
                    clickNumber.Text = (++clickNum).ToString();
                }
                EndClick.PerformClick();
            });
        }
        #endregion

        private void EndClick_Click(object sender, EventArgs e)
        {
            if (isStart)
            {
                isStart = false;
                label9.Text = "";
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
            label6.Text = "结束时间";
            label7.Text = "毫秒";
            label8.Text = "锁定鼠标";
            lockCheckBox.Text = "开启";
            randomMoveCheckBox.Text = "在窗口内随机移动鼠标";
            label10.Text = "移动范围";
            clickNumCheckBox.Text = "开启统计";
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
            label6.Text = "Stop time";
            label7.Text = "ms";
            label8.Text = "LockMouse";
            lockCheckBox.Text = "open";
            randomMoveCheckBox.Text = "Randomly move the mouse";
            label10.Text = "MoveRange";
            clickNumCheckBox.Text = "Statistics";
            radioLeft.Text = "Left";
            radioRgiht.Text = "Right";
            StartClick.Text = "Start(F9)";
            EndClick.Text = "Stop(F10)";
            settingsToolStripMenuItem.Text = "Settings";
            languageToolStripMenuItem.Text = "Language";
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Hide();
            notifyIcon1.Visible = true;
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void RandomMoveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (randomMoveCheckBox.Checked)
            {
                randomX.Enabled = true;
                randomY.Enabled = true;
            }
            else
            {
                randomX.Enabled = false;
                randomY.Enabled = false;
            }
        }
        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="key">输入的内容</param>
        /// <returns></returns>
        private static bool Is_Number(int key)
        {
            return (key < '0' || key > '9') && (key != 8);
        }

        private void RandomX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Is_Number(e.KeyChar))
                e.Handled = true;
        }

        private void RandomY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Is_Number(e.KeyChar))
                e.Handled = true;
        }

        private void SuperCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (lockCheckBox.Checked)
            {
                randomMoveCheckBox.Enabled = true;
            }
            else
            {
                randomMoveCheckBox.Enabled = false;
            }
        }
    }
}