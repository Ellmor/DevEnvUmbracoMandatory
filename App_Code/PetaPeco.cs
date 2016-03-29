using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Core.Logging;
using MandatoryUmbraco.App_Code.Models;

namespace AarhusWebDevCoop.App_Code.PetaPoco
{
    public class PetaPocoApplicationEventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var logger = LoggerResolver.Current.Logger;
            //Get the Umbraco Database context
            var dbContext = ApplicationContext.Current.DatabaseContext;
            var db = new DatabaseSchemaHelper(dbContext.Database, applicationContext.ProfilingLogger.Logger, dbContext.SqlSyntax);
            //Create DB table - and set overwrite to false     
            //Check if the DB table does NOT exist          
            //if (!db.TableExist("CMAuthors"))
            //{
            //    //Create DB table - and set overwrite to false              
            //    db.CreateTable<Author>(false);
            //}
            ////Create DB table - and set overwrite to false          
            ////Check if the DB table does NOT exist           
            //if (!db.TableExist("CMBooks"))
            //{
            //    //Create DB table - and set overwrite to false  
            //    db.CreateTable<Book>(false);
            //}
        }
    }
}