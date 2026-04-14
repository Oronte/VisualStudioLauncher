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
            // 1. Résout les variables d'environnement + chemin absolu
            string absoluteTemplatePath = ResolvePath(templatePath);

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

        private static string ResolvePath(string path)
        {
            // Remplace les variables d'environnement
            string resolved = path
                .Replace("%ProgramFiles%", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
                .Replace("%ProgramFiles(x86)%", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86))
                .Replace("%AppData%", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
                .Replace("%LocalAppData%", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            // Si déjà absolu → on retourne tel quel
            if (Path.IsPathRooted(resolved))
                return resolved;

            // Sinon → chemin relatif depuis la racine du projet
            string projectRoot = Path.GetFullPath(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));

            return Path.GetFullPath(Path.Combine(projectRoot, resolved.Replace("/", "\\")));
        }
    }
}
