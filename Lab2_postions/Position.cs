using System;
using System.Collections.Generic;

namespace Lab2_postions
{
    internal class Position
    {
        private int p2;
        private int p1;
        public int Xpos { get { return p1; } set { if (value < 0) p1 = 0; else p1 = value; } }
        public int Ypos { get { return p2; } set { if (value < 0) p2 = 0; else p2 = value; } } 
      //  public static List<Position> PositionList { get; set; }

        public Position(int v1, int v2)
        {
            this.Xpos = v1;
            this.Ypos = v2;
            int[] newPos= {v1,v2};
            

          //  SortedPosList.PositionList.Add(this);
        }

        public Position(){

        }

        public bool Equals(Position pos1){
            if (Xpos == pos1.Xpos && pos1.Ypos == Ypos){
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string a = "("+Xpos +","+ Ypos+")";
            return a;
        }

        public decimal Length(){
            double temp = (Xpos * Xpos) + (Ypos * Ypos);
            decimal lenghtFromCenter = (decimal)Math.Sqrt(temp);
            return lenghtFromCenter;
        }

        public Position Clone(){
            Position newPos = new Position();
            newPos.Xpos = Xpos;
            newPos.Ypos = Ypos;
            return newPos;
        }

        public static Position operator +(Position p1, Position p2){
            return new Position(p1.Xpos + p2.Xpos, p1.Ypos + p2.Ypos);
        }
        public static Position operator -(Position p1, Position p2)
        {
            int pos1 = Math.Abs(p1.Xpos - p2.Xpos);
            int pos2 = Math.Abs(p1.Ypos - p2.Ypos);
            Position newPos = new Position(pos1,pos2 );

            return newPos;
            }
        public static double operator %(Position p1, Position p2)
        {
            // operator stuff
            int pos1 = p1.Xpos - p2.Xpos;
            int pos2 = p1.Ypos - p2.Ypos;
            int temp = (pos1 * pos1) + (pos2 * pos2);
            double sum = Math.Sqrt(temp);
            return sum;
        }

        public static bool operator >(Position p1, Position p2){
            if (p1.Length() == p2.Length()){
                return p1.Xpos > p2.Xpos ? true : false;
            }
            return p1.Length() > p2.Length() ? true : false;
        }
        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length() == p2.Length())
            {
                return p1.Xpos < p2.Xpos ? true : false;
            }
            return p1.Length() < p2.Length() ? true : false; ;
        }
    }
}