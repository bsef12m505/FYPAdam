﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DTO;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http.Headers;

namespace FYPAdam.Controllers
{
    public class ADAMHomeController : Controller
    {

        public async Task<ActionResult> Index(string catName, string bName)
        {
            if (catName == null && bName == null)
            {
                catName = "Laptop";
                bName = "acer";
            }

            List<Category> categoryList = new List<Category>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Utilities.EngineUrl + "Home/ViewAllCategories");
                request.Timeout = 12000000;
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var serializer = new JavaScriptSerializer();

                StreamReader stream = new StreamReader(response.GetResponseStream());
                string finalResponse = stream.ReadToEnd();
                categoryList = serializer.Deserialize<List<Category>>(finalResponse);


                ViewBag.NameOfCategories = categoryList;


            }
            catch (WebException wex)
            {
                var pageContent = new StreamReader(wex.Response.GetResponseStream())
                        .ReadToEnd();
            }
            List<Product> productList = new List<Product>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Utilities.EngineUrl + "Home/AllTopProductsAgainstBrandAndCategory?catName=" + catName + "&bName=" + bName);
                request.Timeout = 12000000;
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var serializer = new JavaScriptSerializer();

                StreamReader stream = new StreamReader(response.GetResponseStream());
                string finalResponse = stream.ReadToEnd();
                productList = serializer.Deserialize<List<Product>>(finalResponse);

                ViewBag.ProductList = productList;


            }
            catch (WebException wex)
            {
                var pageContent = new StreamReader(wex.Response.GetResponseStream())
                        .ReadToEnd();
            }

            List<Brand> bList = new List<Brand>();
            List<string> bNamesList = new List<string>();
            List<int> bFollowersCountList = new List<int>();
            string[] bname;
            int[] followrs;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Utilities.EngineUrl + "Home/GetAllMobileBrands");
                request.Timeout = 12000000;
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var serializer = new JavaScriptSerializer();

                StreamReader stream = new StreamReader(response.GetResponseStream());
                string finalResponse = stream.ReadToEnd();
                List<Brand> brands = serializer.Deserialize<List<Brand>>(finalResponse);


                foreach (Brand b in brands)
                {
                    bNamesList.Add(b.Name);
                    bFollowersCountList.Add(b.FollowersCount.Value);
                }

                bname = bNamesList.ToArray();
                followrs = bFollowersCountList.ToArray();


                ViewBag.brandNameArray = bname.ToArray();
                ViewBag.followersCountArray = followrs.ToArray();
            }
            catch (Exception)
            {

            }

            List<Brand> bListLaptops = new List<Brand>();
            List<string> bNamesListLaptops = new List<string>();
            List<int> bFollowersCountListLaptops = new List<int>();
            string[] bnameLaptops;
            int[] followrsLaptops;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Utilities.EngineUrl + "Home/GetAllLaptopBrands");
                request.Timeout = 12000000;
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var serializer = new JavaScriptSerializer();

                StreamReader stream = new StreamReader(response.GetResponseStream());
                string finalResponse = stream.ReadToEnd();
                List<Brand> brands = serializer.Deserialize<List<Brand>>(finalResponse);


                foreach (Brand b in brands)
                {
                    bNamesListLaptops.Add(b.Name);
                    bFollowersCountListLaptops.Add(b.FollowersCount.Value);
                }

                bnameLaptops = bNamesListLaptops.ToArray();
                followrsLaptops = bFollowersCountListLaptops.ToArray();


                ViewBag.LaptopbrandNameArray = bnameLaptops;
                ViewBag.LaptopfollowersCountArray = followrsLaptops;
            }
            catch (Exception)
            {

            }
            return View();


        }

        public ActionResult Products(int bId)
        {
            List<Brand> brandList = new List<Brand>();

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Utilities.EngineUrl + "Home/GetAllProductsAgainstBrand?bId=" + bId);
                request.Timeout = 12000000;
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var serializer = new JavaScriptSerializer();

                StreamReader stream = new StreamReader(response.GetResponseStream());
                string finalResponse = stream.ReadToEnd();
                brandList = serializer.Deserialize<List<Brand>>(finalResponse);


            }
            catch (WebException wex)
            {
                var pageContent = new StreamReader(wex.Response.GetResponseStream())
                        .ReadToEnd();
            }
            return View(brandList[0]);
        }

        public ActionResult Trends()
        {
            return View();
        }
        public ActionResult temp()
        {
            return View();
        }

        public ActionResult ProductDetails(int pId)
        {
            List<Product> productList = new List<Product>();
            List<FeatureSentiment> featureSentimentList = new List<FeatureSentiment>();
            List<string> pFeatures = new List<string>();
            List<int> pFeatureCount = new List<int>();
            List<string> nFeatures = new List<string>();
            List<int> nFeatureCount = new List<int>();
            List<string> colorList = new List<string>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Utilities.EngineUrl + "Home/ProductSpecifications?pId=" + pId);
                request.Timeout = 12000000;
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var serializer = new JavaScriptSerializer();
                StreamReader stream = new StreamReader(response.GetResponseStream());
                string finalResponse = stream.ReadToEnd();
                productList = serializer.Deserialize<List<Product>>(finalResponse);

                //Requesting engine for geting the positove and negative features of the produt

                HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(Utilities.EngineUrl + "Home/ProductRefinedFeatures?pId=" + productList[0].Id);
                request1.Timeout = 12000000;
                request1.KeepAlive = false;
                request1.ProtocolVersion = HttpVersion.Version10;
                HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
                var serializer1 = new JavaScriptSerializer();
                StreamReader stream1 = new StreamReader(response1.GetResponseStream());
                string finalResponse1 = stream1.ReadToEnd();
                featureSentimentList = serializer1.Deserialize<List<FeatureSentiment>>(finalResponse1);
                foreach (var fList in featureSentimentList)
                {
                    if (fList.Sentiment == 1)
                    {
                        pFeatureCount.Add(fList.Count);
                        pFeatures.Add(fList.Feature);
                    }

                    else
                    {
                        nFeatureCount.Add(fList.Count);
                        nFeatures.Add(fList.Feature);
                    }
                }

                colorList.Add("color: #9d426b");
                colorList.Add("color: #3fb0e9");
                colorList.Add("color: #42c698");
                colorList.Add("color: red");
                colorList.Add("color: gold");
                colorList.Add("color: blue");
                colorList.Add("color: red");
                colorList.Add("color: yellow");
                colorList.Add("color: gold");
                ViewBag.color = colorList;
                ViewBag.pFeatureList = pFeatures;
                ViewBag.pCountList = pFeatureCount;
                ViewBag.nFeatureList = nFeatures;
                ViewBag.nCountList = nFeatureCount;
            }
            catch (WebException wex)
            {
                var pageContent = new StreamReader(wex.Response.GetResponseStream())
                        .ReadToEnd();
            }

            return View(productList[0]);
        }

        public string CheckAjax(string brandName)
        {
            return brandName;
        }


        public ActionResult Login()
        {


            return View();
        }
        public dynamic LoginAction(string email, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Utilities.EngineUrl + "User/Login?email=" + email + "&password=" + password);
            request.Timeout = 12000000;
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var serializer = new JavaScriptSerializer();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string finalResponse = stream.ReadToEnd();
            bool b = serializer.Deserialize<bool>(finalResponse);
            if (b)
            {
                return RedirectToAction("UserDashboard", "User");
            }

            else
            {
                return RedirectToAction("Login", "AdamHome");
            }

        }

        public dynamic SignUpAction(string firstName, string lastName, string email, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Utilities.EngineUrl + "User/SignUp?firstName=" + firstName + "&lastName=" + lastName + "&email=" + email + "&password=" + password);
            request.Timeout = 12000000;
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var serializer = new JavaScriptSerializer();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string finalResponse = stream.ReadToEnd();
            bool b = serializer.Deserialize<bool>(finalResponse);
            if (b)
            {
                return RedirectToAction("UserDashboard", "User");
            }
            return RedirectToAction("SignUp", "ADAMHome");
        }



        public ActionResult SignUp()
        {
            return View();
        }

        //public ActionResult Products(string brandName, int categoryId)
        //{
        //    List<Brand> productAgainstBrand=new List<Brand>();
        //    Brand brand = new Brand();
        //    try
        //    {

        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/Engine/Home/ViewAllProducts");
        //        request.Timeout = 12000000;
        //        request.KeepAlive = false;
        //        request.ProtocolVersion = HttpVersion.Version10;
        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        var serializer = new JavaScriptSerializer();

        //        StreamReader stream = new StreamReader(response.GetResponseStream());
        //        string finalResponse = stream.ReadToEnd();
        //        productAgainstBrand = serializer.Deserialize<List<Brand>>(finalResponse);
        //        foreach (var b in productAgainstBrand)
        //        {
        //            if (b.Name.ToLower().Equals(brandName.ToLower()) && b.CategoryId==categoryId)
        //            {
        //                brand = b;
        //            }
        //        }
        //    }
        //    catch (WebException wex)
        //    {
        //        var pageContent = new StreamReader(wex.Response.GetResponseStream())
        //                .ReadToEnd();
        //    }

        //    return View(brand);
        //}
        //public ActionResult ProductDetails(int productId)
        //{
        //    List<Product> productList = new List<Product>();
        //    Product prod = new Product();
        //    try
        //    {

        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/Engine/Home/ProductSpecifications");
        //        request.Timeout = 12000000;
        //        request.KeepAlive = false;
        //        request.ProtocolVersion = HttpVersion.Version10;
        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        var serializer = new JavaScriptSerializer();
        //        StreamReader stream = new StreamReader(response.GetResponseStream());
        //        string finalResponse = stream.ReadToEnd();
        //        productList = serializer.Deserialize<List<Product>>(finalResponse);
        //        foreach (var p in productList)
        //        {
        //            if (p.Id == productId)
        //            {
        //                prod = p;
        //            }


        //        }
        //    }
        //    catch (WebException wex)
        //    {
        //        var pageContent = new StreamReader(wex.Response.GetResponseStream())
        //                .ReadToEnd();
        //    }
        //    return View(prod);
        //}

    }
}
