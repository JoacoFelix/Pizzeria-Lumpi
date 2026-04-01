using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_842JF;
using DAL_842JF;
using Servicios_842JF.Observer;

namespace BLL_842JF
{
    public class BLLProveedor_842JF
    {
        DALProveedor_842JF dalProveedor_842JF = new DALProveedor_842JF();
        IdiomaManager_842JF IM_842JF = IdiomaManager_842JF.Instancia_842JF;
        BLLProducto_842JF bllproducto = new BLLProducto_842JF();
        BLLDV_842JF bllDv = new BLLDV_842JF();
        public void Guardar_842JF(BEProveedor_842JF proveedor, List<BEProducto_842JF> prods)
        {
            proveedor.productos_842JF = prods;
            dalProveedor_842JF.Guardar_842JF(proveedor);
            bllDv.Recalcular_842JF(new BEDV_842JF("Proveedor_842JF"));
            foreach (var item in prods)
            {
                dalProveedor_842JF.GuardarProveedorProducto_842JF(new BEProveedorProducto_842JF(item.codProducto_842JF, proveedor.CUIT_842JF));
                bllDv.Recalcular_842JF(new BEDV_842JF("ProveedorProducto_842JF"));
            }
        }
        public List<BEProveedor_842JF> ObtenerTodos_842JF()
        {
            List<BEProveedor_842JF> aux = new List<BEProveedor_842JF> ();
            foreach(var item in  dalProveedor_842JF.ObtenerTodos_842JF())
            {
                foreach(var item2 in dalProveedor_842JF.ObtenerTodosProveedorProducto_842JF())
                {
                    if(item2.CUIT_842JF == item.CUIT_842JF)
                    {
                        item.productos_842JF.Add(bllproducto.ObtenerTodos_842JF().Find(x=>x.codProducto_842JF == item2.codProducto_842JF));
                    }
                }
                aux.Add(item);
            }
            return aux;
        }
        public void Modificar_842JF(BEProveedor_842JF prov, int telefono, bool estado, string mail, string direccion)
        {
            prov.telefono_842JF = telefono;
            prov.estado_842JF = estado;
            prov.mail_842JF = mail;
            prov.direccion_842JF = direccion;
            dalProveedor_842JF.Modificar_842JF(prov);
            bllDv.Recalcular_842JF(new BEDV_842JF("Proveedor_842JF"));
        }
        public void AgregarProducto_842JF(BEProveedor_842JF prov,BEProducto_842JF prod)
        {
            prov.productos_842JF.Add(prod);
            dalProveedor_842JF.GuardarProveedorProducto_842JF(new BEProveedorProducto_842JF(prod.codProducto_842JF, prov.CUIT_842JF));
            bllDv.Recalcular_842JF(new BEDV_842JF("ProveedorProducto_842JF"));
        }
        public void EliminarPrroveedor_842JF(BEProveedor_842JF prov)
        {
            dalProveedor_842JF.EliminarProveedor_842JF(prov);
            bllDv.Recalcular_842JF(new BEDV_842JF("Proveedor_842JF"));
            dalProveedor_842JF.EliminarProvProducto_842JF(prov);
            bllDv.Recalcular_842JF(new BEDV_842JF("ProveedorProducto_842JF"));
        }
        public void EliminarProducto_842JF(BEProveedor_842JF prov, BEProducto_842JF prod)
        {
            prov.productos_842JF.Remove(prod);
            dalProveedor_842JF.EliminarProveedorProducto_842JF(new BEProveedorProducto_842JF(prod.codProducto_842JF,prov.CUIT_842JF));
            bllDv.Recalcular_842JF(new BEDV_842JF("ProveedorProducto_842JF"));
        }
    }
}
