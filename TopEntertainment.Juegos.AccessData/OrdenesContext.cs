using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Ordenes.Domain.Entities;

namespace TopEntertainment.Ordenes.AccessData
{
    public class OrdenesContext : DbContext
    {
        public OrdenesContext() { }

        public OrdenesContext(DbContextOptions<OrdenesContext> options) : base(options) { }
        public virtual DbSet<Compra> Compras { get; set; }
        //public virtual DbSet<Carrito> Carritos { get; set; }
        //public virtual DbSet<CarritoDetalle> CarritoDetalles { get; set; }
        public virtual DbSet<Carrito> Carritos { get; set; }
        public virtual DbSet<JuegoCarrito> JuegoCarrito { get; set; }
        public virtual DbSet<CompraDetalle> CompraDetalles { get; set; }
        public virtual DbSet<EstadoDetalle> EstadoDetalles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TopEnterTainmentOrders;Trusted_Connection=True;Integrated Security=True;;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Importe)
                .HasMaxLength(50);
                entity.Property(e => e.UsuarioId)
                .HasMaxLength(45);
                entity.Property(e => e.FechaHora).HasColumnType("date");
                entity.Property(e => e.Comprobante)
                .HasMaxLength(2000);

            });
            modelBuilder.Entity<CompraDetalle>(entity =>
            {
            entity.HasKey(r => r.Id);

            entity.Property(e => e.Importe)
                  .HasMaxLength(45);

            entity.Property(e => e.Precio)
                  .HasMaxLength(20);

            entity.HasOne(e => e.Compra)
                  .WithOne(d => d.compradetalle)
                  .HasForeignKey<Compra>(a => a.Id);
            /*    
            entity.HasOne(e => e.JuegoCarrito)
                  .WithOne(d => d.Compradetalle)
                  .HasForeignKey<JuegoCarrito>(c => c.Id);
            */
                
                modelBuilder.Entity<Carrito>(entity =>
                {

                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.UsuarioId).IsRequired().HasMaxLength(45);
                    entity.HasOne(e => e.estado).WithMany(e => e.carritosEstado).HasForeignKey(e => e.EstadoID);
                });


                modelBuilder.Entity<JuegoCarrito>(entity =>
                {

                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.ProductoId).IsRequired();
                    entity.Property(e => e.Cantidad).IsRequired();
                    entity.HasOne(e => e.Carrito).WithMany(e => e.Carritos).HasForeignKey(e => e.CarritoID);

                });

                modelBuilder.Entity<EstadoDetalle>(entity =>
                {

                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Estado).IsRequired();
                });

                modelBuilder.Entity<EstadoDetalle>().HasData(
                    new EstadoDetalle() { Id = 1 },//, Estado = "Pendiente" },
                    new EstadoDetalle() { Id = 2 }//, Estado = "Compra" }
                    );

            });








        }
    }
}