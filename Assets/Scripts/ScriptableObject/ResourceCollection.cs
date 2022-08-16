using System.Collections.Generic;
using UnityEngine;

namespace Rewards
{
    [CreateAssetMenu(fileName = nameof(ResourceCollection), menuName = ConstantText.MENU_PATH + nameof(ResourceCollection))]
    internal sealed class ResourceCollection : ScriptableObject
    {
        [field: SerializeField] public List<ResourceConfig> Resources { get; private set; }
    }
}
