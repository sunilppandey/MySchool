using MySchool.Model.Entities;
using MySchool.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        /// <summary>
        /// Gets a list of all the book whose author exactly matches the search string.
        /// </summary>
        /// <param name="author">The author name that the system should search for.</param>
        /// <returns>An IEnumerable of Book with the matching books.</returns>
        public Book FindByAuthor(string author)
        {
            return DataContextFactory.GetDataContext().Set<Book>().Where(x => x.Author == author).FirstOrDefault();
        }
    }
}
