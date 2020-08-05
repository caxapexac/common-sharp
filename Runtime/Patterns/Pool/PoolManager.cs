using System.Collections.Generic;
using Caxapexac.Common.Sharp.Runtime.Patterns.Service;
using LeopotamGroup.Pooling;


namespace Caxapexac.Common.Sharp.Runtime.Patterns.Pool
{
    public class PoolManager : MonoBehaviourService<PoolManager>
    {
        private Dictionary<string, PoolContainer> _pools;
        
        protected override void OnCreateService()
        {
            _pools = new Dictionary<string, PoolContainer>();
        }

        protected override void OnDestroyService()
        {
            
        }
    }
}