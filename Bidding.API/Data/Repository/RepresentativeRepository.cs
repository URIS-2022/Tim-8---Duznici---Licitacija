using Bidding.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bidding.API.Data.Repository
{
    public class RepresentativeRepository : IRepresentativeRepository
    {
        private readonly BiddingDBContext _context;

        public RepresentativeRepository(BiddingDBContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<Representative>> GetAllRepresentatives()
        {
            return await _context.Representatives
                .Include(c=>c.address)
                .Include(c => c.publicBidding)
                .Include(c => c.BuyerApplications)
                .ToListAsync();


        }

        public async Task<Representative> GetRepresentativeByGuid(Guid guid)
        {
            var representative= await _context.Representatives
                .Include(c => c.address)
                .Include(c => c.publicBidding)
                .Include(c => c.BuyerApplications).SingleOrDefaultAsync(x => x.Guid == guid);
            return representative;
        }

        public async Task<Representative?> GetRepresentativeByIdentificationNumber(string identificationNumber)
        {
            return await _context.Representatives.Include(c => c.address)
                .Include(c => c.publicBidding)
                .Include(c => c.BuyerApplications).FirstOrDefaultAsync(x => x.IdentificationNumber == identificationNumber);
        }

        public async Task<Representative> AddRepresentative(Representative representative)
        {
            _context.Representatives.Add(representative);
           
            await _context.SaveChangesAsync();
            return representative;
        }

        public async Task DeleteRepresentative(Guid guid)
        {
            var representative = await _context.Representatives.FindAsync(guid);
            if (representative == null)
            {
                throw new InvalidOperationException("Representative not found");
            }
            _context.Representatives.Remove(representative);
            await _context.SaveChangesAsync();
        }

        public async Task<Representative?> UpdateRepresentative(Representative representative)
        {
            var existingRepresentative = await _context.Representatives.SingleOrDefaultAsync(x => x.Guid == representative.Guid); // ako ne bude radilo izbaciti address
            if (existingRepresentative == null)
            {
                throw new InvalidOperationException($"The Representative with ID '{representative.Guid}' was not found.");
            }

            _context.Entry(existingRepresentative).CurrentValues.SetValues(representative);
            await _context.SaveChangesAsync();

            return existingRepresentative;
        }
    }
}
