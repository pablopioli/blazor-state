namespace BlazorState.Features.Routing
{
  using BlazorState;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using System.Threading;
  using System.Threading.Tasks;

  public partial class RouteState
  {
    internal class InitializeRouteHandler : ActionHandler<InitializeRouteAction>
    {
      public InitializeRouteHandler
      (
        IStore aStore,
        NavigationManager aNavigationManager
      ) : base(aStore)
      {
        NavigationManager = aNavigationManager;
      }

      private RouteState RouteState => Store.GetState<RouteState>();

      private readonly NavigationManager NavigationManager;

      public override Task<Unit> Handle(InitializeRouteAction aInitializeRouteRequest, CancellationToken aCancellationToken)
      {
        RouteState.Route = NavigationManager.Uri;
        return Unit.Task;
      }
    }
  }
}