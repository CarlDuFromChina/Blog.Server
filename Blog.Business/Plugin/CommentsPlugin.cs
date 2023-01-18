using Sixpence.ORM.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sixpence.ORM.EntityManager;
using Blog.Business.Entity;
using Sixpence.Web.Entity;

namespace Blog.Business.Plugin
{
    public class CommentsPlugin : IEntityManagerPlugin
    {
        public void Execute(EntityManagerPluginContext context)
        {
            var manager = context.EntityManager;
            switch (context.Action)
            {
                case EntityAction.PostCreate:
                    {
                        var data = context.Entity as Comments;
                        var messageRemind = new MessageRemind()
                        {
                            id = Guid.NewGuid().ToString(),
                            name = $"{data.name}消息提醒",
                            is_read = false,
                            content = JsonConvert.SerializeObject(data),
                            message_type = data.comment_type
                        };
                        if (data.comment_type == "comment")
                        {
                            messageRemind.receiverId = data.object_ownerid;
                            messageRemind.receiverId_name = data.object_ownerid_name;
                        }
                        else if (data.comment_type == "reply")
                        {
                            messageRemind.receiverId = data.replyid;
                            messageRemind.receiverId_name = data.replyid_name;
                        }
                        manager.Create(messageRemind);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
