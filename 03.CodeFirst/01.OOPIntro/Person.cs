namespace _01.OOPIntro
{
    class Person
    {
        private string name;
        private int age;

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age= age;
        }

        public Person() : this("No name", 1) { }
        public Person(int age) : this("No name", age) { }
        public Person(string name) : this(name, 1) { }

    }
}
