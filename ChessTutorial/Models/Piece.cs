using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web;

namespace ChessTutorial.Models
{
    public abstract class Piece
    {
        public Location Location { get; set; }
        public string UnicodeSymbol { get; set; }
        public string HtmlCode { get; set; }

        public abstract IEnumerable<Location> CheckAvailableMoves();

        public bool ValidateMove(Location newLocation)
        {
            var availableMoves = CheckAvailableMoves();

            // sprawdzić czy nie da się uproscic z equal
            return availableMoves.Any(m=>m.X==newLocation.X&m.Y==newLocation.Y);
        }

        public static Piece RecognizePiece(string name)
        {
            IEnumerable<Piece> allPieces = new List<Piece>()
            {
                new King(),
                new Rook(),
                new Queen()
            };

            Piece choosenPiece = allPieces.First(p => p.GetType().ToString() == name);

            return choosenPiece;
        }

    }

    public class Rook : Piece
    {
        public Rook()
        {
            HtmlCode = "&#9820;";
            UnicodeSymbol = "\u265C";
        }
        public override IEnumerable<Location> CheckAvailableMoves()
        {
            return new List<Location>();
        }

    }
    public class King : Piece
    {
        public King()
        {
            HtmlCode = "&#9818;";
            UnicodeSymbol = "\u265A";
        }
        public override IEnumerable<Location> CheckAvailableMoves()
        {
            var availableMoves = new List<Location>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    availableMoves.Add(new Location((byte)(Location.X+x),(byte)(Location.Y+y)));
                }
            }

            availableMoves.RemoveAll(m => m.IsOnChessboard == false);
            availableMoves.RemoveAll(m => m.X == Location.X & m.Y == Location.Y);

            return availableMoves;
        }

    }

    public class Queen : Piece
    {
        public Queen()
        {
            HtmlCode = "&#9819;";
            UnicodeSymbol = "\u265B";
        }
        public override IEnumerable<Location> CheckAvailableMoves()
        {
            return new List<Location>();
        }

    }

}