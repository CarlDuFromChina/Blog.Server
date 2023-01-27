using System;
using Sixpence.Web.SysConfig;

namespace Blog.Business.SysConfig
{
    public class CommentStrategyConfig : ISysConfig
    {
        public string Name => "切换评论组件";

        public string Code => "comment_strategy";

        public object DefaultValue => "default";

        public string Description => "值范围：default、disqus、none，默认为 default";
    }
}
