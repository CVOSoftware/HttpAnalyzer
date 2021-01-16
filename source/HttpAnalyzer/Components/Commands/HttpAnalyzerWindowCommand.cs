using Microsoft.VisualStudio.Shell;

using System;
using System.ComponentModel.Design;
using Task = System.Threading.Tasks.Task;

using HttpAnalyzer.Components.Tools;

namespace HttpAnalyzer.Components.Commands
{
    internal sealed class HttpAnalyzerWindowCommand
    {
        #region Const

        public const int CommandId = 0x0100;

        #endregion

        private readonly AsyncPackage package;

        private HttpAnalyzerWindowCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandId = new CommandID(CommandGuid, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandId);

            commandService.AddCommand(menuItem);
        }

        private IAsyncServiceProvider ServiceProvider => package;

        private void Execute(object sender, EventArgs e)
        {
            package.JoinableTaskFactory.RunAsync(async () =>
            {
                var type = typeof(HttpAnalyzerWindow);
                var window = await package.ShowToolWindowAsync(type, 0, true, package.DisposalToken);

                if ((window == null) || (window.Frame == null))
                {
                    throw new NotSupportedException("Cannot create tool window");
                }
            });
        }

        #region Static

        public static readonly Guid CommandGuid = new Guid("e63f1f59-afac-4d65-934f-e12480f914fd");

        public static HttpAnalyzerWindowCommand Instance { get; private set; }

        public static async Task InitializeAsync(AsyncPackage package)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            var type = typeof(IMenuCommandService);
            var commandService = await package.GetServiceAsync(type) as OleMenuCommandService;
            
            Instance = new HttpAnalyzerWindowCommand(package, commandService);
        }

        #endregion
    }
}
