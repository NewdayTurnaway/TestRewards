using UnityEngine;

namespace Rewards
{
    [CreateAssetMenu(fileName = nameof(RewardItemData), menuName = ConstantText.MENU_PATH + nameof(RewardItemData))]
    internal sealed class RewardItemData : ScriptableObject
    {
        [SerializeField] private ResourceItemData _resource;
        [SerializeField] private int _countCurrency;
        
        private Reward _reward;

        public Reward Reward
        {
            get
            {
                SetRewardValues();
                return _reward;
            }
        }

        private void SetRewardValues()
        {
            _reward = new(_resource.Type, _resource.Icon, _countCurrency);
        }
    }
}
