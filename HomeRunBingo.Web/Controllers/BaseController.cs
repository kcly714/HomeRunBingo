using HomeRunBingo.Models.ViewModels;
using System.Web.Mvc;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Web.Mvc.Async;
using System.Web.Mvc.Filters;
using System.Web.Profile;
using System.Web.Routing;


namespace HomeRunBingo.Web.Controllers
{
    public class BaseController : Controller
    {
        protected T GetViewModel<T>() where T : BaseViewModel, new()
        {
            T model = new T();

            //customize base view model here

            return model;
        }
    }
}
