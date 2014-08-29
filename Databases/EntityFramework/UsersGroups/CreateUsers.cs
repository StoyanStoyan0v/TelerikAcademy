namespace UsersGroups
{
    using System;
    using System.Linq;

    internal class CreateUsers
    {
        private static void Main(string[] args)
        {
            CreateUser("Pesho", "Ivanov", "Admins");
            CreateUser("Ivan", "Georgiev", "Admins");
            CreateUser("Dimitar", "Petrov", "Privilleged Users");
        }
        
        private static void CreateUser(string userFirstName, string userLastName, string userGroupName)
        {
            using (var context = new GroupsAndUsersEntities())
            {
                using (var contextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        bool hasGroup = context.Groups.Any(g => g.GroupName == userGroupName);

                        if (!hasGroup)
                        {
                            var group = new Group()
                            {
                                GroupName = userGroupName
                            };

                            context.Groups.Add(group);
                        }
                        context.SaveChanges();
                        var user = new User()
                        {
                            FirstName = userFirstName,
                            LastName = userLastName,
                            Group = context.Groups.First(g => g.GroupName == userGroupName)
                        };

                        context.Users.Add(user);
                        context.SaveChanges();
                        contextTransaction.Commit();
                        Console.WriteLine("User added succesfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        contextTransaction.Commit();
                        Console.WriteLine("User failed to add!");
                    }
                }
            }
        }
    }
}