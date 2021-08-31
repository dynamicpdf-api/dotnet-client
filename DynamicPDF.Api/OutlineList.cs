using System.Collections.Generic;
using Newtonsoft.Json;

namespace DynamicPDF.Api
{
    public class OutlineList
    {
        private List<Outline> outlines = null;

        internal OutlineList()
        {
            outlines = new List<Outline>();
        }

        /// <summary>
        /// Adds an <see cref="Outline"/> object to the outline list.
        /// </summary>
        /// <param name="text">Text of the outline.</param>
        /// <returns>The <see cref="Outline"/> object that is created.</returns>
        public Outline Add(string text)
        {
            Outline outline = new Outline(text);
            outlines.Add(outline);
            return outline;
        }

        /// <summary>
        /// Adds an <see cref="Outline"/> object to the outline list.
        /// </summary>
        /// <param name="text">Text of the outline.</param>
        /// <param name="url">URL the action launches.</param>
        /// <returns>The <see cref="Outline"/> object that is created.</returns>
        public Outline Add(string text, string url)
        {
            Outline outline = new Outline(text, new UrlAction(url));
            outlines.Add(outline);
            return outline;
        }

        /// <summary>
        /// Adds an <see cref="Outline"/> object to the outline list.
        /// </summary>
        /// <param name="text">Text of the outline.</param>
        /// <param name="input">Any of the <see cref="ImageInput"/>, <see cref="DlexInput"/>, 
        /// <see cref="PdfInput"/> or <see cref="PageInput"/> objects to create PDF.</param>
        /// <param name="pageOffset">Page number to navigate.</param>
        /// <param name="pageZoom"><see cref="PageZoom"/> to display the destination.</param>
        /// <returns>The <see cref="Outline"/> object that is created.</returns>
        public Outline Add(string text, Input input, int pageOffset = 0, PageZoom pageZoom = PageZoom.FitPage)
        {
            GoToAction linkTo = new GoToAction(input);
            linkTo.PageOffset = pageOffset;
            linkTo.PageZoom = pageZoom;
            Outline outline = new Outline(text, linkTo);
            outlines.Add(outline);
            return outline;
        }


        public void AddPdfOutlines(PdfInput pdfInput)
        {
            outlines.Add(new Outline(pdfInput));
        }

        [JsonProperty]
        internal List<Outline> Outlines
        {
            get
            {
                return this.outlines;
            }
        }

    }
}
