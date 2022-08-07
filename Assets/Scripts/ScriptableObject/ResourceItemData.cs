using UnityEngine;

namespace Rewards
{
    [CreateAssetMenu(fileName = nameof(ResourceItemData), menuName = ConstantText.MENU_PATH + nameof(ResourceItemData))]
    internal sealed class ResourceItemData : ScriptableObject
    {
        [field: SerializeField] public ResourceType Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}
