using UnityEngine;

namespace Rewards
{
    internal sealed class InstallView : MonoBehaviour
    {
        [SerializeField] private RewardsView _rewardsView;
        [SerializeField] private RewardsData _rewardsData;
        [SerializeField] private ResourcesData _resourcesData;
        [SerializeField] private CurrencyView _currencyView;

        private CurrencyController _currencyController;
        private RewardsController _rewardsController;

        private void Awake()
        {
            _currencyController = new(_resourcesData, _currencyView);
            _rewardsController = new(_rewardsView, _rewardsData, _currencyController);
        }

        private void Start()
        {
            _currencyController.Init();
            _rewardsController.Init();
        }

        private void OnDestroy()
        {
            _currencyController.Deinit();
            _rewardsController.Deinit();
        }
    }
}
