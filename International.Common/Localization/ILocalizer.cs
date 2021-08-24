using System;
//using System.Reflection;

namespace International.Common.Localization {

    //[DefaultMember("Item")]
    public interface ILocalizer {

        string this[string key] { get; }

        string this[string key, params object[] arguments] { get; }
    }
}
