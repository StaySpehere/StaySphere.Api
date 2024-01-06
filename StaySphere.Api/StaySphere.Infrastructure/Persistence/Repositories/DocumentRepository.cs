using StaySphere.Domain.Entities;
using StaySphere.Domain.Interfaces.Repositories;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(StaySphereDbContext dbContext) : base(dbContext) { }
    }
}
