using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Notification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        [HttpPost]
        public IActionResult PushNotification([FromBody] NotificationDTO N)
        {

            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    {"Test notification","sent" }
                },
                Token = N.Token,
                Notification = new FirebaseAdmin.Messaging.Notification()
                {
                    Title = N.Title,
                    Body = N.Body
                }
            };


            try
            {

                string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
