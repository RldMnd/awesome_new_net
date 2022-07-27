using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    internal class Other
    {
        public static void Priorq()
        {
            var pq = new PriorityQueue<string, int>();
            pq.Enqueue("A", 0);
            pq.Enqueue("B", -1);
            pq.Enqueue("C", 5);
            var s = "";
            var pr = 0;
            while (pq.TryDequeue(out s,out pr))
            {
                Console.WriteLine(s);
            }
        }

        public static void NewLinq()
        {
            //Второй с конца
            Enumerable.Range(1, 10).ElementAt(^2);
            var range = Enumerable.Range(1, 10).Take(3..);
            range=Enumerable.Range(1, 10).Take(2..4);
            range=Enumerable.Range(1, 10).Take(..^2);
            range = Enumerable.Range(1, 20).DistinctBy(x => x % 5);
            Console.WriteLine(range.ToList());

            var first = new (string Name, int Age)[] { ("Петр", 20), ("Маша", 30), ("Иван", 40) };
            var second = new (string Name, int Age)[] { ("Семен", 30), ("Илья", 30), ("Катерина", 33) };
            var res=first.UnionBy(second, person => person.Age);
            res.ToList();
            var r=second.MaxBy(p=>p.Age);
            res.ToList();
        }

        public static void DT()
        {
            var dto = DateOnly.FromDateTime(DateTime.Now);
            Console.WriteLine(dto.ToString()); 
            var tto = TimeOnly.FromDateTime(DateTime.Now);
            Console.WriteLine(tto.ToString());
        }

    }
}
