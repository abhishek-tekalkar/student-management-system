namespace SMS
{
    public static class GlobalService
    {
        private static int _counter = 0;

        public static string GetNextNumber()
        {
            _counter++;
            return _counter.ToString();
        }
    }
}
