using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssessmentProj
{
    internal class Program
    {
        public static void Main(String[] args)
        {

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

            Testlet t = new Testlet("1", ItemList);
            Testlet Organized = t.ValidateTestlet("1", ItemList);

            Console.WriteLine("Printing here");


            for (int i = 0; i < Organized.Items.Count; i++)
            {
                Console.WriteLine("Ïtem id  = " + Organized.Items[i].ItemId + "ItemType  " + Organized.Items[i].ItemType);
            }

            Console.ReadLine();
        }
    }
}
