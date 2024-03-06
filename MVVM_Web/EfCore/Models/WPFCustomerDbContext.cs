using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTest.Models;

public partial class WPFCustomerDbContext : DbContext
{
    public WPFCustomerDbContext()
    {
    }

    public WPFCustomerDbContext(DbContextOptions<WPFCustomerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=pang;Initial Catalog=WebShop;User ID=sa;Password=PIANao..;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__Customer__2135C94C82DBF96C");

            entity.HasIndex(e => e.CName, "UQ__Customer__D6E7B38484D4A5D3").IsUnique();

            entity.Property(e => e.CId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("c_ID");
            entity.Property(e => e.CAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("c_Address");
            entity.Property(e => e.CAnswer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("c_Answer");
            entity.Property(e => e.CBirth)
                .HasColumnType("datetime")
                .HasColumnName("c_Birth");
            entity.Property(e => e.CCardId)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("c_CardId");
            entity.Property(e => e.CEMail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("c_E_mail");
            entity.Property(e => e.CGender)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("c_Gender");
            entity.Property(e => e.CMobile)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("c_Mobile");
            entity.Property(e => e.CName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("c_Name");
            entity.Property(e => e.CPassword)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("c_Password");
            entity.Property(e => e.CPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("c_Phone");
            entity.Property(e => e.CPostcode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("c_Postcode");
            entity.Property(e => e.CQuestion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("c_Question");
            entity.Property(e => e.CSafeCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("c_SafeCode");
            entity.Property(e => e.CTrueName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("c_TrueName");
            entity.Property(e => e.CType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("c_Type");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EId).HasName("PK__Employee__3EB420A2EF432495");

            entity.Property(e => e.EId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("e_ID");
            entity.Property(e => e.EAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("e_Address");
            entity.Property(e => e.EBirth)
                .HasColumnType("datetime")
                .HasColumnName("e_Birth");
            entity.Property(e => e.EEMail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("e_E_mail");
            entity.Property(e => e.EGender)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("e_Gender");
            entity.Property(e => e.EMobile)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("e_Mobile");
            entity.Property(e => e.EName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("e_Name");
            entity.Property(e => e.EPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("e_Phone");
            entity.Property(e => e.EPostcode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("e_Postcode");
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.GId).HasName("PK__Goods__49FC1D8C4DC2227D");

            entity.Property(e => e.GId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("g_ID");
            entity.Property(e => e.GDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("g_Description");
            entity.Property(e => e.GDiscount).HasColumnName("g_Discount");
            entity.Property(e => e.GImage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("g_Image");
            entity.Property(e => e.GName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("g_Name");
            entity.Property(e => e.GNumber).HasColumnName("g_Number");
            entity.Property(e => e.GPrice).HasColumnName("g_Price");
            entity.Property(e => e.GProduceDate)
                .HasColumnType("datetime")
                .HasColumnName("g_ProduceDate");
            entity.Property(e => e.GStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("g_Status");
            entity.Property(e => e.TId).HasColumnName("t_ID");

            entity.HasOne(d => d.TIdNavigation).WithMany(p => p.Goods)
                .HasForeignKey(d => d.TId)
                .HasConstraintName("FK__Goods__g_Descrip__29572725");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OId).HasName("PK__Orders__904CFE4688B63F90");

            entity.Property(e => e.OId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("o_ID");
            entity.Property(e => e.CId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("c_ID");
            entity.Property(e => e.EId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("e_ID");
            entity.Property(e => e.ODate)
                .HasColumnType("datetime")
                .HasColumnName("o_Date");
            entity.Property(e => e.OSendMode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("o_SendMode");
            entity.Property(e => e.OStatus).HasColumnName("o_Status");
            entity.Property(e => e.OSum).HasColumnName("o_Sum");
            entity.Property(e => e.PId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("p_Id");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__c_ID__300424B4");

            entity.HasOne(d => d.EIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__e_ID__30F848ED");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__p_Id__31EC6D26");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.DId).HasName("PK__OrderDet__D9544583326BA5ED");

            entity.Property(e => e.DId).HasColumnName("d_ID");
            entity.Property(e => e.DNumber).HasColumnName("d_Number");
            entity.Property(e => e.DPrice).HasColumnName("d_Price");
            entity.Property(e => e.GId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("g_ID");
            entity.Property(e => e.OId)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("o_ID");

            entity.HasOne(d => d.GIdNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.GId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDetai__g_ID__35BCFE0A");

            entity.HasOne(d => d.OIdNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDetai__o_ID__34C8D9D1");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__Payments__82E37F494C749578");

            entity.Property(e => e.PId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("p_Id");
            entity.Property(e => e.PMode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("p_Mode");
            entity.Property(e => e.PRemark)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("p_Remark");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("PK__Types__E5787AA757439689");

            entity.Property(e => e.TId).HasColumnName("t_ID");
            entity.Property(e => e.TDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("t_Description");
            entity.Property(e => e.TName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("t_Name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__Users__B50210122A3AC7BA");

            entity.Property(e => e.UId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("u_ID");
            entity.Property(e => e.UName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("u_Name");
            entity.Property(e => e.UPassword)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("u_Password");
            entity.Property(e => e.UType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("u_Type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
