using Microsoft.EntityFrameworkCore;
using Portafolio.WebApi.Entidades.Cargo;
using Portafolio.WebApi.Entidades.Departamento;
using Portafolio.WebApi.Entidades.Empleado;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portafolio.WebApi.Infraestructura.Context
{
    public class PortafolioContext : DbContext
    {
        public PortafolioContext(DbContextOptions<PortafolioContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EmpleadoEntidad> Empleados { get; set; }
        public DbSet<CargoEntidad> Cargos { get; set; }
        public DbSet<DepartamentoEntidad> Departamentos { get; set; }
    }
}
