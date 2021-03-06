// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: envoy/service/metrics/v2/metrics_service.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Envoy.Service.Metrics.V2 {
  /// <summary>
  /// Service for streaming metrics to server that consumes the metrics data. It uses Prometheus metric
  /// data model as a standard to represent metrics information.
  /// </summary>
  public static partial class MetricsService
  {
    static readonly string __ServiceName = "envoy.service.metrics.v2.MetricsService";

    static readonly grpc::Marshaller<global::Envoy.Service.Metrics.V2.StreamMetricsMessage> __Marshaller_StreamMetricsMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Envoy.Service.Metrics.V2.StreamMetricsMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Envoy.Service.Metrics.V2.StreamMetricsResponse> __Marshaller_StreamMetricsResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Envoy.Service.Metrics.V2.StreamMetricsResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Envoy.Service.Metrics.V2.StreamMetricsMessage, global::Envoy.Service.Metrics.V2.StreamMetricsResponse> __Method_StreamMetrics = new grpc::Method<global::Envoy.Service.Metrics.V2.StreamMetricsMessage, global::Envoy.Service.Metrics.V2.StreamMetricsResponse>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "StreamMetrics",
        __Marshaller_StreamMetricsMessage,
        __Marshaller_StreamMetricsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Envoy.Service.Metrics.V2.MetricsServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of MetricsService</summary>
    public abstract partial class MetricsServiceBase
    {
      /// <summary>
      /// Envoy will connect and send StreamMetricsMessage messages forever. It does not expect any
      /// response to be sent as nothing would be done in the case of failure.
      /// </summary>
      /// <param name="requestStream">Used for reading requests from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Envoy.Service.Metrics.V2.StreamMetricsResponse> StreamMetrics(grpc::IAsyncStreamReader<global::Envoy.Service.Metrics.V2.StreamMetricsMessage> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for MetricsService</summary>
    public partial class MetricsServiceClient : grpc::ClientBase<MetricsServiceClient>
    {
      /// <summary>Creates a new client for MetricsService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public MetricsServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for MetricsService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public MetricsServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected MetricsServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected MetricsServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Envoy will connect and send StreamMetricsMessage messages forever. It does not expect any
      /// response to be sent as nothing would be done in the case of failure.
      /// </summary>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncClientStreamingCall<global::Envoy.Service.Metrics.V2.StreamMetricsMessage, global::Envoy.Service.Metrics.V2.StreamMetricsResponse> StreamMetrics(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return StreamMetrics(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Envoy will connect and send StreamMetricsMessage messages forever. It does not expect any
      /// response to be sent as nothing would be done in the case of failure.
      /// </summary>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncClientStreamingCall<global::Envoy.Service.Metrics.V2.StreamMetricsMessage, global::Envoy.Service.Metrics.V2.StreamMetricsResponse> StreamMetrics(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_StreamMetrics, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override MetricsServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new MetricsServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(MetricsServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_StreamMetrics, serviceImpl.StreamMetrics).Build();
    }

  }
}
#endregion
