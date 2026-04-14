using EnvDTE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualStudioLauncher.Models;

namespace VisualStudioLauncher
{
    class RecentProjectsViewModel : ViewModelBase
    {
        public RelayCommand OpenCommand => new RelayCommand(_execute => OpenProject(), _canExecute => SelectedProject != null);
        public RelayCommand RemoveCommand => new RelayCommand(_execute => RemoveProject(), _canExecute => SelectedProject != null);

        ProjectPOCO selectedProject = null;
        public ObservableCollection<ProjectPOCO> Projects { get; set; } = new ObservableCollection<ProjectPOCO>();

        public ProjectPOCO SelectedProject
        {
            get { return selectedProject; }
            set
            {
                selectedProject = value;
                OnPropertyChanged();
            }
        }

        public RecentProjectsViewModel()
        {
            Init();
        }

        public void Init() => Projects = new ObservableCollection<ProjectPOCO>(RecentProjectReader.GetRecentProjects());

        void OpenProject()
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = selectedProject.Path,
                UseShellExecute = true
            });
        }

        void RemoveProject()
        {

        }
    }
}
