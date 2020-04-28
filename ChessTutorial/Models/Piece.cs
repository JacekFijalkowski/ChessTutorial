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

        public static IEnumerable<Piece> GetAllPieces()
        {
            return new List<Piece>()
            {
                new King(),
                new Rook(),
                new Queen(),
                new Bishop(),
                new Knight(),
                new Pawn()
            };
        }
        public static Piece RecognizePiece(string typeName)
        {
            var allPieces = GetAllPieces();
            return allPieces.First(p => p.GetType().ToString() == typeName);
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
            var availableMoves = new List<Location>();

            for (int x = -7; x <= 7; x++)
            {
                availableMoves.Add(new Location((byte)(Location.X+x),(byte)(Location.Y)));
            }
            for (int y = -7; y <= 7; y++)
            {
                availableMoves.Add(new Location((byte)(Location.X),(byte)(Location.Y+y)));
            }

            availableMoves.RemoveAll(m => m.IsOnChessboard == false);
            availableMoves.RemoveAll(m => m.X == Location.X & m.Y == Location.Y);

            return availableMoves;
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
            var bishop = new Bishop(){Location = Location};
            var rook = new Rook(){Location = Location};

            var bishopMoves = bishop.CheckAvailableMoves();
            var rookMoves = rook.CheckAvailableMoves();

            var queenMoves = new List<Location>();
            queenMoves.AddRange(bishopMoves);
            queenMoves.AddRange(rookMoves);

            return queenMoves;
        }

    }
    public class Bishop : Piece
    {
        public Bishop()
        {
            HtmlCode = "&#9821;";
            UnicodeSymbol = "\u265D";
        }
        public override IEnumerable<Location> CheckAvailableMoves()
        {
            var availableMoves = new List<Location>();

            for (int i = 1; i <= 7; i++)
            {
                availableMoves.Add(new Location((byte)(Location.X+i),(byte)(Location.Y+i)));
                availableMoves.Add(new Location((byte)(Location.X+i),(byte)(Location.Y-i)));
                availableMoves.Add(new Location((byte)(Location.X-i),(byte)(Location.Y+i)));
                availableMoves.Add(new Location((byte)(Location.X-i),(byte)(Location.Y-i)));
            }

            availableMoves.RemoveAll(m => m.IsOnChessboard == false);
            availableMoves.RemoveAll(m => m.X == Location.X & m.Y == Location.Y);

            return availableMoves;
        }

    }
    public class Knight : Piece
    {
        public Knight()
        {
            HtmlCode = "&#9822;";
            UnicodeSymbol = "\u265E";
        }
        public override IEnumerable<Location> CheckAvailableMoves()
        {
            return new List<Location>();
        }

    }
    public class Pawn : Piece
    {
        public Pawn()
        {
            HtmlCode = "&#9823;";
            UnicodeSymbol = "\u265F";
        }
        public override IEnumerable<Location> CheckAvailableMoves()
        {
            var availableMoves = new List<Location>();

            availableMoves.Add(new Location((byte)(Location.X),(byte)(Location.Y+1)));

            return availableMoves;
        }

    }
}