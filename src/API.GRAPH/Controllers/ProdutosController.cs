﻿using API.GRAPH.Business;
using API.GRAPH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.GRAPH.Controllers
{

    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        private ProdutoService _service;

        public ProdutosController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _service.ListarTodos();
        }

        [HttpGet("{codigoBarras}")]
        public IActionResult Get(string codigoBarras)
        {
            var produto = _service.Obter(codigoBarras);
            if (produto != null)
                return new ObjectResult(produto);
            else
                return NotFound();
        }

        [HttpPost]
        public Resultado Post([FromBody] Produto produto)
        {
            return _service.Incluir(produto);
        }

        [HttpPut]
        public Resultado Put([FromBody] Produto produto)
        {
            return _service.Atualizar(produto);
        }

        [HttpDelete("{codigoBarras}")]
        public Resultado Delete(string codigoBarras)
        {
            return _service.Excluir(codigoBarras);
        }
    }
}