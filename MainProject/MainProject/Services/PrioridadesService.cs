using MainProject.DAL;
using System.Linq.Expressions;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MainProject.Services
{
    public class PrioridadesService
    {
        private readonly Context _context;

        public PrioridadesService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int PrioridadesId)
        {
            return await _context.Prioridades.AnyAsync(p => p.PrioridadId == PrioridadesId);
        }

        public async Task<bool> Agregar(Prioridades Prioridad)
        {
            _context.Prioridades.Add(Prioridad);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Prioridades Prioridad)
        {
            _context.Update(Prioridad);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Prioridades Prioridad)
        {
            if (!await Verificar(Prioridad.PrioridadId))
                return await Agregar(Prioridad);
            else
                return await Modificar(Prioridad);
        }

        public async Task<bool> Eliminar(Prioridades Prioridad)
        {
            var cantidad = await _context.Prioridades
                .Where(p => p.PrioridadId == Prioridad.PrioridadId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Prioridades?> Buscar(int PrioridadesId)
        {
            return await _context.Prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrioridadId == PrioridadesId);
        }

        public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
        {
            return await _context.Prioridades
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
