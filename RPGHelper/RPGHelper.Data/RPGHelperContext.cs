namespace RPGHelper.Data
{
    using RPGHelper.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RPGHelperContext : DbContext
    {
        // Your context has been configured to use a 'RPGHelperContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RPGHelper.Data.RPGHelperContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RPGHelperContext' 
        // connection string in the application configuration file.
        public RPGHelperContext()
            : base("name=RPGHelperContext")
        {
            Database.SetInitializer(new Initializer());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Hero> Heroes { get; set; }
        public virtual DbSet<HeroStats> HeroStatistics { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemStats> ItemStatistics { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .HasRequired(h => h.HeroStats)
                .WithRequiredPrincipal(hs => hs.Hero);

            modelBuilder.Entity<Item>()
                .HasRequired(i => i.ItemStats)
                .WithRequiredPrincipal(i => i.Item);

            modelBuilder.Entity<Hero>()
                .HasMany(h => h.Items)
                .WithMany(it => it.ItemOwners)
                .Map(m =>
                {
                    m.MapLeftKey("HeroId");
                    m.MapRightKey("ItemId");
                    m.ToTable("HeroesItems");
                });

            modelBuilder.Entity<User>()
                 .HasMany(u => u.Friends)
                 .WithMany()
                 .Map(m =>
                 {
                     m.MapLeftKey("UserId");
                     m.MapRightKey("FriendId");
                     m.ToTable("UsersFriends");
                 });

            modelBuilder.Entity<User>()
                .HasMany(u => u.SentMessages)
                .WithRequired(m => m.Sender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedMessages)
                .WithRequired(m => m.Recipient)
                .WillCascadeOnDelete(false);
        }
    }
}