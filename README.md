![](./logo-banner2.png)

# C# .NET Client Library (`dotnet-client`)

The C# .NET Client library (`dotnet-client`) uses the DynamicPDF API .NET client library to create, merge, split, form fill, stamp, obtain metadata, convert, and secure/encrypt PDF documents. The website for this project is available at [cloud.dynamicpdf.com](https://cloud.dynamicpdf.com/).

The DynamicPDF API consists of the following endpoints.

* `dlex-layout`
* `image-info`
* `pdf`
* `pdf-info`
* `pdf-text`
* `pdf-xmp`

## NuGet

* Obtain the NuGet package at https://www.nuget.org/packages/DynamicPDF.API

## Documentation

* Obtain overview documentation for the DynamicPDF API Client libraries from the [Cloud API Users Guide](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/client-libraries/cloud-api-client-libraries).
* Access the documentation for each particular endpoint from the following Users Guide pages. 

| Endpoint      | REST Endpoint                                                | REST Endpoint Client Library                                 | Description                                                  |
| ------------- | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| `dlex-layout` | [API Users Guide - `dlex-layout`](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/cloud-api-dlex-layout) | [`dlex-layout`](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/client-libraries/client-api-dlex-layout) | Returns a PDF after processing a DLEX file with it's associated JSON data. |
| `image-info`  | [API Users Guide - `image-info`](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/cloud-api-image-info) | [`image-info`](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/client-libraries/client-api-image-info) | Returns image metadata as a JSON document.                   |
| `pdf`         | [API Users Guide - `pdf`](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/cloud-api-pdf) | [`pdf`](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/client-libraries/client-api-pdf) | Returns a PDF after performing one of the pdf endpoint's tasks (`page`, `dlex`, `image`) or merging. |
| `pdf-info`    | [API Users Guide - `pdf-Info`](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/cloud-api-pdf-info) | [`pdf-info`](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/client-libraries/client-api-pdf-info) | Returns PDF metadata as a JSON document.                     |
| `pdf-text`    | [API Users Guide - `pdf-text`](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/cloud-api-pdf-text) | [`pdf-text`](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/client-libraries/client-api-pdf-text) | Returns the text from a PDF as a JSON document.              |
| `pdf-xmp`     | [API Users Guide - `pdf-xmp`](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/cloud-api-pdf-xmp) | [`pdf-xmp`](https://cloud.dynamicpdf.com/docs/usersguide/cloud-api/client-libraries/client-api-pdf-xmp) | Returns XMP metadata from a PDF.                             |

## REST Client

* The underlying C# REST client uses [RestSharp](https://restsharp.dev/).

## **Tutorials**

The following table lists the available tutorials.

| Tutorial Title                                     | Tutorial Location                                            |
| -------------------------------------------------- | ------------------------------------------------------------ |
| Merging PDFs                                       | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/merging-pdfs |
| Completing an AcroForm                             | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/form-completion |
| Creating a PDF Using a DLEX and the `pdf` Endpoint | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/dlex-pdf-endpoint |
| Adding Bookmarks to a PDF                          | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/bookmarks |
| Creating a PDF Using the `dlex-layout` Endpoint    | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/dlex-layout |
| Extracting Image Metadata                          | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/image-info |
| Extract PDF Metadata                               | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-info |
| Extracting PDF's Text                              | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-text |
| Extract XMP Metadata                               | https://cloud.dynamicpdf.com/docs/tutorials/cloud-api/pdf-xmp |

# Support

The primary source for the DynamicPDF API support is through [Stack Overflow](https://stackoverflow.com/questions/tagged/dynamicpdf-api). Please use the "[dynamicpdf-api](https://stackoverflow.com/questions/tagged/dynamicpdf-api)" tag to ask questions. Our support team actively monitors the tag and responds promptly to any questions.  Also, let us know you asked the question by following up with an email to [support@dynamicpdf.com](mailto:support@dynamicpdf.com). 

## Pro Plan Subscribers[#](https://cloud.dynamicpdf.com/support#pro-plan-subscribers)

Ticket support is available to Pro Plan subscribers. But we still encourage you to help the community by posting on Stack Overflow when possible. You can also email [support@dynamicpdf.com](mailto:support@dynamicpdf.com) if you need to ask something specific to your use case that may not help the DynamicPDF Cloud API community.

# License

The `dotnet-client` library is licensed under the [MIT License](./LICENSE).
