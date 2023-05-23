using ConsoleTools;

using E72LET_HFT_2022232.Models;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace E72LET_HFT_2022232
{
    class Program
    {
       static  RestService rest;
        static void Create(string entity)
        {
            if (entity == "Game")
            {
                
                
                Console.WriteLine("Enter  Studio Id:");
                int studid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Minimal Requriements Id:");
                int minid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Age Limit:");
                int agelimit = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Game Appereance Year:");
                int appyear = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Game price:");
                int price = int.Parse(Console.ReadLine());
                Game g = new Game( rest.Get<Game>("Game").Last().Id + 1,studid,minid,name,agelimit,appyear,price);
                try { rest.Post(g, "Game"); }
                catch(Exception e)
                { Console.WriteLine(e.Message); }
                Thread.Sleep(2500);
                
              
            }
            if (entity=="Minimal")
            {
                Console.WriteLine("Enter Operating System:");
                string Os = Console.ReadLine();
                Console.WriteLine("Enter Ram Size");
                double ram = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Ssd Size:");
                double ssd = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter CPU Brand ");
                string cpubrand = Console.ReadLine();
                Console.WriteLine("Enter CPU clockspeed");
                double cpuclock = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter VGA brand");
                string vgabrand = Console.ReadLine();
                Console.WriteLine("Enter VGA memorySize");
                int vgamemory = int.Parse(Console.ReadLine());
                MinimalSystemRequirements min = new MinimalSystemRequirements(rest.Get<MinimalSystemRequirements>("MinimalSystemRequriements").Last().MinimalSystemRequirementsId+1, Os, ram, ssd, cpubrand, cpuclock, vgabrand, vgamemory);
                try { rest.Post(min, "MinimalSystemRequriements"); }
                catch (Exception e)
                { Console.WriteLine(e.Message); }
                Thread.Sleep(2500);


            }
            if (entity == "Studio")
            {
                Console.Write("Enter Studio Name:");
                string name = Console.ReadLine();

                Studio g = new Studio( rest.Get<Studio>("Studio").Last().StudioId + 1, name);
                try { rest.Post(g, "Studio"); }
                catch (Exception e)
                { Console.WriteLine(e.Message); }
                Thread.Sleep(2500);


            }


        }
        
        static void List(string entity)
        {if(entity=="Game")
            { List<Game> games = rest.Get<Game>("Game");
                foreach (var item in games)
                { Console.WriteLine(item.Name); }
                Thread.Sleep(2500);
            }
            
            if(entity=="Studio")
            {
                List<Studio> studios = rest.Get<Studio>("Studio");
                foreach (var item in studios)
                { Console.WriteLine(item.StudioName); }
                Thread.Sleep(2500);
            }
            
         if(entity=="Minimal")
            {
               
                
                List<MinimalSystemRequirements> mins = rest.Get<MinimalSystemRequirements>("MinimalSystemRequriements");
                foreach (var item in mins)
                { Console.WriteLine("Id: " + item.MinimalSystemRequirementsId + "Operating System: "+item.OperatingSystem); }
                    Thread.Sleep(2500);
                
            }
            
            
        }
        static void Read(string entity)
        { if (entity == "Game")
            { Console.WriteLine("Enter the Game ID");
               int gameid = int.Parse(Console.ReadLine());
                try { var item = rest.Get<Game>(gameid, "Game");
                    Console.WriteLine("This Game ID:" + item.Id + "StudioId" + item.StudioId + "Minimal System RequriementsId:" + item.MinimalSystemRequirementsId + "Name" + item.Name + "AgeLimit" + item.Age_Limit + "Appearance" + item.Appearance + "Price" + item.Price);
                    Thread.Sleep(2500);
                }
                catch(Exception e)
                { Console.WriteLine(e.Message); }
                Thread.Sleep(2500);
            }
            if (entity == "Studio")
            { Console.WriteLine("Enter the Studio ID");
                int studioid = int.Parse(Console.ReadLine());
                try { var item = rest.Get<Studio>(studioid, "Studio");
                    Console.WriteLine("This Studio ID:" + item.StudioId+"Name"+item.StudioName);
                    Thread.Sleep(2500);
                }
                catch(Exception e)
                { Console.WriteLine(e.Message); }
                Thread.Sleep(2500);
            }
            if(entity=="Minimal")
            { Console.WriteLine("Enter MinimalSystemRequirementsID");
                int minid = int.Parse(Console.ReadLine());
                try { var item = rest.Get<MinimalSystemRequirements>(minid,"MinimalSystemRequirements");
                    Console.WriteLine("This Minimal System Requirements ID: " + item.MinimalSystemRequirementsId + "Operating System: " + item.OperatingSystem + "Ram Size" + item.RAM_size + "SSD SPACe" + item.SSD_space + "CPU Brand" + item.CPU_Brand + "CPU CLOCK SPEED" + item.CPU_ClockSpeed + "VGA BRAND" + item.VGA_Brand + "VGA Memory Size" + item.VGA_MemorySize);
                    Thread.Sleep(2500);
                }
                catch(Exception e)
                { Console.WriteLine(e.Message); }
                Thread.Sleep(2500);
            }
        }
        static void Update(string entity)
        { if (entity == "Game")
            {
                Console.WriteLine
                    ("Enter the Id of the game:");
               int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Studio Id:");
                int studioId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Minimal System RequirementsId");
                int minId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the game's name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the game's age limit");
                int ageLimit = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the game's appearance year");
                int appearance = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the game's price ");
                int price = int.Parse(Console.ReadLine());
              //  var old = rest.Get<Game>(id,"Game");
              //  Console.WriteLine("the old game's Id:"+old.Id +"StudioId"+ old.StudioId +"MinimalSystemRequrementsId"+ old.MinimalSystemRequirementsId +"Name"+ old.Name +"Age Limit"+ old.Age_Limit +"Appearance"+ old.Appearance + "Price"+old.Price);
                rest.Put<Game>(new Game(id, studioId, minId, name, ageLimit, appearance, price),"Game");
               // var updated = rest.Get<Game>(id, "Game");
                //Console.WriteLine("the new game's Id:" + updated.Id + "StudioId" + updated.StudioId + "MinimalSystemRequrementsId" + updated.MinimalSystemRequirementsId + "Name" + updated.Name + "Age Limit" + updated.Age_Limit + "Appearance" + updated.Appearance + "Price" + updated.Price);
                Thread.Sleep(2500);
            }
        if(entity=="Studio")
            { Console.WriteLine("Enter the Studio Id");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Studio name");
                string name = Console.ReadLine();
            //    var old = rest.Get<Studio>(id,"Studio");
                //Console.WriteLine("the old studio's id:" + old.StudioId + "name:" + old.StudioName);
                rest.Put<Studio>(new Studio(id, name), "Studio");
              //  var updated = rest.Get<Studio>(id, "Studio");
               // Console.WriteLine("the updated studio's id:" + updated.StudioId + "name:" + updated.StudioName);
                Thread.Sleep(2500);
            }
        if(entity=="Minimal")
            { Console.WriteLine("Enter the Requirements id");
                int Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Operation System's name");
                string Os = Console.ReadLine();
                Console.WriteLine("Enter the Ram size");
                double ram = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the ssd space");
                double space = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the CPU's brand");
                string brand = Console.ReadLine();
                Console.WriteLine("Enter the CPU's clockspeed");
                double cpuclock = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Vga brand ");
                string vgabrand = Console.ReadLine();
                Console.WriteLine("Enter the VGA1s clockspeed");
                int vgamemorysize = int.Parse(Console.ReadLine());
             //   var old = rest.Get<MinimalSystemRequirements>(Id, "MinimalSystemRequirements");
             //   Console.WriteLine("Old requirement's Id" + old.MinimalSystemRequirementsId + "Operating System" + old.OperatingSystem + "Ram size" + old.RAM_size + "Cpu brand" + old.CPU_Brand + "Cpu clockspeed" + old.CPU_ClockSpeed + "VgaBrand" + old.VGA_Brand + "VgaMemorySize" + old.VGA_MemorySize);
                rest.Put<MinimalSystemRequirements>(new MinimalSystemRequirements(Id,Os,ram,space,brand,cpuclock,vgabrand,vgamemorysize), "MinimalSystemRequirements");
              //  var updated= rest.Get<MinimalSystemRequirements>(Id, "MinimalSystemRequirements");
               // Console.WriteLine("New requirement's Id" + updated.MinimalSystemRequirementsId + "Operating System" + updated.OperatingSystem + "Ram size" + updated.RAM_size + "Cpu brand" + updated.CPU_Brand + "Cpu clockspeed" + updated.CPU_ClockSpeed + "VgaBrand" + updated.VGA_Brand + "VgaMemorySize" + updated.VGA_MemorySize);
                Thread.Sleep(2500);
            }
       
            
        }
        static void Delete(string entity)
        { if(entity=="Game")
            { Console.WriteLine("ID:");
                int id = int.Parse(Console.ReadLine());
                try { rest.Delete(id, "Game"); }
                catch (Exception e)
                { Console.WriteLine(e.Message);
                    Thread.Sleep(2500);
                }
            }
            if (entity == "Minimal")
            {
                Console.WriteLine("ID:");
                int id = int.Parse(Console.ReadLine());
                try { rest.Delete(id, "MinimalSystemRequirements"); }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(2500);
                }
            }
            if (entity == "Studio")
            {
                Console.WriteLine("ID:");
                int id = int.Parse(Console.ReadLine());
                try { rest.Delete(id, "Studio"); }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(2500);
                }
            }
        }
        

       
       
        

      
       
        static void ActivisionsGamePriceAverage()
        { Console.WriteLine("Activisions game price average: "+rest.GetSingle<double>("Stat/ActivisionsGamePriceAverage"));
            Thread.Sleep(2500);
        }
        static void ContendoCount()
        { Console.WriteLine("Contendo's game count: "+rest.GetSingle<int>("Stat/ContendoCount"));
            Thread.Sleep(2500);
        }

        static void CountOfWin98()
        { Console.WriteLine("Count of Windows 98 Games: "+rest.GetSingle<int>("Stat/CountOfWin98"));
            Thread.Sleep(2500);
        }
        static void NewestGame()
        { Console.WriteLine("The Newest Game's Studio Name:"+rest.GetSingle<string>("Stat/NewestGame"));
            Thread.Sleep(2500);
        }
        static void FirstRockstar()
        { Console.WriteLine("The oldest Rockstar's Game Appereance Year: "+rest.GetSingle<int>("Stat/FirstRockstar"));
            Thread.Sleep(2500);
        }
        static void Main(string[] args)
        {
             rest = new RestService("http://localhost:18902/","game");

            var studioSubMenu = new ConsoleMenu(args, level: 1).Add("List", () => List("Studio")).Add("Create", () => Create("Studio")).Add("Delete", () => Delete("Studio")).Add("Update", () => Update("Studio")).Add("Read",()=>Read("Studio")).Add("Exit",ConsoleMenu.Close);
            var minSubMenu = new ConsoleMenu(args, level: 1).Add("List", () => List("Minimal")).Add("Create", () => Create("Minimal")).Add("Delete", () => Delete("Minimal")).Add("Update", () => Update("Minimal")).Add("Read",()=>Read("Minimal")).Add("Exit",ConsoleMenu.Close);
            var gameSubMenu = new ConsoleMenu(args, level: 1).Add("List", () => List("Game")).Add("Create", () => Create("Game")).Add("Delete", () => Delete("Game")).Add("Update", () => Update("Game")).Add("Read",()=>Read("Game")).Add("ActivisionsGamePriceAverage",()=>ActivisionsGamePriceAverage()).Add("ContendoCount",()=>ContendoCount()).Add("CountOfWin98",()=>CountOfWin98()).Add("NewestGame",()=>NewestGame()).Add("FirstRockstar",()=>FirstRockstar()).Add("Exit",ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0).Add("Games", () => gameSubMenu.Show()).Add("Studios", () => studioSubMenu.Show()).Add("Minimal System Requriements", () => minSubMenu.Show()).Add("Exit",ConsoleMenu.Close);

            menu.Show();

        }
    }
}
