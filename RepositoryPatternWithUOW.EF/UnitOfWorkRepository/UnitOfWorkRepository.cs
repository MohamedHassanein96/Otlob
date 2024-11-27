﻿using Microsoft.EntityFrameworkCore;
using Otlob.Core.IUnitOfWorkRepository;
using Otlob.Core.Models;
using Otlob.EF.BaseRepository;
using Otlob.EF.IBaseRepository;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuGet.Packaging.PackagingConstants;

namespace Otlob.EF.UnitOfWorkRepository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IBaseRepository<ContactUs> ContactUs { get; private set; }

        public IBaseRepository<CustomerConcern> CustomerConcerns { get; private set; }

        public IBaseRepository<Delivery> Deliveries { get; private set; }

        public IBaseRepository<Meal> Meals { get; private set; }

        public IBaseRepository<Order> Orders { get; private set; }
        public IBaseRepository<Restaurant> Restaurants { get; private set; }
        public IBaseRepository<Point> Points { get; private set; }
        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }


        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWorkRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            InitializeRepositories();
        }

        private void InitializeRepositories()
        {
            Restaurants = CreateRepository<Restaurant>();
            Orders = CreateRepository<Order>();
            Meals = CreateRepository<Meal>();
            Deliveries = CreateRepository<Delivery>();
            CustomerConcerns = CreateRepository<CustomerConcern>();
            ContactUs = CreateRepository<ContactUs>();
            Points = CreateRepository<Point>();
        }

        private IBaseRepository<T> CreateRepository<T>() where T : class
        {
            return new BaseRepository<T>(_applicationDbContext);


        }
    }
}
