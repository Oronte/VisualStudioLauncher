using EnvDTE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudioLauncher
{
    public static class SolutionCreator
    {
        public static void CreateProject(string templatePath, string solutionPath, string projectName)
        {
            // 1. Résout le chemin absolu depuis la racine du projet
            string projectRoot = Path.GetFullPath(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));

            string absoluteTemplatePath = Path.IsPathRooted(templatePath)
                ? templatePath
                : Path.GetFullPath(Path.Combine(projectRoot, templatePath.Replace("/", "\\")));

            // 2. Vérifications
            if (!File.Exists(absoluteTemplatePath))
                throw new FileNotFoundException($"Template introuvable : {absoluteTemplatePath}");

            // 3. Prépare les chemins
            string solutionDir = Path.GetDirectoryName(solutionPath);
            string solutionName = Path.GetFileNameWithoutExtension(solutionPath);
            string projectDir = Path.Combine(solutionDir, projectName);

            // 4. Crée les dossiers s'ils n'existent pas
            Directory.CreateDirectory(solutionDir);
            Directory.CreateDirectory(projectDir);

            // 5. Crée l'instance DTE
            Type t = Type.GetTypeFromProgID("VisualStudio.DTE.17.0");
            DTE dte = (DTE)Activator.CreateInstance(t);

            // 6. Crée la solution
            dte.Solution.Create(solutionDir, solutionName);

            // 7. Ajoute le projet
            dte.Solution.AddFromTemplate(
                absoluteTemplatePath,
                projectDir,
                projectName,
                false
            );

            dte.MainWindow.Visible = true;
        }
    }
}
