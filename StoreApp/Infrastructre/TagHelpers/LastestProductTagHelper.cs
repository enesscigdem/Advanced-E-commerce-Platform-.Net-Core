using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;

namespace StoreApp.Infrastructre.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "products")]
    public class LastestProductTagHelper : TagHelper
    {
        private readonly IProductService productService;
        [HtmlAttributeName("number")]
        public int Number { get; set; }
        public LastestProductTagHelper(IProductService productService)
        {
            this.productService = productService;
        }
        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "my-3");

            TagBuilder h6 = new TagBuilder("h6");
            h6.Attributes.Add("class", "lead");

            TagBuilder icon = new TagBuilder("i");
            icon.Attributes.Add("class", "fa fa-box text-secondary");

            h6.InnerHtml.AppendHtml(icon);
            h6.InnerHtml.AppendHtml("Lastest Products");

            TagBuilder ul = new TagBuilder("ul");
            var products = await productService.GetLastestProducts(Number);
            foreach (Product product in products)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href", $"/product/get/{product.ProductId}");
                a.InnerHtml.AppendHtml(product.ProductName);
                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(li);


            }
            div.InnerHtml.AppendHtml(h6);
            div.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(div);
        }
    }
}