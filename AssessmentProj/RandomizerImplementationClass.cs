using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProj
{
    public class Randomizer : IRandomizeItems
    {
        private int numberOfFirstPretestItems;

        public Randomizer(int numberOfFirstPretestItems)
        {
            this.numberOfFirstPretestItems = numberOfFirstPretestItems;
            
        }

        public bool IsEmpty(List<ItemClass> listOfItems)
        {
            if (listOfItems == null)
            {
                return true;
            }

            return !listOfItems.Any();
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
            try
            {
                if (!this.IsEmpty(items))
                {
                    var mixedItems = this.mixedItems(items);

                    this.PretestItemsAsStart(mixedItems);

                    return mixedItems;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception. {0}", ex.Message);
                return null;
            }
        }

        private List<ItemClass> mixedItems(IEnumerable<ItemClass> items)
        {
            try
            {
                var mixedItems = items.ToList();
                Random rd = new Random();

                for (var i = mixedItems.Count - 1; i >= 0; i--)
                {
                    
                    int randomIndex = rd.Next(i + 1);
                    // mixedItems.Swap(randomIndex, i);
                    this.Swap(mixedItems,randomIndex, i);
                }

                return mixedItems;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception. {0}", ex.Message);
                return null;
            }
        }

        private void PretestItemsAsStart(IList<ItemClass> items)
        {
            var PretestItemsToMoveToBeginning = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemType != ItemTypeEnum.Pretest)
                {
                    continue;
                }

                this.Swap(items, i, PretestItemsToMoveToBeginning++);

                if (PretestItemsToMoveToBeginning >= this.numberOfFirstPretestItems)
                {
                    break;
                }
            }
        }
    }
}
