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

        internal HashSet<Template> Templates
        {
            get
            {
                if (templates == null)
                    templates = new HashSet<Template>();
                return templates;
            }
        }

        [JsonProperty("templates")]
        internal HashSet<Template> GetTemplates
        {
            get
            {
                return templates;
            }
        }

        internal HashSet<Font> Fonts
        {
            get
            {
                if (fonts == null)
                    fonts = new HashSet<Font>();
                return fonts;
            }
        }

        [JsonProperty("fonts")]
        internal HashSet<Font> GetFonts
        {
            get
            {
                return fonts;
            }
        }

        [JsonProperty]
        internal string Author { get; set; }

        [JsonProperty]
        internal string Title { get; set; }

        [JsonProperty]
        internal string Subject { get; set; }

        [JsonProperty]
        internal string Creator { get; set; }

        [JsonProperty]
        internal string Producer { get; set; }

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

        internal List<FormField> FormFields
        {
            get
            {
                if (formFields == null)
                    formFields = new List<FormField>();
                return formFields;
            }
        }

        [JsonProperty("formFields")]
        internal List<FormField> GetFormFields
        {
            get
            {
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
