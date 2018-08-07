// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: envoy/config/accesslog/v2/als.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Envoy.Config.Accesslog.V2 {

  /// <summary>Holder for reflection information generated from envoy/config/accesslog/v2/als.proto</summary>
  public static partial class AlsReflection {

    #region Descriptor
    /// <summary>File descriptor for envoy/config/accesslog/v2/als.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AlsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiNlbnZveS9jb25maWcvYWNjZXNzbG9nL3YyL2Fscy5wcm90bxIZZW52b3ku",
            "Y29uZmlnLmFjY2Vzc2xvZy52MhokZW52b3kvYXBpL3YyL2NvcmUvZ3JwY19z",
            "ZXJ2aWNlLnByb3RvGhd2YWxpZGF0ZS92YWxpZGF0ZS5wcm90byL2AQoXSHR0",
            "cEdycGNBY2Nlc3NMb2dDb25maWcSVwoNY29tbW9uX2NvbmZpZxgBIAEoCzI0",
            "LmVudm95LmNvbmZpZy5hY2Nlc3Nsb2cudjIuQ29tbW9uR3JwY0FjY2Vzc0xv",
            "Z0NvbmZpZ0IKuunAAwWKAQIQARIpCiFhZGRpdGlvbmFsX3JlcXVlc3RfaGVh",
            "ZGVyc190b19sb2cYAiADKAkSKgoiYWRkaXRpb25hbF9yZXNwb25zZV9oZWFk",
            "ZXJzX3RvX2xvZxgDIAMoCRIrCiNhZGRpdGlvbmFsX3Jlc3BvbnNlX3RyYWls",
            "ZXJzX3RvX2xvZxgEIAMoCSJxChZUY3BHcnBjQWNjZXNzTG9nQ29uZmlnElcK",
            "DWNvbW1vbl9jb25maWcYASABKAsyNC5lbnZveS5jb25maWcuYWNjZXNzbG9n",
            "LnYyLkNvbW1vbkdycGNBY2Nlc3NMb2dDb25maWdCCrrpwAMFigECEAEiegoZ",
            "Q29tbW9uR3JwY0FjY2Vzc0xvZ0NvbmZpZxIbCghsb2dfbmFtZRgBIAEoCUIJ",
            "uunAAwRyAiABEkAKDGdycGNfc2VydmljZRgCIAEoCzIeLmVudm95LmFwaS52",
            "Mi5jb3JlLkdycGNTZXJ2aWNlQgq66cADBYoBAhABQgRaAnYyYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Envoy.Api.V2.Core.GrpcServiceReflection.Descriptor, global::Validate.ValidateReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Envoy.Config.Accesslog.V2.HttpGrpcAccessLogConfig), global::Envoy.Config.Accesslog.V2.HttpGrpcAccessLogConfig.Parser, new[]{ "CommonConfig", "AdditionalRequestHeadersToLog", "AdditionalResponseHeadersToLog", "AdditionalResponseTrailersToLog" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Envoy.Config.Accesslog.V2.TcpGrpcAccessLogConfig), global::Envoy.Config.Accesslog.V2.TcpGrpcAccessLogConfig.Parser, new[]{ "CommonConfig" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Envoy.Config.Accesslog.V2.CommonGrpcAccessLogConfig), global::Envoy.Config.Accesslog.V2.CommonGrpcAccessLogConfig.Parser, new[]{ "LogName", "GrpcService" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Configuration for the built-in *envoy.http_grpc_access_log*
  /// :ref:`AccessLog &lt;envoy_api_msg_config.filter.accesslog.v2.AccessLog>`. This configuration will
  /// populate :ref:`StreamAccessLogsMessage.http_logs
  /// &lt;envoy_api_field_service.accesslog.v2.StreamAccessLogsMessage.http_logs>`.
  /// </summary>
  public sealed partial class HttpGrpcAccessLogConfig : pb::IMessage<HttpGrpcAccessLogConfig> {
    private static readonly pb::MessageParser<HttpGrpcAccessLogConfig> _parser = new pb::MessageParser<HttpGrpcAccessLogConfig>(() => new HttpGrpcAccessLogConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<HttpGrpcAccessLogConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Envoy.Config.Accesslog.V2.AlsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HttpGrpcAccessLogConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HttpGrpcAccessLogConfig(HttpGrpcAccessLogConfig other) : this() {
      CommonConfig = other.commonConfig_ != null ? other.CommonConfig.Clone() : null;
      additionalRequestHeadersToLog_ = other.additionalRequestHeadersToLog_.Clone();
      additionalResponseHeadersToLog_ = other.additionalResponseHeadersToLog_.Clone();
      additionalResponseTrailersToLog_ = other.additionalResponseTrailersToLog_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HttpGrpcAccessLogConfig Clone() {
      return new HttpGrpcAccessLogConfig(this);
    }

    /// <summary>Field number for the "common_config" field.</summary>
    public const int CommonConfigFieldNumber = 1;
    private global::Envoy.Config.Accesslog.V2.CommonGrpcAccessLogConfig commonConfig_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Envoy.Config.Accesslog.V2.CommonGrpcAccessLogConfig CommonConfig {
      get { return commonConfig_; }
      set {
        commonConfig_ = value;
      }
    }

    /// <summary>Field number for the "additional_request_headers_to_log" field.</summary>
    public const int AdditionalRequestHeadersToLogFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _repeated_additionalRequestHeadersToLog_codec
        = pb::FieldCodec.ForString(18);
    private readonly pbc::RepeatedField<string> additionalRequestHeadersToLog_ = new pbc::RepeatedField<string>();
    /// <summary>
    /// Additional request headers to log in :ref:`HTTPRequestProperties.request_headers
    /// &lt;envoy_api_field_data.accesslog.v2.HTTPRequestProperties.request_headers>`.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> AdditionalRequestHeadersToLog {
      get { return additionalRequestHeadersToLog_; }
    }

    /// <summary>Field number for the "additional_response_headers_to_log" field.</summary>
    public const int AdditionalResponseHeadersToLogFieldNumber = 3;
    private static readonly pb::FieldCodec<string> _repeated_additionalResponseHeadersToLog_codec
        = pb::FieldCodec.ForString(26);
    private readonly pbc::RepeatedField<string> additionalResponseHeadersToLog_ = new pbc::RepeatedField<string>();
    /// <summary>
    /// Additional response headers to log in :ref:`HTTPResponseProperties.response_headers
    /// &lt;envoy_api_field_data.accesslog.v2.HTTPResponseProperties.response_headers>`.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> AdditionalResponseHeadersToLog {
      get { return additionalResponseHeadersToLog_; }
    }

    /// <summary>Field number for the "additional_response_trailers_to_log" field.</summary>
    public const int AdditionalResponseTrailersToLogFieldNumber = 4;
    private static readonly pb::FieldCodec<string> _repeated_additionalResponseTrailersToLog_codec
        = pb::FieldCodec.ForString(34);
    private readonly pbc::RepeatedField<string> additionalResponseTrailersToLog_ = new pbc::RepeatedField<string>();
    /// <summary>
    /// Additional response trailers to log in :ref:`HTTPResponseProperties.response_trailers
    /// &lt;envoy_api_field_data.accesslog.v2.HTTPResponseProperties.response_trailers>`.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> AdditionalResponseTrailersToLog {
      get { return additionalResponseTrailersToLog_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as HttpGrpcAccessLogConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(HttpGrpcAccessLogConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(CommonConfig, other.CommonConfig)) return false;
      if(!additionalRequestHeadersToLog_.Equals(other.additionalRequestHeadersToLog_)) return false;
      if(!additionalResponseHeadersToLog_.Equals(other.additionalResponseHeadersToLog_)) return false;
      if(!additionalResponseTrailersToLog_.Equals(other.additionalResponseTrailersToLog_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (commonConfig_ != null) hash ^= CommonConfig.GetHashCode();
      hash ^= additionalRequestHeadersToLog_.GetHashCode();
      hash ^= additionalResponseHeadersToLog_.GetHashCode();
      hash ^= additionalResponseTrailersToLog_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (commonConfig_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(CommonConfig);
      }
      additionalRequestHeadersToLog_.WriteTo(output, _repeated_additionalRequestHeadersToLog_codec);
      additionalResponseHeadersToLog_.WriteTo(output, _repeated_additionalResponseHeadersToLog_codec);
      additionalResponseTrailersToLog_.WriteTo(output, _repeated_additionalResponseTrailersToLog_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (commonConfig_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CommonConfig);
      }
      size += additionalRequestHeadersToLog_.CalculateSize(_repeated_additionalRequestHeadersToLog_codec);
      size += additionalResponseHeadersToLog_.CalculateSize(_repeated_additionalResponseHeadersToLog_codec);
      size += additionalResponseTrailersToLog_.CalculateSize(_repeated_additionalResponseTrailersToLog_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(HttpGrpcAccessLogConfig other) {
      if (other == null) {
        return;
      }
      if (other.commonConfig_ != null) {
        if (commonConfig_ == null) {
          commonConfig_ = new global::Envoy.Config.Accesslog.V2.CommonGrpcAccessLogConfig();
        }
        CommonConfig.MergeFrom(other.CommonConfig);
      }
      additionalRequestHeadersToLog_.Add(other.additionalRequestHeadersToLog_);
      additionalResponseHeadersToLog_.Add(other.additionalResponseHeadersToLog_);
      additionalResponseTrailersToLog_.Add(other.additionalResponseTrailersToLog_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (commonConfig_ == null) {
              commonConfig_ = new global::Envoy.Config.Accesslog.V2.CommonGrpcAccessLogConfig();
            }
            input.ReadMessage(commonConfig_);
            break;
          }
          case 18: {
            additionalRequestHeadersToLog_.AddEntriesFrom(input, _repeated_additionalRequestHeadersToLog_codec);
            break;
          }
          case 26: {
            additionalResponseHeadersToLog_.AddEntriesFrom(input, _repeated_additionalResponseHeadersToLog_codec);
            break;
          }
          case 34: {
            additionalResponseTrailersToLog_.AddEntriesFrom(input, _repeated_additionalResponseTrailersToLog_codec);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// Configuration for the built-in *envoy.tcp_grpc_access_log* type. This configuration will
  /// populate *StreamAccessLogsMessage.tcp_logs*.
  /// [#not-implemented-hide:]
  /// </summary>
  public sealed partial class TcpGrpcAccessLogConfig : pb::IMessage<TcpGrpcAccessLogConfig> {
    private static readonly pb::MessageParser<TcpGrpcAccessLogConfig> _parser = new pb::MessageParser<TcpGrpcAccessLogConfig>(() => new TcpGrpcAccessLogConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TcpGrpcAccessLogConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Envoy.Config.Accesslog.V2.AlsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TcpGrpcAccessLogConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TcpGrpcAccessLogConfig(TcpGrpcAccessLogConfig other) : this() {
      CommonConfig = other.commonConfig_ != null ? other.CommonConfig.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TcpGrpcAccessLogConfig Clone() {
      return new TcpGrpcAccessLogConfig(this);
    }

    /// <summary>Field number for the "common_config" field.</summary>
    public const int CommonConfigFieldNumber = 1;
    private global::Envoy.Config.Accesslog.V2.CommonGrpcAccessLogConfig commonConfig_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Envoy.Config.Accesslog.V2.CommonGrpcAccessLogConfig CommonConfig {
      get { return commonConfig_; }
      set {
        commonConfig_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TcpGrpcAccessLogConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TcpGrpcAccessLogConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(CommonConfig, other.CommonConfig)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (commonConfig_ != null) hash ^= CommonConfig.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (commonConfig_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(CommonConfig);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (commonConfig_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CommonConfig);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TcpGrpcAccessLogConfig other) {
      if (other == null) {
        return;
      }
      if (other.commonConfig_ != null) {
        if (commonConfig_ == null) {
          commonConfig_ = new global::Envoy.Config.Accesslog.V2.CommonGrpcAccessLogConfig();
        }
        CommonConfig.MergeFrom(other.CommonConfig);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (commonConfig_ == null) {
              commonConfig_ = new global::Envoy.Config.Accesslog.V2.CommonGrpcAccessLogConfig();
            }
            input.ReadMessage(commonConfig_);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// Common configuration for gRPC access logs.
  /// </summary>
  public sealed partial class CommonGrpcAccessLogConfig : pb::IMessage<CommonGrpcAccessLogConfig> {
    private static readonly pb::MessageParser<CommonGrpcAccessLogConfig> _parser = new pb::MessageParser<CommonGrpcAccessLogConfig>(() => new CommonGrpcAccessLogConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CommonGrpcAccessLogConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Envoy.Config.Accesslog.V2.AlsReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CommonGrpcAccessLogConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CommonGrpcAccessLogConfig(CommonGrpcAccessLogConfig other) : this() {
      logName_ = other.logName_;
      GrpcService = other.grpcService_ != null ? other.GrpcService.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CommonGrpcAccessLogConfig Clone() {
      return new CommonGrpcAccessLogConfig(this);
    }

    /// <summary>Field number for the "log_name" field.</summary>
    public const int LogNameFieldNumber = 1;
    private string logName_ = "";
    /// <summary>
    /// The friendly name of the access log to be returned in :ref:`StreamAccessLogsMessage.Identifier
    /// &lt;envoy_api_msg_service.accesslog.v2.StreamAccessLogsMessage.Identifier>`. This allows the
    /// access log server to differentiate between different access logs coming from the same Envoy.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string LogName {
      get { return logName_; }
      set {
        logName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "grpc_service" field.</summary>
    public const int GrpcServiceFieldNumber = 2;
    private global::Envoy.Api.V2.Core.GrpcService grpcService_;
    /// <summary>
    /// The gRPC service for the access log service.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Envoy.Api.V2.Core.GrpcService GrpcService {
      get { return grpcService_; }
      set {
        grpcService_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CommonGrpcAccessLogConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CommonGrpcAccessLogConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (LogName != other.LogName) return false;
      if (!object.Equals(GrpcService, other.GrpcService)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (LogName.Length != 0) hash ^= LogName.GetHashCode();
      if (grpcService_ != null) hash ^= GrpcService.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (LogName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(LogName);
      }
      if (grpcService_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(GrpcService);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (LogName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(LogName);
      }
      if (grpcService_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(GrpcService);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CommonGrpcAccessLogConfig other) {
      if (other == null) {
        return;
      }
      if (other.LogName.Length != 0) {
        LogName = other.LogName;
      }
      if (other.grpcService_ != null) {
        if (grpcService_ == null) {
          grpcService_ = new global::Envoy.Api.V2.Core.GrpcService();
        }
        GrpcService.MergeFrom(other.GrpcService);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            LogName = input.ReadString();
            break;
          }
          case 18: {
            if (grpcService_ == null) {
              grpcService_ = new global::Envoy.Api.V2.Core.GrpcService();
            }
            input.ReadMessage(grpcService_);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
