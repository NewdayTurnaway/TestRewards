using System.Collections.Generic;

namespace Rewards
{
    internal sealed class RewardsInfo
    {
        public RewardsDataType RewardsDataType { get; private set; }
        public float TimeCooldown { get; private set; }
        public float TimeDeadline { get; private set; }
        public List<Reward> Rewards { get; private set; } = new();

        public RewardsInfo(RewardsData rewardsData)
        {
            RewardsDataType = rewardsData.RewardsDataType;

            TimeCooldown = (int)rewardsData.TimeCooldown;
            TimeDeadline = (int)rewardsData.TimeDeadline;

            foreach (RewardItemData rewardItemData in rewardsData.Rewards)
            {
                Rewards.Add(rewardItemData.Reward);
            }
        }
    } 
}
