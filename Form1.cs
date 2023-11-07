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
            // ���ü��̹��� 
            _keyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookCallback, IntPtr.Zero, 0);
        }

        // ���� Windows API ����
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

        // ���� user32.dll �еķ���
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        //��ȡ��ǰ���㴰�ڵľ��
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        //��ȡ���ڱ���
        [DllImport("user32", SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        //ʹ�� ScreenToClient() ��������Ļ����ת��Ϊ����������
        [DllImport("user32.dll")]
        static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        //ʹ�� GetCursorPos() ������ȡ��ǰ������Ļ����
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpPoint);

        // ί������ HookProc
        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        struct RECT
        {
            public int Left;        //��������
            public int Top;         //��������
            public int Right;       //��������
            public int Bottom;      //��������
        }
        // ����һ�� POINT �ṹ�壬���ڴ洢����
        struct POINT
        {
            public int x;
            public int y;
        }
        // ����¼�����
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;
        // �����¼�����
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        // ��ǰ���㴰�ھ��
        private IntPtr targetHandle;
        // ȫ�ֱ������洢����Ƿ������������
        private bool isRunning = false, isStart = false;
        // ���̹��Ӿ��
        private IntPtr _keyboardHook;
        // ��������
        private string language = "chinese";
        // ͳ�Ƶ������
        private long clickNum = 0;

        // ���̹��ӻص�����
        private static IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int keyCode = Marshal.ReadInt32(lParam);
                if (keyCode == (int)Keys.F9)
                {
                    // ���� F9 ����ʼ����������
                    ((Form1)Application.OpenForms[0]).StartClick.PerformClick();
                }
                else if (keyCode == (int)Keys.F10)
                {
                    // ���� F10 ��ֹͣ����������
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
                        "chinese" => "X��Y����Ϊ��",
                        "english" => "X and Y cannot be empty",
                        _ => "error",
                    };
                    MessageBox.Show(msg, "��ʾ");
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
                    //��ȡ������ʱ��
                    int delay = int.Parse(IntervalTime.Text);

                    isRunning = true;

                    //�������������ģʽ�Ļ�
                    if (lockCheckBox.Checked)
                    {
                        //��ȡ��ǰ�������ڴ��ڵľ��
                        targetHandle = GetForegroundWindow();
                        StringBuilder title = new StringBuilder(256);
                        GetWindowText(targetHandle, title, title.Capacity);//�õ����ڵı��� 
                        label9.Text = title.Append($"��{targetHandle.ToString()}��").ToString();
                        if (targetHandle == IntPtr.Zero)
                        {
                            string msg = language switch
                            {
                                "chinese" => "��ѡ��һ�����ں��ٿ�ʼ!",
                                "english" => "Please select a target window first.",
                                _ => "error",
                            };
                            MessageBox.Show(msg, "��ʾ");
                            return;
                        }
                        // ��ȡ����λ��
                        RECT rect;
                        GetWindowRect(targetHandle, out rect);
                        // ��ȡ��ǰ������Ļ����
                        GetCursorPos(out POINT p);
                        // ����Ļ����ת��Ϊ����������
                        //ScreenToClient(hWnd, ref p);


                        int x = Convert.ToInt32(randomX.Text);
                        int y = Convert.ToInt32(randomY.Text);

                        //�ж��Ƿ����Ƶ������
                        if (clickCount.Text.Length > 0)
                        {
                            int count = int.Parse(clickCount.Text);
                            //�ж��Ƿ�������ͳ��
                            if (clickNumCheckBox.Checked)
                            {
                                //�Ƿ�������ƶ����
                                if (randomMoveCheckBox.Checked)
                                {
                                    Start_MouseClick(downFlag, upFlag, delay, count, clickNum, p, x, y);
                                }
                                else
                                {
                                    //���ƴ���������
                                    Start_MouseClick(downFlag, upFlag, delay, count, clickNum, p);
                                }
                            }
                            else
                            {
                                //�Ƿ�������ƶ����
                                if (randomMoveCheckBox.Checked)
                                {
                                    Start_MouseClick(downFlag, upFlag, delay, count, p, x, y);
                                }
                                else
                                {
                                    //���ƴ���ģʽ
                                    Start_MouseClick(downFlag, upFlag, delay, count, p);
                                }
                            }
                        }
                        else
                        {
                            //�ж��Ƿ�������ͳ��
                            if (clickNumCheckBox.Checked)
                            {
                                //�Ƿ�������ƶ����
                                if (randomMoveCheckBox.Checked)
                                {
                                    Start_MouseClick(downFlag, upFlag, delay, clickNum, p, x, y);
                                }
                                else
                                {
                                    //����
                                    Start_MouseClick(downFlag, upFlag, delay, clickNum, p);
                                }
                            }
                            else
                            {
                                //�Ƿ�������ƶ����
                                if (randomMoveCheckBox.Checked)
                                {

                                    //����ģʽ��������ƶ�
                                    Start_MouseClick(downFlag, upFlag, delay, p, x, y);
                                }
                                else
                                {
                                    //����ģʽ
                                    Start_MouseClick(downFlag, upFlag, delay, p);
                                }
                            }
                        }
                    }
                    else
                    {
                        //�ж��Ƿ����Ƶ������
                        if (clickCount.Text.Length > 0)
                        {
                            int count = int.Parse(clickCount.Text);
                            //�ж��Ƿ�������ͳ��
                            if (clickNumCheckBox.Checked)
                            {
                                //���ƴ���������
                                Start_MouseClick(downFlag, upFlag, delay, count, clickNum);
                            }
                            else
                            {
                                //���ƴ���ģʽ
                                Start_MouseClick(downFlag, upFlag, delay, count);
                            }
                        }
                        else
                        {
                            //�ж��Ƿ�������ͳ��
                            if (clickNumCheckBox.Checked)
                            {
                                //����
                                Start_MouseClick(downFlag, upFlag, delay, clickNum);
                            }
                            else
                            {
                                //����ģʽ
                                Start_MouseClick(downFlag, upFlag, delay);
                            }
                        }
                    }
                }
                else
                {
                    string msg = language switch
                    {
                        "chinese" => "�������������������!",
                        "english" => "Input interval or method!",
                        _ => "�������������������!",
                    };
                    MessageBox.Show(msg, "��ʾ");
                }
            }
        }

        #region ����ģʽ
        /// <summary>
        /// �������ģʽ
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
        /// �������ģʽ�����Ӽ���
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
        /// ���ƴ���ģʽ
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
        /// ���ƴ���ģʽ�����Ӽ���
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

        #region ����ģʽ
        /// <summary>
        /// �������������ģʽ
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
        /// ������������Ӽ���������ģʽ
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
        /// ���ƴ���������ģʽ
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
        /// ���ƴ��������Ӽ���������ģʽ
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

        #region ����ģʽ������ƶ�
        /// <summary>
        /// �������������ģʽ
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
        /// ������������Ӽ���������ģʽ
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
        /// ���ƴ���������ģʽ
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
        /// ���ƴ��������Ӽ���������ģʽ
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
            // �رռ��̹���
            UnhookWindowsHookEx(_keyboardHook);
        }

        private void ChineseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            language = "chinese";
            label1.Text = "������";
            label2.Text = "�������";
            label3.Text = "�����ʽ";
            label4.Text = "��ʼʱ��";
            label5.Text = "�������";
            label6.Text = "����ʱ��";
            label7.Text = "����";
            label8.Text = "�������";
            lockCheckBox.Text = "����";
            randomMoveCheckBox.Text = "�ڴ���������ƶ����";
            label10.Text = "�ƶ���Χ";
            clickNumCheckBox.Text = "����ͳ��";
            radioLeft.Text = "���";
            radioRgiht.Text = "�Ҽ�";
            StartClick.Text = "��ʼ���(F9)";
            EndClick.Text = "ֹͣ���(F10)";
            settingsToolStripMenuItem.Text = "����";
            languageToolStripMenuItem.Text = "����";

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
        /// �ж��Ƿ�������
        /// </summary>
        /// <param name="key">���������</param>
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