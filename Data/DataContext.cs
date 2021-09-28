using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        //Construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Lista de propriedades que serão transformadas em tabelas no banco de dados
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}