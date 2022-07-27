using SistemasWeb.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SistemasWeb.Areas.Categorias.Models;

namespace SistemasWeb.Library
{
    public class LCategorias
    {
        private ApplicationDbContext _context;

        public LCategorias(ApplicationDbContext context)
        {
            _context = context;
        }
        public IdentityError RegistrarCategoria(TCategoria categoria)
        {
            IdentityError identityError;
            try {
                _context.Add(categoria);
                _context.SaveChanges();
                identityError = new IdentityError { Code = "Done" };
            } 
            catch (Exception e) {
                identityError = new IdentityError
                {
                    Code = "Error",
                    Description = e.Message
                };
            }
            return identityError;
        }
        public List<TCategoria> getTCategoria(String valor)
        {
            List<TCategoria> listCategoria;
            if (valor == null)
            {
                listCategoria = _context._TCategoria.ToList();
            }
            else
            {
                listCategoria = _context._TCategoria.Where(c => c.Nombre.StartsWith(valor)).ToList();
            }
            return listCategoria;
        }
        internal IdentityError UpdateEstado(int id)
        {
            IdentityError identityError;
            try
            {
                var categoria = _context._TCategoria.Where(c => c.CategoriaID.Equals(id)).ToList().ElementAt(0);
                categoria.Estado = categoria.Estado ? false : true;
                _context.Update(categoria);
                _context.SaveChanges();
                identityError = new IdentityError { Description = "Done" };
            }
            catch (Exception e)
            {
                identityError = new IdentityError
                {
                    Code = "Error",
                    Description = e.Message
                };
            }
            return identityError;
        }

    }
}
