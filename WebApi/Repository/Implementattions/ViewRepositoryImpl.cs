using WebApi.Model.Context;
using WebApi.Model.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Repository.Implementattions
{
    public class ViewRepositoryImpl<T> : IViewRepository<T> where T : BaseView
    {
        private MySQLContext _context;
        private DbSet<T> dataset;

        public ViewRepositoryImpl(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }


        public List<T> FindAll()
        {
            return dataset.OrderBy(a => a.name).ToList();
        }

    }
}
