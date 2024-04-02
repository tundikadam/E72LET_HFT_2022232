using E72LET_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E72LET_HFT_202232.WpfClient
{
  public class MainWindowViewModel:ObservableRecipient
    {
        public RestCollection<Game> Games { get; set; }
        private Game selectedGame;
       

        public Game SelectedGame
        {
            get { return selectedGame; }
            set { SetProperty(ref selectedGame, value);
                (DeleteGameCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand CreateGameCommand { get; set; }
        public ICommand DeleteGameCommand { get; set; }
        public ICommand UpdateGameCommand { get; set; } 

        public MainWindowViewModel()
        {
            Games = new RestCollection<Game>("http://localhost:18902/","game");
            CreateGameCommand = new RelayCommand(() => 
            { Games.Add(new Game() 
            { Name = "Tractor Racer" 
            });
            });
            DeleteGameCommand = new RelayCommand(() => { Games.Delete(SelectedGame.Id); },
                () => { return SelectedGame != null; }
            );
        }
    }
}
