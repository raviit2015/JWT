using Newtonsoft.Json;
using System;

namespace JWTAuthentication.Models
{
    public static class JsonHelper
    {
        public static bool TryParseJson(string obj, Type type, out object result)
        {
            bool success = true;
            var settings = new JsonSerializerSettings
            {
                Error = (sender, args) => { success = false; args.ErrorContext.Handled = true; },
                MissingMemberHandling = MissingMemberHandling.Error,
            };
            result = JsonConvert.DeserializeObject(obj, type, settings);
            return success;
        }

        #region Commented Code

        //public static bool TryParse(string stringValue, out JToken value)
        //{
        //    bool result = false;
        //    value = null;
        //    if (!string.IsNullOrEmpty(stringValue))
        //    {
        //        stringValue = stringValue.Trim();
        //    }

        //    if (!string.IsNullOrWhiteSpace(stringValue) && (IsObject(stringValue) || IsArray(stringValue)))
        //    {
        //        try
        //        {
        //            stringValue = stringValue.Trim();

        //            value = JToken.Parse(stringValue);
        //            result = true;
        //        }
        //        catch
        //        {
        //            result = false;
        //        }
        //    }
        //    else
        //    {
        //        result = false;
        //    }

        //    return result;
        //}

        //private static bool IsObject(string stringValue)
        //{
        //    return stringValue.StartsWith("{") && stringValue.EndsWith("}");
        //}

        //private static bool IsArray(string stringValue)
        //{
        //    return stringValue.StartsWith("[") && stringValue.EndsWith("]");
        //}

        #endregion

    }
}

