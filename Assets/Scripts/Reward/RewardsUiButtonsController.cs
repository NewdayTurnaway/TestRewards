namespace Rewards
{
    internal sealed class RewardsUiButtonsController
    {
        private readonly RewardsView _view;
        private readonly RewardsStateController _rewardsStateController;

        public RewardsUiButtonsController(RewardsView view, RewardsStateController rewardsStateController)
        {
            _view = view;
            _rewardsStateController = rewardsStateController;
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

        public void RefreshButtonState() => 
            _view.GetRewardButton.interactable = _rewardsStateController.IsGetReward;

        private void ClaimReward() =>
            _rewardsStateController.ClaimReward();

        private void ResetRewardsState() =>
            _rewardsStateController.ResetRewardsState();
    }
}
