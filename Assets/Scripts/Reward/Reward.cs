using UnityEngine;

namespace Rewards
{
    internal sealed class Reward
    {
        [field: SerializeField] public ResourceType ResourceType { get; private set; }
        [field: SerializeField] public Sprite ResourceIcon { get; private set; }
        [field: SerializeField] public int CountCurrency { get; private set; }

        public Reward(ResourceType resourceType, Sprite resourceIcon, int countCurrency)
        {
            ResourceType = resourceType;
            ResourceIcon = resourceIcon;
            CountCurrency = countCurrency;
        }
    }
}
