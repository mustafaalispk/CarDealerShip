﻿using CarDealerShip.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealerShip.Data
{
    class CarDealerShipContext : DbContext
    {
        private string connectionString;

        public DbSet<Car> Car { get; set; }

        public CarDealerShipContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
