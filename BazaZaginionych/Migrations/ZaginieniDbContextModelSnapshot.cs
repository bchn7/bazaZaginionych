// <auto-generated />
using BazaZaginionych.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BazaZaginionych.Migrations
{
    [DbContext(typeof(ZaginieniDbContext))]
    partial class ZaginieniDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BazaZaginionych.Models.ZaginieniModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Zaginieni");
                });
#pragma warning restore 612, 618
        }
    }
}
