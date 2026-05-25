using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;
using DataApplication.Context;

namespace AgendamentoVeterinario.Cadastro.API.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AgendamentoVeterinarioContext _context;
        private IDbContextTransaction _transaction = null!;

        public UnitOfWork(AgendamentoVeterinarioContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }
    }
}