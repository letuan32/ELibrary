﻿using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using ELibrary_Team_1.Models;
using ELibrary.Data;

namespace ELibrary_Team1.DataAccess.Data.Repository
{
    public class DocumentCategoryRepository : GenericRepository<DocumentCategory>, IDocumentCategoryRepository
    {
        private readonly ELibraryDbContext _db;
        public DocumentCategoryRepository(ELibraryDbContext db) : base(db)
        {
            _db = db;
        }
    }
}