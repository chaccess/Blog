using Main.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Main.Api.Data
{
    public class ApplicationDBRepository(ApplicationDBContext context) : IApplicationDBRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Record?> GetRecord(long id)
        {
            return await _context.Records.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> PostRecord(Record record)
        {
            try
            {
                await _context.Records.AddAsync(record);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
