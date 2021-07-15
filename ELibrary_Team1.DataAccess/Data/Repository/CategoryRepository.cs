using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using ELibrary_Team_1.Models;
using ELibrary.Data;

namespace ELibrary_Team1.DataAccess.Data.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ELibraryDbContext _db;
        public CategoryRepository(ELibraryDbContext db) : base(db)
        {
            _db = db;
        }
    }
}