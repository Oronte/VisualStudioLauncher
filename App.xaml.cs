using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Shell;

namespace VisualStudioLauncher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            JumpList jumpList = new JumpList();

            JumpTask task1 = new JumpTask
            {
                Title = "KrampusEngine",
                Description = "Frappe atomique",
            };

            JumpTask task2 = new JumpTask
            {
                Title = "TrucDeMusiqueDeIoan",
                Description = "Frappe pas trop atomique",
            };

            jumpList.JumpItems.Add(task1);
            jumpList.JumpItems.Add(task2);

            JumpList.SetJumpList(this, jumpList);
        }
    }

}
