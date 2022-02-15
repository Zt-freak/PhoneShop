﻿using Phoneshop.Domain.Interfaces;
using Phoneshop.WinForms.Logic.Extensions;
using Phoneshop.WinForms.Objects;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace Phoneshop.WinForms.Logic
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> brandRepository;

        public BrandService(IRepository<Brand> brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public Brand GetOrCreate(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var command = new SqlCommand("SELECT * FROM brands WHERE name = '" + name + "'");

            var result = brandRepository.GetRecord(command);

            if (result == null)
            {
                Create(new Brand { Name = name });
                return GetOrCreate(name);
            }

            return result;
        }

        public void Create(Brand brand)
        {
            var command = new SqlCommand("INSERT INTO Brands (Name) VALUES (@BrandName)");
            command.Parameters.AddWithValue("BrandName", brand.Name);
            brandRepository.ExecuteNonQuery(command);
        }

        [ExcludeFromCodeCoverage]
        public static Brand PhoneMapper(SqlDataReader reader)
        {
            return new()
            {
                Id = reader.GetInt("Id"),
                Name = reader.GetString("Name"),
            };
        }
    }
}
