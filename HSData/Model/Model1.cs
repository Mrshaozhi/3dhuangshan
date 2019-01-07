namespace HSData.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Rl_Collect> Rl_Collect { get; set; }
        public virtual DbSet<Rl_Praise> Rl_Praise { get; set; }
        public virtual DbSet<Tb_Calendar> Tb_Calendar { get; set; }
        public virtual DbSet<Tb_CountAddress> Tb_CountAddress { get; set; }
        public virtual DbSet<Tb_CountClick> Tb_CountClick { get; set; }
        public virtual DbSet<Tb_FeedBack> Tb_FeedBack { get; set; }
        public virtual DbSet<Tb_Log> Tb_Log { get; set; }
        public virtual DbSet<Tb_Photo> Tb_Photo { get; set; }
        public virtual DbSet<Tb_Strategy> Tb_Strategy { get; set; }
        public virtual DbSet<Tb_User> Tb_User { get; set; }
        public virtual DbSet<Tb_Weather> Tb_Weather { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tb_Photo>()
                .HasMany(e => e.Rl_Praise)
                .WithRequired(e => e.Tb_Photo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tb_Strategy>()
                .HasMany(e => e.Rl_Collect)
                .WithRequired(e => e.Tb_Strategy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tb_Strategy>()
                .HasMany(e => e.Rl_Praise)
                .WithRequired(e => e.Tb_Strategy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tb_User>()
                .HasMany(e => e.Rl_Collect)
                .WithRequired(e => e.Tb_User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tb_User>()
                .HasMany(e => e.Rl_Praise)
                .WithRequired(e => e.Tb_User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tb_User>()
                .HasMany(e => e.Tb_Calendar)
                .WithRequired(e => e.Tb_User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tb_User>()
                .HasMany(e => e.Tb_FeedBack)
                .WithRequired(e => e.Tb_User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tb_User>()
                .HasMany(e => e.Tb_Log)
                .WithRequired(e => e.Tb_User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tb_User>()
                .HasMany(e => e.Tb_Photo)
                .WithRequired(e => e.Tb_User)
                .WillCascadeOnDelete(false);
        }
    }
}
