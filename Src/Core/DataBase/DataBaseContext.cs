using System;
using Commander.Src.Core.AuthCore.JWTModels;
using Commander.Src.Feature.Auth.Domain.Entity;
using Commander.Src.Feature.Cmd.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Commander.Src.Core.Database
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public DbSet<Command> Commands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}