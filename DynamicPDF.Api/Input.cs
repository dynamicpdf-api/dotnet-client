using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using System;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the base class for inputs.
    /// </summary>
    public abstract class Input
    {
        private Template template;
        private string id = null;
        internal Input()
        {
        }

        internal Input(string cloudResourcePath)
        {
            ResourceName = cloudResourcePath;
        }
        internal Input(Resource resource)
        {
            Resources.Add(resource);
            ResourceName = resource.ResourceName;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal abstract InputType Type { get; }

        [JsonProperty]
        internal string TemplateId { get; set; }

        internal List<Resource> Resources { get; set; } = new List<Resource>();

        /// <summary>
        /// Gets or sets the resource name.
        /// </summary>
        public string ResourceName { get; set; }

       
        public string Id
        {
            get
            {
                if (id == null)
                {
                    id = Guid.NewGuid().ToString();
                }
                return id;
            }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        [JsonIgnore]
        public Template Template
        {
            set
            {
                this.template = value;
                TemplateId = template.Id;
            }
            get { return this.template; }
        }
    }
}
