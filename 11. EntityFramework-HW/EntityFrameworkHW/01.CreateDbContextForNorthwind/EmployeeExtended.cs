namespace CreateDbContextForNorthwind
{
    using System.Data.Linq;

    public partial class Employee
    {
        public EntitySet<Territory> TerritoriesSet
        {
            get
            {
                EntitySet<Territory> territoriesSet = new EntitySet<Territory>();
                territoriesSet.AddRange(this.Territories);
                return territoriesSet;
            }
        }
    }
}
