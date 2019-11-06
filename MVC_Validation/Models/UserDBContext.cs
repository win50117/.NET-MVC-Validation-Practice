namespace MVC_Validation.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserDBContext : DbContext
    {
        public UserDBContext()
            : base("name=UserDB")
        {
        }

        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTable>()
                .Property(e => e.UserSex)
                .IsFixedLength();
        }
    }
}
