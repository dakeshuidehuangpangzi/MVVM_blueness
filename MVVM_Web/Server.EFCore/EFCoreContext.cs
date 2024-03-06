using Microsoft.EntityFrameworkCore;
using Models;

namespace EFCore
{
    public class EFCoreContext : DbContext
    {
        public EFCoreContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //连接数据库密码和用户
            optionsBuilder.UseSqlServer("Server=PANG;Database=WebShop;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TypeModel> Types { get; set; }
        public DbSet<CustomerModel> CustomerModels { get; set; }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }

        public DbSet<GoodModel> GoodModels { get; set; }

        public DbSet<OrderDetailModel> OrderDetailModels { get; set; }
        public DbSet<OrderModel> OrderModels { get; set; }
        public DbSet<PaymentModel> PaymentModels { get; set; }





    }
}