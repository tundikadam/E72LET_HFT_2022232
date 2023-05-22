using ConsoleTools;
using E72LET_HFT_2022232.Logic;
using E72LET_HFT_2022232.Models;
using E72LET_HFT_2022232.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace E72LET_HFT_2022232
{
    internal class Program
    {
        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        
        static void List(string entity)
        {
            Console.WriteLine(entity + " list");
            Console.ReadLine();
        }
        static void Update(string entity)
        { Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        { Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            var studioSubMenu = new ConsoleMenu(args, level: 1).Add("List", () => List("Studio")).Add("Create", () => Create("Studio")).Add("Delete", () => Delete("Studio")).Add("Update", () => Update("Studio")).Add("Exit",ConsoleMenu.Close);
            var minSubMenu = new ConsoleMenu(args, level: 1).Add("List", () => List("MinimalSystemRequriements")).Add("Create", () => Create("MinimalSystemRequriements")).Add("Delete", () => Delete("MinimalSystemRequriements")).Add("Update", () => Update("MinimalSystemRequriements")).Add("Exit",ConsoleMenu.Close);
            var gameSubMenu = new ConsoleMenu(args, level: 1).Add("List", () => List("Game")).Add("Create", () => Create("Game")).Add("Delete", () => Delete("Game")).Add("Update", () => Update("Game")).Add("Exit",ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0).Add("Games", () => gameSubMenu.Show()).Add("Studios", () => studioSubMenu.Show()).Add("Minimal System requriements", () => minSubMenu.Show()).Add("Exit",ConsoleMenu.Close);

            menu.Show();

        }
    }
}
