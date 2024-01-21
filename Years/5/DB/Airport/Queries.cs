using Airport.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Airport
{
    public static class Queries
    {
        public static List<Employee> Q1(Context context, int departmentId)
        {
            return context
                .Employees
                .Where(e => e.DepartmentId == departmentId)
                .OrderBy(e => e.HiredDate)
                .ThenBy(e => e.Sex)
                .ThenBy(e => e.Birthday)
                .ThenBy(e => e.ChildrenNumber)
                .ThenBy(e => e.Salary)
                .ToList();
        }
    }
}