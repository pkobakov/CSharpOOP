using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        //AddPlayer { player type} { player username}
        //AddCard { card type} { card name}
        //AddPlayerCard { username} { card name}
        //Fight { attack user} { enemy user}
        //Report

        private IReader Reader;
        private IWriter Writer;
        private IManagerController Controller;

        public Engine(IReader reader, IWriter writer)
        {
            Reader = reader;
            Writer = writer;
            Controller = new ManagerController();
        }

        public void Run()
        {

            while (true)
            {
               

                try
                {
                    string[] input = Reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string command = input[0];

                    if (command == "Exit")
                    {
                        Environment.Exit(0);
                    }

                    else if (command == "AddPlayer")
                    {
                        Writer.WriteLine(Controller.AddPlayer(input[1], input[2]));
                    }

                    else if (command == "AddCard")
                    {
                        Writer.WriteLine(Controller.AddCard(input[1], input[2]));
                    }

                    else if (command == "AddPlayerCard")
                    {
                        Writer.WriteLine(Controller.AddPlayerCard(input[1], input[2]));
                    }

                    else if (command == "Fight")
                    {
                        Writer.WriteLine(Controller.Fight(input[1], input[2]));
                    }

                    else if (command == "Report")
                    {
                        Writer.WriteLine(Controller.Report());
                    }
                }
                catch (Exception ae)
                {

                    Writer.WriteLine(ae.Message);
                }

            }
        



        }
    }
}
