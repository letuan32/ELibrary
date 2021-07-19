using ELibrary.Data;
using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using System.Threading.Tasks;

namespace ELibrary_Team1.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ELibraryDbContext _db;

        public IAppUserRepository AppUser { get; private set; }
        public IAccessRequestRepository AccessRequest { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IChapterRepository Chapter { get; private set; }
        public IDocumentCategoryRepository DocumentCategory { get; private set; }
        public IDocumentRepository Document { get; private set; }
        public IUpdateRequestRepository UpdateRequest { get; private set; }
        public IUserVoteRepository UserVote { get; private set; }
       

        public ISP_Call SP_Call { get; set; }

        public UnitOfWork(ELibraryDbContext db)
        {
            _db = db;
            AppUser = new AppUserRepository(_db);
            Document = new DocumentRepository(_db);
            AccessRequest = new AccessRequestRepository(_db);
            Category = new CategoryRepository(_db);
            Chapter = new ChapterRepository(_db);
            DocumentCategory = new DocumentCategoryRepository(_db);
            UpdateRequest = new UpdateRequestRepository(_db);
            UserVote = new UserVoteRepository(_db);
            SP_Call = new SP_Call(_db);

        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void SaveChange()
        {
            _db.SaveChanges();
        }

        public async Task SaveChangeAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
