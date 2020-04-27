using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessTutorial.Dtos
{
    public class PieceDto
    {
        public LocationDto Location { get; set; }
        public string UnicodeSymbol { get; set; }
        public string HtmlCode { get; set; }

    }
}