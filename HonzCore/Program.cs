using System;

namespace HonzCore
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            HonzCore.Main.HonzCoreMain.instance.Run(new Game1());
        }
    }
#endif
}
