using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;

namespace msgpk
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new temp2.luisdialog());
            }
            else if (activity.Type == ActivityTypes.ConversationUpdate)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                Activity reply = activity.CreateReply("**Hello, I am TuBo**. I am your Mathemetics tutor.I am pretty good in the fields of  :   \n**1**.How to solve basic problems in whole numbers. in  \n \ta.Addition  \n  \tb.Subtraction  \n  \tc.Multiplication  \n  \td.Division  \n**2**.How to solve linear equations \n(write it in ax+b=c form where a,c are positive integers)  \n**3**.To find area of square and rectangle  \n(give dimensions like side1,side2 even in square)   \n**4**.To find perimeter of square and rectangle  \n(give dimensions like side1,side2 even in square)  ");
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
            }

            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                
            }
            else if (message.Type == ActivityTypes.Typing)
            {
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}