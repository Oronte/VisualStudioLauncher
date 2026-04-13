using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudioLauncher
{
    public class SolutionCreator
    {
        public void CreateProject(string templatePath, string solutionPath, string projectName)
        {
            Type t = Type.GetTypeFromProgID("VisualStudio.DTE.17.0");
            DTE dte = (DTE)Activator.CreateInstance(t);

            dte.Solution.Create(System.IO.Path.GetDirectoryName(solutionPath),
                                System.IO.Path.GetFileName(solutionPath));

            dte.Solution.AddFromTemplate(templatePath,
                                        System.IO.Path.GetDirectoryName(solutionPath),
                                        projectName);

            dte.MainWindow.Visible = true;
        }
    }
}
