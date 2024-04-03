using E72LET_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace E72LET_HFT_202232.WpfClient
{
   public class MinimalSystemRequriementViewModel:ObservableRecipient
    {
        public RestCollection<MinimalSystemRequirements> Mins { get; set; }
        private MinimalSystemRequirements selectedMin;
        private string errorMessage;


        public MinimalSystemRequirements SelectedMin
        {
            get { return selectedMin; }
            set
            {
                if (value != null)
                {
                    selectedMin = new MinimalSystemRequirements()
                    {
                        MinimalSystemRequirementsId = value.MinimalSystemRequirementsId,
                    OperatingSystem = value.OperatingSystem,
                    
                };
                    OnPropertyChanged();
                    (DeleteMinCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateMinCommand { get; set; }
        public ICommand DeleteMinCommand { get; set; }
        public ICommand UpdateMinCommand { get; set; }
        
        public static bool IsInDesingMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public string ErrorMessage { get => errorMessage; set { SetProperty(ref errorMessage, value); } }

        public MinimalSystemRequriementViewModel()
        {

            if (!IsInDesingMode)
            {
                Mins = new RestCollection<MinimalSystemRequirements>("http://localhost:18902/", "minimalsystemrequirements", "hub");
                CreateMinCommand = new RelayCommand(() =>
                {
                    Mins.Add(new MinimalSystemRequirements()
                    { 
                        OperatingSystem = SelectedMin.OperatingSystem,
                    }) ;
                });

                UpdateMinCommand = new RelayCommand(() =>
                {
                    try { Mins.Update(SelectedMin); }
                    catch (ArgumentException ex)
                    { ErrorMessage = ex.Message; }
                });
                DeleteMinCommand = new RelayCommand(() => { Mins.Delete(SelectedMin.MinimalSystemRequirementsId); },
                   () => { return SelectedMin != null; }
               );
               

            }
            SelectedMin = new MinimalSystemRequirements();

        }
    }
}
