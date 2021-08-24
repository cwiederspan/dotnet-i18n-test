using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

using International.Common.Messaging;

namespace International.Web.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {

        private readonly IStringLocalizer<Messages> MessageLocalizer;

        public ValuesController(
            IStringLocalizer<Messages> messageLocalizer
        ) {
            // Save for later use
            this.MessageLocalizer = messageLocalizer;
        }

        [HttpGet]
        public string Get() {
            return this.MessageLocalizer["Value"];
        }
    }
}
