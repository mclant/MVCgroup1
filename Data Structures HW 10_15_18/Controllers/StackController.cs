using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data_Structures_HW_10_15_18.Models;

namespace Data_Structures_HW_10_15_18.Controllers
{
    public class StackController : Controller
    {
        //rob is the man

        // GET: Stack
        public static Stack<string> mystack = new Stack<string>();

        //these are variables to try and get my search box to work:)
        public bool searching = false;
        public string searchword = null;

        //these are all methods used when called on from the view, to do everything to our stack
        public ActionResult StackIndex()
        {
            
            return View("StackIndex");
        }

        
        public ActionResult addone()
        {
            mystack.Push("item number #" + (mystack.Count + 1));


            return View("StackIndex");
        }

        public ActionResult displaystack()
        {
            if (mystack.Count == 0)
            {
                ViewBag.Delete = "The Stack is Empty. Please add an item to the stack before displaying.";
            }
            else
            {
                ViewBag.Stack = mystack;
            }

            return View("StackIndex");
        }

        public ActionResult popstack()
        {
            if (mystack.Count == 0)
            {
                ViewBag.Delete = "The Stack is empty. No item can be deleted.";
            }
            else
            {
                mystack.Pop();
            }

            return View("StackIndex");
        }

        public ActionResult hugelist()
        {
            mystack.Clear();

            for (int i = 0; i < 2000; i++)
            {
                mystack.Push("New Entry " + (mystack.Count + 1));
            }

            return View("StackIndex");
        }

        public ActionResult clearstack()
        {
            mystack.Clear();

            return View("StackIndex");
        }

        public ActionResult searchstack()
        {
            if (mystack.Count == 0)
            {
                ViewBag.Search = "Stack is empty. Please add items to the stack.";
            }
            else
            {
                ViewBag.Search = "im not null";
            }
            
            return View("StackIndex");
        }

        //gets the input data from the user
        [HttpPost]
        public ActionResult getsearchitem()
        {
            string searchitem = null;
            if (mystack.Contains(searchitem) == true)
            {
                ViewBag.Searched = "Found!";
            }
            else
            {
                ViewBag.Searched = "Not Found.";
            }

            return View("StackIndex");
        }

        [HttpPost]
        public String SearchStack(FormCollection form)
        {
            String searchword = form["Search Here"].ToString();
            if (mystack.Contains(searchword) == true)
            {
                ViewBag.searchresult = "Found!";
            }
            else
            {
                ViewBag.searchresult = "Not Fount.";
            }
            return ViewBag.searchresult;
        }
    }
}