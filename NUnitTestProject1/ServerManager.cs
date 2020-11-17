using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    public static class ServerManager
    {
        public static void start()
        {
            string strCmdText;
            strCmdText = "java -jar runTodoManagerRestAPI-1.5.5.jar";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }

        public static void close()
        {

        }

        public static void shutdown()
        {

        }
        public static void isworking()
        {

        }

    }

}
