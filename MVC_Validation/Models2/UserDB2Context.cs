namespace MVC_Validation.Models2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserDB2Context : DbContext
    {
        public UserDB2Context()
            : base("name=UserDB2")
        {
        }

        public virtual DbSet<UserTable2> UserTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTable2>()
                .Property(e => e.UserSex)
                .IsFixedLength();
        }
    }
}
