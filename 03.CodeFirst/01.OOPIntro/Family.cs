namespace _01.OOPIntro
{
    using System;
    using System.Collections.Generic;

    class Family
    {
        private List<Person> people;
        public Family()
        {
            this.people = new List<Person>();
        }
        
        public void AddMember(Person member)
        {
            this.people.Add(member);
        }
        public Person GetOldestMember()
        {
            if (this.people.Count==0)
            {
                throw new Exception("No family members.");
            }
            int maxAge=int.MinValue;
            Person oldestPerson=null;
            foreach (var person in this.people)
            {
                if (person.Age > maxAge)
                {
                    maxAge = person.Age;
                    oldestPerson = person;
                }
            }
            return oldestPerson;

        }
    }
}
