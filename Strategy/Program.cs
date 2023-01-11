using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
     class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager= new CustomerManager();
            customerManager.CreditCalclatorBase = new After2010CreditCalculator();
            customerManager.SaveCredit();

            customerManager.CreditCalclatorBase = new Before2010CreditCalculator();
            customerManager.SaveCredit();
            Console.ReadLine();
        }
    }

    abstract class CreditCalclatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculator : CreditCalclatorBase
    {
        public override void Calculate()
        {

            Console.WriteLine("Credit calculated using before2010");
        }
    }
    class After2010CreditCalculator : CreditCalclatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using after2010");
        }
    }


    class CustomerManager
    {
        public CreditCalclatorBase CreditCalclatorBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business");
            CreditCalclatorBase.Calculate();
        }
    }
}
