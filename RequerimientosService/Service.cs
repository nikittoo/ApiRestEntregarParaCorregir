using RequerimientosData;
using RequerimientosDto;
using RequerimientosEntities;

namespace RequerimientosService
{
    public class Service
    {
        public List<RequerimientoDto> ObtenerTodosRequerimiento()
        {
            List<RequerimientoEntitie> requerimientos = RequerimientosArchivo.LeerDesdeArchivoJson();

            return requerimientos.Select(x => new RequerimientoDto()
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descripcion = x.Descripcion,
                Prioridad = (TipoPrioriodad)x.Prioridad,
                EstadoActual = (TipoEstado)x.EstadoActual
            }).ToList();
        }

        public RequerimientoDto CrearRequerimiento(RequerimientoDto requerimientoDto)
        {
            RequerimientoEntitie requerimiento = new RequerimientoEntitie()
            {
                Titulo = requerimientoDto.Titulo,
                Descripcion = requerimientoDto.Descripcion,
                Prioridad = (int)requerimientoDto.Prioridad,
                EstadoActual = (int)requerimientoDto.EstadoActual
            };

            requerimiento.FechaCreacion = DateTime.Now;
            requerimiento = RequerimientosArchivo.GuardarEnArchivoJson(requerimiento);

            requerimientoDto.Id = requerimiento.Id;

            return requerimientoDto;
        }

        public RequerimientoDto ObtenerRequerimientoPorId(int id)
        {
            RequerimientoEntitie requerimientoEntitie = RequerimientosArchivo.LeerDesdeArchivoJson().FirstOrDefault(x => x.Id == id);

            if (requerimientoEntitie != null)
            {
                RequerimientoDto requerimientoDto = new RequerimientoDto()
                {
                    Id = requerimientoEntitie.Id,
                    Titulo = requerimientoEntitie.Titulo,
                    Descripcion = requerimientoEntitie.Descripcion,
                    Prioridad = (TipoPrioriodad)requerimientoEntitie.Prioridad,
                    EstadoActual = (TipoEstado)requerimientoEntitie.EstadoActual
                };

                return requerimientoDto;
            }

            return null;
        }

        public RequerimientoDto ActualizarRequerimiento(RequerimientoDto requerimientoDto)
        {
            RequerimientoEntitie requerimientoEntitie = RequerimientosArchivo.LeerDesdeArchivoJson().FirstOrDefault(x => x.Id == requerimientoDto.Id);

            if (requerimientoEntitie != null)
            {
                //requerimientoEntitie.Id = requerimientoDto.Id;
                requerimientoEntitie.Titulo = requerimientoDto.Titulo;
                requerimientoEntitie.Descripcion = requerimientoDto.Descripcion;
                requerimientoEntitie.Prioridad = (int)requerimientoDto.Prioridad;
                requerimientoEntitie.EstadoActual = (int)requerimientoDto.EstadoActual;

                RequerimientosArchivo.GuardarEnArchivoJson(requerimientoEntitie);

                return requerimientoDto;
            }

            return null;
        }

        public void EliminarRequerimiento(int id)
        {
            RequerimientoEntitie requerimientoEntitie = RequerimientosArchivo.LeerDesdeArchivoJson().FirstOrDefault(x => x.Id == id);

            if (requerimientoEntitie != null)
            {
                requerimientoEntitie.FechaVencimiento = DateTime.Now;

                RequerimientosArchivo.GuardarEnArchivoJson(requerimientoEntitie);
            }
        }
    }
}
