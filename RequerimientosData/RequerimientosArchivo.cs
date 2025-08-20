using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RequerimientosEntities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RequerimientosData
{
    public static class RequerimientosArchivo
    {
        public static RequerimientoEntitie GuardarEnArchivoJson(RequerimientoEntitie requerimiento)
        {
            var listado = LeerDesdeArchivoJson();//me esta dando null

            if (requerimiento.Id != 0)
            {
                listado.RemoveAll(x => x.Id == requerimiento.Id);
            }
            else
            {
                requerimiento.Id = listado.Count + 1;
            }

            listado.Add(requerimiento);

            string rutaArchivo = "C:\\Users\\Usuario\\Desktop\\ApiRestEntregarParaCorregir\\Requerimientos.json"; //C:\Users\Usuario\Desktop\ApiRestEntregarParaCorregir
            
            string json = JsonConvert.SerializeObject(listado, Formatting.Indented);
            
            File.WriteAllText(rutaArchivo, json);

            return requerimiento;
        }

        public static List<RequerimientoEntitie> LeerDesdeArchivoJson()
        {
            string rutaArchivo = "C:\\Users\\Usuario\\Desktop\\ApiRestEntregarParaCorregir\\Requerimientos.json";

            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                
                if (json == "")
                {
                    return new List<RequerimientoEntitie>();
                }

                return JsonConvert.DeserializeObject<List<RequerimientoEntitie>>(json);
            }
            else
            {
                return new List<RequerimientoEntitie>();
            }
        }
    }
}
