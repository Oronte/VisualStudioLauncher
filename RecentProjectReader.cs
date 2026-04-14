using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using VisualStudioLauncher.Models;

namespace VisualStudioLauncher
{
    public class RecentProjectReader
    {
        static public List<ProjectPOCO> GetRecentProjects() => JsonConvert.DeserializeObject<List<ProjectPOCO>>(File.ReadAllText("RecentProjects.json"));
    }
}
