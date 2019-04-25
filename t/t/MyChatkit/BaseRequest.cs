using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace t
{
    public abstract class BaseRequest
    {

        protected BaseRequest()
        {
            Headers = new Dictionary<string, object>();
            QueryParameters = new Dictionary<string, object>();
            FormData = new Dictionary<string, object>();
        }

        public Dictionary<string, object> FormData
        {
            get;
            set;
        }

        [JsonIgnore]
        public Dictionary<string, object> Headers
        {
            get;
            set;
        }

        [JsonIgnore]
        public Dictionary<string, object> QueryParameters
        {
            get;
            private set;
        }

        public override string ToString()
        {
            var json = JsonConvert.SerializeObject(this);
            return json;
        }

    }
}
