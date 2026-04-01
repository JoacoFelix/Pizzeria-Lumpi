using BE_842JF;
using DAL_842JF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_842JF
{
    public class BLLPizza_842JF
    {
        DALPizza_842JF dalpizza_842JF = new DALPizza_842JF();
        BLLProducto_842JF bllproducto = new BLLProducto_842JF();
        public List<BEPizza_842JF> ObtenerTodas_842JF()
        {
            List<BEPizza_842JF> aux = new List<BEPizza_842JF>();
            foreach(var item in dalpizza_842JF.ObtenerTodas_842JF())
            {
                if (item.codPizza_842JF == 1)
                {
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Harina"), 200);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Queso"), 500);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Salsa"), 100);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Oregano"), 10);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Aceituna"), 8);
                }
                else if (item.codPizza_842JF == 2)
                {
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Harina"), 200);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Queso"), 500);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Salsa"), 100);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Jamon"), 200);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Oregano"), 10);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Aceituna"), 8);
                }
                else if (item.codPizza_842JF == 3)
                {
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Harina"), 200);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Queso"), 500);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Salsa"), 100);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Jamon"), 200);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Morron"), 50);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Oregano"), 10);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Aceituna"), 8);
                }
                else if (item.codPizza_842JF == 4)
                {
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Harina"), 200);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Queso"), 500);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Cebolla"), 400);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Oregano"), 10);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Aceituna"), 8);
                }
                else if (item.codPizza_842JF == 5)
                {
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Harina"), 200);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Queso"), 500);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Salsa"), 100);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Jamon Crudo"), 150);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Rucula"), 100);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Oregano"), 10);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Aceituna"), 8);
                }
                else if (item.codPizza_842JF == 6)
                {
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Harina"), 400);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Queso"), 500);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Jamon"), 200);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Cebolla"), 200);
                    item.productos.Add(bllproducto.ObtenerTodos_842JF().Find(x => x.nombre_842JF == "Oregano"), 10);
                }
                aux.Add(item);
            }
            return aux;
        }
    }
}
