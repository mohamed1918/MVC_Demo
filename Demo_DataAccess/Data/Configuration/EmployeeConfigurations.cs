﻿
using Demo_DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DataAccess.Data.Configuration
{
    internal class EmployeeConfigurations :BaseEntityConfigrations<Employee> ,IEmployeeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("nvarchar(50)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");

            builder.Property(E => E.Gender).HasConversion((gender) => gender.ToString(),
                (toGender)=>(Gender) Enum.Parse(typeof(Gender),toGender));

            builder.Property(E => E.EmployeeType).HasConversion((EmployeeType) => EmployeeType.ToString(),
                (toEmployeeType) => (EmployeeType)Enum.Parse(typeof(EmployeeType), toEmployeeType));

            base.Configure(builder);
        }
    }

    internal interface IEmployeeConfiguration<T>
    {
    }
}
