using Dapper;
using Entity.Model.Entity.Location;
using Entity.Model.Entity.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entity.Model.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Vista> Vistas { get; set; }
        public DbSet<Rol_Vista> RolVistas { get; set; }

        protected readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration): base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // llaves foraneas de Security 

            modelBuilder.Entity<Usuario>()
            .HasOne(u => u.persona)
            .WithMany(p => p.Usuarios)
            .HasForeignKey(u => u.personaId);

            modelBuilder.Entity<Vista>()
            .HasOne(u => u.modulo)
            .WithMany(p => p.vistas)
            .HasForeignKey(u => u.moduloId);

            modelBuilder.Entity<Rol_Vista>()
                .HasOne(rv => rv.rol)
                .WithMany(r => r.rol_Vistas_rol)
                .HasForeignKey(rv => rv.rolId);

            modelBuilder.Entity<Rol_Vista>()
                .HasOne(rv => rv.vista)
                .WithMany(v => v.rol_vista_vista)
                .HasForeignKey(rv => rv.vistaId);

            modelBuilder.Entity<Usuario_rol>()
                .HasOne(rv => rv.usuario)
                .WithMany(v => v.usuario_rol_usuario)
                .HasForeignKey(rv => rv.usuario_id);

            modelBuilder.Entity<Usuario_rol>()
                .HasOne(rv => rv.rol)
                .WithMany(v => v.rol_usuario_rol)
                .HasForeignKey(rv => rv.rol_id);

            // llaves foraneas de Location 
            modelBuilder.Entity<Country>()
                .HasOne(c => c.continet)
                .WithMany(co => co.country)
                .HasForeignKey(c => c.Continet_id);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.country)
                .WithMany(co => co.departments)
                .HasForeignKey(d => d.countryId);

            modelBuilder.Entity<City>()
                .HasOne(c => c.department)
                .WithMany(co => co.city)
                .HasForeignKey(c => c.departmentId);


            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //DataInicial.Data(modelBuilder);

            //ajuste des tipo de dato datetime
        }
        ///<summary>
        ///es una opcion en Entity Framework core que controla si se deben registar o no datos sensibles (como valores de parametros de consola)
        ///durante la ejecucion de consultas y operaciones en la base de dato.
        ///</summary>
        ///<param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            //otras configuraciones
            //Defino que todos los decimales usados tengan la precicion (18, 2)
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }
        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }
        //parameter

        //security
        public DbSet<Rol> rol => Set<Rol>();
        public DbSet<Persona> personas => Set<Persona>();
        public DbSet<Vista> vistas => Set<Vista>(); 
        public DbSet<Usuario_rol> usuario_rol => Set<Usuario_rol>();
        public DbSet<Modulo> modulo => Set<Modulo>();

        public DbSet<Usuario> usuario => Set<Usuario>();
        public DbSet<Rol_Vista> rol_vista => Set<Rol_Vista>();

        public DbSet<Continet> continet => Set<Continet>();
        public DbSet<Country> country => Set<Country>();
        public DbSet<Department> department => Set<Department>();
        public DbSet<City> city => Set<City>();
    }
    public readonly struct DapperEFCoreCommand : IDisposable
    {
        public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
        {
            var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
            var commandType = type ?? CommandType.Text;
            var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

            Definition = new CommandDefinition(
                text,
                parameters,
                transaction,
                commandTimeout,
                commandType,
                cancellationToken: ct
                );
        }
        public CommandDefinition Definition { get; }

        public void Dispose()
        {
        }

    }
}
