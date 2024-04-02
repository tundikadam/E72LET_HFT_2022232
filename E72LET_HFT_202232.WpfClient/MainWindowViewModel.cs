using E72LET_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET_HFT_202232.WpfClient
{
  public class MainWindowViewModel
    {
        public RestCollection<Game> Games { get; set; }
        public MainWindowViewModel()
        {
            Games = new RestCollection<Game>("http://localhost:18902/", "swagger");
        }
    }
}
