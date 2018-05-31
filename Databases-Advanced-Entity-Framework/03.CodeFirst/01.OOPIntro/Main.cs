namespace _01.OOPIntro
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            #region//Create Person Constructor
            //string[] input = Console.ReadLine().Split(',').ToArray();
            //Person person = null;
            //person = ParseInput(input);
            //Console.WriteLine(person.Name + " " + person.Age);
            #endregion
            #region//Oldest Family Member
            //int rows = int.Parse(Console.ReadLine());
            //Family family = new Family();
            //for (int i = 0; i < rows; i++)
            //{
            //    string[] input = Console.ReadLine().Split(' ').ToArray();
            //    Person person = ParseInput(input);
            //    family.AddMember(person);
            //}
            //try
            //{
            //    Person oldest = family.GetOldestMember();
            //    Console.WriteLine("The oldest is: " + oldest.Name + " " + oldest.Age);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            #endregion
            #region//Get Students Count
            //    string student = Console.ReadLine();
            //while (!student.Equals("End"))
            //{
            //    Student stdnt = new Student(student);
            //    student = Console.ReadLine();
            //}
            //Console.WriteLine(Student.Counter);
            #endregion
            #region//Get Reduced Plank 
            //Console.WriteLine(Calculation.ReducePlanck());
            #endregion
            #region//Math Utilities
            //string[] input = Console.ReadLine().Split(' ').ToArray();
            //while (!input[0].Equals("End"))
            //{
            //    PrintResult(input);
            //    input = Console.ReadLine().Split(' ').ToArray();
            //}
            #endregion
        }

        private static void PrintResult(string[] input)
        {
            float firstNum = float.Parse(input[1]);
            float secondNum = float.Parse(input[2]);
            float result = 0;

            switch (input[0])
            {
                case "Sum":
                    result = MathUtil.Sum(firstNum, secondNum);
                    break;
                case "Multiply":
                    result = MathUtil.Multiply(firstNum, secondNum);
                    break;
                case "Divide":
                    result = MathUtil.Divide(firstNum, secondNum);
                    break;
                case "Percentage":
                    result = MathUtil.Percentage(firstNum, secondNum);
                    break;
                case "Subtract":
                    result = MathUtil.Subtract(firstNum, secondNum);
                    break;
            }
            Console.WriteLine($"{result:f2}");
        }
        private static Person ParseInput(string[] input)
        {
            Person person;
            int n;
            bool isNumeric = int.TryParse(input[0], out n);
            if (input.Length == 2)
            {
                person = new Person(input[0], int.Parse(input[1]));

            }
            else if (input.Length == 1)
            {
                if (isNumeric)
                {
                    person = new Person(int.Parse(input[0]));
                }
                else
                {
                    person = new Person(input[0]);
                }
            }
            else
            {
                person = new Person();
            }

            return person;
        }
    }
}