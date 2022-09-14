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
        public List<ItemClass> Items;

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

        public Testlet ProcessTestlet(string testletId, List<ItemClass> items)
        {
            try
            {
                //validate Testlet
                bool isValid = ValidateTestlet(testletId, items);
                //if validation is successful process it
                if (isValid == true)
                {
                    this.randomizer = new Randomizer(2);
                    var randomItems = this.randomizer.RandomizeItems(items);
                    return new Testlet(testletId, randomItems);

                }

                else
                {
                    throw new Exception("Testlet should have 10 items out of which 4 pretest and 6 operational");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.ReadLine();
            }
            return null;

        }
        public bool ValidateTestlet(string testletId, List<ItemClass> items)
        {
            if (!IsEmpty(items))
            {
                if (items.Count == FixedItems)
                {
                    var itemsTypeWise = items.ToLookup(i => i.ItemType);
                    

                    bool isValidPreTest = ValidateNumberOfPreTest(items);
                    bool isValidOperational = ValidateNumberOfOperational(items);

                    if (isValidPreTest == true && isValidOperational == true)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                    

                }

                return false;

            }
            else
            {
                return false;
            }

        }

        

    }
}
