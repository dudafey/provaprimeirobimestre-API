using System;


namespace API.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Estimativa { get; set; }
        public string Responsavel { get; set; }
        public DateTime CriadoEm { get; private set; } = DateTime.Now;

    }
}
