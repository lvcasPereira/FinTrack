using Infrastructura.EF;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Infrastructura.Repositorios
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private GastosContext _context;
        public RepositorioCategoria(GastosContext context)
        {
            _context = context;
        }
        public void Add(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();

        }

        public void Delete(int Id)
        {
            Categoria CatAux = GetById(Id);
            _context.Categorias.Remove(CatAux);
            _context.SaveChanges();
        }

        public bool ExisteCategoria(string nombre)
        {
            bool existe = false;
            
            if(_context.Categorias.Any(c => c.Nombre.Value == nombre))
            {
                existe = true;
            }

            return existe;
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _context.Categorias
                    .ToList();
        }


        public Categoria GetById(int id)
        {
            Categoria Aux = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if (Aux == null) throw new CategoriaNoEncontradaException($"No existe categoria con id {id}.");

            return Aux;
        }

        public void Update(int id, Categoria categoria)
        {
            var categoriaExistente = _context.Categorias.Find(id);
            if (categoriaExistente == null) throw new CategoriaNoEncontradaException($"No existe categoria con id {id}.");

            categoriaExistente.Nombre = categoria.Nombre;

            _context.SaveChanges();
        }
    }
}
