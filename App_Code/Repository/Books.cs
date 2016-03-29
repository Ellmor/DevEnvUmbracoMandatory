using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MandatoryUmbraco.App_Code.Repository
{
    using Models;
    using System.Collections.Generic;
    using Umbraco.Core.Persistence;

    namespace ComputerMagic.PetaPoco.Repository
    {
        public static class Books
        {
            public static IList<Book> GetAll()
            {
                UmbracoDatabase db = Umbraco.Core.ApplicationContext.Current.DatabaseContext.Database;
                return db.Fetch<Book>("SELECT * FROM CMBooks ORDER BY Title");
            }

            public static Page<Book> GetAllPaged(int Page, int RecordsPerPage)
            {
                UmbracoDatabase db = Umbraco.Core.ApplicationContext.Current.DatabaseContext.Database;
                return db.Page<Book>(Page, RecordsPerPage, "SELECT * FROM CMBooks ORDER BY Title");
            }

            public static IList<Book> GetAllByAuthorID(int AuthorID)
            {
                UmbracoDatabase db = Umbraco.Core.ApplicationContext.Current.DatabaseContext.Database;
                return db.Fetch<Book>("SELECT * FROM CMBooks WHERE AuthorID = @0 ORDER BY Title", AuthorID);
            }

            public static Page<Book> GetAllPagedByAuthorID(int Page, int RecordsPerPage, int AuthorID)
            {
                UmbracoDatabase db = Umbraco.Core.ApplicationContext.Current.DatabaseContext.Database;
                return db.Page<Book>(Page, RecordsPerPage, "SELECT * FROM CMBooks WHERE AuthorID = @0 ORDER BY Title", AuthorID);
            }

            public static Book GetByBookID(int BookID)
            {
                UmbracoDatabase db = Umbraco.Core.ApplicationContext.Current.DatabaseContext.Database;
                List<Book> Records = db.Fetch<Book>("SELECT * FROM CMBooks WHERE BookID = @0", BookID);

                if (Records.Count > 0)
                    return Records[0];
                else
                    return null;
            }

            public static Book Save(Book item)
            {
                UmbracoDatabase db = Umbraco.Core.ApplicationContext.Current.DatabaseContext.Database;
                db.Save(item);
                return item;
            }

            public static int DeleteByBookID(int BookID)
            {
                UmbracoDatabase _database = Umbraco.Core.ApplicationContext.Current.DatabaseContext.Database;
                return _database.Execute("DELETE FROM CMBooks WHERE BookID = @0", BookID);
            }
        }
    }
}