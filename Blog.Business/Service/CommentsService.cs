using Sixpence.Web;
using Sixpence.ORM.Entity;
using Sixpence.Common;
using System.Collections.Generic;
using System.Linq;
using Sixpence.ORM.Models;
using Sixpence.ORM.EntityManager;
using Blog.Business.Entity;
using Sixpence.Web.Service;

namespace Blog.Business.Service
{
    public class CommentsService : EntityService<Comments>
    {
        #region 构造函数
        public CommentsService() : base() { }
        public CommentsService(IEntityManager manager) : base(manager) { }
        #endregion

        public override IEnumerable<Comments> GetDataList(IList<SearchCondition> searchList, string orderBy, string viewId = "", string searchValue = "")
        {
            var comments = base.GetDataList(searchList, orderBy, viewId, searchValue).ToList();
            var dataList = comments.Where(item => string.IsNullOrEmpty(item.parentid));
            dataList.Each(item => item.comments = comments.Where(e => e.parentid == item.id));
            return dataList.ToList();
        }
    }
}
