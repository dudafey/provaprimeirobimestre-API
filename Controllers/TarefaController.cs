using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/tarefa")]
    public class TarefaController : ControllerBase
    {
        private readonly DataContext _context;
        public TarefaController(DataContext context)
        {
            _context = context;
        }

        // POST: api/tarefa/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return Created("", tarefa);
        }

        // GET: api/tarefa/list
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListAsync() => Ok(await _context.Tarefas.ToListAsync());

        // GET: api/tarefa/getbyid/5
        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            Tarefa tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                return Ok(tarefa);
            }
            return NotFound();
        }

        // DELETE: api/tarefa/delete/bolacha
        [HttpDelete]
        [Route("delete/{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int Id)
        {
            //Retorna o primeiro elemento com base na expressão lambda
            Tarefa tarefa = _context.Tarefas.FirstOrDefault
            (
                tarefa => tarefa.Id == Id
            );
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/tarefa/delete/bolacha
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
            return Ok(tarefa);
        }
    }
}