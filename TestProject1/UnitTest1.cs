using System.Linq;
using AssessmentProj;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
           public void GetRandomizeItems_checking_10items_in_the_list()
        {
            var randomizer = new Randomizer(2);
            //Arrange  
            List<ItemClass> ItemList = new List<ItemClass>();
            ItemList.Add(new ItemClass { ItemId = "1", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "2", ItemType = ItemTypeEnum.Pretest });
            ItemList.Add(new ItemClass { ItemId = "3", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "4", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "5", ItemType = ItemTypeEnum.Pretest });
            ItemList.Add(new ItemClass { ItemId = "6", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "7", ItemType = ItemTypeEnum.Pretest });
            ItemList.Add(new ItemClass { ItemId = "8", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "9", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "10", ItemType = ItemTypeEnum.Pretest });


            int actual = 10;

   
            //Act  
            var expected = randomizer.RandomizeItems(ItemList);
            //Assert  
            Assert.AreEqual(actual,expected.Count);
        }


        [TestMethod]
        public void List_passed_should_contain_6_operational_and_4_pretest()
        {
            var randomizer = new Randomizer(2);
            int totalOperational = 0;
            int totalPretest = 0;


            //Arrange  
            List<ItemClass> ItemList = new List<ItemClass>();
            ItemList.Add(new ItemClass { ItemId = "1", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "2", ItemType = ItemTypeEnum.Pretest });
            ItemList.Add(new ItemClass { ItemId = "3", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "4", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "5", ItemType = ItemTypeEnum.Pretest });
            ItemList.Add(new ItemClass { ItemId = "6", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "7", ItemType = ItemTypeEnum.Pretest });
            ItemList.Add(new ItemClass { ItemId = "8", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "9", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "10", ItemType = ItemTypeEnum.Pretest });

            var RandomItemsAfterFunctionCall = randomizer.RandomizeItems(ItemList);

            foreach (var ItemClass in RandomItemsAfterFunctionCall)
            {
                if (ItemClass.ItemType == ItemTypeEnum.Pretest)
                {
                    totalPretest = totalPretest + 1;
                }
                else if (ItemClass.ItemType == ItemTypeEnum.Operational)
                {
                    totalOperational = totalOperational + 1;
                }

            }
            
            int expectedOperational = 6;
            int expectedPretest = 4;
            int expected = 0;
            //Act  
            if (totalPretest == expectedPretest && totalOperational == expectedOperational)
            {
                expected = 1;
            }
            int actual = 1;
            //Assert  
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Randomizer_returns_first_two_are_pretest()
        {
            var randomizer = new Randomizer(2);
            //Arrange  
            List<ItemClass> ItemList = new List<ItemClass>();
            ItemList.Add(new ItemClass { ItemId = "1", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "2", ItemType = ItemTypeEnum.Pretest });
            ItemList.Add(new ItemClass { ItemId = "3", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "4", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "5", ItemType = ItemTypeEnum.Pretest });
            ItemList.Add(new ItemClass { ItemId = "6", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "7", ItemType = ItemTypeEnum.Pretest });
            ItemList.Add(new ItemClass { ItemId = "8", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "9", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "10", ItemType = ItemTypeEnum.Pretest });

            int totalPretest = 0;

            var afterRandomized = randomizer.RandomizeItems(ItemList);

            for(int i=0; i< afterRandomized.Count; i++)
            {
                if ((afterRandomized[i].ItemType == ItemTypeEnum.Pretest && i==0) || (afterRandomized[i].ItemType == ItemTypeEnum.Pretest && i == 1))
                {
                    totalPretest = totalPretest + 1;
                }
               

            }

            int actual = 2;
            //Assert  
            Assert.AreEqual(actual, totalPretest);
        }

        [TestMethod]
        public void Remaining_8_out_of_10_items_contains_2_pretest_and_6_operational()
        {
            var randomizer = new Randomizer(2);
            //Arrange  
            List<ItemClass> ItemList = new List<ItemClass>();
            ItemList.Add(new ItemClass { ItemId = "1", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "2", ItemType = ItemTypeEnum.Pretest });
            ItemList.Add(new ItemClass { ItemId = "3", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "4", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "5", ItemType = ItemTypeEnum.Pretest });
            ItemList.Add(new ItemClass { ItemId = "6", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "7", ItemType = ItemTypeEnum.Pretest });
            ItemList.Add(new ItemClass { ItemId = "8", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "9", ItemType = ItemTypeEnum.Operational });
            ItemList.Add(new ItemClass { ItemId = "10", ItemType = ItemTypeEnum.Pretest });

            var randomizedItems = randomizer.RandomizeItems(ItemList);

            var remainingItems = randomizedItems.Skip(2).ToArray();
            int totalPretest = 0;
            int totalOperational = 0;


            foreach (var ItemClass in remainingItems)
            {
                if (ItemClass.ItemType == ItemTypeEnum.Pretest)
                {
                    totalPretest = totalPretest + 1;
                }
                else if (ItemClass.ItemType == ItemTypeEnum.Operational)
                {
                    totalOperational = totalOperational + 1;
                }

            }

            int expectedOperational = 6;
            int expectedPretest = 2;
            int expected = 0;
            //Act  
            if (totalPretest == expectedPretest && totalOperational == expectedOperational)
            {
                expected = 1;
            }
            int actual = 1;
            //Assert  
            Assert.AreEqual(actual, expected);
        }

    }
}
