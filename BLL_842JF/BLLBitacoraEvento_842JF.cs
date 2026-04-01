using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE_842JF;
using DAL_842JF;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;
using Servicios_842JF.Observer;

namespace BLL_842JF
{
    public class BLLBitacoraEvento_842JF
    {
        DALBitacoraEvento_842JF dalBitacoraEvento;
        IdiomaManager_842JF IM_842JF = IdiomaManager_842JF.Instancia_842JF;
        public BLLBitacoraEvento_842JF()
        {
            dalBitacoraEvento = new DALBitacoraEvento_842JF();
        }
        public void RegistrarEvento_842JF(BEEvento_842JF evento)
        {
            dalBitacoraEvento.RegistrarEvento_842JF(evento);
        }
        public List<BEEvento_842JF> ObtenerTodos_842JF()
        {
            return dalBitacoraEvento.ObtenerTodos_842JF();
        }
        public void GenerarReporte_842JF(List<BEEvento_842JF> eventos)
        {
            IM_842JF.CargarFormulario_842JF("formBitacoraEventos_842JF");
            string tempFolder = Path.Combine(Path.GetTempPath(), $"AuditoriaTemp_{Guid.NewGuid()}");
            Directory.CreateDirectory(tempFolder);
            string rutaPdf = Path.Combine(tempFolder, $"Auditoria_{DateTime.Now:ddMMyy_HHmm}.pdf");
            Document documento = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(documento, new FileStream(rutaPdf, FileMode.Create));
            documento.Open();
            var tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
            documento.Add(new Paragraph(IM_842JF.ObtenerString_842JF("datagridview.columna.reporte"), tituloFont));
            documento.Add(new Paragraph("\n"));
            PdfPTable tabla = new PdfPTable(6);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 12, 10, 10, 10, 10, 10 });
            tabla.AddCell(new PdfPCell(new Phrase(IM_842JF.ObtenerString_842JF("datagridview.columna.login"), headerFont)));
            tabla.AddCell(new PdfPCell(new Phrase(IM_842JF.ObtenerString_842JF("datagridview.columna.fecha"), headerFont)));
            tabla.AddCell(new PdfPCell(new Phrase(IM_842JF.ObtenerString_842JF("datagridview.columna.hora"), headerFont)));
            tabla.AddCell(new PdfPCell(new Phrase(IM_842JF.ObtenerString_842JF("datagridview.columna.modulo"), headerFont)));
            tabla.AddCell(new PdfPCell(new Phrase(IM_842JF.ObtenerString_842JF("datagridview.columna.evento"), headerFont)));
            tabla.AddCell(new PdfPCell(new Phrase(IM_842JF.ObtenerString_842JF("datagridview.columna.criticidad"), headerFont)));
            foreach (var ev in eventos)
            {
                tabla.AddCell(new Phrase(ev.login_842JF, normalFont));
                tabla.AddCell(new Phrase(ev.fechaHora_842JF.ToString("dd/MM/yyyy"), normalFont));
                tabla.AddCell(new Phrase(ev.fechaHora_842JF.ToString("HH:mm:ss"), normalFont));
                tabla.AddCell(new Phrase(ev.modulo_842JF, normalFont));
                tabla.AddCell(new Phrase(ev.evento_842JF, normalFont));
                tabla.AddCell(new Phrase(ev.criticidad_842JF.ToString(), normalFont));
            }
            documento.Add(tabla);
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
                catch { }
            });
        }
                
    }
}
