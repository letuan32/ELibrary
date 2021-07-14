using ELibrary.Data;
using ELibrary_Team_1.Models;
using ELibrary_Team1.DataAccess.Data.Repository.IRepository;

namespace ELibrary_Team1.DataAccess.Data.Repository.Repository
{
    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
    {
        private readonly ELibraryDbContext _db;
        public DocumentRepository(ELibraryDbContext db) : base(db)
        {
            _db = db;
        }
    }
}