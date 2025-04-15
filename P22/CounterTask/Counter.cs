namespace CounterTask
{
    public class Counter
    {
        private int _count;

        private string _name;
        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public void Increment()
        {
            _count++;
        }

        public void Reset()
        {
            _count = 0;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }

        }
        public int Ticks
        {
            get
            {
                return _count;
            }
        }
        public void ResetByDefault()
        {
            // unchecked allows a value that overflows int range without throwing an exception.
            unchecked
            {
                _count = (int)2147483647912;
                // value is beyond the max value of int
                // This wraps around and results in a negative value.
                // This does NOT crash the program.;
            }
        }
    }
}