﻿using WebApi.Model.Context;
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
        


       
    }
}
