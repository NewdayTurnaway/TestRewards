using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Rewards
{
    internal sealed class RewardsFactory
    {
        private readonly RewardsView _view;
        private readonly RewardsInfo _rewardsInfo;

        private readonly List<ContainerSlotRewardView> _slots = new();

        public RewardsFactory(RewardsView view, RewardsInfo rewardsInfo, List<ContainerSlotRewardView> slots)
        {
            _view = view;
            _rewardsInfo = rewardsInfo;
            _slots = slots;
        }

        public void InitSlots()
        {
            for (int i = 0; i < _rewardsInfo.Rewards.Count; i++)
            {
                ContainerSlotRewardView instanceSlot = CreateSlotRewardView();
                _slots.Add(instanceSlot);
            }
        }

        private ContainerSlotRewardView CreateSlotRewardView() =>
            Object.Instantiate
            (
                _view.SlotPrefab,
                _view.SlotsContainer,
                false
            );

        public void DeinitSlots()
        {
            foreach (ContainerSlotRewardView slot in _slots)
                Object.Destroy(slot.gameObject);

            _slots.Clear();
        }
    }
}
