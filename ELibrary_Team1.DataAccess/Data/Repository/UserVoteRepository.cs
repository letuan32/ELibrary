using ELibrary_Team_1.Models;
using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using ELibrary.Data;

namespace ELibrary_Team1.DataAccess.Data.Repository.Repository
{
    public class UserVoteRepository : GenericRepository<UserVote>, IUserVoteRepository
    {
        private readonly ELibraryDbContext _db;
        public UserVoteRepository(ELibraryDbContext db) : base(db)
        {
            _db = db;
        }
    }
}