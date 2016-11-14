using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Fast_Exec
{
    class KeyboardHooker : IDisposable
    {
        public event EventHandler<bool> ExecuteListening;
        public event EventHandler<char> ExecuteButtonPressed;

        public KeyboardHooker()
        {
            SetHook();
        }

        public void Resume()
        {
            SetHook();
        }

        public void Pause()
        {
            Unhook();
        }
        
        public void Dispose()
        {
            Unhook();
        }

        bool lctrl = false;
        bool rctrl = false;
        bool readingKey = false;
        private void KeyPressed(KeyboardHookStruct Data)
        {
            if (lctrl && rctrl)
            {
                readingKey = !readingKey;
                ExecuteListening?.Invoke(this, readingKey);
            }
            else if (readingKey && Data.VirtualKeyCode != 162 && Data.VirtualKeyCode != 163)
            {
                readingKey = false;
                var key = char.ConvertFromUtf32(Data.VirtualKeyCode).ToCharArray().FirstOrDefault();
                ExecuteButtonPressed?.Invoke(this, key);
            }

            if (Data.VirtualKeyCode == 162 && Data.Flags == 0)
                lctrl = true;
            else if (Data.VirtualKeyCode == 162 && Data.Flags == 128)
                lctrl = false;

            if (Data.VirtualKeyCode == 163 && Data.Flags == 1)
                rctrl = true;
            else if (Data.VirtualKeyCode == 163 && Data.Flags == 129)
                rctrl = false;
        }

        #region Логика перехвата и страшные винапишные штуки

        private const int WH_KEYBOARD_LL = 13;

        private LowLevelKeyboardProcDelegate m_callback;
        private IntPtr m_hHook;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(
            int idHook,
            LowLevelKeyboardProcDelegate lpfn,
            IntPtr hMod, int dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(IntPtr lpModuleName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CallNextHookEx(
            IntPtr hhk,
            int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(
        [In] IntPtr hWnd,
        [Out, Optional] IntPtr lpdwProcessId
        );

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern ushort GetKeyboardLayout(
            [In] int idThread
            );

        public ushort GetKeyboardLayout()
        {
            return GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero));
        }

        private IntPtr LowLevelKeyboardHookProccessing(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return CallNextHookEx(m_hHook, nCode, wParam, lParam);
            }
            else
            {
                var khs = (KeyboardHookStruct)
                          Marshal.PtrToStructure(lParam,
                          typeof(KeyboardHookStruct));

                KeyPressed(khs);
                return CallNextHookEx(m_hHook, nCode, wParam, lParam);
            }
        }

        // Структура кнопки
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardHookStruct
        {
            public readonly int VirtualKeyCode;
            public readonly int ScanCode;
            public readonly int Flags;
            public readonly int Time;
            public readonly IntPtr ExtraInfo;
        }

        private delegate IntPtr LowLevelKeyboardProcDelegate(
            int nCode, IntPtr wParam, IntPtr lParam);

        public void SetHook()
        {
            m_callback = LowLevelKeyboardHookProccessing;
            m_hHook = SetWindowsHookEx(WH_KEYBOARD_LL, m_callback, GetModuleHandle(IntPtr.Zero), 0);
        }
        public void Unhook()
        {
            UnhookWindowsHookEx(m_hHook);
        }
        #endregion
    }
}
