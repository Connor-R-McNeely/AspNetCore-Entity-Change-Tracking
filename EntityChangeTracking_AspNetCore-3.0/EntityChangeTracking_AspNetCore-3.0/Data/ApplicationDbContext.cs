using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityChangeTracking_AspNetCore_3._0.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EntityChangeTracking_AspNetCore_3._0.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Authorization;

namespace EntityChangeTracking_AspNetCore_3._0.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private IHttpContextAccessor _httpContextAccessor;

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync();
        }

        public void UpdateTimestamps()
        {
            var iTimestampEntities = ChangeTracker.Entries()
                .Where(x => x.Entity is ITimestamp)
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            var userName = _httpContextAccessor.HttpContext.User?.Identity?.Name;

            userName = userName ?? "System";

            foreach (var e in iTimestampEntities.Where(x => x.State == EntityState.Added))
            {
                ((ITimestamp)e.Entity).CreatedDateTime = DateTime.Now;
                ((ITimestamp)e.Entity).CreatedBy = userName;
            }

            foreach (var e in iTimestampEntities.Where(x => x.State == EntityState.Modified))
            {
                e.Property("CreatedDateTime").IsModified = false;
                e.Property("CreatedBy").IsModified = false;
                ((ITimestamp)e.Entity).EditedDateTime = DateTime.Now;
                ((ITimestamp)e.Entity).EditedBy = userName;
            }
        }
    }
}
