﻿using System;

namespace AsgSearch.DAL
{
    public class DALContext : IDALContext
    {
        private DB dbContext;
        private IQueryRepository queries;

        public DALContext()
        {
            dbContext = new DB();
        }

        public IQueryRepository Queries
        {
            get { return queries ?? (queries = new QueryRepository(dbContext)); }
        }

        public int SaveChanges()
        {
            // HINT: Implementation is a one-liner! :)
            dbContext.Queries.Add(dbContext.Queries.Create());
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (queries != null)
                queries.Dispose();
            if (dbContext != null)
                dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}