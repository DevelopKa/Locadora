#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Locadora.Data.Dtos.Locacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rental.Data;
using Rental.Models;

namespace Locadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaosController : ControllerBase
    {
        private readonly RentalContext _context;
        private readonly IMapper _mapper;

        public LocacaosController(RentalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Locacaos
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Locacao>>> GetLocacaos()
        //{
        //    return await _context.Locacaos.ToListAsync();
        //}
        public IActionResult GetLocacaos()
        {
            List<Locacao> locacaos = _context.Locacaos.ToList();
            if (locacaos == null)
            {
                return NotFound();
            }
            List<ReadLocadoraDto> readDto = _mapper.Map<List<ReadLocadoraDto>>(locacaos);
            return Ok(readDto);
        }

        // GET: api/Locacaos/5
        [HttpGet("{id}")]
        public IActionResult GetLocacaoId(int id)
        {
            Locacao locacao = _context.Locacaos.FirstOrDefault(locacao => locacao.Id == id);
            if (locacao != null)
            {
                ReadLocadoraDto locacaoDto = _mapper.Map<ReadLocadoraDto>(locacao);
                return Ok(locacaoDto);
            }
            return NotFound();
        }

        // PUT: api/Locacaos/5
        [HttpPut("{id}")]
        public IActionResult PutLocacao(int id, [FromBody] UpdateLocadoraDto locacaoDto)
        {
            Locacao locacao = _context.Locacaos.FirstOrDefault(locacao => locacao.Id == id);
            if (locacao == null)
            {
                return NotFound();
            }
            _mapper.Map(locacaoDto, locacao);
            _context.SaveChanges();
            return NoContent();
        }

        // POST: api/Locacaos  
        [HttpPost]
        public IActionResult PostLocacao([FromBody] CreateLocadoraDto locacaoDto)
        {
            Locacao locacao = _mapper.Map<Locacao>(locacaoDto);
            _context.Locacaos.Add(locacao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLocacaoId), new { Id = locacao.Id }, locacao);
        }

        // DELETE: api/Locacaos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLocacao(int id)
        {
            Locacao locacao = _context.Locacaos.FirstOrDefault(locacao => locacao.Id == id);
            if (locacao == null)
            {
                return NotFound();
            }
            _context.Remove(locacao);
            _context.SaveChanges();
            return NoContent();
        }

        private bool LocacaoExists(int id)
        {
            return _context.Locacaos.Any(e => e.Id == id);
        }
    }
}
