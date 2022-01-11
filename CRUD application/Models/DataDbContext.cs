using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_application.Models
{
    public class DataDbContext :DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) //configure dbContext option 
        {
        }

        public DbSet<Order_table> Order_table { get; set; }
    }
}
