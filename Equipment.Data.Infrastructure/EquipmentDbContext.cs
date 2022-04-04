using Equipment.Data.Infrastructure.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment.Data.Infrastructure
{
    public class EquipmentDbContext : DbContext
    {
        public EquipmentDbContext(DbContextOptions<EquipmentDbContext> options) : base(options)
        {

        }
        public DbSet<Tables.Equipment> Equipments { get; set; }
        public DbSet<Tables.AppUser> AppUsers { get; set; }
        public DbSet<Tables.CategoryLookup> CategoryLookups { get; set; }
        public DbSet<Tables.DepartmentLookup> DepartmentLookups { get; set; }
        public DbSet<Tables.MaintainancePeriodLookup> MaintainancePeriodLookups { get; set; }
        public DbSet<Tables.StatusLookup> StatusLookups { get; set; }       
        public DbSet<Tables.SubCategoryLookup> SubCategoryLookups { get; set; }
        public DbSet<Tables.SupplierLookup> SupplierLookups { get; set; }
        public DbSet<Tables.UnitLookup> UnitLookups { get; set; }
     

    }
}
