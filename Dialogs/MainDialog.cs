using QSoft.CxPerium.Dialogs.WhatsApp;
using QSoft.CxPerium.Services;
using System;
namespace CxPerium.BotTemplate.Dialogs
{
    public class MainDialog : WelcomeDialog
    {
    
        public override void RunDialog()
        {
            this.Messages.SendMessage("Hello World");
           
        }
    }
}
