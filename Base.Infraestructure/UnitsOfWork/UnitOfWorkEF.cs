using Base.Application.Contracts.Persistence;

namespace Base.Infraestructure.UnitsOfWork
{
    public class UnitOfWorkEF(ApplicationDbContext context): IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }

    }
}
