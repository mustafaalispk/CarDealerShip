using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealerShip.Data
{
    class CarDealerShipContext : DbContext
    {
        private string connectionString;

        public CarDealerShipContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=CarDealerShip;Trusted_Connection=True");
        }
    }
}
