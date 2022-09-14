using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;



namespace AssessmentProj
{
   
    

    public class Testlet
    {
        public string TestletId;
        private List<ItemClass> Items;

        private int FixedItems = 10;
        private int OperationalItems = 6;
        private int PretestItems = 4;
        private IRandomizeItems randomizer;

        public Testlet(string testletId, List<ItemClass> items)
        {
            this.TestletId = testletId;
            this.Items = items;

        }

       



        private Testlet(IRandomizeItems rndmzr)
        {
            this.randomizer = rndmzr;
        }

        public static bool IsEmpty(List<ItemClass> list)
        {
            if (list == null)
            {
                return true;
            }

            return !list.Any();
        }


        public bool ValidateNumberOfPreTest(List<ItemClass> items)
        {
            int CountOfPretest = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemType == ItemTypeEnum.Pretest)
                {
                    CountOfPretest = CountOfPretest + 1;

                }
            }

            if (CountOfPretest == PretestItems)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public bool ValidateNumberOfOperational(List<ItemClass> items)
        {
            int CountOfOperational = 0;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemType == ItemTypeEnum.Operational)
                {
                    CountOfOperational = CountOfOperational + 1;

                }

            }

            if (CountOfOperational == OperationalItems)
            {
                return true;
            }
            else
            {
                return false;

            }
        }


            public Testlet ValidateTestlet(string testletId, List<ItemClass> items)
        {
            if (!IsEmpty(items))
            {
                if (items.Count == FixedItems)
                {
                    var itemsTypeWise = items.ToLookup(i => i.ItemType);
                    bool isValid = false;

                    bool isValidPreTest = ValidateNumberOfPreTest(items);
                    bool isValidOperational = ValidateNumberOfOperational(items);

                    if (isValidPreTest == true && isValidOperational==true)
                    {
                        isValid = true;
                    }

                    if (isValid == true)
                    {
                        this.randomizer = new Randomizer(2);
                        var randomItems = this.randomizer.RandomizeItems(items);
                        return new Testlet(testletId, randomItems);

                    }
                    else
                    {
                        return null;
                    }

                }

                return null;

            }
            else
            {
                return null;
            }

        }

        public static void Main(String[] args)
        {
            
            List<ItemClass> ItemList = new List<ItemClass>();
            ItemList.Add(new ItemClass{ ItemId = "1", ItemType = ItemTypeEnum.Operational });
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
            

            for (int i=0; i< Organized.Items.Count; i++)
            {
                Console.WriteLine("Ïtem id  = "+ Organized.Items[i].ItemId + "ItemType  "+ Organized.Items[i].ItemType);
            }

            Console.ReadLine();
        }

    }
}
