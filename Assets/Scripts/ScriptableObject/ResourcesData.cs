using System.Collections.Generic;
using UnityEngine;

namespace Rewards
{
    [CreateAssetMenu(fileName = nameof(ResourcesData), menuName = ConstantText.MENU_PATH + nameof(ResourcesData))]
    internal sealed class ResourcesData : ScriptableObject
    {
        [field: SerializeField] public List<ResourceItemData> Resources { get; private set; }
    }
}
