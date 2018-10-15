using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Structures_HW_10_15_18.Controllers
{
    public class DictionaryController : Controller
    {
        public static Dictionary<int, string> mydictionary = new Dictionary<int, string>();

        // GET: Dictionary
        public ActionResult DictionaryIndex()
        {
            return View();
        }

        public ActionResult addone()
        {
            mydictionary.Add((mydictionary.Count + 1),"item number #" + (mydictionary.Count + 1));


            return View("DictionaryIndex");
        }

        public ActionResult displaydictionary()
        {
            if (mydictionary.Count == 0)
            {
                ViewBag.dictionary = "The dictionary is empty. Nothing to display.";
            }
            else
            {
                ViewBag.dictionary = mydictionary;
            }

            return View("DictionaryIndex");
        }

        public ActionResult deletedictionary()
        {
            if (mydictionary.Count == 0)
            {
                ViewBag.delete = "The dictionary is empty and you cannot delete anything.";
            }
            else
            {
                int i = mydictionary.Count();
                mydictionary.Remove(i);
            }

            return View("DictionaryIndex");
        }

        public ActionResult hugelist()
        {
            mydictionary.Clear();

            for (int i = 0; i < 2000; i++)
            {
                mydictionary.Add((mydictionary.Count + 1), "item number #" + (mydictionary.Count + 1));
            }

            return View("DictionaryIndex");
        }

        public ActionResult cleardictionary()
        {
            mydictionary.Clear();

            return View("DictionaryIndex");
        }

        public ActionResult searchdictionary()
        {
            if (mydictionary.Count == 0)
            {
                ViewBag.Search = "The Dictionary is empty. You must add items before searching the Dictionary.";
            }
            else
            {
                ViewBag.Search = "im not null";
            }
            return View("DictionaryIndex");
        }

        //gets the input data from the user
        [HttpPost]
        public String SearchDictionary(FormCollection form)
        {
            String searchword = form["Search Here"].ToString();
            if (mydictionary.ContainsValue(searchword))
            {
                ViewBag.searchresult = "Found!";
            }
            else
            {
                ViewBag.searchresult = "Not Found.";
            }
            return ViewBag.searchresult;
        }
    }
}