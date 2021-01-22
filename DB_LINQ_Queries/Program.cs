using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;


namespace DB_LINQ_Queries
{
    //Entity classes
    public class Car
    {
        public int carId { get; set; }
        public string carName { get; set; }
        public string carModel { get; set; }
        public int carYear { get; set; }
        public string carColor { get; set; }
    }

    //Context Class
    public class CarShowroom: DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=CarShowroom;Trusted_Connection=True;");
        }
    }

    public class Student: IComparable<Student>
    {
        public int studentId { get; set; }
        public string studentName { get; set; }
        public int studentAge { get; set; }

        public int CompareTo(Student other)
        {
            if (this.studentAge >= other.studentAge)
                return 1;
            return 0;
        }
    }

    //class StudentComparer : IEqualityComparer<Student>
    //{
    //    public bool Equals(Student x, Student y)
    //    {
    //        if (x.studentId == y.studentId && x.studentName.ToLower() == y.studentName.ToLower())
    //            return true;

    //        return false;
    //    }

    //    public int GetHashCode(Student obj)
    //    {
    //        return obj.studentId.GetHashCode();
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CarShowroom())
            {
                var std1 = new Car()
                {
                    carName = "BMW",
                    carModel = "5 Series",
                    carYear = 2005,
                    carColor = "Blue"
                };

                var std2 = new Car()
                {
                    carName = "Honda",
                    carModel = "Civic",
                    carYear = 2013,
                    carColor = "White"
                };

                var std3 = new Car()
                {
                    carName = "Toyota",
                    carModel = "Camry",
                    carYear = 2010,
                    carColor = "Red"
                };

                var std4 = new Car()
                {
                    carName = "Mercedes",
                    carModel = "S class",
                    carYear = 2019,
                    carColor = "Black"
                };

                var std5 = new Car()
                {
                    carName = "KIA",
                    carModel = "Sportage",
                    carYear = 2020,
                    carColor = "Grey"
                };

                /*context.Cars.Add(std1);
                context.Cars.Add(std2);
                context.Cars.Add(std3);
                context.Cars.Add(std4);
                context.Cars.Add(std5);*/
                context.SaveChanges();

                //Linq Query (where query)
                var car = (from s in context.Cars
                           where s.carName.Contains("m")
                           select s).FirstOrDefault<Car>();

                Console.WriteLine("------------------------Where Query------------------------");
                Console.WriteLine($"{car.carName}, {car.carModel}, {car.carYear}, {car.carColor}" );

                //Linq query (ofType query)

                var myList = new ArrayList();

                myList.Add(1);
                myList.Add(2);
                myList.Add("One");
                myList.Add("Two");
                myList.Add("Three");
                myList.Add(3);

                var stringQueries = from s in myList.OfType<string>()
                                    select s;

                Console.WriteLine("------------------------ofType Query------------------------");
                foreach (var s in stringQueries)
                {
                    Console.WriteLine(s);
                }

                //Linq Query (OrderBy query)

                var SortedQuery = from s in context.Cars
                                  orderby s.carName descending
                                  select s;

                Console.WriteLine("------------------------orderBy Query------------------------");
                foreach (var s in SortedQuery)
                {
                    Console.WriteLine(s.carName);
                }

                //Linq Query (GroupBy query)

                var myStudentDictionary = new Dictionary<int, string>()
                {
                    { 6, "wamik" }, { 8, "umair" }, { 7, "ihtisham" }, { 9, "afaq" }, { 10, "wamik"}, { 2, "atta" } 
                };

                var groupQuery = from s in myStudentDictionary
                                 group s by s.Value;

                
                Console.WriteLine("------------------------groupBy Query------------------------");
                foreach (var s in groupQuery)
                {
                    Console.WriteLine("The key is: {0}", s.Key); //Each group has a key 

                    foreach (var a in s) // Each group has inner collection
                        Console.WriteLine($"Data under this key: {a.Key}");
                }

                //Linq Query (ALL, ANY OR Conatins query)

                var myStudentList = new List<Student>()
                {
                    new Student() {studentId = 1, studentName = "wamik", studentAge=23},
                    new Student() {studentId = 2, studentName = "ihtisham", studentAge= 23},
                    new Student() {studentId = 3, studentName = "atta", studentAge= 22},
                    new Student() {studentId = 4, studentName = "afaq", studentAge= 20},
                    new Student() {studentId = 5, studentName = "umair", studentAge= 23},
                    new Student() {studentId = 6, studentName = "askari", studentAge= 26}
                };

                var myStudentList1 = new List<Student>()
                {
                    new Student() {studentId = 3, studentName = "wamik", studentAge=23},
                    new Student() {studentId = 2, studentName = "ihtisham", studentAge= 23}
                };

                var res1 = myStudentList.All(s => s.studentAge >= 18 && s.studentAge <= 24);
                var res2 = myStudentList.Any(s => s.studentAge >= 18 && s.studentAge <= 24);

                Console.WriteLine("------------------------All Any or Contain Query------------------------");
                Console.WriteLine($"Result of ALL query: {res1}");
                Console.WriteLine($"Result of ANY query: {res2}");

                //Aggregation Operators
                string studentNamesInString = myStudentList.Aggregate<Student, string>("Student Names: ", (str, s) => str += s.studentName + ",");

                Console.WriteLine("------------------------Aggregation queries------------------------");
                Console.WriteLine(studentNamesInString);

                int studentAgeSum = myStudentList.Aggregate<Student, int>(0, (age, s) => age += s.studentAge);
                int studentAgeSum1 = myStudentList.Sum(s => s.studentAge);
                double studentAgeAvg = myStudentList.Average(s => s.studentAge);
                var eldestStudent = myStudentList.Max();

                Console.WriteLine($"Sum of students age is: {studentAgeSum}");
                Console.WriteLine($"Sum of students age is: {studentAgeSum1}");
                Console.WriteLine($"Average of students age is: {studentAgeAvg}");
                Console.WriteLine($"Total students are: {myStudentList.Count}");
                Console.WriteLine($"Eldest student name: {eldestStudent.studentName}");


                string studentNamesInString1 = myStudentList.Aggregate<Student, string>(String.Empty, (str, s) => str += s.studentName + ",");
                studentNamesInString1 = studentNamesInString1.Substring(0, studentNamesInString1.Length - 1);

                Console.WriteLine(studentNamesInString1);

                //Distinct Except Intersect Union Queries
                var myDistinctStudent = myStudentList.Distinct(new StudentComparer());

                Console.WriteLine("------------------------Distinct Except Intersect Union queries------------------------");
                foreach (var s in myDistinctStudent)
                    Console.WriteLine(s.studentName);


                var myExceptStudent = myStudentList.Except(myStudentList1, new StudentComparer());

                //var myExceptStudent1 = myStudentList.ExcepttestTest("umar");

                Console.WriteLine("------------------------Distinct Except Intersect Union queries------------------------");
                foreach (var s in myExceptStudent)
                    Console.WriteLine(s.studentName);
            }
        }
    }
}
