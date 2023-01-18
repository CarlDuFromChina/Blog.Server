using Sixpence.Web.WebApi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Business.Entity;
using Blog.Business.Service;

namespace Blog.Business.Controller
{
    public class UpvoteController : EntityBaseController<Upvote, UpvoteService>
    {
        [HttpGet("is_up")]
        public bool IsUp(string objectid)
        {
            return new UpvoteService().IsUp(objectid);
        }
    }
}
