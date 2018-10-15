using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Structures_HW_10_15_18.Controllers
{
    public class QueueController : Controller
    {
        public static Queue<string> myqueue = new Queue<string>();

        // GET: Queue
        public ActionResult QueueIndex()
        {
            return View();
        }

        public ActionResult addone()
        {
            myqueue.Enqueue("item number #" + (myqueue.Count + 1));


            return View("QueueIndex");
        }

        public ActionResult displayqueue()
        {
            if (myqueue.Count == 0)
            {
                ViewBag.Empty = "Queue is empty. Please add Items to the Queue.";
            }
            else
            {
                ViewBag.Queue = myqueue;
            }

            return View("QueueIndex");
        }

        public ActionResult deletequeue()
        {
            if (myqueue.Count == 0)
            {
                ViewBag.Queue = "Queue is empty. Please add items to Queue before deleting.";
            }
            else
            {
                myqueue.Dequeue();
            }

            return View("QueueIndex");
        }

        public ActionResult hugelist()
        {
            myqueue.Clear();

            for (int i = 0; i < 2000; i++)
            {
                myqueue.Enqueue("New Entry " + (myqueue.Count + 1));
            }

            return View("QueueIndex");
        }

        public ActionResult clearqueue()
        {
            myqueue.Clear();

            return View("QueueIndex");
        }

        public ActionResult searchqueue()
        {
            if (myqueue.Count == 0)
            {
                ViewBag.Search = "Queue is empty. Add items to Queue before searching.";
            }
            else
            {
                ViewBag.Search = "im not null";
            }
            return View("QueueIndex");
        }

        //gets the input data from the user
        [HttpPost]
        public String SearchQueue(FormCollection form)
        {
            String searchword = form["Search Here"].ToString();
            if (myqueue.Contains(searchword) == true)
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