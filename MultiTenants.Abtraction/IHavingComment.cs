using System.Collections.Generic;

namespace MultiTenants.Abtraction
{
    public interface IHavingComment 
    {
        IEnumerable<IComment> Comments { get; }
    }
}
