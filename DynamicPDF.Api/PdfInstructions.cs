using Newtonsoft.Json;
using System.Collections.Generic;

namespace DynamicPDF.Api
{
    internal class PdfInstructions
    {
        private List<FormField> formFields = null;
        private HashSet<Template> templates = null;
        private HashSet<Font> fonts = null;
        private OutlineList outlines = null;

        [JsonProperty]
        internal HashSet<Template> Templates
        {
            get
            {
                if (templates == null)
                    templates = new HashSet<Template>();
                return templates;
            }
        }

        [JsonProperty]
        internal HashSet<Font> Fonts
        {
            get
            {
                if (fonts == null)
                    fonts = new HashSet<Font>();
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
        internal string Creator { get; set; } = "DynamicPDF Cloud Api";

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

       
        internal OutlineList Outlines
        {
            get
            {
                if (outlines == null)
                    outlines = new OutlineList();
                return outlines;
            }
        }

        [JsonProperty("outlines")]
        internal List<Outline> GetOutlines
        {
            get
            {
                if(outlines != null)
                    return outlines.Outlines;
                return null;
            }
        }
    }
}
