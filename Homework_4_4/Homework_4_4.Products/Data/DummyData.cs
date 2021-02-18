using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_4_4.Products.Data
{
    public class DummyData
    {
        private static volatile DummyData _instance = null;
        private static readonly object padLock = new object();

        public static DummyData Instance
        {
            get
            {
                lock (padLock)
                {
                    if (_instance == null)
                    {
                        _instance = new DummyData();
                    }
                }
                return _instance;
            }
        }

        private DummyData()
        {
            FillData();
        }

        private void FillData()
        {
            for (int i = 1; i <= 10; i++)
            {
                Products.Add(new Model.Products { Id = i, Name = "Product_" + i, Price = 100 + (i * 10) });
            }
        }

        public List<Model.Products> Products = new List<Model.Products>();
    }
}

