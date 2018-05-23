using FileSystemViewer.Engine.Components.Behaviors;
using FileSystemViewer.Engine.Input;
using FileSystemViewer.Logic.Managers.Refreshes;
using System;

namespace FileSystemViewer.Logic.Behaviors.InputBehaviors
{
    internal sealed class InputBehavior : IInputBehavior
    {
        private readonly IRefreshManager refreshManager;

        public InputBehavior(IRefreshManager refreshManager)
        {
            this.refreshManager = refreshManager;
        }

        public bool IsEnabled => true;

        public void ProcessInput(IPressedKeysManager manager)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey(intercept: true);

                string name = info.Key.ToString();
                bool isDefined = Enum.TryParse(name, out Key consoleKey);
                if (isDefined)
                {
                    manager.PressedKeys.Add(consoleKey);
                    refreshManager.CanRefresh = true;
                }
                else
                {
                    refreshManager.CanRefresh = false;
                }
            }
        }
    }
}