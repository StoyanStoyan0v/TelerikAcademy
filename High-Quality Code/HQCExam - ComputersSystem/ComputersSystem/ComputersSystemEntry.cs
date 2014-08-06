namespace ComputersSystem
{
    using System;
    using ComputersSystem.ComputerFactories;

    internal class ComputersSystemEntry
    {
        private static Manufacturer creator;

        private static Computer pc, laptop, server;

        public static void Main()
        {
            var manufacturer = Console.ReadLine();
            if (manufacturer == "HP")
            {
                creator = new HP();
                pc = creator.IntroducePC();
                server = creator.IntroduceServer();
                laptop = creator.IntroduceLaptop();
            }
            else if (manufacturer == "Dell")
            {
                creator = new Dell();
                pc = creator.IntroducePC();
                server = creator.IntroduceServer();
                laptop = creator.IntroduceLaptop();
            }
            else if (manufacturer == "Lenovo")
            {
                creator = new Lenovo();
                pc = creator.IntroducePC();
                server = creator.IntroduceServer();
                laptop = creator.IntroduceLaptop();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (command == null || command.StartsWith("Exit"))
                {
                    break;
                }

                var commandInfo = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commandInfo.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var commandName = commandInfo[0];
                var commandArgument = int.Parse(commandInfo[1]);

                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandArgument);
                }
                else if (commandName == "Play")
                {
                    pc.Play(commandArgument);
                }

                continue;
            }
        }
    }
}