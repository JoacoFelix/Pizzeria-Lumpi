using System.Diagnostics;
using BE_842JF;
using DAL_842JF;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Servicios_842JF.Observer;
using Document = iTextSharp.text.Document;

namespace BLL_842JF
{
    public class BLLFactura_842JF
    {
        DALFactura_842JF dalfactura_842JF = new DALFactura_842JF();
        BLLPedido_842JF bllpedido_842JF = new BLLPedido_842JF();
        IdiomaManager_842JF IM_842JF = IdiomaManager_842JF.Instancia_842JF;
        BLLDV_842JF bllDv = new BLLDV_842JF();
        public void CrearFactura_842JF(BEFactura_842JF factura)
        {
            GenerarFactura_842JF(factura);
            dalfactura_842JF.CrearFactura_842JF(factura);
            bllDv.Recalcular_842JF(new BEDV_842JF("Factura_842JF"));
        }
        public List<BEFactura_842JF> ObtenerTodos_842JF()
        {
            List<BEFactura_842JF> lista = new List<BEFactura_842JF>();
            foreach (var item in dalfactura_842JF.ObtenerTodas_842JF())
            {
                item.pedido_842JF = bllpedido_842JF.ObtenerTodos_842JF().Find(x => x.nroPedido_842JF == item.pedido_842JF.nroPedido_842JF);
                item.total_842JF = item.pedido_842JF.total_842JF;
                lista.Add(item);
            }
            return lista;
        }
        public void GenerarFactura_842JF(BEFactura_842JF factura)
        {
            IM_842JF.CargarFormulario_842JF("formGenerarFactura_842JF");

            var pizzasAgrupadas = factura.pedido_842JF.pizzas_842JF.GroupBy(p => p.nombre_842JF)
            .Select(grupo =>
            {
                int cantidad = grupo.Count();
                decimal precioUnitario = grupo.First().precio_842JF;
                decimal total = cantidad * precioUnitario;
                return $"{cantidad}x {grupo.Key} - ${total:F2}";
            });
            string listaPizzas = string.Join("\n - ", pizzasAgrupadas);

            string mensaje = $"{IM_842JF.ObtenerString_842JF("mensaje.numero")} {factura.nroFactura_842JF}\n" +
                                $"{IM_842JF.ObtenerString_842JF("mensaje.cliente")} {factura.pedido_842JF.cliente_842JF.DNI_842JF} - {factura.pedido_842JF.cliente_842JF.nombre_842JF} {factura.pedido_842JF.cliente_842JF.apellido_842JF}\n" +
                                $"{IM_842JF.ObtenerString_842JF("mensaje.fecha")} {factura.fecha_842JF}\n" +
                                $"{IM_842JF.ObtenerString_842JF("mensaje.medioDePago")} {factura.medioDePago_842JF}\n" +
                                $"{IM_842JF.ObtenerString_842JF("mensaje.pizzas")}\n - {listaPizzas}\n" +
                                $"{IM_842JF.ObtenerString_842JF("mensaje.totalSinIva")} {(factura.total_842JF - (factura.total_842JF * 0.21m)):F2}\n" +
                                $"{IM_842JF.ObtenerString_842JF("mensaje.total")} {factura.total_842JF}";
            Task.Run(() =>
            {
                string tempFolder = Path.Combine(Path.GetTempPath(), $"FacturaTemp_{Guid.NewGuid()}");
                Directory.CreateDirectory(tempFolder);
                string rutaPdf = Path.Combine(tempFolder, $"Factura_{factura.nroFactura_842JF}.pdf");

                Document documento = new Document();
                PdfWriter.GetInstance(documento, new FileStream(rutaPdf, FileMode.Create));
                documento.Open();
                var font = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                documento.Add(new Paragraph("FACTURA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));
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
            });
        }
    }
}
