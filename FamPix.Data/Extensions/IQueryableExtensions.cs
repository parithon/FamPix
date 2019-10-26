using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamPix.Core
{
    public static class IQueryableExtensions
    {
        public static Task<List<T>> ToListAsync<T>(this IQueryable<T> query)
        {
            return EntityFrameworkQueryableExtensions.ToListAsync(query);
        }
    }
}
