using MainProject.DAL;
using MainProject.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MainProject.Services
{
    public class ClientesService
    {
        private readonly Context _context;

        public ClientesService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int ClienteId)
        {
            return await _context.Clientes.AnyAsync(c => c.ClienteId == ClienteId);
        }

        public async Task<bool> Agregar(Clientes Clientes)
        {
            _context.Clientes.Add(Clientes);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Clientes Clientes)
        {
            _context.Update(Clientes);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Clientes Clientes)
        {
            if (!await Verificar(Clientes.ClienteId))
                return await Agregar(Clientes);
            else
                return await Modificar(Clientes);
        }

        public async Task<bool> Eliminar(Clientes cliente)
        {
            var cantidad = await _context.Clientes
                .Where(c => c.ClienteId == cliente.ClienteId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Clientes?> Buscar(int ClienteId)
        {
            return await _context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClienteId == ClienteId);
        }

        public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
        {
            return await _context.Clientes
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
