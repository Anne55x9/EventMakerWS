namespace EventMakerWS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EventContext : DbContext
    {
        public EventContext()
            : base("name=EventContext")
        {
            base.Configuration.ProxyCreationEnabled = false;

        }

        public virtual DbSet<EventTable> EventTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventTable>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EventTable>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<EventTable>()
                .Property(e => e.Place)
                .IsUnicode(false);
        }
    }
}
