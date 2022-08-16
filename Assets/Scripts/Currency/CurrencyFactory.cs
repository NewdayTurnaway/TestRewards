using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Rewards
{
    internal sealed class CurrencyFactory
    {
        private readonly CurrencyView _view;

        private readonly List<ResourceItemData> _resources = new();
        private readonly List<CurrencySlotView> _slots = new();

        public CurrencyFactory(CurrencyView currencyView, List<ResourceItemData> resources, List<CurrencySlotView> slots)
        {
            _view = currencyView;
            _resources = resources;
            _slots = slots;
        }

        public void Init()
        {
            for (int i = 0; i < _resources.Count; i++)
            {
                ResourceType type = _resources[i].Type;
                CurrencySlotView instanceSlot = CreateCurrencySlotView();
                instanceSlot.SetInfo(type, _resources[i].Icon);
                _slots.Add(instanceSlot);
            }
        }

        private CurrencySlotView CreateCurrencySlotView() =>
            Object.Instantiate
            (
                _view.CurrencyPrefab,
                _view.CurrencyContainer,
                false
            );

        public void Deinit()
        {
            foreach (CurrencySlotView slot in _slots)
                Object.Destroy(slot.gameObject);

            _slots.Clear();
        }
    }
}
