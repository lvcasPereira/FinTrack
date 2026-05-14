using Infrastructura.EF;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructura.Repositorios
{
    public class RepositorioGasto : IRepositorioGasto
    {
        private GastosContext _context;
        public RepositorioGasto(GastosContext context)
        {
            _context = context;
        }

        public void Add(Gasto gasto)
        {
            _context.Gastos.Add(gasto);
            _context.SaveChanges();
        }

        public IEnumerable<Gasto> GetAll()
        {
            return _context.Gastos
                .Include(g => g.Categoria)
                .ToList();
        }

        public Gasto GetById(int id)
        {
            var gasto = _context.Gastos.Include(g => g.Categoria).FirstOrDefault(g => g.Id == id);
            if (gasto == null) throw new GastoNoEncontradoException($"No existe gasto con id {id}.");
            return gasto;
        }

        public IEnumerable<Gasto> GetByCategoria(int categoriaId)
        {
            return _context.Gastos
                .Include(g => g.Categoria)
                .Where(g => g.CategoriaId == categoriaId)
                .ToList();
        }

        public IEnumerable<Gasto> GetByFecha(DateTime fecha)
        {
            return _context.Gastos
                .Include(g => g.Categoria)
                .Where(g => g.Fecha.Month == fecha.Month && g.Fecha.Year == fecha.Year)
                .ToList();
        }

        public void Delete(int Id)
        {
            Gasto unGasto = GetById(Id);
            _context.Gastos.Remove(unGasto);
            _context.SaveChanges();
        }

        public void Update(int id, Gasto gasto)
        {
            var gastoExistente = _context.Gastos.Find(id);
            if (gastoExistente == null) throw new GastoNoEncontradoException($"No existe gasto con id {id}.");

            gastoExistente.Descripcion = gasto.Descripcion;
            gastoExistente.Precio = gasto.Precio;
            gastoExistente.CategoriaId = gasto.CategoriaId;
            gastoExistente.Fecha = gasto.Fecha;

            _context.SaveChanges();
        }
    }
}
