using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
     class Program
    {
        static void Main(string[] args)
        {
            Employee ferit = new Employee { Name = "Ferit Şimşek" };
            Employee seyma = new Employee { Name = "Şeyma Şimşek" };
            ferit.AddSubordinate(seyma);

            Contractor tahir= new Contractor { Name = "Tahir" };
            seyma.AddSubordinate(tahir);
            Employee sevval = new Employee { Name = "Şevval Şimşek" };
            ferit.AddSubordinate(sevval);
            Employee ali = new Employee { Name = "    Ali Şimşek" };
            sevval.AddSubordinate(ali);
            Console.WriteLine(ferit.Name);

            foreach (Employee manager in ferit)
            {
                Console.WriteLine("     {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("     {0}",employee.Name);
                }
                
            }
            Console.ReadLine();

        }
    }

    interface IPerson
    {
         string Name { get; set; }

    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }
    class Employee : IPerson,IEnumerable<IPerson>
    {

        List<IPerson> _subordinates = new List<IPerson>();
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
