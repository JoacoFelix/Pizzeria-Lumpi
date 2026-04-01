using BE_842JF;
using DAL_842JF;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Servicios_842JF.Observer;
using System.Diagnostics;

namespace BLL_842JF
{
    public class BLLOrdenDeCompra_842JF
    {
        DALOrdenDeCompra_842JF dalOrdenDeCompra_842JF = new DALOrdenDeCompra_842JF();
        BLLProducto_842JF bllproducto = new BLLProducto_842JF();
        BLLProveedor_842JF bllproveedor = new BLLProveedor_842JF();
        BLLDV_842JF bllDv = new BLLDV_842JF();

        IdiomaManager_842JF IM_842JF = IdiomaManager_842JF.Instancia_842JF;
        public void Guardar_842JF(BEOrdenCompra_842JF orden)
        {
            dalOrdenDeCompra_842JF.Guardar_842JF(orden);
            bllDv.Recalcular_842JF(new BEDV_842JF("OrdenDeCompra_842JF"));
        }
        public List<BEOrdenCompra_842JF> ObtenerTodos_842JF()
        {
            List<BEOrdenCompra_842JF> aux = new List<BEOrdenCompra_842JF>();
            foreach (var item in dalOrdenDeCompra_842JF.ObtenerTodos_842JF())
            {
                item.producto_842JF = bllproducto.ObtenerTodos_842JF().Find(x => x.codProducto_842JF == item.producto_842JF.codProducto_842JF);
                item.proveedor_842JF = bllproveedor.ObtenerTodos_842JF().Find(x => x.CUIT_842JF == item.proveedor_842JF.CUIT_842JF);
                aux.Add(item);
            }
            return aux;
        }
        public void Recibir_842JF(BEOrdenCompra_842JF orden)
        {
            orden.recibida_842JF = true;
            dalOrdenDeCompra_842JF.Recibir_842JF(orden);
            bllDv.Recalcular_842JF(new BEDV_842JF("OrdenDeCompra_842JF"));
        }
        public void Pagar_842JF(BEOrdenCompra_842JF orden)
        {
            orden.pago_842JF = true;
            dalOrdenDeCompra_842JF.Pagar_842JF(orden);
            bllDv.Recalcular_842JF(new BEDV_842JF("OrdenDeCompra_842JF"));
        }
        public void EliminarOrden_842JF(BEOrdenCompra_842JF orden)
        {
            dalOrdenDeCompra_842JF.EliminarOrden_842JF(orden);
            bllDv.Recalcular_842JF(new BEDV_842JF("OrdenDeCompra_842JF"));
        }
        public void ImprimirOrden_842JF(BEOrdenCompra_842JF orden)
        {
            IM_842JF.CargarFormulario_842JF("formGenerarOrdenDeCompra_842JF");

            string mensaje = $"{IM_842JF.ObtenerString_842JF("mensaje.codigoOrden")} {orden.codOrdenCompra_842JF}\n" +
                             $"{IM_842JF.ObtenerString_842JF("mensaje.fecha")} {orden.fecha_842JF}\n" +
                             $"{IM_842JF.ObtenerString_842JF("mensaje.producto")} {orden.producto_842JF.nombre_842JF}\n" +
                             $"{IM_842JF.ObtenerString_842JF("mensaje.proveedor")} {orden.proveedor_842JF.nombre_842JF}\n" +
                             $"{IM_842JF.ObtenerString_842JF("mensaje.precioUnitario")} {orden.precioUnitario_842JF:C2}\n" +
                             $"{IM_842JF.ObtenerString_842JF("mensaje.cantidad")} {orden.cantidad_842JF}\n"+
                             $"{IM_842JF.ObtenerString_842JF("mensaje.medida")} {orden.producto_842JF.medida_842JF}\n"+
                             $"{IM_842JF.ObtenerString_842JF("mensaje.total")} {orden.cantidad_842JF * orden.precioUnitario_842JF}\n";

            string tempFolder = Path.Combine(Path.GetTempPath(), $"OrdenCompraTemp_{Guid.NewGuid()}");
            Directory.CreateDirectory(tempFolder);

            string rutaPdf = Path.Combine(tempFolder, $"OrdenCompra_{orden.codOrdenCompra_842JF}.pdf");

            Document documento = new Document();
            PdfWriter.GetInstance(documento, new FileStream(rutaPdf, FileMode.Create));
            documento.Open();

            var font = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            documento.Add(new Paragraph("ORDEN DE COMPRA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));
            documento.Add(new Paragraph("\n" + mensaje, font));

            documento.Close();

            Process.Start(new ProcessStartInfo
            {
                FileName = rutaPdf,
                UseShellExecute = true
            });

            Task.Run(async () =>
            {
                await Task.Delay(5000);
                try
                {
                    if (File.Exists(rutaPdf)) File.Delete(rutaPdf);
                    if (Directory.Exists(tempFolder)) Directory.Delete(tempFolder, true);
                }
                catch
                {
                }
            });
        }
    }
}
