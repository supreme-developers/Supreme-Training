#pragma checksum "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbcf521320451f273815c7ba42467e8c02610097"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_FolderItemsPartial), @"mvc.1.0.view", @"/Views/Shared/FolderItemsPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/FolderItemsPartial.cshtml", typeof(AspNetCore.Views_Shared_FolderItemsPartial))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\_ViewImports.cshtml"
using SSIDocumentControl;

#line default
#line hidden
#line 2 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\_ViewImports.cshtml"
using SSIDocumentControl.Models;

#line default
#line hidden
#line 3 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\_ViewImports.cshtml"
using SSIDocumentControl.ViewModels;

#line default
#line hidden
#line 4 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\_ViewImports.cshtml"
using SSIDocumentControl.Core;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbcf521320451f273815c7ba42467e8c02610097", @"/Views/Shared/FolderItemsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af7d239a7e33a50a158fda377a7cbc5531a200f8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_FolderItemsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SSIDocumentControl.ViewModels.FolderItemsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SetPdfExpiration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 351, true);
            WriteLiteral(@"
<div class=""row"">
    <table class=""table"">
        <thead>
            <tr>
                <th>
                    Name
                </th>
                <th>
                    Modified
                </th>
                <th>Members</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 18 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
             foreach (var item in Model.Folders)
            {

#line default
#line hidden
            BeginContext(475, 93, true);
            WriteLiteral("                <tr>\r\n                    <td class=\"text-lg-left\">\r\n                        ");
            EndContext();
            BeginContext(568, 652, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbcf521320451f273815c7ba42467e8c026100975468", async() => {
                BeginContext(622, 406, true);
                WriteLiteral(@"
                            <div class=""container"">
                                <div class=""row"">
                                    <div class=""col-xs-6"">

                                        <i class=""fas fa-folder text-warning fa-3x""></i>
                                    </div>
                                    <div class=""col-xs-6 p-3"">
                                        ");
                EndContext();
                BeginContext(1029, 39, false);
#line 30 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
                EndContext();
                BeginContext(1068, 148, true);
                WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 22 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
                                                  WriteLiteral(item.FolderId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1220, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1300, 51, false);
#line 38 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ModifiedDateTime));

#line default
#line hidden
            EndContext();
            BeginContext(1351, 2332, true);
            WriteLiteral(@"
                    </td>
                    <td>
                        2 Members
                    </td>
                    <td class=""text-lg-left"">

                        <a class=""nav-link "" id=""more"" href=""#"" data-toggle=""dropdown"">
                            <i class=""mdi mdi-dots-horizontal mdi-24px text-gray ""></i>
                        </a>
                        <div class=""dropdown-menu dropdown-menu-right navbar-dropdown preview-list"" aria-labelledby=""more"">

                            <a class=""dropdown-item preview-item"">
                                <div class=""preview-thumbnail"">
                                    <i class=""mdi mdi-download  text-success""></i>
                                </div>
                                <div class=""preview-item-content"">
                                    <p class=""font-weight-light small-text"">
                                        Download
                                    </p>

                          ");
            WriteLiteral(@"      </div>
                            </a>
                            <div class=""dropdown-divider""></div>
                            <a class=""dropdown-item preview-item"">
                                <div class=""preview-thumbnail"">
                                    <i class=""mdi mdi-drag-vertical  text-dark""></i>
                                </div>
                                <div class=""preview-item-content"">
                                    <p class=""font-weight-light small-text"">Move</p>
                                </div>
                            </a>
                            <div class=""dropdown-divider""></div>
                            <a class=""dropdown-item preview-item"">
                                <div class=""preview-thumbnail"">
                                    <i class=""fas fa-copy text-primary""></i>
                                </div>
                                <div class=""preview-item-content"">
                                    <p");
            WriteLiteral(@" class=""font-weight-light small-text"">
                                        Copy
                                    </p>
                                </div>
                            </a>
                        </div>
                    </td>
                </tr>
");
            EndContext();
#line 84 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
            }

#line default
#line hidden
            BeginContext(3698, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 85 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
             foreach (var doc in Model.Documents)
            {
                var expired = DateTime.Compare(DateTime.Now, Convert.ToDateTime(doc.ExpiryDate)) < 0 ? false : true;
                string expiredLink = "";
                if (expired) { expiredLink = "btn disabled"; }

#line default
#line hidden
            BeginContext(3988, 95, true);
            WriteLiteral("                <tr>\r\n                    <td class=\"text-lg-left\">\r\n\r\n                        ");
            EndContext();
            BeginContext(4083, 1617, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbcf521320451f273815c7ba42467e8c0261009712714", async() => {
                BeginContext(4158, 166, true);
                WriteLiteral("\r\n                            <div class=\"container\">\r\n                                <div class=\"row\">\r\n                                    <div class=\"col-xs-6\">\r\n");
                EndContext();
#line 97 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
                                         if (doc.MimeType == "pdf")
                                        {

#line default
#line hidden
                BeginContext(4436, 105, true);
                WriteLiteral("                                            <i class=\"fas fa-file-pdf fa-3x\" style=\"color:#ea5050\"></i>\r\n");
                EndContext();
#line 100 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
                                        }
                                        else if (doc.MimeType.Contains("doc"))
                                        {

#line default
#line hidden
                BeginContext(4707, 106, true);
                WriteLiteral("                                            <i class=\"fas fa-file-word fa-3x\" style=\"color:#295496\"></i>\r\n");
                EndContext();
#line 104 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
                                        }
                                        else if (doc.MimeType.Contains("xls"))
                                        {

#line default
#line hidden
                BeginContext(4979, 107, true);
                WriteLiteral("                                            <i class=\"fas fa-file-excel fa-3x\" style=\"color:#1f7044\"></i>\r\n");
                EndContext();
#line 108 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
                BeginContext(5218, 94, true);
                WriteLiteral("                                            <i class=\"fas fa-file text-secondary fa-3x\"></i>\r\n");
                EndContext();
#line 112 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
                                        }

#line default
#line hidden
                BeginContext(5355, 148, true);
                WriteLiteral("                                    </div>\r\n                                    <div class=\"col-xs-6 p-3\">\r\n                                        ");
                EndContext();
                BeginContext(5504, 46, false);
#line 115 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
                                   Write(Html.DisplayFor(modelItem => doc.DocumentName));

#line default
#line hidden
                EndContext();
                BeginContext(5550, 146, true);
                WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 93 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
                                                           WriteLiteral(doc.DocId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5700, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(5780, 50, false);
#line 122 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
                   Write(Html.DisplayFor(modelItem => doc.ModifiedDatetime));

#line default
#line hidden
            EndContext();
            BeginContext(5830, 729, true);
            WriteLiteral(@"
                    </td>
                    <td>
                        2 Members
                    </td>
                    <td class=""text-lg-left"">

                        <a class=""nav-link "" id=""more"" href=""#"" data-toggle=""dropdown"">
                            <i class=""mdi mdi-dots-horizontal mdi-24px text-gray ""></i>
                        </a>
                        <div class=""dropdown-menu dropdown-menu-left navbar-dropdown preview-list"" aria-labelledby=""more"">
                            <a class=""dropdown-item preview-item revise"" 
                               data-toggle=""modal"" 
                               data-target=""#reviseModal""
                               data-doc-id=""");
            EndContext();
            BeginContext(6560, 9, false);
#line 136 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
                                       Write(doc.DocId);

#line default
#line hidden
            EndContext();
            BeginContext(6569, 1775, true);
            WriteLiteral(@""" >
                                <div class=""preview-thumbnail"">
                                    <i class=""mdi mdi-download  text-success""></i>
                                </div>
                                <div class=""preview-item-content"">
                                    <p class=""font-weight-light small-text"">
                                        Edit / Revise
                                    </p>

                                </div>
                            </a>
                            <div class=""dropdown-divider""></div>
                            <a class=""dropdown-item preview-item"">
                                <div class=""preview-thumbnail"">
                                    <i class=""mdi mdi-drag-vertical  text-dark""></i>
                                </div>
                                <div class=""preview-item-content"">
                                    <p class=""font-weight-light small-text"">Move</p>
                                ");
            WriteLiteral(@"</div>
                            </a>
                            <div class=""dropdown-divider""></div>
                            <a class=""dropdown-item preview-item"">
                                <div class=""preview-thumbnail"">
                                    <i class=""fas fa-copy text-primary""></i>
                                </div>
                                <div class=""preview-item-content"">
                                    <p class=""font-weight-light small-text"">
                                        Copy
                                    </p>
                                </div>
                            </a>
                        </div>
                    </td>

                </tr>
");
            EndContext();
#line 171 "D:\Development\SourceCode\Supreme\SSIDocumentControl\SSIDocumentControl\Views\Shared\FolderItemsPartial.cshtml"
            }

#line default
#line hidden
            BeginContext(8359, 284, true);
            WriteLiteral(@"        </tbody>
    </table>
</div>
<div class=""row"">
    <div class=""col-12"">
        <div class=""modal fade"" id=""reviseModal"" tabindex=""-1"" role=""dialog""
             aria-labelledby=""newFile"" aria-hidden=""true"">
            <div class=""vc-createFile"">
            </div>
");
            EndContext();
            BeginContext(8714, 36, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(8767, 438, true);
                WriteLiteral(@" 
<script>
    $(function () {
        alert('erh');
    });
    $('#reviseModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var docId = button.data('doc-id');
        console.log(docId);
        //set header text based on action (edit or create)
      
        $('#reviseModal .vc-createFile').load('/Documents/ReviseDocument', { 'docId': docId });

    });
</script>
    ");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SSIDocumentControl.ViewModels.FolderItemsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
