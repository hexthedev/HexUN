using UnityEngine;

namespace Hex.UN.Runtime.Framework.SharedResource
{
    public class SharedResourceClearer : MonoBehaviour
    {
        [SerializeField]
        ASOSharedResource[] _sharedResources;

        private void Awake()
        {
            foreach(ASOSharedResource res in _sharedResources)
            {
                res.Clear();
            }

            Destroy(this.gameObject);
        }
    }
}