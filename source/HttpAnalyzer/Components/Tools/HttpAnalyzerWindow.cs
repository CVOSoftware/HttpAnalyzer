using Microsoft.VisualStudio.Shell;

using System;
using System.Runtime.InteropServices;

using HttpAnalyzer.Components.UserControls;

namespace HttpAnalyzer.Components.Tools
{
    [Guid(WindowGuidString)]
    public class HttpAnalyzerWindow : ToolWindowPane
    {
        public const string WindowGuidString = "6249e229-5805-4f2b-8155-bc101e35e9d4";

        public HttpAnalyzerWindow() : base(null)
        {
            Caption = "Http Analyzer";
            Content = new HttpAnalyzerWindowControl();
        }
    }
}
