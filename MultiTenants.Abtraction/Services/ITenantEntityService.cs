using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTenants.Abtraction.Services
{
    public interface ITenantEntityService
    {
       /// <summary>
       /// Publish an entity to all tenants
       /// </summary>
       /// <param name="entity"></param>
       /// <returns></returns>
        Task PublishAsync(IMayHaveTenant entity);

        /// <summary>
        /// Publish an entity to specific tenants
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tenantIds"></param>
        /// <returns></returns>
        Task PublishAsync(IMayHaveTenant entity, IEnumerable<int> tenantIds);

        Task UnSubscribeAsync(IMayHaveTenant entity);
        Task Subscribe(IMayHaveTenant entity);

        Task<bool> CheckSubscribe<T>() where T : IMayHaveTenant;
        Task<bool> CheckSubcribe(IMayHaveTenant entity);
        Task<IEnumerable<Type>> GetListSubcribeEntitiesAsync();
    }
}
