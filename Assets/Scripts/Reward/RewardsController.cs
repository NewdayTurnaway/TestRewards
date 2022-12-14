using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rewards
{
    internal sealed class RewardsController
    {
        private readonly RewardsView _view;
        private readonly RewardsInfo _rewardsInfo;
        private readonly CurrencyController _currencyController;

        private readonly List<ContainerSlotRewardView> _slots = new();
        private Coroutine _coroutine;

        private bool _isInitialized;

        private readonly RewardsFactory _factory;
        private readonly RewardsUiController _uiController;


        public RewardsController(RewardsView view, RewardsData rewardsData, CurrencyController currencyController)
        {
            _view = view;
            _rewardsInfo = new(rewardsData);
            _currencyController = currencyController;

            _factory = new(_view, _rewardsInfo, _slots);
            _uiController = new(_view, _rewardsInfo, _currencyController, _slots);
        }

        public void Init()
        {
            if (_isInitialized)
                return;

            _factory.InitSlots();
            _uiController.Init();
            StartRewardsUpdating();

            _isInitialized = true;
        }

        public void Deinit()
        {
            if (!_isInitialized)
                return;

            _factory.DeinitSlots();
            StopRewardsUpdating();
            _uiController.Deinit();

            _isInitialized = false;
        }

        private void StartRewardsUpdating() =>
            _coroutine = _view.StartCoroutine(RewardsStateUpdater());

        private void StopRewardsUpdating()
        {
            if (_coroutine == null)
                return;

            _view.StopCoroutine(_coroutine);
            _coroutine = null;
        }

        private IEnumerator RewardsStateUpdater()
        {
            WaitForSeconds waitForSecond = new(1);

            while (true)
            {
                _uiController.RefreshRewardsState();
                _uiController.RefreshUi();
                _currencyController.CurrencySlotsRefresh();
                yield return waitForSecond;
            }
        }
    }
}
