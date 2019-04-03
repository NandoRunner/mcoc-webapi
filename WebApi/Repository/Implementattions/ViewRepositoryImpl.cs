using System.Collections.Generic;
using WebApi.Model;
using System.Threading;
using WebApi.Model.Context;
using System;
using System.Linq;
using WebApi.Model.Base;
using Microsoft.EntityFrameworkCore;

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
        
        public List<T> FindMovieCount(enMovieCount order)
        {
            if (order == enMovieCount.name)
            {
                return dataset.OrderBy(p => p.Name).ToList();
            }
            else
            {
                return dataset.ToList();
            }
        }

       
    }
}
