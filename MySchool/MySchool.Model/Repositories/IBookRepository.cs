using MySchool.Infrastructure;
using MySchool.Model.Entities;
using System.Collections.Generic;

namespace MySchool.Model.Repositories
{
    public interface IBookRepository : IRepository<Book, int>
    {
        Book FindByAuthor(string author);
    }
}
