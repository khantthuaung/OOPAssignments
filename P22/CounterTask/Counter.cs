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
            unchecked{
                    _count = (int)2147483647912;
            }
                //Answer to Q13
                //No, the code does not run — it throws a compile-time error.
                //The value 2147483647912 exceeds the maximum limit of the int data type in C#, 
                // which is 2,147,483,647. To store larger values, 
                // we must use a long data type or cast it with overflow handling (e.g., unchecked).
                //To fix this , we can use a long data type or handle the overflow.

                // The 'unchecked' block tells the compiler to ignore overflow errors,
                // so the large number wraps around and is stored as a negative int.
        }
    }
}