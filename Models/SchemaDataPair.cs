using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Models
{
    public class SchemaDataPair
    {
        [JsonProperty("jsonschemaid", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string JSONSchemaId { get; set; }

        [JsonProperty("jsondata", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [Required(AllowEmptyStrings = false)]
        public JObject JSONData { get; set; }
    }
}
