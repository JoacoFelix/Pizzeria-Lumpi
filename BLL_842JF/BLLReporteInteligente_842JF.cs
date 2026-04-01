using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks; // Necesario para Task.Run y Task.Delay
using System.Windows.Forms.DataVisualization.Charting;

namespace BLL_842JF
{
    public class BLLReporteInteligente_842JF
    {
        BLLCliente_842JF bllcliente = new BLLCliente_842JF();
        BLLPizza_842JF bllpizza = new BLLPizza_842JF();
        BLLPedidoPizza_842JF bllpedidoPizza = new BLLPedidoPizza_842JF();
        BLLPedido_842JF bllpedido = new BLLPedido_842JF();
        BLLFactura_842JF bllfactura = new BLLFactura_842JF();

        public void GenerarReporte() // 🚨 NO recibe ruta por parámetro
        {
            // 1. Ejecutar la generación del reporte en un hilo secundario
            Task.Run(() =>
            {
                // Definir rutas temporales
                string tempFolder = Path.Combine(Path.GetTempPath(), $"ReporteTemp_{Guid.NewGuid()}");
                Directory.CreateDirectory(tempFolder);
                string rutaPdf = Path.Combine(tempFolder, $"ReportePizzas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                try
                {
                    // 2. Generar gráficos en paralelo (dentro del Task.Run principal)
                    var taskTopClientes = Task.Run(() => GenerarGraficoTopClientesUltimoMes());
                    var taskVentasMes = Task.Run(() => GenerarGraficoVentasPorMes());
                    var taskPizzasVendidas = Task.Run(() => GenerarGraficoPizzasMasVendidas());

                    Task.WaitAll(taskTopClientes, taskVentasMes, taskPizzasVendidas);

                    var imagenTopClientes = taskTopClientes.Result;
                    var imagenVentasPorMes = taskVentasMes.Result;
                    var imagenPizzas = taskPizzasVendidas.Result;

                    // 3. Crear el documento PDF
                    Document doc = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaPdf, FileMode.Create));
                    doc.Open();

                    // 4. Agregar contenido
                    doc.Add(new Paragraph("Top Clientes del Último Mes"));
                    doc.Add(new Paragraph("\n"));
                    AgregarImagenAlPDF(doc, imagenTopClientes);

                    doc.Add(new Paragraph("\nVentas por Mes (Año Actual)"));
                    doc.Add(new Paragraph("\n"));
                    AgregarImagenAlPDF(doc, imagenVentasPorMes);

                    doc.Add(new Paragraph("\n\n\n\n\n\nPizzas Más Vendidas Últimos 3 Meses"));
                    doc.Add(new Paragraph("\n"));
                    AgregarImagenAlPDF(doc, imagenPizzas);

                    doc.Close();

                    // 5. Abrir el PDF (usa Process.Start)
                    var psi = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = rutaPdf,
                        UseShellExecute = true
                    };
                    System.Diagnostics.Process.Start(psi);

                    // 6. Configurar la tarea de limpieza temporizada
                    Task.Run(async () =>
                    {
                        await Task.Delay(5000); // Espera 5 segundos
                        try
                        {
                            // Eliminar el archivo después de que el visor lo haya liberado
                            if (File.Exists(rutaPdf)) File.Delete(rutaPdf);
                            // Eliminar la carpeta temporal
                            if (Directory.Exists(tempFolder)) Directory.Delete(tempFolder, true);
                        }
                        catch
                        {
                            // No hacer nada si falla la eliminación (por ejemplo, si el PDF sigue abierto)
                        }
                    });
                }
                catch (Exception ex)
                {
                    // Manejar excepciones de creación/lectura de datos aquí
                    // Nota: Es importante notificar a la capa de UI sobre este error si ocurre.
                    Debug.WriteLine($"Error al generar reporte temporal: {ex.Message}");
                }
            });
        }

        // --- MÉTODOS AUXILIARES Y GRÁFICOS RESTANTES (Sin cambios en el cuerpo) ---

        private void AgregarImagenAlPDF(Document doc, System.Drawing.Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                iTextSharp.text.Image pdfImg = iTextSharp.text.Image.GetInstance(ms.ToArray());
                pdfImg.ScaleToFit(500f, 300f);
                doc.Add(pdfImg);
            }
        }

        private System.Drawing.Image GenerarGraficoTopClientesUltimoMes()
        {
            var pedidos = bllpedido.ObtenerTodos_842JF();
            var clientes = bllcliente.ObtenerTodos_842JF();
            var facturas = bllfactura.ObtenerTodos_842JF();

            DateTime limite = DateTime.Now.AddMonths(-1);

            var pedidosConFecha = facturas
                .Where(f => f.fecha_842JF >= limite)
                .GroupBy(f => f.pedido_842JF.nroPedido_842JF)
                .Select(g => g.First().pedido_842JF)
                .ToList();

            var topClientes = pedidosConFecha
                .GroupBy(p => p.cliente_842JF.DNI_842JF)
                .Select(g => new
                {
                    DNI = g.Key,
                    Cantidad = g.Count(),
                    Nombre = clientes
                        .Where(c => c.DNI_842JF == g.Key)
                        .Select(c => c.nombre_842JF + " " + c.apellido_842JF)
                        .FirstOrDefault()
                })
                .OrderByDescending(x => x.Cantidad)
                .Take(5)
                .ToList();

            Chart chart = new Chart();
            chart.Width = 800;
            chart.Height = 600;

            chart.Titles.Add("Top 5 Clientes - Pedidos Último Mes");

            ChartArea area = new ChartArea("Area1");

            area.AxisX.IsLabelAutoFit = true;
            area.AxisX.LabelStyle.Angle = -20;
            area.AxisX.MajorGrid.LineWidth = 0;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            area.AxisX.Title = "Cliente";
            area.AxisY.Title = "Cantidad de Pedidos";

            chart.ChartAreas.Add(area);

            Series series = new Series("Top Clientes");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "N0";

            series.IsXValueIndexed = true;

            // Se elimina el foreach incorrecto

            int i = 0;
            series.Points.Clear();

            foreach (var c in topClientes)
            {
                series.Points.AddY(c.Cantidad);
                series.Points[i].AxisLabel = c.Nombre;
                i++;
            }

            chart.Series.Add(series);

            return ConvertirChartAImagen(chart);
        }

        private System.Drawing.Image GenerarGraficoVentasPorMes()
        {
            var facturas = bllfactura.ObtenerTodos_842JF();

            int añoActual = DateTime.Now.Year;

            var facturasAnio = facturas.Where(f => f.fecha_842JF.Year == añoActual).ToList();

            var pedidosPorMes = facturasAnio
                .GroupBy(f => f.fecha_842JF.Month)
                .Select(g => new
                {
                    Mes = g.Key,
                    Cantidad = g.Count()
                })
                .ToDictionary(x => x.Mes, x => x.Cantidad);

            var listaMeses = Enumerable.Range(1, 12)
                .Select(m => new
                {
                    Mes = m,
                    Cantidad = pedidosPorMes.ContainsKey(m) ? pedidosPorMes[m] : 0
                })
                .OrderBy(x => x.Mes)
                .ToList();

            Chart chart = new Chart();
            chart.Width = 900;
            chart.Height = 600;

            var area = new ChartArea("Area1");

            area.AxisX.IsMarginVisible = false;
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.Title = "Cantidad de Pedidos";
            area.AxisX.Title = "Mes";
            chart.ChartAreas.Add(area);

            chart.Titles.Add($"Pedidos generados por mes - {añoActual}");

            Series series = new Series("PedidosGenerados");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;

            series.IsXValueIndexed = true;

            series.IsValueShownAsLabel = true;
            series.Font = new System.Drawing.Font("Segoe UI", 9f, FontStyle.Bold);

            int i = 0;
            foreach (var item in listaMeses)
            {
                string mesLabel = new DateTime(añoActual, item.Mes, 1).ToString("MMM");

                series.Points.AddXY(i, item.Cantidad);

                series.Points[i].AxisLabel = mesLabel;

                i++;
            }

            chart.Series.Add(series);

            var legend = new Legend();
            legend.Enabled = false;
            chart.Legends.Add(legend);

            var mesMaxPedidos = listaMeses.OrderByDescending(x => x.Cantidad).FirstOrDefault();
            if (mesMaxPedidos != null && mesMaxPedidos.Cantidad > 0)
            {
                int indiceMax = mesMaxPedidos.Mes - 1;

                series.Points[indiceMax].Color = Color.Red;
                series.Points[indiceMax].MarkerColor = Color.Red;
                series.Points[indiceMax].LabelBackColor = Color.Yellow;
                series.Points[indiceMax].Label = $"MAX: {mesMaxPedidos.Cantidad}";
            }

            return ConvertirChartAImagen(chart);
        }

        private System.Drawing.Image GenerarGraficoPizzasMasVendidas()
        {
            var pedidos = bllpedido.ObtenerTodos_842JF();
            var pizzas = bllpizza.ObtenerTodas_842JF();
            var pedidoPizzas = bllpedidoPizza.ObtenerTodos_842JF();
            var facturas = bllfactura.ObtenerTodos_842JF();

            DateTime limite = DateTime.Now.AddMonths(-3);

            var pedidosValidos = facturas
                .Where(f => f.fecha_842JF >= limite)
                .Select(f => f.pedido_842JF.nroPedido_842JF)
                .ToList();

            var pedidoPizzaFiltrado = pedidoPizzas
                .Where(pp => pedidosValidos.Contains(pp.nroPedido_842JF))
                .ToList();

            var query = pedidoPizzaFiltrado
                .GroupBy(pp => pp.codPizza_842JF)
                .Select(g => new
                {
                    IdPizza = g.Key,
                    Cant = g.Sum(x => x.cantidad_842JF),
                    Nombre = pizzas.FirstOrDefault(p => p.codPizza_842JF == g.Key)?.nombre_842JF
                })
                .OrderByDescending(x => x.Cant)
                .ToList();

            Chart chart = new Chart();
            chart.Width = 900;
            chart.Height = 600;
            chart.ChartAreas.Add(new ChartArea());

            Series series = new Series("Pizzas");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = false;

            Legend legend = new Legend("Leyenda");
            legend.Docking = Docking.Right;
            legend.Alignment = StringAlignment.Center;
            legend.LegendStyle = LegendStyle.Table;
            legend.TableStyle = LegendTableStyle.Tall;
            legend.Font = new System.Drawing.Font("Arial", 10);

            chart.Legends.Add(legend);
            series.LegendText = "#VALX (#VALY)";

            foreach (var item in query)
                series.Points.AddXY(item.Nombre, item.Cant);

            chart.Series.Add(series);

            return ConvertirChartAImagen(chart);
        }



        private System.Drawing.Image ConvertirChartAImagen(Chart chart)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                chart.SaveImage(ms, ChartImageFormat.Png);
                return System.Drawing.Image.FromStream(ms);
            }
        }
    }
}