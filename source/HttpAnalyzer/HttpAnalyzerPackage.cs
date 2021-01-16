using Microsoft.VisualStudio.Shell;

using System;
using System.Runtime.InteropServices;
using System.Threading;

using Task = System.Threading.Tasks.Task;

namespace HttpAnalyzer
{
    [Guid(PackageGuidString)]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(HttpAnalyzerWindow))]
    public sealed class HttpAnalyzerPackage : AsyncPackage
    {
        public const string PackageGuidString = "ed5d736b-a951-4876-925c-78fd43d33006";

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await HttpAnalyzerWindowCommand.InitializeAsync(this);
        }
    }
}
