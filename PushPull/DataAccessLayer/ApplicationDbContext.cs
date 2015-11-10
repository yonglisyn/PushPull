using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using PushPull.Constants;
using PushPull.Models;

namespace PushPull.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int,
        ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            //Database.Initialize(true);
        }

        static ApplicationDbContext()
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }
        public DbSet<TaskCard> TaksCards { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<CustomerLife> CustomerLives { get; set; }
        public DbSet<TaskReport> Reports { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            CommonConfiguration(modelBuilder);
            KeyConfiguration(modelBuilder);
            PropertiesConfiguration(modelBuilder);
            NavigationConfiguration(modelBuilder);
            base.OnModelCreating(modelBuilder);
            TableColumnNameConfiguration(modelBuilder);
        }

        private static void TableColumnNameConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("User").Property(x => x.Id).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationRole>()
                .ToTable("Role");
            modelBuilder.Entity<ApplicationUserRole>()
                .ToTable("UserRole");
            modelBuilder.Entity<ApplicationUserClaim>()
                .ToTable("UserClaim");
            modelBuilder.Entity<ApplicationUserLogin>()
                .ToTable("UserLogin");
        }

        private static void NavigationConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasMany(a => a.TaskCards).WithRequired(t => t.User)
                .HasForeignKey(t => t.UserId);
            modelBuilder.Entity<ApplicationUser>().HasMany(a => a.Assets).WithRequired(t => t.User)
                .HasForeignKey(t => t.UserId);
            modelBuilder.Entity<ApplicationUser>().HasMany(a => a.CustomerLives).WithRequired(t => t.User)
                .HasForeignKey(t => t.UserId);
        }

        private static void PropertiesConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskCard>().Property(t => t.TaskId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TaskCard>().Property(x => x.UserId).HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                    new IndexAttribute("IX_TaskCard_UserId")));
            modelBuilder.Entity<TaskCard>()
                .Property(t => t.Card.Content)
                .HasMaxLength(AccountConstSettings.CommonStringLength);

            modelBuilder.Entity<Asset>().Property(x => x.UserId).HasColumnAnnotation(
                IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_Asset_UserId")));
            modelBuilder.Entity<Asset>().Property(x => x.Date).HasColumnAnnotation(
                IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_Asset_Date")));
            
            modelBuilder.Entity<CustomerLife>().Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            modelBuilder.Entity<ApplicationUser>()
                .Property(t => t.PasswordHash)
                .HasMaxLength(AccountConstSettings.PasswordHashLength);

            modelBuilder.Entity<TaskReport>().Property(x => x.UserId).HasColumnAnnotation(
                IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_TaskReport_UserId")));
            modelBuilder.Entity<TaskReport>().Property(x => x.WeekIndex).HasColumnAnnotation(
                IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_TaskReport_WeekIndex")));
            
        }

        private static void KeyConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskCard>().HasKey(t => t.TaskId);
            modelBuilder.Entity<CustomerLife>().HasKey(a => a.Id);
            modelBuilder.Entity<Asset>().HasKey(x => new { x.UserId, x.AssetPurpose, x.AssetType, x.Date });
            modelBuilder.Entity<TaskReport>().HasKey(x => new { x.UserId, x.EisenHowerType, x.WeekIndex});

        }

        private static void CommonConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(AccountConstSettings.CommonStringLength));
        }

    }
}