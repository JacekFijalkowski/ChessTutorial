using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessTutorial.Models
{
    public class Location
    {
        public Location(byte x, byte y)
        {
            this.X = x;
            this.Y = y;

            // Location 0,0 means "outside of chessboard"
            if (X>8|X<1|Y>8|Y<1)
            {
                X = 0;
                Y = 0;
                IsOnChessboard = false;
            }
        }

        public readonly bool IsOnChessboard = true;

        public byte X { get; private set; }

        public byte Y { get; private set; }
    }
}