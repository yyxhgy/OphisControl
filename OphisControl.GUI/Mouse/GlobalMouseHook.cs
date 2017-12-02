﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OphisControl.GUI.Mouse
{
    public delegate void delGlobalMouseMove(GlobalMouseArgs e);
    public delegate void delGlobalMouseUp(GlobalMouseArgs e);
    public class GlobalMouseHook
    {
        public static event delGlobalMouseMove evtGlobalMouseMove;
        public static event delGlobalMouseMove evtGlobalMouseUp;

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        private LowLevelMouseProc _Proc;
        private IntPtr _HookId = IntPtr.Zero;
        private MSLLHOOKSTRUCT _HookStruct;

        public GlobalMouseHook()
        {
            Load();
        }
        ~GlobalMouseHook()
        {
            Stop();
        }
        private void Load()
        {
            _HookId = SetHook();
        }
        private IntPtr SetHook()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    _Proc = HookCallBack;
                    return SetWindowsHookEx(WH_MOUSE_LL, _Proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }
        private IntPtr HookCallBack(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 & MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam)
            {
                GlobalMouseArgs e = new GlobalMouseArgs();
                e.Position = new System.Windows.Point(_HookStruct.pt.x, _HookStruct.pt.y);
                e.Button = System.Windows.Input.MouseButton.Left;
                evtGlobalMouseUp?.Invoke(e);
            }
            return CallNextHookEx(_HookId, nCode, wParam, lParam);
        }
        public void Stop()
        {
            bool retMouse = true;
            if ((int)_HookId != 0)
            {
                UnhookWindowsHookEx(_HookId);
                _HookId = IntPtr.Zero;
            }
            //如果卸下钩子失败
            if (!retMouse) throw new Exception("UnhookWindowsHookEx failed.");
        }
        private const int WH_MOUSE_LL = 14;
        /// <summary>
        /// 鼠标左键状态
        /// </summary>
        private bool _LeftBtnPressed = false;
        /// <summary>
        /// 鼠标右键状态
        /// </summary>
        private bool _RightBtnPressed = false;
        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            MK_CONTROL = 0x0008
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT { public POINT pt; public uint mouseData; public uint flags; public uint time; public IntPtr dwExtraInfo; }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName); private void Window_Closed(object sender, EventArgs e) { UnhookWindowsHookEx(_HookId); }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        private static extern int GetKeyState(int keyCode);
    }
}
