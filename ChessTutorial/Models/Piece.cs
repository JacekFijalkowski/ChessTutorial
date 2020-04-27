using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace ChessTutorial.Models
{
    public abstract class Piece
    {
        public Location Location { get; set; }
        public string UnicodeSymbol { get; set; }
        public string HtmlCode { get; set; }

        public abstract IEnumerable<Location> GetAvailableMoves();

        public abstract bool ValidateMove();

    }

    public class Rook : Piece
    {
        public Rook()
        {
            HtmlCode = "&#9820;";
            UnicodeSymbol = "\u265C";
        }
        public override IEnumerable<Location> GetAvailableMoves()
        {
            return new List<Location>();
        }

        public override bool ValidateMove()
        {
            return true;
        }
    }
    public class King : Piece
    {
        public King()
        {
            HtmlCode = "&#9818;";
            UnicodeSymbol = "\u265A";
        }
        public override IEnumerable<Location> GetAvailableMoves()
        {
            return new List<Location>();
        }

        public override bool ValidateMove()
        {
            return true;
        }
    }

}