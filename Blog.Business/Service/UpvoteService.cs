using Sixpence.Web.Auth;
using Sixpence.ORM.Entity;
using Sixpence.ORM.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Business.Entity;
using Sixpence.Web.Service;

namespace Blog.Business.Service
{
    public class UpvoteService : EntityService<Upvote>
    {
        #region 构造函数
        public UpvoteService() : base() { }

        public UpvoteService(IEntityManager manager) : base(manager) { }
        #endregion

        public bool IsUp(string objectid)
        {
            var sql = @"
SELECT * FROM upvote
WHERE objectid = @objectid AND created_by = @ownerid";
            var data = Manager.QueryFirst<Upvote>(sql, new Dictionary<string, object>() { { "@objectid", objectid }, { "@ownerid", UserIdentityUtil.GetCurrentUserId() } });
            return data != null;
        }
    }
}
