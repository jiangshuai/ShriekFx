﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Shriek.Commands;
using Shriek.Samples.Commands;
using Shriek.Storage;

namespace Shriek.Samples.InProcess
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddShriek();

            var container = services.BuildServiceProvider();

            var bus = container.GetService<ICommandBus>();
            var eventStorage = container.GetService<IEventStorage>();

            var id = Guid.NewGuid();

            bus.Send(new CreateTodoCommand(id)
            {
                Name = "get up",
                Desception = "good day",
                FinishTime = DateTime.Now.AddDays(1)
            });

            Console.WriteLine($"{nameof(CreateTodoCommand)} sended!");

            bus.Send(new ChangeTodoCommand(id)
            {
                Name = "eat breakfast",
                Desception = "yummy!",
                FinishTime = DateTime.Now.AddDays(1)
            });

            Console.WriteLine($"{nameof(ChangeTodoCommand)} sended!");

            bus.Send(new ChangeTodoCommand(id)
            {
                Name = "go to work",
                Desception = "fighting!",
                FinishTime = DateTime.Now.AddDays(1)
            });
            Console.WriteLine($"{nameof(ChangeTodoCommand)} sended!");

            bus.Send(new ChangeTodoCommand(id)
            {
                Name = "call boss",
                Desception = "haha!",
                FinishTime = DateTime.Now.AddDays(1)
            });
            Console.WriteLine($"{nameof(ChangeTodoCommand)} sended!");

            bus.Send(new ChangeTodoCommand(id)
            {
                Name = "coding",
                Desception = "great!",
                FinishTime = DateTime.Now.AddDays(1)
            });
            Console.WriteLine($"{nameof(ChangeTodoCommand)} sended!");

            bus.Send(new ChangeTodoCommand(id)
            {
                Name = "drive car",
                Desception = "be careful!",
                FinishTime = DateTime.Now.AddDays(-1)
            });
            Console.WriteLine($"{nameof(ChangeTodoCommand)} sended!");

            Console.ReadKey();
        }
    }
}