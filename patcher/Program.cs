
using System;
using System.IO;
using patcher;


class Program
{
    static void Main()
    {
        Logic httpdebugger = new Logic("HTTPDebuggerUI.exe", "HTTPDebuggerUIPatched.exe");
        httpdebugger.Patch1();
        httpdebugger.Patch2();
        httpdebugger.Patch3();
        httpdebugger.Save();
        Console.ReadKey();
    }
}