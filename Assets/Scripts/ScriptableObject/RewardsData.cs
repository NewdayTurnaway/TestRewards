using System.Collections.Generic;
using UnityEngine;

namespace Rewards
{
    [CreateAssetMenu(fileName = nameof(RewardsData), menuName = ConstantText.MENU_PATH + nameof(RewardsData))]
    internal sealed class RewardsData : ScriptableObject
    {
        private const int SECONDS = 60;
        private const int MINUTES = 60;
        private const int HOURS = 24;
        private const int DAYS = 14;
        private const int DOUBLING = 2;

        private int? _timeCooldown;
        private int? _timeDeadline;

        [field: SerializeField] public RewardsDataType RewardsDataType { get; private set; }
        [field: SerializeField] public int Cooldown { get; private set; } = 1;
        [field: SerializeField] public List<RewardItemData> Rewards { get; private set; }

        public int? TimeCooldown
        {
            get
            {
                if (_timeCooldown == null)
                {
                    _timeCooldown = CalculationCooldown(RewardsDataType);
                }
                return _timeCooldown;
            }
        }
        public int? TimeDeadline
        { 
            get
            {
                if (_timeDeadline == null)
                {
                    _timeDeadline = _timeCooldown * DOUBLING;
                }
                return _timeDeadline;
            }
        }

        private int CalculationCooldown(RewardsDataType rewardsDataType)
        {
            int cooldown = Cooldown * SECONDS * MINUTES * HOURS;

            return rewardsDataType switch
            {
                RewardsDataType.Daily => cooldown,
                RewardsDataType.Weekly => cooldown * DAYS,
                _ => 0,
            };
        }
    }
}
