using HelpDeskLogin.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Util.Helpers
{
    [HtmlTargetElement("dropdrown-grupo")]
    public class DropDownGrupoHelper : TagHelper
    {
        private readonly ApplicationDbContext _context;

        public DropDownGrupoHelper(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            output.TagName = "select";
            output.Attributes.SetAttribute("class", "awesome-select, form-control");

            var grupos = _context.grupos.AsQueryable();

            foreach (var item in grupos)
            {
                TagBuilder option = new TagBuilder("option")
                {
                    TagRenderMode = TagRenderMode.Normal
                };
                option.Attributes.Add("value", item.idGrupo.ToString());
                option.InnerHtml.Append(item.grupo);
                output.Content.AppendHtml(option);
            }

        }
    }
}
