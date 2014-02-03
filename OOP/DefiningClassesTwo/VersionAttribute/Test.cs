namespace VersionAttribute
{
    using System;

    [Version(3, 58)]
    class CustomAttributesDemo
    {
        static void Main(string[] args)
        {
            Type type = typeof(CustomAttributesDemo);
            object[] versionAttributes =
              type.GetCustomAttributes(false);
            foreach (VersionAttribute attribute in versionAttributes)
            {
                Console.WriteLine("The version of this class is {0}.{1}. ", attribute.Major, attribute.Minor);
            }
        }
    }
}
