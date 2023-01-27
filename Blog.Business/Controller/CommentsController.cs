using System.Collections.Generic;
using System.Linq;
using Sixpence.Web.WebApi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sixpence.ORM.Models;
using Blog.Business.Service;
using Blog.Business.Entity;
using Sixpence.Web.Cache;
using Blog.Business.SysConfig;

namespace Blog.Business.Controller
{
    public class CommentsController : BaseApiController
    {
        [HttpPost]
        public string CreateData(Comments entity)
        {
            return new CommentsService().CreateData(entity);
        }

        [HttpGet("search")]
        public virtual DataModel<Comments> GetViewData(string pageSize = "", string pageIndex = "", string searchList = "", string orderBy = "", string viewId = "", string searchValue = "")
        {
            var _searchList = string.IsNullOrEmpty(searchList) ? null : JsonConvert.DeserializeObject<IList<SearchCondition>>(searchList);

            if (string.IsNullOrEmpty(pageSize) || string.IsNullOrEmpty(pageIndex))
            {
                var list = new CommentsService().GetDataList(_searchList, orderBy, viewId, searchValue).ToList();
                return new DataModel<Comments>()
                {
                    DataList = list,
                    RecordCount = list.Count
                };
            }

            int.TryParse(pageSize, out var size);
            int.TryParse(pageIndex, out var index);
            return new CommentsService().GetDataList(_searchList, orderBy, size, index, viewId, searchValue);
        }

        [HttpGet("comment_strategy")]
        public object GetCommentStrategy()
        {
            return SysConfigCache.GetValue<CommentStrategyConfig>();
        }
    }
}
