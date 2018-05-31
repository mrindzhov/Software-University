namespace _01.OOPIntro
{
    class Student
    {
        private string name;
        private static int counter;

        public static int Counter
        {
            get
            {
                return counter;
            }
        }

        public Student(string name)
        {
            this.name = name;
            ++counter;
        }

    }
}
