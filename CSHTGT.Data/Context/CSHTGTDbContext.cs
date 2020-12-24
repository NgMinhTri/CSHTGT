using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace CSHTGT.Data.Context
{
    public class CSHTGTDbContext : DbContext
    {
        public CSHTGTDbContext( DbContextOptions options) : base(options)
        {

        }
    }

}
