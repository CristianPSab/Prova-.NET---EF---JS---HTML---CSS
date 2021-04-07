using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjEntidades
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 7

            var categoria = new Categoria { Id = 1, Nombre = "Lacteos", Descripcion = "Productos lacteos" };
            var producto = new Producto { Codigo = 1, Nombre = "Leche", Descripcion = "Producto Lacteo", Categoria = categoria };
            var producto2 = new Producto { Codigo = 2, Nombre = "Manzana", Descripcion = "Producto frutal ", Categoria = categoria };
            using (var contexto = new Context())
            {
                try
                {

                    contexto.Productos.Add(producto);
                    contexto.Productos.Add(producto2);


                    contexto.SaveChanges();

                    //Ejercicio 8

                    var leftJoin = from p in contexto.Productos
                                   join c in contexto.Categorias on p.IdCategoria equals c.Id into Id
                                   select new
                                   {
                                       ProductoC = p.Codigo,
                                       CategoriaN = categoria.Nombre,
                                       CategoriaD = categoria.Descripcion
                                   };
                    Console.WriteLine("Código del producto\tNombre de categoria\tNombre de descripción");

                    foreach (var data in leftJoin)
                    {
                        Console.WriteLine(data.ProductoC + "\t\t\t\t" + data.CategoriaN + "\t\t" + data.CategoriaD);

                    }

                    Console.ReadLine();


                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);

                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }
    }
}
