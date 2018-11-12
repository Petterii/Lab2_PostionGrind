using System;
using System.Collections.Generic;

namespace Lab2_postions
{
    class SortedPosList
    {
        private List<Position> positionList = new List<Position>(); 
        public List<Position> PositionList { get { return positionList; } set { positionList = value; } }

        const string FILEPATH = "./WriteLines2.txt";


        public SortedPosList(){
            try
            {
                System.IO.File.ReadAllLines(FILEPATH);
            }
            catch
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(FILEPATH))
                { };
            }
           }

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
                    newInst.PositionList.Add(PositionList[i]);     
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

        public static void PrintFile()
        {

        }

        public int Count(){
            return PositionList.Count;
        }
  

        public void Add(Position pos){
            if (PositionList.Count == 0)
            {
                PositionList.Insert(0, pos);
                SavePositionToFile(pos);
            }
            else{

                for (int i = 0; i < PositionList.Count; i++)
                {
              
                    if (PositionList[i].Length() > pos.Length())
                    {
                        PositionList.Insert(i, pos);
                        SavePositionToFile(pos);
                        return;
                    }

                    if (PositionList.Count-1 == i)
                    {
                        PositionList.Insert(PositionList.Count, pos);
                        SavePositionToFile(pos);
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
                newList.PositionList.Add(p1.PositionList[i].Clone());

                if(i < p2.Count())
                newList.PositionList.Add(p2.PositionList[i].Clone());

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

        public void WriteToFile(Position p){
            SortedPosList readList = ReadFileToSortedList();

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(FILEPATH))
            {
                string temp = ToString();

                for (int i = 0; i < readList.Count(); i++)
                {                 
                    file.WriteLine(readList.PositionList[i].ToString());
                }

                for (int i = 0; i < PositionList.Count; i++)
                {
                    file.WriteLine(PositionList[i].ToString());

                }

            }

     
        }

        public void SavePositionToFile(Position p)
        {
            SortedPosList readList = ReadFileToSortedList();

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(FILEPATH))
            {
                string temp = ToString();

                for (int i = 0; i < readList.Count(); i++)
                {
                    file.WriteLine(readList.PositionList[i].ToString());
                }

                file.WriteLine(p.ToString());


            }


        }

        public SortedPosList ReadFileToSortedList(){
    
            string[] lines = System.IO.File.ReadAllLines(FILEPATH);

            SortedPosList nList = new SortedPosList();

            for (int i = 0; i < lines.Length; i++)
            {
                nList.PositionList.Add(StringToPosition(lines[i]));
            }

            return nList;
        }

        public Position StringToPosition(string pos){
            string posR1 = pos.Replace("(",string.Empty);
            string posR2 = posR1.Replace(")", string.Empty);
            string[] twoPoints = posR2.Split(",");

            Position position = new Position(int.Parse(twoPoints[0]),int.Parse(twoPoints[1]));
            return position;
        }
    }
}