using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace runner
{
    public static class Runner
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length != 3)
                args = File.ReadAllLines(Setting.ConfigFile);

            var username = args[0];
            var pwd = args[1];

            try
            {
                pwd = StringCipher.Decrypt(args[1], Setting.Password);
            }
            catch
            {
                Console.WriteLine("bad password");
            }

            
            for (int i = 2; i < args.Length; i++)
                DoWork(username, pwd, args[i]);
        }




        private static void SendLine(string str)
        {
            Send(str);
            SendKeys.SendWait("{Enter}");
        }
        private static void Send(string str)
        {
            foreach (var s in FixString(str))
            {
                try { SendKeys.SendWait("" + (char) s);}
                finally{ Thread.Sleep(10); }
            }
        }

        private static string FixString(string str)
        {
            return Regex.Replace(str, "[+^%~(){}]", "{$0}");
        }
        private static void SendPattern(string pattern, int delay = 500)
        {
            SendKeys.SendWait(pattern);
            Thread.Sleep(delay);
        }


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private static void DoWork(string username, string pwd, string exe)
        {
            if (string.IsNullOrEmpty(exe))
                return;

            try
            {
                Process p = Process.Start("runas", "/noprofile /user:" + username + " " + exe);
                Thread.Sleep(1000);

                SetForegroundWindow(p.MainWindowHandle);
                SendLine(pwd);

#if DEBUG
                doSomeFunWithNotePad(exe);
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }






        #region Some Fun

        private static void doSomeFunWithNotePad(string exe)  // this made for end-user-testing porpose
        {
            if (exe == "notepad")
            {
                while (Process.GetProcessesByName(exe).Length == 0)
                    Thread.Sleep(1000);

                SetForegroundWindow(LastTime(Process.GetProcessesByName(exe)).MainWindowHandle);
                Fun();
            }
        }

        private static Process LastTime(Process[] processes)
        {
            DateTime? dt = null;
            Process res = null;
            foreach (var p in processes)
            {
                if (dt == null)
                {
                    dt = p.StartTime;
                    res = p;
                }
                else if (dt < p.StartTime)
                {
                    dt = p.StartTime;
                    res = p;
                }
            }
            return res;
        }


        private static void Fun()
        {
            SendLine("\tmrapp was here\n");

            PaintAWall();


            SendPattern("^(a)");
            SendPattern("{backspace}");

            SendLine("Good bye");

            SendPattern("%{F4}");
            SendPattern("{right}");
            SendPattern("{enter}");
        }

        private static void PaintAWall()
        {
            SendLine(@"     /\/\/\/\/\/\/\/\/\/\/\/\/\");
            SendLine(@"     /\/\/\/\/\/\/\/\/\/\/\/\/\");
            SendLine(@"     /\/\/\/\/\/\/\/\/\/\/\/\/\");
            SendLine(@"     /\/\/\/\/\/\/\/\/\/\/\/\/\");
        }

        #endregion
    }
}
