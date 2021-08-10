using Newtonsoft.Json;
using System.Collections.Generic;

namespace DynamicPDF.Api
{
    internal class PdfInstructions
    {
        private List<FormField> formFields = null;
        private List<Template> templates = null;
        private List<Font> fonts = null;
        private List<Outline> outlines = null;

        [JsonProperty]
        internal List<Template> Templates
        {
            get
            {
                if (templates == null)
                    templates = new List<Template>();
                return templates;
            }
        }

        [JsonProperty]
        internal List<Font> Fonts
        {
            get
            {
                if (fonts == null)
                    fonts = new List<Font>();
                return fonts;
            }
        }

        [JsonProperty]
        internal string Author { get; set; } = "CeteSoftware";

        [JsonProperty]
        internal string Title { get; set; }

        [JsonProperty]
        internal string Subject { get; set; }

        [JsonProperty]
        internal string Creator { get; set; } = "DynmaicPDF Cloud Api";

        [JsonProperty]
        internal string Keywords { get; set; }

        [JsonProperty]
        internal Security Security { get; set; } = null;

        [JsonProperty]
        internal bool? FlattenAllFormFields { get; set; }

        [JsonProperty]
        internal bool? RetainSignatureFormFields { get; set; }

        [JsonProperty]
        internal List<Input> Inputs { get; set; } = new List<Input>();

        [JsonProperty]
        internal List<FormField> FormFields
        {
            get
            {
                if (formFields == null)
                    formFields = new List<FormField>();
                return formFields;
            }
        }

        [JsonProperty]
        internal List<Outline> Outlines
        {
            get
            {
                if (outlines == null)
                    outlines = new List<Outline>();
                return outlines;
            }
        }
    }
}
