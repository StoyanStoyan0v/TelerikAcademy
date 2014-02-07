using StudentsInfo;

class Tests
{
    static void Main(string[] args)
    {
        //All test are in different static classes (in the namespace/folder Tests) and has ExecuteTest method.
        SelectByGroup.ExecuteTest();
        SelectByEmail.ExecuteTest();
        SelectByTelNumber.ExecuteTest();
        SelectByMarks.ExecuteTest();
        SelectByMarks2.ExecuteTest();
        SelectByFN.ExecuteTest();
        SelectByDepartament.ExecuteTest();
        GroupStudents.ExecuteTest();
    }
}


