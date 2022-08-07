using System;
using System.Collections.Generic;

namespace Rewards
{
    internal sealed class RewardsUiController
    {
        private readonly RewardsView _view;
        private readonly RewardsInfo _rewardsInfo;
        private readonly CurrencyController _currencyController;

        private readonly List<ContainerSlotRewardView> _slots = new();

        private readonly RewardsUiButtonsController _uiButtonsController;

        public RewardsUiController(RewardsView view, RewardsInfo rewardsInfo, 
            CurrencyController currencyController, List<ContainerSlotRewardView> slots)
        {
            _view = view;
            _rewardsInfo = rewardsInfo;
            _currencyController = currencyController;
            _slots = slots;

            _uiButtonsController = new(_view, _rewardsInfo, _currencyController);
        }

        public void Init()
        {
            RefreshUi();
            _uiButtonsController.SubscribeButtons();
        }

        public void Deinit() => 
            _uiButtonsController.UnsubscribeButtons();

        public void RefreshRewardsState() => 
            _uiButtonsController.RefreshRewardsState();

        public void RefreshUi()
        {
            _view.GetRewardButton.interactable = _uiButtonsController.IsGetReward;
            _view.TimerNewReward.text = GetTimerNewRewardText();
            RefreshSlots();
        }

        private string GetTimerNewRewardText()
        {
            if (_uiButtonsController.IsGetReward)
                return ConstantText.REWARD_READY;

            if (_view.TimeGetReward.HasValue)
            {
                DateTime nextClaimTime = _view.TimeGetReward.Value.AddSeconds(_rewardsInfo.TimeCooldown);
                TimeSpan currentClaimCooldown = nextClaimTime - DateTime.UtcNow;

                string timeGetReward =
                    $"{currentClaimCooldown.Days:D2}:{currentClaimCooldown.Hours:D2}:" +
                    $"{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

                return $"{ConstantText.NEXT_TIME} {timeGetReward}";
            }

            return string.Empty;
        }

        private void RefreshSlots()
        {
            for (var i = 0; i < _slots.Count; i++)
            {
                Reward reward = _rewardsInfo.Rewards[i];
                int countDay = i + 1;
                bool isSelected = i == _view.CurrentSlotInActive;

                _slots[i].SetData(_rewardsInfo.RewardsDataType, reward, countDay, isSelected);
            }
        }
    }
}
