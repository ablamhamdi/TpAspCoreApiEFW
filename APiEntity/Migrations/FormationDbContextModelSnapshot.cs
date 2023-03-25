﻿// <auto-generated />
using APiEntity.DbCont;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APiEntity.Migrations
{
    [DbContext(typeof(FormationDbContext))]
    partial class FormationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APiEntity.Entitys.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Contact");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("APiEntity.Entitys.Cuisin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Cuisin");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Cuisin");
                });

            modelBuilder.Entity("APiEntity.Entitys.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("CuisinId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("PK_Restaurant");

                    b.HasIndex("ContactId")
                        .IsUnique();

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("APiEntity.Entitys.Cuisin", b =>
                {
                    b.HasOne("APiEntity.Entitys.Restaurant", "Restaurant")
                        .WithMany("Cuisins")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Cuisins_RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("APiEntity.Entitys.Restaurant", b =>
                {
                    b.HasOne("APiEntity.Entitys.Contact", "Contact")
                        .WithOne("Restaurant")
                        .HasForeignKey("APiEntity.Entitys.Restaurant", "ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Restaurant_Contact");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("APiEntity.Entitys.Contact", b =>
                {
                    b.Navigation("Restaurant")
                        .IsRequired();
                });

            modelBuilder.Entity("APiEntity.Entitys.Restaurant", b =>
                {
                    b.Navigation("Cuisins");
                });
#pragma warning restore 612, 618
        }
    }
}
