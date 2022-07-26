![](./logo-banner2.png)

___

# C# .NET Client Library (`dotnet-client`)

The C# .NET Client Examples project uses the DynamicPDF Cloud API Java client library to create, merge, split, form fill, stamp, obtain metadata, convert, and secure/encrypt PDF documents. This project contains the DynamicPDF Cloud API's .NET client library (`dotnet-client`) for the following REST API endpoints. The website for this project is available at [cloud.dynamicpdf.com](https://cloud.dynamicpdf.com/).

* `dlex-layout`
* `image-info`
* `pdf`
* `pdf-info`
* `pdf-text`
* `pdf-xmp`

## NuGet

* Obtain the NuGet package at https://www.nuget.org/packages/DynamicPDF.API

## Documentation

* Obtain overview documentation for the DynamicPDF Cloud API Client libraries from the [Cloud API Users Guide](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/client-libraries/cloud-api-client-libraries).
* Access the documentation for each particular endpoint from the following Users Guide pages. 

| Endpoint      | REST Endpoint                                                | REST Endpoint Client Library              | Description                                                  |
| ------------- | ------------------------------------------------------------ | ----------------------------------------- | ------------------------------------------------------------ |
| `dlex-layout` | [Cloud API Users Guide - `dlex-layout`](./cloud-api-dlex-layout) | [`dlex-layout`](./client-api-dlex-layout) | Returns a PDF after processing a DLEX file with it's associated JSON data. |
| `image-info`  | [Cloud API Users Guide - `image-info`](./cloud-api-image-info) | [`image-info`](./client-api-image-info)   | Returns image metadata as a JSON document.                   |
| `pdf`         | [Cloud API Users Guide - `pdf`](./cloud-api-pdf)             | [`pdf`](./client-api-pdf)                 | Returns a PDF after performing one of the pdf endpoint's tasks (`page`, `dlex`, `image`) or merging. |
| `pdf-info`    | [Cloud API Users Guide - `pdf-Info`](./cloud-api-pdf-info)   | [`pdf-info`](./client-api-pdf-info)       | Returns PDF metadata as a JSON document.                     |
| `pdf-text`    | [Cloud API Users Guide - `pdf-text`](./cloud-api-pdf-text)   | [`pdf-text`](./client-api-pdf-text)       | Returns the text from a PDF as a JSON document.              |
| `pdf-xmp`     | [Cloud API Users Guide - `pdf-xmp`](./cloud-api-pdf-xmp)     | [`pdf-xmp`](./client-api-pdf-xmp)         | Returns XMP metadata from a PDF.                             |

## REST Client

* The underlying C# REST client uses [RestSharp](https://restsharp.dev/).

## Tutorials

* The following lists the tutorials provided by DynamicPDF Cloud API that illustrate using the API's endpoints.
* Obtain the project, [dotnet-client-examples](https://github.com/dynamicpdf-api/dotnet-client-examples) to view complete worked examples for each of the following tutorials

| Tutorial                                                     | Endpoint/Tool | Sample Project                              | Description                                                  |
| ------------------------------------------------------------ | ------------- | ------------------------------------------- | ------------------------------------------------------------ |
| [Merging PDFs](./cloud-api/merging-pdfs)                     | `pdf`         | Merge PDFs (pdf endpoint)                   | Use the `pdf` endpoint to merge three pre-existing `pdf` documents. |
| [Completing an Acroform](./cloud-api/form-completion)        | `pdf`         | Fill an Acroform (pdf endpoint)             | Use the `pdf` endpoint to fill-out a pre-existing PDF form with values and save the resulting PDF. |
| [Creating a PDF from DLEX (`pdf` Endpoint)](./cloud-api/dlex-pdf-endpoint) | `pdf`         | Create a PDF (pdf endpoint)                 | Use the `pdf` endpoint to generate a PDF report using DLEX. Then merge two PDF documents and then append the merged PDFs to the PDF created using the DLEX report. |
| [Adding Bookmarks to a PDF](./cloud-api/bookmarks)           | `pdf`         | Add Bookmarks (pdf endpoint)                | Use the Outline element in JSON instructions with the `pdf` endpoint to create a PDF that includes bookmarks. |
| [Creating a PDF from DLEX (`dlex-layout` Endpoint)](./cloud-api/dlex-layout) | `dlex-layout` | Create a PDF (dlex-layout endpoint)         | Use the `dlex-layout` endpoint to create PDF reports dynamically on the cloud. |
| [Get Image Metadata](./cloud-api/image-info)                 | `image-info`  | Get Image Information (image-info endpoint) | Use the `image-info` endpoint to get metadata describing an image. |
| [Extract PDF Metadata](./cloud-api/pdf-info)                 | `pdf-info`    | Get PDF Information (pdf-info endpoint)     | The `pdf-info` endpoint returns metadata from a PDF document. |
| [Extract PDF Text](./cloud-api/pdf-text)                     | `pdf-text`    | Extract Text (pdf-text endpoint)            | Extract text from PDF documents using the `pdf-text` endpoint. |
| [Extract XMP Metadata](./cloud-api/pdf-xmp)                  | `pdf-xmp`     | Get XMP Metadata (pdf-xmp endpoint)         | Extract XMP meta-data from PDF documents using the `pdf-xmp` endpoint. |

# Support

The primary source for the DynamicPDF Cloud API support is through [Stack Overflow](https://stackoverflow.com/questions/tagged/dynamicpdf-api). Please use the "[dynamicpdf-api](https://stackoverflow.com/questions/tagged/dynamicpdf-api)" tag to ask questions. Our support team actively monitors the tag and responds promptly to any questions.  Also, let us know you asked the question by following up with an email to [support@dynamicpdf.com](mailto:support@dynamicpdf.com). 

## Pro Plan Subscribers[#](https://cloud.dynamicpdf.com/support#pro-plan-subscribers)

Ticket support is available to Pro Plan subscribers. But we still encourage you to help the community by posting on Stack Overflow when possible. You can also email [support@dynamicpdf.com](mailto:support@dynamicpdf.com) if you need to ask something specific to your use case that may not help the DynamicPDF Cloud API community.

# License

The dotnet-client library is licensed under the [MIT License](./LICENSE).
