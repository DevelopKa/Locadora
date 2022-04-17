#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Locadora.Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rental.Data;
using Rental.Models;

namespace Locadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly RentalContext _context;
        private readonly IMapper _mapper;

        public ClientesController(RentalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        // GET: api/Clientes
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        //{
        //    return await _context.Clientes.ToListAsync();
        //}
        public IActionResult GetClientes()
        {
            List<Cliente> clientes = _context.Clientes.ToList();
            if (clientes == null)
            {
                return NotFound();
            }
            List<ReadClienteDto> readDto = _mapper.Map<List<ReadClienteDto>>(clientes);
            return Ok(readDto);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public IActionResult GetClientesId(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente != null)
            {
                ReadClienteDto clienteDto = _mapper.Map<ReadClienteDto>(cliente);
                return Ok(clienteDto);
            }
            return NotFound();
        }


        //// PUT: api/Clientes/5        
        

        [HttpPut("{id}")]
        public IActionResult PutCliente(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _mapper.Map(clienteDto, cliente);
            _context.SaveChanges();
            return NoContent();
        }

        //// POST: api/Clientes  
        [HttpPost]
        public IActionResult PostCliente([FromBody] CreateClienteDto clienteDto)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDto);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetClientesId), new { Id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
