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
  public class MainWindowViewModel:ObservableRecipient
    {
        public RestCollection<Game> Games { get; set; }
        private Game selectedGame;
        private string errorMessage;
       

        public Game SelectedGame
        {
            get { return selectedGame; }
            set { if (value != null)
                {
                    selectedGame = new Game()
                    {
                        Name = value.Name,
                        Id = value.Id,
                    };
                    OnPropertyChanged();
                    (DeleteGameCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateGameCommand { get; set; }
        public ICommand DeleteGameCommand { get; set; }
        public ICommand UpdateGameCommand { get; set; } 
        public  static bool IsInDesingMode
        { get { var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            } }

        public string ErrorMessage { get => errorMessage; set { SetProperty(ref errorMessage, value); }}

        public MainWindowViewModel()
        {
            
               if(!IsInDesingMode)
            {
                Games = new RestCollection<Game>("http://localhost:18902/", "game");
                CreateGameCommand = new RelayCommand(() =>
                {
                    Games.Add(new Game()
                    {
                        Name = SelectedGame.Name
                    }); ;
                });
               
                UpdateGameCommand = new RelayCommand(() =>
                { try { Games.Update(SelectedGame); }
                    catch (ArgumentException ex)
                    { ErrorMessage = ex.Message; } });
                DeleteGameCommand = new RelayCommand(() => { Games.Delete(SelectedGame.Id); },
                   () => { return SelectedGame != null; }
               );
            }
            SelectedGame = new Game();

        }
    }
}
