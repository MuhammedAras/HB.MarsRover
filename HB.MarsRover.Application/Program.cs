using HB.MarsRover.Abstractions;
using HB.MarsRover.Core;
using HB.MarsRover.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace HB.MarsRover.Application
{
    class Program
    {
        private static IServiceProvider serviceProvider;
        private static IInputParser inputParser;

        private const string OUTPUT_FORMAT = "{0}, {1} {2}";

        static void Main(string[] args)
        {
            serviceProvider = DependecyResolver.RegisterServices();
            inputParser = serviceProvider.GetService<IInputParser>();

            try
            {
                Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            serviceProvider.DisposeServices();
        }

        private static void Start()
        {
            IPlateau plateau = GetPlateau();

            plateau.Rovers = GetRovers(plateau);

            Console.WriteLine("Expected Output:");
            foreach (var rover in plateau.Rovers)
            {
                IRoverCommandCenter commandCenter = serviceProvider.GetService<IRoverCommandCenter>();

                commandCenter.Rover = rover;
                commandCenter.HandleCommands();
                commandCenter.ExecuteCommands();
                
                Console.WriteLine(string.Format(OUTPUT_FORMAT, commandCenter.Rover.Position.X, commandCenter.Rover.Position.Y, commandCenter.Rover.Direction.ToString()));
            }
        }

        private static IPlateau GetPlateau()
        {
            IPlateau plateau = serviceProvider.GetService<IPlateau>();
            bool isInvalid = true;
            
            while (isInvalid)
            {
                Console.WriteLine("Plateau size: ");
                var plateauSize = Console.ReadLine();
                isInvalid = !inputParser.TryParsePlateauInput(plateauSize, plateau);

                if(isInvalid)
                    Console.WriteLine("Please enter valid coordinates!");
            }

            return plateau;
        }

        private static List<IRover> GetRovers(IPlateau plateau)
        {
            List<IRover> rovers = new List<IRover>();
            bool isAddAnotherRover = true;

            while (isAddAnotherRover)
            {
                IRover rover = serviceProvider.GetService<IRover>();
                rover.Plateau = plateau;

                Console.WriteLine("Rover Position: ");
                var roverPosition = Console.ReadLine();

                bool isValid = inputParser.TryParseRoverInput(roverPosition, rover);
                
                if (!isValid)
                    Console.WriteLine("Please enter valid coordinates and direction!");
                else
                {
                    bool isInvalidCommands = true;

                    while (isInvalidCommands)
                    {
                        Console.WriteLine("Commands: ");
                        var commandsInput = Console.ReadLine();
                        isInvalidCommands = !inputParser.TryParseCommandnput(commandsInput, rover);

                        if (isInvalidCommands)
                        {
                            Console.WriteLine("Please enter valid command letters! (M, R, L) ");
                            rover.Commands.Clear();
                        }
                        else
                        {
                            rovers.Add(rover);
                        }
                    }

                    Console.WriteLine("Do you want to land another rover? (Y/N) ");
                    var yesOrNo = Console.ReadLine();

                    if (yesOrNo.ToUpper() != "Y")
                        isAddAnotherRover = false;
                }          
            }

            return rovers;
        }

    }
}
