using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Data
{
    public static class StudentData
    {
        public static Student[] Seed()
        {
            string runtimeVersion = typeof(Startup)
                .GetTypeInfo()
                .Assembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion;

            Student[] students = new Student[]
            {
                new Student()
                {
                    Id = 1,
                    NameFirst = "Player",
                    NameLast = "Main"
                },
                new Student()
                {
                    Id = 2,
                    NameFirst = "David",
                    NameLast = "Default"
                },
            };

            return students;
        }
    }
}
