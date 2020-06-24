using System;
using System.Web.Mvc;

namespace WebService.Controllers
{
    public abstract class BaseController : Controller
    {
        public const string SystemMessage = "MY_DIALOG";

        protected void ShowMessage(string htmlContent, string htmlTitle = "Mensagem do Sistema", MyDialog.DialogType type = MyDialog.DialogType.Info)
        {
            this.ShowMessage(new MyDialog { Title = htmlTitle, Content = htmlContent, @Type = type });
        }

        protected void ShowMessage(MyDialog dialog)
        {
            this.TempData[SystemMessage] = dialog.ToString();
        }
    }
}