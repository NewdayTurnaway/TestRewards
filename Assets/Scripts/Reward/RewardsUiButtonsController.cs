using System;

namespace Rewards
{
    internal sealed class RewardsUiButtonsController
    {
        private readonly RewardsView _view;
        private readonly RewardsInfo _rewardsInfo;
        private readonly CurrencyController _currencyController;

        public bool IsGetReward { get; private set; }

        public RewardsUiButtonsController(RewardsView view, RewardsInfo rewardsInfo, CurrencyController currencyController)
        {
            _view = view;
            _rewardsInfo = rewardsInfo;
            _currencyController = currencyController;
        }

        public void SubscribeButtons()
        {
            _view.GetRewardButton.onClick.AddListener(ClaimReward);
            _view.ResetButton.onClick.AddListener(ResetRewardsState);
        }

        public void UnsubscribeButtons()
        {
            _view.GetRewardButton.onClick.RemoveListener(ClaimReward);
            _view.ResetButton.onClick.RemoveListener(ResetRewardsState);
        }

        private void ClaimReward()
        {
            if (!IsGetReward)
                return;

            Reward reward = _rewardsInfo.Rewards[_view.CurrentSlotInActive];
            _currencyController.AddResource(reward.ResourceType, reward.CountCurrency);

            _view.TimeGetReward = DateTime.UtcNow;
            _view.CurrentSlotInActive++;

            RefreshRewardsState();
        }

        public void RefreshRewardsState()
        {
            bool gotRewardEarlier = _view.TimeGetReward.HasValue;
            if (!gotRewardEarlier)
            {
                IsGetReward = true;
                return;
            }

            TimeSpan timeFromLastRewardGetting =
                DateTime.UtcNow - _view.TimeGetReward.Value;

            bool isDeadlineElapsed =
                timeFromLastRewardGetting.Seconds >= _rewardsInfo.TimeDeadline;

            bool isTimeToGetNewReward =
                timeFromLastRewardGetting.Seconds >= _rewardsInfo.TimeCooldown;

            if (isDeadlineElapsed)
                ResetRewardsState();

            IsGetReward = isTimeToGetNewReward;
        }

        private void ResetRewardsState()
        {
            _view.TimeGetReward = null;
            _view.CurrentSlotInActive = 0;
        }
    }
}
