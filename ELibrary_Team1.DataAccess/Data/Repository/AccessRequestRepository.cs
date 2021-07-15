using ELibrary.Data;
using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using ELibrary_Team_1.Models;

namespace ELibrary_Team1.DataAccess.Data.Repository
{
    public class AccessRequestRepository : GenericRepository<AccessRequest>, IAccessRequestRepository 
    {
        private readonly ELibraryDbContext _db;
        public AccessRequestRepository(ELibraryDbContext db) : base(db)
        {
            _db = db;
        }
    }
}