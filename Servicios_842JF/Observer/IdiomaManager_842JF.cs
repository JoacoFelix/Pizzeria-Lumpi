using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Servicios_842JF.Observer
{
    public class IdiomaManager_842JF : IIdioma_842JF
    {
        private List<IIdiomaObserver_842JF> forms_842JF = new List<IIdiomaObserver_842JF>();
        private Dictionary<string, object> diccionario = new Dictionary<string, object>();
        public string Idioma_842JF { get; set; }
        public static IdiomaManager_842JF Instancia_842JF { get; } = new IdiomaManager_842JF();
        public IdiomaManager_842JF() { }
        public void CambiarIdioma_842JF(string idioma)
        {
            Idioma_842JF = idioma;
            Notificar_842JF();
        }
        public void CargarFormulario_842JF(string formulario)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Idiomas", $"{Idioma_842JF}", $"{formulario}.json");
                if (!File.Exists(path)) throw new FileNotFoundException($"No se encontro el archivo de idioma{path}");
                string json = File.ReadAllText(path);
                diccionario = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void CargarInstancia_842JF(string formulario)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Instancia", $"{formulario}.json");
                if (!File.Exists(path)) throw new FileNotFoundException($"No se encontro el archivo {path}");
                string json = File.ReadAllText(path);
                diccionario = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public string ObtenerString_842JF(string clave)
        {
            var claves = clave.Split('.');
            object current = diccionario;
            foreach (var subclave in claves)
            {
                if (subclave.Contains('['))
                {
                    var name = subclave.Substring(0, subclave.IndexOf('['));
                    var indexStr = subclave.Substring(subclave.IndexOf('[') + 1);
                    indexStr = indexStr.TrimEnd(']');
                    int index = int.Parse(indexStr);

                    if (current is Dictionary<string, object> dict && dict.ContainsKey(name))
                    {
                        if (dict[name] is JsonElement element && element.ValueKind == JsonValueKind.Array)
                        {
                            var item = element[index];
                            return item.ToString();
                        }
                    }
                }
                else
                {
                    if (current is Dictionary<string, object> dict && dict.ContainsKey(subclave))
                    {
                        current = dict[subclave];
                        if (current is JsonElement el)
                        {
                            if (el.ValueKind == JsonValueKind.Object)
                            {
                                current = JsonSerializer.Deserialize<Dictionary<string, object>>(el.GetRawText());
                            }
                            else
                            {
                                return el.ToString();
                            }
                        }
                    }
                    else
                    {
                        return clave;
                    }
                }
            }
            return current?.ToString() ?? clave;
        }
        public void Agregar_842JF(IIdiomaObserver_842JF observer)
        {
            forms_842JF.Add(observer);
        }
        public void Eliminar_842JF(IIdiomaObserver_842JF observer)
        {
            forms_842JF.Remove(observer);
        }

        public void Notificar_842JF()
        {
            foreach (var item in forms_842JF)
            {
                item.Actualizar_842JF();
            }
        }
    }
}
