namespace SchoolInformation
{
    using System;
    using System.Collections.Generic;

    public class Teacher : People, ICommentable
    {
        private readonly List<Discipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            this.disciplines = new List<Discipline>();
        }

        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
        }


        public void AddDisciplines(params Discipline[] disciplines)
        {
            foreach (var discipline in disciplines)
            {
                if (this.disciplines.Contains(discipline))
                {
                    throw new ArgumentException("This teacher already teaches this discipline!");
                }

                this.disciplines.Add(discipline);
            }
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            if (!this.disciplines.Contains(discipline))
            {
                throw new ArgumentException("This teacher does not teach such discipline!");
            }

            this.disciplines.Remove(discipline);
        }

        public override string ToString()
        {
            return string.Format("Name of teacher: {0}{1}\n\n", this.Name, string.Join(" ", this.Disciplines));
        }
    }
}
