using System.Collections.Generic;
using UnityEngine;

namespace Rewards
{
    internal sealed class CurrencyController
    {
        private readonly CurrencyView _view;

        private readonly List<ResourceItemData> _resources = new();
        private readonly List<CurrencySlotView> _slots = new();

        private readonly CurrencyFactory _factory;

        private int GetResourceValue(ResourceType type)
        {
            return PlayerPrefs.GetInt(type.ToString());
        }

        private void SetResourceValue(ResourceType type, int value)
        {
            PlayerPrefs.SetInt(type.ToString(), value);
        }

        public CurrencyController(ResourcesData resourcesData, CurrencyView currencyView)
        {
            _resources = resourcesData.Resources;
            _view = currencyView;

            _factory = new(_view, _resources, _slots);
        }

        public void Init()
        {
            _factory.Init();
            foreach (CurrencySlotView view in _slots)
            {
                view.SetData(GetResourceValue(view.Type));
            }
        }

        public void Deinit()
        {
            _factory.Deinit();
        }

        public void CurrencySlotsRefresh()
        {
            foreach (CurrencySlotView view in _slots)
            {
                view.SetData(GetResourceValue(view.Type));
            }
        }

        public void AddResource(ResourceType type, int value)
        {
            int resourceValue = GetResourceValue(type);
            SetResourceValue(type, resourceValue + value);
            foreach(CurrencySlotView view in _slots)
            {
                if (view.Type == type)
                {
                    view.SetData(resourceValue);
                }
            }
        }
    }
}
