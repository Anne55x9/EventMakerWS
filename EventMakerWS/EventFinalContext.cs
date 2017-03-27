namespace EventMakerWS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EventFinalContext : DbContext
    {
        public EventFinalContext()
            : base("name=EventFinalContext")
        {
        }

        public virtual DbSet<EventsFINAL> EventsFINAL { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventsFINAL>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EventsFINAL>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<EventsFINAL>()
                .Property(e => e.Place)
                .IsUnicode(false);
        }
    }
}
