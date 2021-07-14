using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using ELibrary_Team_1.Models;
using ELibrary.Data;

namespace ELibrary_Team1.DataAccess.Data.Repository.Repository
{
    public class UpdateRequestRepository : GenericRepository<UpdateRequest>, IUpdateRequestRepository
    {
        private readonly ELibraryDbContext _db;
        public UpdateRequestRepository(ELibraryDbContext db) : base(db)
        {
            _db = db;
        }
    }
}