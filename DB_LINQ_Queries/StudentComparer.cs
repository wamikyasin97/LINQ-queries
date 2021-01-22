using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DB_LINQ_Queries
{
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.studentId == y.studentId && x.studentName.ToLower() == y.studentName.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(Student obj)
        {
            return obj.studentId.GetHashCode();
        }
    }

    //public class StudentComparer: IEqualityComparer<Student>
    //{
    //    public bool ExcepttestTest<TSource>(this IEnumerable<TSource> first, string y)
    //    {
    //        if (y.ToLower() == first.studentName.ToLower())
    //        {
    //            return true;
    //        }
    //        return false;
    //    }

    //    public bool Equals(Student x, Student y)
    //    {
    //        if (x.studentId == y.studentId && x.studentName.ToLower() == y.studentName.ToLower())
    //            return true;

    //        return false;
    //    }

    //    public static bool tempEqul(this string x, Student y)
    //    {
    //        if (x.ToLower() == y.studentName.ToLower())
    //        {
    //            return true;
    //        }

    //        return false;
    //    }

    //    public int GetHashCode(Student obj)
    //    {
    //        return obj.studentId.GetHashCode();
    //    }
    //}
}
