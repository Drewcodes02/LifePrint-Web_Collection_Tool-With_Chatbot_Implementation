#pragma checksum "/Users/macbookair/Desktop/LifePrint/LifePrint/Pages/Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e60b9df7088503a18129e643f59e3c357418d8c"
// <auto-generated/>
#pragma warning disable 1591
namespace LifePrint.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/macbookair/Desktop/LifePrint/LifePrint/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/macbookair/Desktop/LifePrint/LifePrint/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/macbookair/Desktop/LifePrint/LifePrint/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/macbookair/Desktop/LifePrint/LifePrint/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/macbookair/Desktop/LifePrint/LifePrint/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/macbookair/Desktop/LifePrint/LifePrint/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/macbookair/Desktop/LifePrint/LifePrint/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/macbookair/Desktop/LifePrint/LifePrint/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/macbookair/Desktop/LifePrint/LifePrint/_Imports.razor"
using LifePrint;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/macbookair/Desktop/LifePrint/LifePrint/_Imports.razor"
using LifePrint.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/macbookair/Desktop/LifePrint/LifePrint/Pages/Index.razor"
using Microsoft.AspNetCore.Components.Web.Extensions.Head;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/{userID:int}")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Web.Extensions.Head.Title>(0);
            __builder.AddAttribute(1, "Value", "Lifeprint FOCUS");
            __builder.CloseComponent();
            __builder.AddMarkupContent(2, "\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Web.Extensions.Head.Link>(3);
            __builder.AddAttribute(4, "rel", "icon");
            __builder.AddAttribute(5, "type", "image/x-icon");
            __builder.AddAttribute(6, "href", "../wwwroot/img/favicon.ico");
            __builder.CloseComponent();
            __builder.AddMarkupContent(7, "\n\n\n\n\n");
            __builder.AddMarkupContent(8, "<h2>User Dashboard</h2>\n");
            __builder.AddMarkupContent(9, "<p class=\"alert alert-success\">This dashboard is a work in progress, you will see graphs and analytics on performance from completed surveys.</p>\n");
            __builder.AddMarkupContent(10, "<p class=\"alert alert-danger\">Blah blah blah blah blah blah blah</p>\n\n\n");
            __builder.AddMarkupContent(11, "<label> Here you can find important information and links.</label>\n\n");
            __builder.AddMarkupContent(12, "<div class=\"container h-100 dashboard-item-container\"><div class=\"row justify-content-evenly \"><div class=\"col-sm item-box dashboard-item\"><div class=\"content\"><p class=\"item-box-title\"><h3>Dashboard Item 1</h3></p>\n                Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\n                Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\n                Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\n                Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\n\n                <br>\n                <button class=\"btn btn-success\">\n                    Click me\n                </button></div></div>\n        <div class=\"col-sm item-box dashboard-item\"><div class=\"content\"><p class=\"item-box-title\"><h3></h3></p>\n                Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\n                Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\n                Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\n                Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\n\n                <br>\n                <button class=\"btn btn-success\">\n                    Click me\n                </button></div></div>\n        <div class=\"col-sm item-box dashboard-item\"><div class=\"content\"><p class=\"item-box-title\"><h3>Progress</h3></p>\n                Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\n                Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\n                Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\n                Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...\n\n                <br>\n                <button class=\"btn btn-success\">\n                    Click me\n                </button></div></div></div></div>");
        }
        #pragma warning restore 1998
#nullable restore
#line 76 "/Users/macbookair/Desktop/LifePrint/LifePrint/Pages/Index.razor"
       

    private List<Health> healthResults = new List<Health>();

    public List<int> subGH = new List<int>();
    public List<int> subEF = new List<int>();
    public List<int> subEW = new List<int>();
    public List<int> subHVSF = new List<int>();

    [Parameter]
    public int UserID { get; set; }

    protected override Task OnInitializedAsync()
    {
       

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "/Users/macbookair/Desktop/LifePrint/LifePrint/Pages/Index.razor"
                                
        //OutputSubdomains();
        return Task.CompletedTask;
    }

    public void GetHealthData()
    {
        using var db = new LifeprintDatabaseContext();

        healthResults = db.Health.ToList();


    }

    private void SplitDomains()
    {
        subGH.Add(healthResults[0].H1GhHvsfScore ?? default(int));
        subGH.Add(healthResults[0].H2GhScore ?? default(int));
        subGH.Add(healthResults[0].H3GhScore ?? default(int));
        subGH.Add(healthResults[0].H4GhScore ?? default(int));
        subGH.Add(healthResults[0].H5GhScore ?? default(int));
        subGH.Add(healthResults[0].H15GhScore ?? default(int));
        subGH.Add(healthResults[0].H16GhScore ?? default(int));
        subGH.Add(healthResults[0].H17GhScore ?? default(int));
        subGH.Add(healthResults[0].H18GhScore ?? default(int));
    }

    private void OutputSubdomains()
    {
        foreach(int sub in subGH)
        {
            Console.WriteLine(sub);
        }
    }

    private void CalculatePercentage()
    {
        float sum = subGH.Sum();
        Console.WriteLine(sum);

        float max = (subGH.Count * 5);
        Console.WriteLine(max);

        float percentage = (sum / max) * 100f ;
        

        Console.WriteLine(percentage + "%");

    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591