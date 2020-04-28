using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChessTutorial.Dtos;

namespace ChessTutorial.Controllers.Api
{
    public class PiecesController : ApiController
    {
        [HttpPost]
        // POST api/pieces/checkAvailableMoves
        public IHttpActionResult CheckAvailableMoves(PieceDto pieceDto)
        {
            return Ok(new List<LocationDto>() 
            {
                new LocationDto() 
                {
                    X = 3,
                    Y = 5
                }
            });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
