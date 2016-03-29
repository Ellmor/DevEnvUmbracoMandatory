
using MandatoryUmbraco.App_Code.Models;
using System.Collections.Generic;
using Umbraco.Core.Persistence;

namespace MandatoryUmbraco.PetaPoco.Repository
{
    public static class Authors
    {
        public static IList<Author> GetAll()
        {
            UmbracoDatabase db = Umbraco.Core.ApplicationContext.Current.DatabaseContext.Database;
            return db.Fetch<Author>("SELECT * FROM CMAuthors ORDER BY Surname, Name");
        }

        public static Page<Author> GetAllPaged(int Page, int RecordsPerPage)
        {
            UmbracoDatabase db = Umbraco.Core.ApplicationContext.Current.DatabaseContext.Database;
            return db.Page<Author>(Page, RecordsPerPage, "SELECT * FROM CMAuthors ORDER BY Surname, Name");
        }

        public static Author GetByAuthorID(int AuthorID)
        {
            UmbracoDatabase db = Umbraco.Core.ApplicationContext.Current.DatabaseContext.Database;
            List<Author> Records = db.Fetch<Author>("SELECT * FROM CMAuthors WHERE AuthorID = @0", AuthorID);

            if (Records.Count > 0)
                return Records[0];
            else
                return null;
        }

        public static Author Save(Author item)
        {
            UmbracoDatabase db = Umbraco.Core.ApplicationContext.Current.DatabaseContext.Database;
            db.Save(item);
            return item;
        }

        public static int DeleteByAuthorID(int AuthorID)
        {
            UmbracoDatabase _database = Umbraco.Core.ApplicationContext.Current.DatabaseContext.Database;
            return _database.Execute("DELETE FROM CMAuthors WHERE AuthorID = @0", AuthorID);
        }
    }
}