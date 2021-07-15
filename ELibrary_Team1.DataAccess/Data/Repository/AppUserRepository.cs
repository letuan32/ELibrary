using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using ELibrary_Team_1.Models;
using ELibrary.Data;

namespace ELibrary_Team1.DataAccess.Data.Repository
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        private readonly ELibraryDbContext _db;
        public AppUserRepository(ELibraryDbContext db) : base(db)
        {
            _db = db;
        }
    }
}