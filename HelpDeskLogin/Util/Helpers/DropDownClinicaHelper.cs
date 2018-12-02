using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskLogin.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HelpDeskLogin.Util.Helpers
{
    [HtmlTargetElement("dropdrown-clinica")]
    public class DropDownClinicaHelper : TagHelper
    {
        private readonly ApplicationDbContext _context;

        public DropDownClinicaHelper(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            output.TagName = "select";
            output.Attributes.SetAttribute("class", "awesome-select, form-control");

            var clinicas = _context.Clinicas.AsQueryable();

            foreach (var item in clinicas)
            {
                TagBuilder option = new TagBuilder("option")
                {
                    TagRenderMode = TagRenderMode.Normal
                };
                option.Attributes.Add("value", item.idClinica.ToString());
                option.InnerHtml.Append(item.nome);
                output.Content.AppendHtml(option);
            }

        }
    }
}
