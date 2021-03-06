
using HomeRunBingo.Models.Domain;
using HomeRunBingo.Models.Requests;
using HomeRunBingo.Models.Responses;
using HomeRunBingo.Services;
using HomeRunBingo.Services.Security;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;

namespace HomeRunBingo.Web.Controllers.Api
{
    [AllowAnonymous]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserService _svc;
        private IPrincipal _principal;
        private IAuthenticationService _auth;

        public UserController(IUserService svc, IPrincipal principal, IAuthenticationService auth)
        {
            _principal = principal;
            _svc = svc;
            _auth = auth;
        }

        [HttpPost]
        [Route]
        //=============controllerfor register==================
        public HttpResponseMessage CreateUser(RegisterAddRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = _svc.CreateUser(model);
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

        [Route("current"), HttpGet]
        public HttpResponseMessage Current()
        {
            try
            {
                // changed email to name
                UserBase userBase = (UserBase)_principal.Identity.GetCurrentUser();
                userBase.Name = _svc.UserSelectById(userBase.Id);
                return Request.CreateResponse(HttpStatusCode.OK, userBase);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        //======================controller for login=====================
        [HttpPost]
        [Route("login")]

        public HttpResponseMessage UserLogInWithHash(LoginRequest loginRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool userinfo = _svc.UserLogIn(loginRequest);
                    ItemResponse<Boolean> resp = new ItemResponse<Boolean>();
                    resp.Item = userinfo;

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

        [Route("logout"), HttpGet]
        public HttpResponseMessage Logout()
        {
            _auth.LogOut();
            return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());
        }

    }
}