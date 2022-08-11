using Microsoft.AspNetCore.Mvc;

namespace Obra.MVC.Controllers
{
    public class ControllerBase : Controller
    {
        public void CreateViewBags()
        {
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();

            switch(controllerName.ToLower())
            {
                case "clientefornecedores":
                    ViewBag.ControllerName = "Cadastro de Clientes e Fornecedores";
                    ViewBag.ControllerIcon = "fa-solid fa-people-group";
                    break;
                case "contas":
                    ViewBag.ControllerName = "Cadastro de Contas";
                    ViewBag.ControllerIcon = "fa-solid fa-credit-card";
                    break;
                case "empreendimentos":
                    ViewBag.ControllerName = "Cadastro de Empreendimentos";
                    ViewBag.ControllerIcon = "fa-solid fa-building";
                    break;
                case "fotoempreendimentos":
                    ViewBag.ControllerName = "Cadastro de Fotos de Empreendimentos";
                    ViewBag.ControllerIcon = "fa-solid fa-images";
                    break;
                case "tipodepagamentos":
                    ViewBag.ControllerName = "Cadastro de Tipos de Pagamentos";
                    ViewBag.ControllerIcon = "fa-solid fa-money-bill-1-wave";
                    break;
                case "tipodedespesareceitas":
                    ViewBag.ControllerName = "Cadastro de Tipos de Despesas e Receitas";
                    ViewBag.ControllerIcon = "fa-solid fa-money-bill-transfer";
                    break;
            }

            switch(actionName.ToLower())
            {
                case "index":
                    ViewBag.ActionName = "Consulta geral";
                    ViewBag.ActionIcon = "fa-solid fa-rectangle-list";
                    break;
                case "details":
                    ViewBag.ActionName = "Consulta";
                    ViewBag.ActionIcon = "fa-solid fa-magnifying-glass";
                    break;
                case "create":
                    ViewBag.ActionName = "Criar novo";
                    ViewBag.ActionIcon = "fa-solid fa-plus";
                    break;
                case "delete":
                    ViewBag.ActionName = "Exclusão";
                    ViewBag.ActionIcon = "fa-solid fa-trash";
                    break;
                case "edit":
                    ViewBag.ActionName = "Alteração";
                    ViewBag.ActionIcon = "fa-solid fa-pen-to-square";
                    break;
            }
        }
    }
}