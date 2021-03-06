namespace TestApp.Client
{
  using BlazorState.Features.JavaScriptInterop;
  using BlazorState.Features.Routing;
  using BlazorState.Pipeline.ReduxDevTools;
  using Microsoft.AspNetCore.Components;
  using System.Threading.Tasks;

  public partial class App : ComponentBase
  {
    [Inject] private JsonRequestHandler JsonRequestHandler { get; set; }
#if ReduxDevToolsEnabled
    [Inject] private ReduxDevToolsInterop ReduxDevToolsInterop { get; set; }
#endif
    [
      System.Diagnostics.CodeAnalysis.SuppressMessage
      (
        "CodeQuality",
        "IDE0051:Remove unused private members",
        Justification = "Injected so it is created by the container. Even though the IDE says it is not used it is."
      )
    ]
    [Inject]
    private RouteManager RouteManager { get; set; }

    protected override async Task OnAfterRenderAsync(bool aFirstRender)
    {
#if ReduxDevToolsEnabled
      await ReduxDevToolsInterop.InitAsync();
#endif
      await JsonRequestHandler.InitAsync();
    }
  }
}