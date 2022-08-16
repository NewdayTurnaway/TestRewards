using UnityEngine;

namespace Rewards
{
    [CreateAssetMenu(fileName = nameof(RewardConfig), menuName = ConstantText.MENU_PATH + nameof(RewardConfig))]
    internal sealed class RewardConfig : ScriptableObject
    {
        [SerializeField] private ResourceConfig _resource;
        [SerializeField] private int _countCurrency;

        public ResourceType ResourceType => _resource.Type;
        public Sprite ResourceIcon => _resource.Icon;
        public int CountCurrency => _countCurrency;
    }
}
