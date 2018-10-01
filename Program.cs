using System;
using System.Linq;
using Model;

namespace Dev_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new JobContext())
            {
                //Company c1 = new Company { Name = "Apple", Address = "Plein" };
                //Company c2 = new Company { Name = "Microsoft", Address = "Straat" };
                //Company c3 = new Company { Name = "Acer", Address = "Pad" };
                //Company c4 = new Company { Name = "HP", Address = "Laan" };
                //Company c5 = new Company { Name = "Asus", Address = "Singel" };
                //db.Company.AddRange(c1, c2, c3, c4, c5);

                //Staff s1 = new Staff {SSN=2345, Name = "Tom", Birthday = "23-04-1993", Phone=123456789, CompanyName="Microsoft"};
                //Staff s2 = new Staff {SSN =3456, Name = "Jordy", Birthday = "20-12-1989", Phone=234567891, CompanyName="Microsoft" };
                //Staff s3 = new Staff {SSN =4567, Name = "Menno", Birthday = "12-01-1999", Phone=345678912, CompanyName="HP" };
                //Staff s4 = new Staff {SSN =5678, Name = "Julia", Birthday = "30-09-1986", Phone=456789123, CompanyName="Asus" };
                //Staff s5 = new Staff {SSN =6789, Name = "Danilo", Birthday = "05-10-1986", Phone=567891234, CompanyName="Asus" };
                //db.Staff.AddRange(s1, s2, s3, s4, s5);

                //Task t1 = new Task { Number = 1, Description= "Create" };
                //Task t2 = new Task { Number = 2, Description = "Update" };
                //Task t3 = new Task { Number = 3, Description = "Delete" };
                //Task t4 = new Task { Number = 4, Description = "Modify" };
                //Task t5 = new Task { Number = 5, Description = "View" };
                //db.Task.AddRange(t1, t2, t3, t4, t5);

                //Perform p1 = new Perform { TaskNumber = 2, StaffSSN = 2345 };
                //Perform p2 = new Perform { TaskNumber = 2, StaffSSN = 3456 };
                //Perform p3 = new Perform { TaskNumber = 1, StaffSSN = 4567 };
                //Perform p4 = new Perform { TaskNumber = 4, StaffSSN = 5678 };
                //Perform p5 = new Perform { TaskNumber = 3, StaffSSN = 5678 };
                //db.Perform.AddRange(p1, p2, p3, p4, p5);

                var projected = from Task in db.Task from Perform in db.Perform from Staff in db.Staff where Staff.SSN == Perform.StaffSSN && Task.Number == Perform.TaskNumber  select new {Task = Task.Description, L = Staff.Name};

                foreach (var item in projected)
                {
                    Console.WriteLine("{0}-{1}", item.Task, item.L);
                }

                //db.SaveChanges();
            }
        }
    }
}
