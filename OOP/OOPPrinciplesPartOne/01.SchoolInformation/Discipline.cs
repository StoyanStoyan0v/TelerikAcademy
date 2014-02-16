namespace SchoolInformation
{
    using System;

    public class Discipline : ICommentable
    {
        private string name;
        private int? numberOfLectures, numberOfExercises;

        public Discipline(string name, int lectureNum, int exercisesNum)
        {
            this.Name = name;
            this.numberOfLectures = lectureNum;
            this.numberOfExercises = exercisesNum;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The discipline name cannot be empty!");
                }
                this.name = value;
            }
        }

        public int? NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            set
            {
                if(value==null || value<0)
                {
                    throw new ArgumentException("The number of lectures cannot be empty or negative!");
                }
                this.numberOfLectures = value;
            }
        }

        public int? NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
            set
            {
                if (value == null || value < 0)
                {
                    throw new ArgumentException("The number of exercises cannot be empty or negative!");
                }
                this.numberOfExercises = value;
            }
        }

        public string Comment
        {
            get
            {
                return this.Comment;
            }
            set
            {
                if(value.Length<10 || value.Length>30)
                {
                    throw new ArgumentException("The comment must be between 10 and 30 characters long!");
                }

                this.Comment = value;
            }
        }
        public override string ToString()
        {
            return string.Format("\n{0,-5} | Num. of lectures: {1} | Num. of exercises: {2}",
                this.Name,this.NumberOfLectures,this.NumberOfExercises);
        }
    }
}
