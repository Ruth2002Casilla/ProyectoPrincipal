using MainProject.DAL;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MainProject.Services
{
    public class TicketsService
    {
        private readonly IDbContextFactory<Context> _contextFactory;

        public TicketsService(IDbContextFactory<Context> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> Verificar(int TicketId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Tickets.AnyAsync(t => t.TicketId == TicketId);
            }
        }

        public async Task<bool> Agregar(Tickets Ticket)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Tickets.Add(Ticket);
                return await context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> Modificar(Tickets Ticket)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Update(Ticket);
                return await context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> Guardar(Tickets Ticket)
        {
            if (!await Verificar(Ticket.TicketId))
                return await Agregar(Ticket);
            else
                return await Modificar(Ticket);
        }

        public async Task<bool> Eliminar(Tickets Ticket)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Remove(Ticket);
                return await context.SaveChangesAsync() > 0;
            }
        }

        public async Task<Tickets?> Buscar(int TicketId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Tickets
                    .AsNoTracking()
                    .FirstOrDefaultAsync(t => t.TicketId == TicketId);
            }
        }

        public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Tickets
                    .AsNoTracking()
                    .Where(criterio)
                    .ToListAsync();
            }
        }
    }
}
