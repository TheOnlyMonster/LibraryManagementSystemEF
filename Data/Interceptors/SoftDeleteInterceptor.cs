using LibraryManagementSystemEF.Entities.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemEF.Data.Interceptors
{
    internal class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if(eventData.Context is null)
            {
                return result;
            }

            var entries = eventData.Context.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.Entity is ISoftDeletable entity)
                {
                    if (entry.State == EntityState.Deleted)
                    {
                        entry.State = EntityState.Modified;
                        entity.IsDeleted = true;
                    }
                }
            }

            return base.SavingChanges(eventData, result);
        }
    }
}
