using System;

using Microsoft.Extensions.Localization;

using International.Common.Localization;

namespace International.Common.Messaging {

    public class Messages : ILocalizer {

        public readonly IStringLocalizer<Messages> Localizer;

        public Messages(IStringLocalizer<Messages> localizer) {
            this.Localizer = localizer;
        }

        public string this[string index] {
            get {
                return this.Localizer[index];
            }
        }

        public string this[string index, params object[] arguments] {
            get {
                return this.Localizer[index, arguments];
            }
        }
    }
}
