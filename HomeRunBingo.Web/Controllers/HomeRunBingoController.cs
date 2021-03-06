using HomeRunBingo.Models.Domain;
using HomeRunBingo.Models.Responses;
using HomeRunBingo.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeRunBingo.Web.Controllers.Api
{

    [AllowAnonymous]
    [RoutePrefix("api/card")]
    public class HomeRunBingoController : ApiController
    {
        private IBingoCardService _bingoCardService;

        public HomeRunBingoController(IBingoCardService bingoCardService)
        {
            _bingoCardService = bingoCardService;
        }
         

        [Route("post"), HttpPost]
        public HttpResponseMessage CreateCard(BingoCardDomain model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = _bingoCardService.CreateBingoCard(model);
                    ItemResponse<int> resp = new ItemResponse<int>();
                    resp.Item = id;
                
                    return Request.CreateResponse(HttpStatusCode.OK, resp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [Route("{Userid:int}"), HttpGet]
        public HttpResponseMessage SelectByUserId(int Userid)
        {
            try
            {
                ItemResponse<List<BingoCardDomain>> resp = new ItemResponse<List<BingoCardDomain>>();
                resp.Item = _bingoCardService.SelectByUserId(Userid);
                
                return Request.CreateResponse(HttpStatusCode.OK, resp );
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
