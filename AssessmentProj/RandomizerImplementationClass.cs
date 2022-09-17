using System;
using System.Collections.Generic;
using System.Linq;

namespace AssessmentProj
{
    public class Randomizer : IRandomizeItems
    {
        public int NumberOfFirstPretestItems { get; }

        public Randomizer(int numberOfFirstPretestItems)
        {
            NumberOfFirstPretestItems = numberOfFirstPretestItems;

        }

        public void Swap(IList<ItemClass> items, int i, int j)
        {
            if (i == j)
            {
                return;
            }

            var tmp = items[i];
            items[i] = items[j];
            items[j] = tmp;
        }

        public List<ItemClass> RandomizeItems(List<ItemClass> items)
        {
            var mixedItems = this.MixedItems(items);

            PretestItemsAsStart(mixedItems);

            return mixedItems;
        }

        private List<ItemClass> MixedItems(IEnumerable<ItemClass> items)
        {

            var mixedItems = items.ToList();
            var rd = new Random();

            for (var i = mixedItems.Count - 1; i >= 0; i--)
            {

                var randomIndex = rd.Next(i + 1);
                Swap(mixedItems, randomIndex, i);
            }

            return mixedItems;

        }

        private void PretestItemsAsStart(IList<ItemClass> items)
        {
            var pretestItemsToMoveToBeginning = 0;

            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].ItemType != ItemTypeEnum.Pretest)
                {
                    continue;
                }

                Swap(items, i, pretestItemsToMoveToBeginning++);

                if (pretestItemsToMoveToBeginning >= NumberOfFirstPretestItems)
                {
                    break;
                }
            }
        }
    }
}
