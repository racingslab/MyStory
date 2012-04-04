﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MyStory.Models;
using MyStory.Models.Infrastructure;
using MarkdownDeep;
using AutoMapper;
using MyStory.ViewModels;

namespace MyStory.Controllers
{
    public class HomeController : MyStoryController
    {
        public HomeController() { }

        // for test purpose
        public HomeController(MyStoryContext context)
        {
            base.dbContext = context;
        }

        public ActionResult Index(int page=1)
        {
            ViewBag.NumberOfAccounts = dbContext.Accounts.Count();

            int perPage = page == 1 ? 20 : 10;
            var query = dbContext.Posts.OrderByDescending(p => p.DateCreated);
            var posts = query.Skip((page - 1) * perPage).Take(perPage).ToList();
            var postListViewModel = Mapper.Map<List<Post>, List<PostListViewModel>>(posts);

            return View("Index", postListViewModel);
        }

       

    }
}
