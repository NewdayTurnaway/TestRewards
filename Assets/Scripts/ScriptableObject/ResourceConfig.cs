using UnityEngine;

namespace Rewards
{
    [CreateAssetMenu(fileName = nameof(ResourceConfig), menuName = ConstantText.MENU_PATH + nameof(ResourceConfig))]
    internal sealed class ResourceConfig : ScriptableObject
    {
        [field: SerializeField] public ResourceType Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}
