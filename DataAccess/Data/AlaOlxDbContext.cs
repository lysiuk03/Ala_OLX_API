
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OLX_Ala.Data
{
    public class AlaOlxDbContext : IdentityDbContext<User>
    {
        public AlaOlxDbContext()
        {
            
        }
        public AlaOlxDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Announcement>()
                .Property(a => a.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category() {Id=1, Name="Help"},
                new Category() {Id=2, Name="Children's world"},
                new Category() {Id=3, Name="Real estate"},
                new Category() {Id=4, Name="Car"},
                new Category() {Id=5, Name="Spare parts"},
                new Category() {Id=6, Name="Work"},
                new Category() {Id=7, Name="Animals"},
                new Category() {Id=8, Name="House and garden"},
                new Category() {Id=9, Name="Electronics"},
                new Category() {Id=10, Name="Business and services"},
                new Category() {Id=11, Name="Rent and hire"},
                new Category() {Id=12, Name="Fashion and style"},
                new Category() {Id=13, Name="Hobbies, recreation and sports"}
            });
            modelBuilder.Entity<Region>().HasData(new[]
           {
                new Region() {Id=1, Name="Vinnitsa"},
                new Region() {Id=2, Name="Dnipro"},
                new Region() {Id=3, Name="Donetsk"},
                new Region() {Id=4, Name="Zhytomyr"},
                new Region() {Id=5, Name="Zaporizhzhia"},
                new Region() {Id=6, Name="Ivano-Frankivsk"},
                new Region() {Id=7, Name="Kyiv"},
                new Region() {Id=8, Name="Kropyvnytskyi"},
                new Region() {Id=9, Name="Luhansk"},
                new Region() {Id=10, Name="Lutsk"},
                new Region() {Id=11, Name="Lviv"},
                new Region() {Id=12, Name="Mykolaiv"},
                new Region() {Id=13, Name="Odesa"},
                new Region() {Id=14, Name="Poltava"},
                new Region() {Id=15, Name="Rivne"},
                new Region() {Id=16, Name="Sumy"},
                new Region() {Id=17, Name="Ternopil"},
                new Region() {Id=18, Name="Uzhhorod"},
                new Region() {Id=19, Name="Kharkiv"},
                new Region() {Id=20, Name="Kherson"},
                new Region() {Id=21, Name="Khmelnytskyi"},
                new Region() {Id=22, Name="Cherkasy"},
                new Region() {Id=23, Name="Chernivtsi"},
                new Region() {Id=24, Name="Chernihiv"}
            });

            modelBuilder.Entity<Announcement>().HasData(new[]
            {
                new Announcement() { Id = 1, Name = "Dog", Price=100, InStock=true, ImageURL="https://i.pinimg.com/736x/63/ec/9b/63ec9b2eeb79eb6cbaf9d05c47a19a4c.jpg",CategoryId=7,RegionId=1,ContactName ="Dasha",Phone="+380674973625"},
                new Announcement() { Id = 2, Name = "Cat",Price=80,InStock=true,ImageURL="https://static.fundacion-affinity.org/cdn/farfuture/xFsdVk-9Vi8ifllknxGrwV-ul0WVSmjXl7DSObD4iLU/mtime:1644939075/sites/default/files/los-10-sonidos-principales-del-gato-fa.jpg",CategoryId=7,RegionId=2,ContactName ="Masha",Phone="+380854763746" },
                new Announcement() { Id = 3, Name = "Phone",Price=200,InStock=true,ImageURL="https://www.cnet.com/a/img/resize/0302d07e10ba8dc211f7b4e25891ad46dda31976/hub/2023/02/05/f52fdc98-dafc-4d05-b20e-8bd936b49a53/oneplus-11-review-cnet-lanxon-promo-8.jpg",CategoryId=9,RegionId=3,ContactName ="Roma",Phone="+380857497463" },
                new Announcement() { Id = 4, Name = "Car",Price=3000,InStock=true,ImageURL="https://cdn.jdpower.com/Average%20Weight%20Of%20A%20Car.jpg",CategoryId=4,RegionId=4,ContactName ="Misha",Phone="+380654788473" },
                new Announcement() { Id = 5, Name = "Nike",Price=250,InStock=true, ImageURL="https://images.prom.ua/4137447034_w640_h640_muzhskoj-zimnij-svitshot.jpg",CategoryId=12,RegionId=5,ContactName ="Elia",Phone="+380758497362"},
                new Announcement() { Id = 6, Name = "Carhartt",Price=300,InStock=true,ImageURL="https://vintagewholesaleeurope.com/cdn/shop/products/image_8e7df972-8464-40bd-89b6-72b19fa2519b_1024x1024@2x.jpg", CategoryId=12,RegionId=6,ContactName ="Boria",Phone="+380584763847"}
            });
        }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Region> Regions { get; set; }
        //public DbSet<Order> Orders { get; set; }
    }
}
