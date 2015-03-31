using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutoMapper
{
    class Program
    {
        #region Model

        public class Employee
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public Address Address { get; set; }
            public string Position { get; set; }
            public bool Gender { get; set; }
            public int Age { get; set; }
            public int YearsInCompany { get; set; }
            public DateTime StartDate { get; set; }
        }

        public class Address
        {
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public int Number { get; set; }
        }

        public class EmployeeViewItem
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Position { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public int YearsInCompany { get; set; }
            public string StartDate { get; set; }
        }

        #endregion

        static void Main()
        {
            #region CreateMap

            Mapper.CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());
            Mapper.CreateMap<Employee, EmployeeViewItem>()
                .ForMember(ev => ev.Address, m => m.MapFrom(a => a.Address.City + ", " +
                                                                 a.Address.Street + " " +
                                                                 a.Address.Number))
                .ForMember(ev => ev.Gender, m => m.ResolveUsing<GenderResolver>().FromMember(e => e.Gender));

            #endregion

            #region Map

            Employee employee = InitEmployee();
            EmployeeViewItem employeeVIewItem = Mapper.Map<Employee, EmployeeViewItem>(employee);

            #endregion
        }

        private static Employee InitEmployee()
        {
            return new Employee
            {
                Name = "John SMith",
                Email = "john@codearsenal.net",
                Address = new Address
                {
                    Country = "USA",
                    City = "New York",
                    Street = "Wall Street",
                    Number = 7
                },
                Position = "Manager",
                Gender = true,
                Age = 35,
                YearsInCompany = 5,
                StartDate = new DateTime(2007, 11, 2)
            };
        }
    }

    #region helper

    public class GenderResolver : ValueResolver<bool, string>
    {
        protected override string ResolveCore(bool source)
        {
            return source ? "Man" : "Female";
        }
    }

    public class DateTimeTypeConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(ResolutionContext context)
        {
            return ((DateTime)context.SourceValue).ToShortDateString();
        }
    }

    #endregion

}
