﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OS.MealServices.DataLayer.Migrations
{
    [DbContext(typeof(MealContext))]
    [Migration("20191118155153_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MealSystem.DataLayer.Entities.IngredientEF", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAllergene")
                        .HasColumnType("bit");

                    b.Property<string>("NameDutch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameFrench")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("MealSystem.DataLayer.Entities.MealEF", b =>
                {
                    b.Property<int>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameDutch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameFrench")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MealId");

                    b.ToTable("Meal");
                });

            modelBuilder.Entity("MealSystem.DataLayer.Entities.MealIngredient", b =>
                {
                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("MealId", "IngredientId");

                    b.ToTable("MealIngredients");
                });

            modelBuilder.Entity("MealSystem.DataLayer.Entities.MealIngredient", b =>
                {
                    b.HasOne("MealSystem.DataLayer.Entities.IngredientEF", "Ingredient")
                        .WithMany("MealIngredient")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MealSystem.DataLayer.Entities.MealEF", "Meal")
                        .WithMany("MealIngredient")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
