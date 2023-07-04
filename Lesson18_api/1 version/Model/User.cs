using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lesson18_api
{
    internal class User
    {
        [JsonProperty ("first_name")]
        public string first_name { get; set; }
        [JsonProperty("last_name")]
        public string last_name { get; set; }
        [JsonProperty("id", DefaultValueHandling= DefaultValueHandling.Ignore)]
        public int id { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   first_name == user.first_name &&
                   last_name == user.last_name &&
                   email == user.email &&
                   avatar == user.avatar;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(first_name, last_name, email, avatar);
        }

        public override string? ToString()
        {
            return $"{first_name}, {last_name}, {email}, {avatar}";
        }
    }
}

