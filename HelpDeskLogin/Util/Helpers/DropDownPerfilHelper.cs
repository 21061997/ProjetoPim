using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskLogin.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpDeskLogin.Util.Helpers
{
    [HtmlTargetElement("dropdrown-perfil")]
    public class DropDownPerfilHelper : TagHelper
    {
        
            private readonly ApplicationDbContext _context;

            public DropDownPerfilHelper(ApplicationDbContext context)
            {
                this._context = context;
            }

            public override void Process(
                TagHelperContext context,
                TagHelperOutput output)
            {
                output.TagName = "select";
                output.Attributes.SetAttribute("class", "awesome-select, form-control");

                var perfils = _context.Roles.AsQueryable();

                foreach (var item in perfils)
                {
                    TagBuilder option = new TagBuilder("option")
                    {
                        TagRenderMode = TagRenderMode.Normal
                    };
                    option.Attributes.Add("value", item.Id.ToString());
                    option.InnerHtml.Append(item.Name);
                    output.Content.AppendHtml(option);
                }

            }

    }
}
