using DynamicPDF.Api.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a pdf endpoint.
    /// </summary>
    public class Pdf : Endpoint
    {
        PdfInstructions instructions;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pdf"/> class.
        /// </summary>
        public Pdf() : base()
        {
            this.instructions = new PdfInstructions();
        }

        internal override string EndpointName { get; } = "pdf";

        /// <summary>
        /// Adds additional resource to the endpoint.
        /// </summary>
        /// <param name="resourcePath">The resource file path.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public void AddAdditionalResource(string resourcePath,  string resourceName = null)
        {
            if( resourceName == null)
                resourceName = Path.GetFileName(resourcePath);
            AdditionalResource resource = new AdditionalResource( resourcePath, resourceName);
            Resources.Add(resource);
        }

        /// <summary>
        /// Adds additional resource to the endpoint.
        /// </summary>
        /// <param name="resourceData">The resource data.</param>
        /// <param name="additionalResourceType">The type of the additional resource.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public void AddAdditionalResource(byte[] resourceData, AdditionalResourceType additionalResourceType, string resourceName)
        {
            ResourceType type = ResourceType.Pdf;
            switch(additionalResourceType)
            {
                case AdditionalResourceType.Font:
                    type = ResourceType.Font;
                    break;
                case AdditionalResourceType.Image:
                    type = ResourceType.Image;
                    break;
                case AdditionalResourceType.Pdf:
                    type = ResourceType.Pdf;
                    break;
            }
            AdditionalResource resource = new AdditionalResource(resourceData, resourceName, type);
            Resources.Add(resource);
        }

        /// <summary>
        /// Gets or sets the collection of resource.
        /// </summary>
        public HashSet<Resource> Resources { get; } = new HashSet<Resource>();

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public string Author
        {
            get
            {
                return this.instructions.Author;
            }
            set
            {
                this.instructions.Author = value;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get
            {
                return this.instructions.Title;
            }
            set
            {
                this.instructions.Title = value;
            }
        }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string Subject
        {
            get
            {
                return this.instructions.Subject;
            }
            set
            {
                this.instructions.Subject = value;
            }
        }

        /// <summary>
        /// Gets or sets the creator.
        /// </summary>
        public string Creator
        {
            get
            {
                return this.instructions.Creator;
            }
            set
            {
                this.instructions.Creator = value;
            }
        }

        /// <summary>
        /// Gets or sets the keywords.
        /// </summary>
        public string Keywords
        {
            get
            {
                return this.instructions.Keywords;
            }
            set
            {
                this.instructions.Keywords = value;
            }
        }

        /// <summary>
        /// Gets or sets the security.
        /// </summary>
        public Security Security
        {
            get
            {
                return this.instructions.Security;
            }
            set
            {
                this.instructions.Security = value;
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether to flatten all form fields.
        /// </summary>
        public bool? FlattenAllFormFields
        {
            get
            {
                return this.instructions.FlattenAllFormFields;
            }
            set
            {
                this.instructions.FlattenAllFormFields = value;
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether to retain signature form field.
        /// </summary>
        public bool? RetainSignatureFormFields
        {
            get
            {
                return this.instructions.RetainSignatureFormFields;
            }
            set
            {
                this.instructions.RetainSignatureFormFields = value;
            }
        }

        /// <summary>
        /// Returns a <see cref="PdfInput"/> object containing the input pdf.
        /// </summary>
        /// <param name="resource">The resource of type <see cref="PdfResource"/>.</param>
        /// <param name="options">The merge options for the pdf.</param>
        public PdfInput AddPdf(PdfResource resource, MergeOptions options = null)
        {
            PdfInput input = new PdfInput(resource, options);
            this.Inputs.Add(input);
            return input;
        }

        /// <summary>
        /// Returns a <see cref="PdfInput"/> object containing the input pdf.
        /// </summary>
        /// <param name="cloudResourcePath">The resource path in cloud resource manager.</param>
        /// <param name="options">The merge options for the pdf.</param>
        public PdfInput AddPdf(string cloudResourcePath, MergeOptions options = null)
        {
            PdfInput input = new PdfInput(cloudResourcePath, options);
            this.Inputs.Add(input);
            return input;
        }

        /// <summary>
        /// Returns an <see cref="ImageInput"/> object containing the input pdf.
        /// </summary>
        /// <param name="resource">The resource of type <see cref="ImageResource"/>.</param>
        public ImageInput AddImage(ImageResource resource)
        {
            ImageInput input = new ImageInput(resource);
            this.Inputs.Add(input);
            return input;
        }

        /// <summary>
        /// Returns an <see cref="ImageInput"/> object containing the input pdf.
        /// </summary>
        /// <param name="cloudResourcePath">The resource path in cloud resource manager.</param>
        public ImageInput AddImage(string cloudResourcePath)
        {
            ImageInput input = new ImageInput(cloudResourcePath);
            this.Inputs.Add(input);
            return input;
        }

        /// <summary>
        /// Returns a <see cref="DlexInput"/> object containing the input pdf.
        /// </summary>
        /// <param name="dlexResource">The dlex resource of type <see cref="DlexResource"/>.</param>
        /// <param name="layoutData">The layout data resource of type <see cref="LayoutDataResource"/>.</param>
        public DlexInput AddDlex(DlexResource dlexResource, LayoutDataResource layoutData)
        {
            DlexInput input = new DlexInput(dlexResource, layoutData);
            this.Inputs.Add(input);
            return input;
        }

        /// <summary>
        /// Returns a <see cref="DlexInput"/> object containing the input pdf.
        /// </summary>
        /// <param name="cloudResourcePath">The resource path in cloud resource manager.</param>
        /// <param name="layoutData">The layout data resource of type <see cref="LayoutDataResource"/>.</param>
        public DlexInput AddDlex(string cloudResourcePath, LayoutDataResource layoutData)
        {
            DlexInput input = new DlexInput(cloudResourcePath, layoutData);
            this.Inputs.Add(input);
            return input;
        }

        /// <summary>
        /// Returns a <see cref="DlexInput"/> object containing the input pdf.
        /// </summary>
        /// <param name="cloudResourcePath">The resource path in cloud resource manager.</param>
        /// <param name="layoutData">The json data string used to create the PDF report.</param>
        public DlexInput AddDlex(string cloudResourcePath, string layoutData)
        {
            DlexInput input = new DlexInput(cloudResourcePath, layoutData);
            this.Inputs.Add(input);
            return input;
        }

        /// <summary>
        /// Returns a <see cref="DlexInput"/> object containing the input pdf.
        /// </summary>
        /// <param name="dlexResource">The resource path in cloud resource manager.</param>
        /// <param name="layoutData">The json data string used to create the PDF report.</param>
        public DlexInput AddDlex(DlexResource dlexResource, string layoutData)
        {
            DlexInput input = new DlexInput(dlexResource, layoutData);
            this.Inputs.Add(input);
            return input;
        }

        /// <summary>
        /// Returns a <see cref="PageInput"/> object containing the input pdf.
        /// </summary>
        /// <param name="pageWidth">The width of the page.</param>
        /// <param name="pageHeight">The height of the page.</param>
        public PageInput AddPage(float pageWidth, float pageHeight)
        {
            PageInput input = new PageInput(pageWidth, pageHeight);
            this.Inputs.Add(input);
            return input;
        }

        /// <summary>
        /// Returns a <see cref="PageInput"/> object containing the input pdf.
        /// </summary>
        public PageInput AddPage()
        {
            PageInput input = new PageInput();
            this.Inputs.Add(input);
            return input;
        }

        /// <summary>
        /// Gets the inputs.
        /// </summary>
        public List<Input> Inputs
        {
            get
            {
                return this.instructions.Inputs;
            }
        }

        /// <summary>
        /// Gets the templates.
        /// </summary>
        public HashSet<Template> Templates
        {
            get
            {
                return this.instructions.Templates;
            }
        }

        /// <summary>
        /// Gets the fonts.
        /// </summary>
        public HashSet<Font> Fonts
        {
            get
            {
                return this.instructions.Fonts;
            }
        }

        /// <summary>
        /// Gets the formFields.
        /// </summary>
        public List<FormField> FormFields
        {
            get
            {
                return this.instructions.FormFields;
            }
        }

        /// <summary>
        /// Gets the outlines.
        /// </summary>
        [JsonIgnore]
        public OutlineList Outlines
        {
            get
            {
                return this.instructions.Outlines;
            }
        }

        /// <summary>
        /// Gets the instructions json based on the inputs passed.
        /// </summary>
        /// <returns>The json string.</returns>
        public string GetInstructionsJson()
        {
            foreach (Input input in instructions.Inputs)
            {
                if (input.Type == InputType.Page)
                {
                    PageInput pageInput = (PageInput)input;
                    foreach (Element element in pageInput.Elements)
                    {
                        if (element.TextFont != null)
                        {
                            instructions.Fonts.Add(element.TextFont);
                        }
                    }
                }
                if (input.Template != null)
                {
                    instructions.Templates.Add(input.Template);
                    if (input.Template.Elements != null && input.Template.Elements.Count > 0)
                    {
                        foreach (Element element in input.Template.Elements)
                        {
                            if (element.TextFont != null)
                            {
                                instructions.Fonts.Add(element.TextFont);
                            }

                        }
                    }
                }
            }

            String jsonText = JsonConvert.SerializeObject(this.instructions, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });
            return jsonText;
        }

        /// <summary>
        /// Process to create pdf.
        /// </summary>
        public PdfResponse Process()
        {
            var task = ProcessAsync();
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Process to create pdf.
        /// </summary>
        /// Returns collection of <see cref="PdfResponse"/> as multithreading tasks <see cref="Task"/>.

        public Task<PdfResponse> ProcessAsync()
        {
            var request = base.CreateRestRequest();
            request.AddHeader("Content-Type", "multipart/form-data");

            request.AlwaysMultipartFormData = true;
            RestClient restClient = base.Client;
            return Task<PdfResponse>.Run(() =>
            {

                HashSet<Resource> finalResources = new HashSet<Resource>();
                foreach (Input input in instructions.Inputs)
                {
                    if (input.Type == InputType.Page)
                    {
                        PageInput pageInput = (PageInput)input;
                        foreach (Element element in pageInput.Elements)
                        {
                            if (element.Resource != null)
                            {
                                finalResources.Add(element.Resource);
                            }
                            if (element.TextFont != null)
                            {
                                instructions.Fonts.Add(element.TextFont);
                            }
                        }
                    }
                    foreach (Resource resource in input.Resources)
                    {
                        finalResources.Add(resource);
                    }
                    if (input.Template != null)
                    {
                        instructions.Templates.Add(input.Template);
                        if (input.Template.Elements != null && input.Template.Elements.Count > 0)
                        {
                            foreach (Element element in input.Template.Elements)
                            {
                                if (element.Resource != null)
                                {
                                    finalResources.Add(element.Resource);
                                }
                                if (element.TextFont != null)
                                {
                                    instructions.Fonts.Add(element.TextFont);
                                }

                            }
                        }
                    }
                }

                foreach (Resource resource in Resources)
                {
                    finalResources.Add(resource);
                }

                String jsonText = JsonConvert.SerializeObject(this.instructions, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                });
                request.AddFile("Instructions", Encoding.UTF8.GetBytes(jsonText), "Instructions.json", "application/json");
                if (instructions.Inputs == null)
                    throw new EndpointException("Minimum one input required.");
                foreach (Resource resource in finalResources)
                {
                    if (resource.Type == ResourceType.LayoutData)
                    {
                        LayoutDataResource res = (LayoutDataResource)resource;
                        request.AddFile("Resource", resource.Data, res.LayoutDataResourceName, resource.MimeType);
                    }
                    else
                        request.AddFile("Resource", resource.Data, resource.ResourceName, resource.MimeType);
                }
                PdfResponse response = null;
                //IRestResponse restResponse = restClient.ExecuteAsyncPost()
                IRestResponse restResponse = restClient.Post(request);
                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response = new PdfResponse(restResponse.RawBytes);
                    response.IsSuccessful = true;
                    response.StatusCode = restResponse.StatusCode;
                }
                else
                {
                    response = new PdfResponse();
                    string output = restResponse.Content;
                    response.ErrorJson = restResponse.Content;
                    response.ErrorId = response.ErrorId;
                    response.ErrorMessage = restResponse.ErrorMessage;
                    response.IsSuccessful = false;
                    response.StatusCode = restResponse.StatusCode;
                }
                return response;
            });
        }
    }
}
