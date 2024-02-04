﻿using Microsoft.EntityFrameworkCore;

namespace MainProject.DAL
{
    public class ContextFactory
    {
        private readonly DbContextOptions<Context> _options;

        public ContextFactory(DbContextOptions<Context> options)
        {
            _options = options;
        }

        public Context CreateContext()
        {
            return new Context(_options);
        }
    }
}


