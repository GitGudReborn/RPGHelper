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
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}