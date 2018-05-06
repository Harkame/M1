using System.Data.Entity;

namespace LibraryManager.Database
{
    public class Initializer : MigrateDatabaseToLatestVersion<LibraryContext, Configuration>
    {
    }
}