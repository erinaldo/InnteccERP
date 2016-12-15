namespace DataObjects
{
    
    // Factory of factories. This class is a factory class that creates
    // data-base specific factories which in turn create data acces objects.
    // ** GoF Design Patterns: Factory.

    public class DaoFactories
    {
        // gets a provider specific (i.e. database specific) factory 
        
        // ** GoF Design Pattern: Factory

        public static IDaoFactory GetFactory(string dataProvider)
        {
            // return the requested DaoFactory

            switch (dataProvider.ToLower())
            {
                //case "ado.net": return new AdoNet.DaoFactory();
                //case "linq2sql": return new Linq2Sql.DaoFactory();
                //case "entityframework": return new EntityFramework.DaoFactory();
                case "ormlite":
                    return new DaoFactory();
                default: return new DaoFactory();
            }
        }
    }
}
