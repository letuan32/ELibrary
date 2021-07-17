using System;
using ELibrary_Team_1.Models;
using System.Threading.Tasks;

namespace ELibrary_Team1.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IAppUserRepository AppUser { get; }
        IAccessRequestRepository AccessRequest { get; }
        ICategoryRepository Category { get; }
        ISP_Call SP_Call { get; }
        IChapterRepository Chapter { get; }
        IDocumentCategoryRepository DocumentCategory { get; }
        IDocumentRepository Document { get; }
        IUpdateRequestRepository UpdateRequest { get; }
        IUserVoteRepository UserVote { get; }
        void SaveChange();
        Task SaveChangeAsync();
    }
}
