namespace StudentInfo
{
    using System;
    using System.Linq;
    
    public class Student : ICloneable, IComparable<Student>
    {
        public Student(string firstName, string midName, string lastName, ulong ssn, string address, ulong mobileNum,
            string email, byte course, University university, Faculty faculty, Specialty specialty)
        {
            this.FirstName = firstName;
            this.MidName = midName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.Address = address;
            this.MobileNumber = mobileNum;
            this.Email = email;
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }

        public string FirstName { get; private set; }

        public string MidName { get; private set; }

        public string LastName { get; set; }

        public ulong Ssn { get; private set; }

        public string Address { get; set; }

        public ulong MobileNumber { get; set; }

        public string Email { get; set; }

        public byte Course { get; set; }

        public Faculty Faculty { get; set; }

        public Specialty Specialty { get; set; }

        public University University { get; set; }

        public override bool Equals(object obj)
        {
            return this.Ssn == (obj as Student).Ssn;
        }

        public static bool operator ==(Student firstStud, Student secondstud)
        {
            return Student.Equals(firstStud, secondstud);
        }

        public static bool operator !=(Student firstStud, Student secondstud)
        {
            return !Student.Equals(firstStud, secondstud);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.Ssn.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nSSN: {1}\nEmail: {2}\nCourse: {3}\nUniversity: {4}\nFaculty: {5}\nSpecialty: {6}\n",
                this.FirstName + " " + this.MidName + " " + this.LastName, this.Ssn, this.Email, this.Course, this.University,
                this.Faculty, this.Specialty);
        }
        
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            return new Student(this.FirstName, this.MidName, this.LastName, this.Ssn, this.Address, this.MobileNumber,
                this.Email, this.Course, this.University, this.Faculty, this.Specialty);
        }

        public int CompareTo(Student obj)
        {
            if (this.FirstName.CompareTo(obj.FirstName) != 0)
            {
                return this.FirstName.CompareTo(obj.FirstName);
            }

            if (this.MidName.CompareTo(obj.MidName) != 0)
            {
                return this.MidName.CompareTo(obj.MidName);
            }

            if (this.LastName.CompareTo(obj.LastName) != 0)
            {
                return this.LastName.CompareTo(obj.LastName);
            }

            if (this.Ssn != obj.Ssn)
            {
                return this.Ssn.CompareTo(obj.Ssn);
            }

            return 0;
        }
    }
}