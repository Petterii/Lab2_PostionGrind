using System;

namespace Lab2_postions
{
    class Program
    {
        protected static void Main(string[] args)
        {

            Console.WriteLine(new Position(2, 4) + new Position(1, 2) + " : plus Operator on pos\n");
            Console.WriteLine(new Position(2, 4) - new Position(1, 2) + " : minus Operator on pos\n");
            Console.WriteLine(new Position(1, 2) - new Position(3, 6) + " : minus Operator on pos\n");
            Console.WriteLine(new Position(3, 5) % new Position(1, 3) + " : modulos operator on pos\n");
            Console.WriteLine(new Position(5, 3) < new Position(3, 10));
          

            SortedPosList list1 = new SortedPosList();
            SortedPosList list2 = new SortedPosList();
            list1.Add(new Position(3, 7));
            list1.Add(new Position(1, 4));
            list1.Add(new Position(2, 6));
            list1.Add(new Position(2, 3));
            Console.WriteLine(list1 + " : First List\n");
            list1.Remove(new Position(2, 6));
            Console.WriteLine(list1 + " : Remove from first List\n");

            list2.Add(new Position(3, 7));
            list2.Add(new Position(1, 2));
            list2.Add(new Position(3, 6));
            list2.Add(new Position(2, 3));
            list2.Add(new Position(2, 3));
            Console.WriteLine((list2 + list1) + " : Plus \n");


            Console.WriteLine(list1 + " : First\n");
            Console.WriteLine(list2 + " : Second\n");


            Console.WriteLine((list2 - list1) + " : Minus \n");
            SortedPosList circleList = new SortedPosList();
            circleList.Add(new Position(1, 1));
            circleList.Add(new Position(2, 2));
            circleList.Add(new Position(3, 3));
            Console.WriteLine(circleList + " : CircleList\n");

            Console.WriteLine(circleList.CircleContent(new Position(5, 5), 4) + " : Inside Circle \n");

            // list1.WriteToFile();
            Console.WriteLine(list1.ReadFileToSortedList() + " : File");
        }
    }
}
