namespace Steelsa
{
    public static class StatusConsole
    {
        private static IStatusConsole _console;
        public static void Initialize(IStatusConsole console)
        {
            _console = console;
        }

        public static void WriteLine(string message, params object[] args)
        {
            if (_console == null) {
                System.Diagnostics.Trace.WriteLine("状态控制台(StatusConsole)未初始化!");
                return;
            }
            var msg = string.Format(message, args);
            _console.ShowMessage(msg);
        }

        public static void WriteReady()
        {
            _console.ShowMessage("就绪");
        }

        public static object ShowFlyout()
        {
            return _console.ShowFlyout();
        }
        public static void CloseFlyout()
        {
            _console.CloseFlyout();
        }
    }

    public interface IStatusConsole
    {
        void ShowMessage(string msg);
        object ShowFlyout();
        void CloseFlyout();
    }
}
