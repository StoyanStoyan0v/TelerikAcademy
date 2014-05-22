namespace PersonCreator
{
    public class PersonCreator
    {
        enum Gender
        {
            Male,
            Female
        };

        private class Person
        {
            public Gender Gender { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }

        public void Make_Чуек(int personId)
        {
            Person newPerson = new Person();
            newPerson.Age = personId;

            if (personId % 2 == 0)
            {
                newPerson.Name = "Batkata";
                newPerson.Gender = Gender.Male;
            }
            else
            {
                newPerson.Name = "Matseto";
                newPerson.Gender = Gender.Female;
            }
        }
    }
}