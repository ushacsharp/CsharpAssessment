using System;
using System.Collections.Generic;


namespace AssessmentProj
{
    internal class Program
    {
        public static void Main(String[] args)
        {

            var itemList = new List<ItemClass>();
            itemList.Add(new ItemClass { ItemId = "1", ItemType = ItemTypeEnum.Operational });
            itemList.Add(new ItemClass { ItemId = "2", ItemType = ItemTypeEnum.Pretest });
            itemList.Add(new ItemClass { ItemId = "3", ItemType = ItemTypeEnum.Operational });
            itemList.Add(new ItemClass { ItemId = "4", ItemType = ItemTypeEnum.Operational });
            itemList.Add(new ItemClass { ItemId = "5", ItemType = ItemTypeEnum.Pretest });
            itemList.Add(new ItemClass { ItemId = "6", ItemType = ItemTypeEnum.Operational });
            itemList.Add(new ItemClass { ItemId = "7", ItemType = ItemTypeEnum.Pretest });
            itemList.Add(new ItemClass { ItemId = "8", ItemType = ItemTypeEnum.Operational });
            itemList.Add(new ItemClass { ItemId = "9", ItemType = ItemTypeEnum.Operational });
            itemList.Add(new ItemClass { ItemId = "10", ItemType = ItemTypeEnum.Pretest });
            itemList.Add(new ItemClass { ItemId = "11", ItemType = ItemTypeEnum.Pretest });

            try
            {
                Console.WriteLine("Printing here");

                var testlet = new Testlet("1", itemList);
                var organized = testlet.Randomize();

                foreach (var item in organized.Items)
                {
                    Console.WriteLine("Ïtem id  = " + item.ItemId + "ItemType  " + item.ItemType);
                }

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error processing Testlet: {e}");
                Console.ReadLine();

            }
        }
    }
}
