using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace HelpDeskLogin.Views.Manage
{
    public static class ManageNavPages
    {
        public static string ActivePageKey => "ActivePage";

        public static string Index => "Index";

        public static string ChangePassword => "ChangePassword";

        public static string ExternalLogins => "ExternalLogins";

        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        public static string Usuarios => "Usuarios";
        public static string Funcionarios => "Funcionarios";
        public static string Categorias => "Categorias";
        public static string Prioridades => "Prioridades";
        public static string Grupos => "Grupos";
        public static string Clinicas => "Clinicas";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);
        public static string UsuariosNavClass(ViewContext viewContext) => PageNavClass(viewContext, Usuarios);
        public static string FuncionariosNavClass(ViewContext viewContext) => PageNavClass(viewContext, Funcionarios);
        public static string CategoriasNavClass(ViewContext viewContext) => PageNavClass(viewContext, Categorias);
        public static string PrioridadesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Prioridades);
        public static string GruposNavClass(ViewContext viewContext) => PageNavClass(viewContext, Grupos);
        public static string ClinicasNavClass(ViewContext viewContext) => PageNavClass(viewContext, Clinicas);
    
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
