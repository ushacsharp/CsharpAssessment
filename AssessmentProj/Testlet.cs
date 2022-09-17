using System;
using System.Collections.Generic;
using System.Linq;


namespace AssessmentProj
{
    public class Testlet
    {
        public string TestletId { get; }
        public List<ItemClass> Items { get; }

        private const int ExpectedTotalItems = 10;
        private const int ExpectedOperationalItems = 6;
        private const int ExpectedPretestItems = 4;

        public IRandomizeItems Randomizer { get; } = new Randomizer(2);

        public Testlet(string testletId, List<ItemClass> items)
        {
            ValidateTestlet(testletId, items);

            TestletId = testletId;
            Items = items;
        }

        public Testlet Randomize()
        {
            var randomItems = Randomizer.RandomizeItems(Items);

            return new Testlet(TestletId, randomItems);

        }

        private void ValidateTestlet(string testletId, List<ItemClass> items)
        {
            if (IsEmpty(testletId)) throw new Exception("Testlet Id cannot be empty");
            if (IsEmpty(items)) throw new Exception("Testlet cannot be empty");

            if (items.Count != ExpectedTotalItems) throw new InvalidTestletException("Testlet should contain 10 items");

            var isValidPreTest = ValidateNumberOfPreTest(items);
            var isValidOperational = ValidateNumberOfOperational(items);

            if (!isValidPreTest || !isValidOperational) throw new InvalidTestletPresetAndOperationalException("Testlet should contain 4 preset and 6 Operational items");
            
        }

        private static bool IsEmpty(List<ItemClass> items)
        {
            return items == null || !items.Any();
        }

        private static bool IsEmpty(string testletId)
        {
            return string.IsNullOrEmpty(testletId);
        }


        public bool ValidateNumberOfPreTest(List<ItemClass> items)
        {
            var countOfPretest = items.Count(t => t.ItemType == ItemTypeEnum.Pretest);

            return countOfPretest == ExpectedPretestItems;
        }

        public bool ValidateNumberOfOperational(List<ItemClass> items)
        {
            var countOfOperational = items.Count(t => t.ItemType == ItemTypeEnum.Operational);

            return countOfOperational == ExpectedOperationalItems;
        }

    }
}
