using Movie.Models.Responses;
using Movie.Models.ViewModels;
using Movie.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace Movie.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/contactus")]
    public class ContactUsController : ApiController
    {
        private IContactUsService _contactUsService;
        private ISendGridService _sendGridService;


        public ContactUsController(IContactUsService contactUsService, ISendGridService sendGridService)
        {
            _contactUsService = contactUsService;
            _sendGridService = sendGridService;

        }

        [HttpPost]
        [Route]
        public HttpResponseMessage Insert(ContactUsModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemResponse<int> resp = new ItemResponse<int>();
                    resp.Item = _contactUsService.Insert(model);
                    _sendGridService.ContactUs(model);
                    return Request.CreateResponse(HttpStatusCode.OK, resp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }






    }
}
