using QSoft.CxPerium.Dialogs.WhatsApp;
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
