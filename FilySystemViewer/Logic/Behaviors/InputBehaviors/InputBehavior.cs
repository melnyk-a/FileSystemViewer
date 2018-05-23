using FilySystemViewer.Engine.Components.Behaviors;
using FilySystemViewer.Engine.Input;
using FilySystemViewer.Logic.Managers.Refreshes;
using System;

namespace FilySystemViewer.Logic.Behaviors.InputBehaviors
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