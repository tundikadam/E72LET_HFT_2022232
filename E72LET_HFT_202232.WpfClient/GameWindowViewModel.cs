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
  public class GameWindowViewModel:ObservableRecipient
    {
        public RestCollection<Game> Games { get; set; }
        private Game selectedGame;
        private string errorMessage;
        bool IsSomethingSelected = false;

        public Game SelectedGame
        {
            get { return selectedGame; }
            set { if (value != null)
                {
                    selectedGame = new Game()
                    {
                        
                        
                        Id = value.Id,
                        StudioId = value.StudioId,
                        MinimalSystemRequirementsId = value.MinimalSystemRequirementsId,
                        Name = value.Name,
                        Age_Limit=value.Age_Limit,  
                        Appearance = value.Appearance,  
                        Price = value.Price

                    };
                    IsSomethingSelected = true;
                    OnPropertyChanged();

                    

                }
                else { selectedGame = new Game();
                    IsSomethingSelected = false;
                } (DeleteGameCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (UpdateGameCommand as RelayCommand)?.NotifyCanExecuteChanged();
            }
        }


        public ICommand CreateGameCommand { get; set; }
        public ICommand DeleteGameCommand { get; set; }
        public ICommand UpdateGameCommand { get; set; }
        public ICommand ActivisionsGamePriceAverageCommand { get; set; }
        public ICommand ContendoCount { get; set; }
        public ICommand CountOfWin98 { get; set; }
        public ICommand NewestGame{ get; set; }
        public ICommand FirstRockstar { get; set; }
        public  static bool IsInDesingMode
        { get { var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            } }

        public string ErrorMessage { get => errorMessage; set { SetProperty(ref errorMessage, value); }}

        public GameWindowViewModel()
        {
            
               if(!IsInDesingMode)
            {
                Games = new RestCollection<Game>("http://localhost:18902/", "game","hub");
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
                DeleteGameCommand = new RelayCommand(() =>
                {
                    Games.Delete(SelectedGame.Id);
                    IsSomethingSelected = false;
                },
                   () => IsSomethingSelected != false
               ); ; ;
                ActivisionsGamePriceAverageCommand = new RelayCommand(() => { });
                
            }
            SelectedGame = new Game();

        }
    }
}
