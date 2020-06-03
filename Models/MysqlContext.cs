using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TodoApi.Models;


namespace TodoApi.Models
{
    public class MysqlContext : DbContext
    {
        public MysqlContext(DbContextOptions<MysqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<addresses> addresses { get; set; }
        public virtual DbSet<building_details> building_details { get; set; }
        public DbSet<buildings> buildings { get; set; }
        public DbSet<columns> columns { get; set; }
        public DbSet<customers> customers { get; set; }
        public virtual DbSet<elevators> elevators { get; set; }
        public virtual DbSet<employees> employees { get; set; }
        public DbSet<leads> leads { get; set; }
        public virtual DbSet<batteries> batteries { get; set; }
        public virtual DbSet<quotes> quotes { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<interventions> interventions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<batteries>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.building_id)
                    .HasName("index_batteries_on_building_id");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.building_id)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.created_at)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.updated_at)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.building)
                    .WithMany(p => p.batteries)
                    .HasForeignKey(d => d.building_id)
                    .HasConstraintName("fk_rails_fc40470545");
            });

            modelBuilder.Entity<building_details>(entity =>
            {
                entity.ToTable("building_details");

                entity.HasIndex(e => e.building_id)
                    .HasName("index_building_details_on_building_id");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.building_id)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.building)
                    .WithMany(p => p.building_details)
                    .HasForeignKey(d => d.building_id)
                    .HasConstraintName("fk_rails_51749f8eac");
            });

            modelBuilder.Entity<buildings>(entity =>
            {
                entity.ToTable("buildings");


                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<columns>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.battery_id)
                    .HasName("index_columns_on_battery_id");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.battery_id)
                    .HasColumnName("battery_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.battery)
                    .WithMany(p => p.columns)
                    .HasForeignKey(d => d.battery_id)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });



            modelBuilder.Entity<elevators>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.column_id)
                    .HasName("index_elevators_on_column_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.column_id)
                    .HasColumnName("column_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.column)
                    .WithMany(p => p.elevators)
                    .HasForeignKey(d => d.column_id)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });


            modelBuilder.Entity<customers>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)");

                entity.Property(e => e.company_desc)
                .HasColumnName("company_desc")
                .HasColumnType("varchar(255)");

                entity.Property(e => e.contact_email)
                    .HasColumnName("contact_email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.tech_manager_email)
                    .HasColumnName("tech_manager_email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.full_name_STA)
                    .HasColumnName("full_name_STA")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.tech_authority_phone)
                    .HasColumnName("tech_authority_phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.updated_at)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

            });


            modelBuilder.Entity<leads>(entity =>
            {
                entity.ToTable("leads");

                entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .HasColumnType("bigint(20)");

                entity.Property(e => e.Company_name)
                    .HasColumnName("company_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Full_name)
                    .HasColumnName("full_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.project_name)
                    .HasColumnName("project_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

            });
        }


    }
}