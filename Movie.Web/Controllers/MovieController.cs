using Movie.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Web.Controllers
{
    /*
     * MovieMVC: The RoutePrefix is combined with the Route on every method below
     * to create a complete Route for each method.
     * 
     * The Method is the endpoint, not the controller.
     * 
     * The purpose of "Routing" is to have a Request find it's way to an end Point.
     * 
     * 
     */

    [RoutePrefix("Movie")]
    public class MovieController : BaseController
    {
        //private IEmployeeService _employeeService;

        //public MovieController(IEmployeeService employeeService)
        //{
        //    _employeeService = employeeService;
        //}

        #region - Simple Gets - 
        
        [Route("index"), Route, HttpGet]        
        public ActionResult Index()
        {
            /*
             * MovieMVC: This method has two routes
             * 1) Movie/index
             * 2) Movie
             * 
             * This accepts a GET request 
             * 
             * it renders a view with a file name of Index because that is the name of the method 
             * and when we called the view no other name was provided.
             */

            return View();
        }


        [Route("alpha"), HttpGet]
        public ActionResult Alpha()
        {
            /*
            * MovieMVC: Routes
            * 1) Movie/alpha
            * 
            * 
            * it renders a view with a file name of Alpha because that is the name of the method 
            * and when we called the view no other name was provided.
           */

            return View();
        }

        [Route("Beta")]
        public ActionResult Gamma()
        {
            /*
            * MovieMVC: Routes
            * 1) Movie/beta
            * 
            * 
            * it renders a view with a file name of Gamma because that is the name of the method 
            * and when we called the view no other name was provided.
            */

            return View();
        }

        [Route("Omega")]
        public ActionResult RandomName()
        {
            /*
            * MovieMVC: Routes
            * 1) Movie/Omega
            * 
            * 
            * it renders a view with a file name of Delta because that is the name we provide
             * when calling the View. This overrides the fact that the method in this case is RandomName
            */

            return View("Delta");
        } 
        #endregion

        [Route("Epsilon")]
        public ActionResult Epsilon(int age)
        {
            /*
            * MovieMVC: Routes
            * 1) Movie/epsilon
            * 
            * 
            * it renders a view with a file name of Epsilon because that is the name of the method 
            * and when we called the view no other name was provided.
             * 
             * additionally this method must be passed a parameter of type Int with a name of age
             * 
             * this param is passed into the View wrapped in an ItemViewModel class
            */

            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = age;
            return View(model);
        }

        [Route("Epsilon/{countOfSomething:int}")]
        public ActionResult EpsilonCount(int countOfSomething)
        {

            /*
          * MovieMVC: Routes
          * 1) Movie/Epsilon/{and required to be Followed By Some Int}
          * 
          * 
          * it renders a view with a file name of Epsilon because that is the View Name specified
           * 
           * additionally this method must be passed a parameter of type Int in the route, not as a parameter. 
           * we will refer to this part of the route by the name of countOfSomething
           * 
           * this param is passed into the View wrapped in an ItemViewModel class
          */


            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = countOfSomething;
            return View("Epsilon", model);
        }


        [Route("Epsilon/{uid:guid}")]
        public ActionResult Zeta(Guid uid)
        {
            /*
            * MovieMVC: Routes
            * 1) Movie/Epsilon/{and required to be Followed By Some Guid}
            * 
            * 
            * it renders a view with a file name of Index because that is the View Name specified
            * 
            * additionally this method must be passed a parameter of type Guid in the route, not as a parameter. 
            * we will refer to this part of the route by the name of countOfSomething
            * 
            * this param is passed into the View wrapped in an ItemViewModel class
             * 
             * Make note the route name, method name and view file name do not match
             * 
            */

            ItemViewModel<Guid> model = new ItemViewModel<Guid>();
            model.Item = uid;
            return View("Index",model);
        }


        [Route("zeta/{count}/{firstName}")]
        public ActionResult Zeta(int count, string firstName)
        {
            MovieViewModel model = new MovieViewModel();
            model.Data = firstName;
            model.Count = count;
            return View("Index", model);
        }


        [Route("eta")]
        public ActionResult Eta(string firstName,int count = 0)
        {
            MovieViewModel model = new MovieViewModel();
            model.Data = firstName;
            model.Count = count;
            return View("Index", model);
        }


        
    }
}
