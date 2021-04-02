using System;
using System.Collections.Generic;
using BowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BowlingLeague.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "Page-Info")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo;

        public PaginationTagHelper(IUrlHelperFactory uhf)
        {
            urlInfo = uhf;
        }

        public PageNumberingInfo PageInfo { get; set; }

        //Our Own dictionary (key value pairs) that we are creation
        [HtmlAttributeName(DictionaryAttributePrefix = "Page-Url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlInfo.GetUrlHelper(ViewContext);
            //Build and add tag to Div
            TagBuilder finishedTag = new TagBuilder("div");

            for (int i = 1; i<= PageInfo.NumPages; i++)
            {
                TagBuilder individualTag = new TagBuilder("a");

                KeyValuePairs["PageNum"] = i;
                individualTag.Attributes["href"] = urlHelper.Action("Index", KeyValuePairs);
                individualTag.InnerHtml.Append(i.ToString());

                finishedTag.InnerHtml.AppendHtml(individualTag);
            }
            

            output.Content.AppendHtml(finishedTag.InnerHtml);
        }
    }
}
