using FilySystemViewer.Engine.Components;
using FilySystemViewer.Engine.Components.Behaviors;
using FilySystemViewer.Engine.Components.Behaviors.Factories;
using FilySystemViewer.Engine.Frames;
using FilySystemViewer.Engine.Input;
using FilySystemViewer.Graphics;
using FilySystemViewer.Logic;
using FilySystemViewer.Logic.Behaviors;
using FilySystemViewer.Logic.Behaviors.DrawBehaviors;
using FilySystemViewer.Logic.Behaviors.DrawBehaviors.DrawConnectionBehavior;
using FilySystemViewer.Logic.Behaviors.DrawBehaviors.DrawEntryBehaviors;
using FilySystemViewer.Logic.Behaviors.InputBehaviors;
using FilySystemViewer.Logic.Behaviors.UpdateBehaviors;
using FilySystemViewer.Logic.Behaviors.UpdateBehaviors.MoveBehaviors;
using FilySystemViewer.Logic.Behaviors.UpdateBehaviors.UpdatePositionBehavior;
using FilySystemViewer.Logic.Behaviors.UpdateBehaviours;
using FilySystemViewer.Logic.Managers.CreatedEntriesList;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Managers.Sizes;
using FilySystemViewer.Logic.Objects.FileSystemEntries;
using FilySystemViewer.Logic.Objects.FileSystemEntries.FileSystemFactories;
using Ninject;
using System;

namespace FilySystemViewer
{
    internal sealed class Application : IRunnable
    {
        private readonly Lazy<IKernel> container;

        public Application()
        {
            container = new Lazy<IKernel>(CreateContainer);
        }

        private IKernel CreateContainer()
        {
            var container = new StandardKernel();

            container.Bind<IFrameRunner>().To<SettingsAdjustmentFrameRunner>();
            container.Bind<IFrameRunner>().To<InputFrameRunner>();
            container.Bind<IFrameRunner>().To<UpdateFrameRunner>();
            container.Bind<IFrameRunner>().To<DrawFrameRunner>();
            container.Bind<IFrameRunner>().To<ResetFrameRunner>();

            container.Bind<IRenderer>().To<ConsoleRenderer>().InSingletonScope();
            container.Bind<ISizeProvider>().To<SizeProvider>().InSingletonScope();
            container.Bind<ISelectedProvider, ISelectedManager>().To<SelectManager>().InSingletonScope();
            container.Bind<ISystemRootProvider, ISystemRootManager>().To<SystemRootManager>().InSingletonScope();
            container.Bind<ICreatedEntriesProvider, ICreatedEntriesManager>().To<CreatedEntries>().InSingletonScope();
            container.Bind<IPressedKeysProvider, IPressedKeysManager>().To<PressedKeysManager>().InSingletonScope();
            container.Bind<IRefreshProvider, IRefreshManager>().To<RefreshManager>().InSingletonScope();
            container.Bind<IFileSystemFactory<FileSystemEntry>>().To<FileSystemFactory>().InSingletonScope();

            container.Bind<IComponentProvider>().To<ComponentProvider>();

            container.Bind<IComponentFinder>().To<ComponentFinder<ISettingsAdjustmentBehavior>>();
            container.Bind<IComponentFinder>().To<ComponentFinder<IInputBehavior>>();
            container.Bind<IComponentFinder>().To<ComponentFinder<IUpdateBehavior>>();
            container.Bind<IComponentFinder>().To<ComponentFinder<IDrawBehavior>>();
            container.Bind<IComponentFinder>().To<ComponentFinder<IResetBehavior>>();

            container.Bind<IComponentFactory<ISettingsAdjustmentBehavior>>().To<SettingsAdjustmentFactory>();
            container.Bind<IComponentFactory<IInputBehavior>>().To<InputComponentFactory>();
            container.Bind<IComponentFactory<IUpdateBehavior>>().To<UpdateComponentFactory>();
            container.Bind<IComponentFactory<IDrawBehavior>>().To<DrawComponentFactory>();
            container.Bind<IComponentFactory<IResetBehavior>>().To<ResetComponentFactory>();

            container.Bind<ISettingsAdjustmentBehavior>().To<InitializeRootBehavior>();
            container.Bind<ISettingsAdjustmentBehavior>().To<WindowSetUpBehavior>();
            container.Bind<IInputBehavior>().To<InputBehavior>();
            container.Bind<IUpdateBehavior>().To<MoveDownBehavior>();
            container.Bind<IUpdateBehavior>().To<MoveUpBehavior>();
            container.Bind<IUpdateBehavior>().To<MoveRightBehavior>();
            container.Bind<IUpdateBehavior>().To<MoveLeftBehavior>();
            container.Bind<IUpdateBehavior>().To<CollapseBehavior>();
            container.Bind<IUpdateBehavior>().To<CreateEntriesBehavior>();
            container.Bind<IUpdateBehavior>().To<ExpandBehavior>();
            container.Bind<IUpdateBehavior>().To<UpdatePositionAfterSelectedBehavior>();
            container.Bind<IUpdateBehavior>().To<UpdateAllPositionsBehavior>();
            container.Bind<IDrawBehavior>().To<CleanScreenBehavior>();
            container.Bind<IDrawBehavior>().To<PCDrawBehavior>();
            container.Bind<IDrawBehavior>().To<LogicalDriveDrawBehavior>();
            container.Bind<IDrawBehavior>().To<FolderDrawBehavior>();
            container.Bind<IDrawBehavior>().To<FileDrawBehavior>();
            container.Bind<IDrawBehavior>().To<DrawRepositoryConnectionBehavior>();
            container.Bind<IDrawBehavior>().To<DrawFileConnectionBehavior>();
            container.Bind<IResetBehavior>().To<ResetBehavior>();

            return container;
        }

        public void Run()
        {
            ApplicationLogic applicationLogic = container.Value.Get<ApplicationLogic>();
            applicationLogic.Run();
        }
    }
}