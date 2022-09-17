using AssessmentProj;

namespace TestProject1
{
    [TestClass]
    public class TestletTests
    {
        [TestMethod]
           public void Testlet_Should_Contain_10items()
        {
            var itemList = new List<ItemClass>
            {
                new() { ItemId = "1", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "3", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "4", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "5", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "6", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "7", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "8", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "9", ItemType = ItemTypeEnum.Operational }
            };

            Assert.ThrowsException<InvalidTestletException>(() => new Testlet("testletId", itemList));
        }


        [TestMethod]
        public void Testlet_Should_Contain_6_operational_and_4_pretest()
        {
            
            //Arrange  
            var itemList = new List<ItemClass>
            {
                new() { ItemId = "1", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "3", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "4", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "5", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "6", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "7", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "8", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "9", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "10", ItemType = ItemTypeEnum.Pretest }
            };

            Assert.ThrowsException<InvalidTestletPresetAndOperationalException>(() => new Testlet("testletId", itemList));

        }

        [TestMethod]
        public void Randomizer_returns_first_two_are_pretest()
        {
           
            //Arrange  
            var itemList = new List<ItemClass>
            {
                new() { ItemId = "1", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "3", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "4", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "5", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "6", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "7", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "8", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "9", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "10", ItemType = ItemTypeEnum.Pretest }
            };

            var testlet = new Testlet("testletId1", itemList);
            var randomized = testlet.Randomize();

            Assert.AreEqual(ItemTypeEnum.Pretest, randomized.Items[0].ItemType);
            Assert.AreEqual(ItemTypeEnum.Pretest, randomized.Items[0].ItemType);
        }


        [TestMethod]
        public void Remaining_8_out_of_10_items_contains_2_pretest_and_6_operational()
        {
            var itemList = new List<ItemClass>
            {
                new() { ItemId = "1", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "3", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "4", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "5", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "6", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "7", ItemType = ItemTypeEnum.Pretest },
                new() { ItemId = "8", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "9", ItemType = ItemTypeEnum.Operational },
                new() { ItemId = "10", ItemType = ItemTypeEnum.Pretest }
            };

            var testlet = new Testlet("testletId1", itemList);
            var randomized = testlet.Randomize();

            var remainingItems = randomized.Items.Skip(2).ToArray();
           
            var totalPretest = 0;
            var totalOperational = 0;


            foreach (var itemClass in remainingItems)
            {
                switch (itemClass.ItemType)
                {
                    case ItemTypeEnum.Pretest:
                        totalPretest += 1;
                        break;
                    case ItemTypeEnum.Operational:
                        totalOperational += 1;
                        break;
                }
            }
            
            Assert.AreEqual(6, totalOperational);
            Assert.AreEqual(2, totalPretest);
        }

    }
}
