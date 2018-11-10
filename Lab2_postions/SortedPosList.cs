using System;
using System.Collections.Generic;

namespace Lab2_postions
{
    internal class SortedPosList
    {
        private List<Position> positionList = new List<Position>(); 
        public List<Position> PositionList { get { return positionList; } set { positionList = value; } }


        public SortedPosList Clone(){
            SortedPosList newInst = new SortedPosList();
            newInst.PositionList = new List<Position>();

            for (int i = 0; i < PositionList.Count; i++)
            {
                newInst.PositionList.Add(PositionList[i].Clone());
            }

            return newInst;
        }

        public bool Remove(Position pos)
        {
            PositionList.Remove(pos);
            return true;
        }

        public SortedPosList CircleContent(Position position, double radius)
        {
            SortedPosList newInst = new SortedPosList();
            newInst.PositionList = new List<Position>();
            for (int i = 0; i < PositionList.Count; i++)
            {
                if (InCircle(position,radius, i))
                    newInst.Add(PositionList[i]);     
            }
            return newInst;
        }

        public bool InCircle(Position position, double radius,int i)
        {  
            double center_x = position.Xpos;
            double center_y = position.Ypos;
            double dx = Math.Abs(PositionList[i].Xpos - center_x);
            double dy = Math.Abs(PositionList[i].Ypos - center_y);
            return (dx * dx + dy * dy <= radius * radius);
        }

        public override string ToString()
        {
            string combineString = "";
            foreach(Position item in PositionList){
               
                combineString += item.ToString();
            }
            return combineString;
        }

        public int Count(){
            return PositionList.Count;
        }
  

        public void Add(Position pos){
            if (PositionList.Count == 0)
                PositionList.Insert(0, pos);
            else{

                for (int i = 0; i < PositionList.Count; i++)
                {
              
                    if (PositionList[i].Length() > pos.Length())
                    {
                        PositionList.Insert(i, pos);
                        return;
                    }

                    if (PositionList.Count-1 == i)
                    {
                        PositionList.Insert(PositionList.Count, pos);
                        return;
                    }
                }
            }
        }

        public static SortedPosList operator +(SortedPosList p1, SortedPosList p2)
        {
            SortedPosList newList = new SortedPosList();
            int size = p1.Count();
            if (p1.Count() <= p2.Count())
                size = p2.Count();
            for (int i = 0; i < size; i++)
            {
                if(i < p1.Count())
                newList.Add(p1.PositionList[i].Clone());

                if(i < p2.Count())
                newList.Add(p2.PositionList[i].Clone());

            }
            // operator stuff
            return newList;
        }


        public static SortedPosList operator -(SortedPosList p1, SortedPosList p2)
        {
   
            int firstSize = p1.Count() -1;
            int secondSize = p2.Count()-1;

            int i1 = 0;
            int i2 = 0;

            while (i1 <= firstSize && i2 <= secondSize)
            {
                if (p1.PositionList[i1].Equals(p2.PositionList[i2]))
                {
                    p1.Remove(p1.PositionList[i1]);
                    firstSize--;
                }
                else if (p1.PositionList[i1].Length() > p2.PositionList[i2].Length())
                {
                    i2++;
                }
                else
                    i1++;
            }
            return p1;
        }


    }
}