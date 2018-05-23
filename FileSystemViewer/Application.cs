using FileSystemViewer.Engine.Components;
using FileSystemViewer.Engine.Components.Behaviors;
using FileSystemViewer.Engine.Components.Behaviors.Factories;
using FileSystemViewer.Engine.Frames;
using FileSystemViewer.Engine.Input;
using FileSystemViewer.Graphics;
using FileSystemViewer.Logic;
using FileSystemViewer.Logic.Behaviors;
using FileSystemViewer.Logic.Behaviors.DrawBehaviors;
using FileSystemViewer.Logic.Behaviors.DrawBehaviors.DrawConnectionBehavior;
using FileSystemViewer.Logic.Behaviors.DrawBehaviors.DrawEntryBehaviors;
using FileSystemViewer.Logic.Behaviors.InputBehaviors;
using FileSystemViewer.Logic.Behaviors.UpdateBehaviors;
using FileSystemViewer.Logic.Behaviors.UpdateBehaviors.MoveBehaviors;
using FileSystemViewer.Logic.Behaviors.UpdateBehaviors.UpdatePositionBehavior;
using FileSystemViewer.Logic.Behaviors.UpdateBehaviours;
using FileSystemViewer.Logic.Managers.CreatedEntriesList;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Managers.Sizes;
using FileSystemViewer.Logic.Objects.FileSystemEntries;
using FileSystemViewer.Logic.Objects.FileSystemEntries.FileSystemFactories;
using Ninject;
using System;

namespace FileSystemViewer
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