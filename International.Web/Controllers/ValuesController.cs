using Microsoft.AspNetCore.Mvc;

using International.Common.Localization;

namespace International.Web.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {

        private readonly ILocalizer Localizer;

        public ValuesController(
            ILocalizer localizer
        ) {
            // Save for later use
            this.Localizer = localizer;
        }

        [HttpGet]
        public string Get() {
            return this.Localizer["Value"];
        }
    }
}
