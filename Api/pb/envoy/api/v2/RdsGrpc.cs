// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: envoy/api/v2/rds.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Envoy.Api.V2 {
  /// <summary>
  /// The resource_names field in DiscoveryRequest specifies a route configuration.
  /// This allows an Envoy configuration with multiple HTTP listeners (and
  /// associated HTTP connection manager filters) to use different route
  /// configurations. Each listener will bind its HTTP connection manager filter to
  /// a route table via this identifier.
  /// </summary>
  public static partial class RouteDiscoveryService
  {
    static readonly string __ServiceName = "envoy.api.v2.RouteDiscoveryService";

    static readonly grpc::Marshaller<global::Envoy.Api.V2.DiscoveryRequest> __Marshaller_DiscoveryRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Envoy.Api.V2.DiscoveryRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Envoy.Api.V2.DiscoveryResponse> __Marshaller_DiscoveryResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Envoy.Api.V2.DiscoveryResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Envoy.Api.V2.DiscoveryRequest, global::Envoy.Api.V2.DiscoveryResponse> __Method_StreamRoutes = new grpc::Method<global::Envoy.Api.V2.DiscoveryRequest, global::Envoy.Api.V2.DiscoveryResponse>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "StreamRoutes",
        __Marshaller_DiscoveryRequest,
        __Marshaller_DiscoveryResponse);

    static readonly grpc::Method<global::Envoy.Api.V2.DiscoveryRequest, global::Envoy.Api.V2.DiscoveryResponse> __Method_FetchRoutes = new grpc::Method<global::Envoy.Api.V2.DiscoveryRequest, global::Envoy.Api.V2.DiscoveryResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "FetchRoutes",
        __Marshaller_DiscoveryRequest,
        __Marshaller_DiscoveryResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Envoy.Api.V2.RdsReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of RouteDiscoveryService</summary>
    public abstract partial class RouteDiscoveryServiceBase
    {
      public virtual global::System.Threading.Tasks.Task StreamRoutes(grpc::IAsyncStreamReader<global::Envoy.Api.V2.DiscoveryRequest> requestStream, grpc::IServerStreamWriter<global::Envoy.Api.V2.DiscoveryResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Envoy.Api.V2.DiscoveryResponse> FetchRoutes(global::Envoy.Api.V2.DiscoveryRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for RouteDiscoveryService</summary>
    public partial class RouteDiscoveryServiceClient : grpc::ClientBase<RouteDiscoveryServiceClient>
    {
      /// <summary>Creates a new client for RouteDiscoveryService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public RouteDiscoveryServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for RouteDiscoveryService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public RouteDiscoveryServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected RouteDiscoveryServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected RouteDiscoveryServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncDuplexStreamingCall<global::Envoy.Api.V2.DiscoveryRequest, global::Envoy.Api.V2.DiscoveryResponse> StreamRoutes(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return StreamRoutes(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::Envoy.Api.V2.DiscoveryRequest, global::Envoy.Api.V2.DiscoveryResponse> StreamRoutes(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_StreamRoutes, null, options);
      }
      public virtual global::Envoy.Api.V2.DiscoveryResponse FetchRoutes(global::Envoy.Api.V2.DiscoveryRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return FetchRoutes(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Envoy.Api.V2.DiscoveryResponse FetchRoutes(global::Envoy.Api.V2.DiscoveryRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_FetchRoutes, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Envoy.Api.V2.DiscoveryResponse> FetchRoutesAsync(global::Envoy.Api.V2.DiscoveryRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return FetchRoutesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Envoy.Api.V2.DiscoveryResponse> FetchRoutesAsync(global::Envoy.Api.V2.DiscoveryRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_FetchRoutes, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override RouteDiscoveryServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new RouteDiscoveryServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(RouteDiscoveryServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_StreamRoutes, serviceImpl.StreamRoutes)
          .AddMethod(__Method_FetchRoutes, serviceImpl.FetchRoutes).Build();
    }

  }
}
#endregion
