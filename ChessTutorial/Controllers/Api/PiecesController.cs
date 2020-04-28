using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChessTutorial.Dtos;
using ChessTutorial.Models;

namespace ChessTutorial.Controllers.Api
{
    public class PiecesController : ApiController
    {
        [HttpPost]
        // POST api/pieces/checkAvailableMoves
        public IHttpActionResult CheckAvailableMoves(PieceDto pieceDto)
        {
            var choosenPiece = Piece.RecognizePiece(pieceDto.Name);

            choosenPiece.Location = new Location(pieceDto.Location.X,pieceDto.Location.Y);

            var availableMoves = choosenPiece.CheckAvailableMoves();

            var availableMovesDto = availableMoves.Select(move => new LocationDto() {X = move.X, Y = move.Y}).ToList();


            return Ok(availableMovesDto);
        }

        // POST api/pieces/validateMove
        public IHttpActionResult ValidateMove(PieceDto pieceDto)
        {
            var choosenPiece = Piece.RecognizePiece(pieceDto.Name);

            choosenPiece.Location = new Location(pieceDto.Location.X,pieceDto.Location.Y);

            Location nextLocation = new Location(pieceDto.NextLocation.X,pieceDto.NextLocation.Y);

            return Ok(choosenPiece.ValidateMove(nextLocation));
        }

    }
}
