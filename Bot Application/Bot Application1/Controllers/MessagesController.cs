using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;

namespace Bot_Application1
{
    
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        string[] imageBank = { "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker01.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker02.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker03.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker04.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker05.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker06.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker07.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker08.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker09.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker10.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker11.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker12.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker13.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker14.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker15.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker16.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker17.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker18.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker19.png",
                               "https://raw.githubusercontent.com/arnoldmyint/MicrosoftH2017/master/Sticker20.png"

        };

        //<summary>
        //POST: api/Messages
        //Receive a message from a user and reply to it
        //</summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            if (activity.Type == ActivityTypes.Message)
            {
                // calculate something for us to return
                int length = (activity.Text ?? string.Empty).Length;
                // return our reply to the user
                Activity reply = activity.CreateReply($"My answer for \"{activity.Text}\"");
                Random rnd = new Random();
                int rand = rnd.Next(0, 21);  // 1 <= month < 13
                reply.Attachments.Add(new Attachment()
                
                {

                    ContentUrl = imageBank[rand],
                    ContentType = "image/png",
                    Name = "Magic 8 Ball Results"
                });

                await connector.Conversations.ReplyToActivityAsync(reply);


            }
            else
            {
                Activity reply = activity.CreateReply($"You sent a non text");
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}