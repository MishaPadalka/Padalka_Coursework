using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class RailwayContext : DbContext
    {
        public RailwayContext(DbContextOptions<RailwayContext> options) : base(options)
        {

        }
        public DbSet<Train> Trains { set; get; }
        public DbSet<RailwayCarriage> RailwayCarriages { set; get; }
        public DbSet<Seat> Seats { set; get; }
        public DbSet<Order> Orders { set; get; }
    }
}
