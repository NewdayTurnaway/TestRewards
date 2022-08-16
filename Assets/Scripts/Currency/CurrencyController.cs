using System.Collections.Generic;
using UnityEngine;

namespace Rewards
{
    internal sealed class CurrencyController
    {
        private readonly CurrencyView _view;

        private readonly List<ResourceConfig> _resources = new();
        private readonly List<CurrencySlotView> _slots = new();

        private readonly CurrencySlotPanel _currencySlotPanel;

        public CurrencyController(ResourceCollection resourcesData, CurrencyView currencyView)
        {
            _resources = resourcesData.Resources;
            _view = currencyView;

            _currencySlotPanel = new(_view, _resources, _slots);
        }

        public void Init()
        {
            _currencySlotPanel.Init();
            foreach (CurrencySlotView view in _slots)
            {
                view.SetData(GetResourceValue(view.Type));
            }
        }

        public void Deinit()
        {
            _currencySlotPanel.Deinit();
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

        private int GetResourceValue(ResourceType type)
        {
            return PlayerPrefs.GetInt(type.ToString());
        }

        private void SetResourceValue(ResourceType type, int value)
        {
            PlayerPrefs.SetInt(type.ToString(), value);
        }
    }
}
