namespace StudentsInfo
{
    public class Group
    {
        public Group(int groupNumber, string departamentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartamentName = departamentName;
        }

        public int GroupNumber { get; set; }

        public string DepartamentName { get; set; }
    }
}
