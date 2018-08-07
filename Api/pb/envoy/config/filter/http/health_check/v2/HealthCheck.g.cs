// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: envoy/config/filter/http/health_check/v2/health_check.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Envoy.Config.Filter.Http.HealthCheck.V2 {

  /// <summary>Holder for reflection information generated from envoy/config/filter/http/health_check/v2/health_check.proto</summary>
  public static partial class HealthCheckReflection {

    #region Descriptor
    /// <summary>File descriptor for envoy/config/filter/http/health_check/v2/health_check.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static HealthCheckReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjtlbnZveS9jb25maWcvZmlsdGVyL2h0dHAvaGVhbHRoX2NoZWNrL3YyL2hl",
            "YWx0aF9jaGVjay5wcm90bxIoZW52b3kuY29uZmlnLmZpbHRlci5odHRwLmhl",
            "YWx0aF9jaGVjay52MhoeZ29vZ2xlL3Byb3RvYnVmL2R1cmF0aW9uLnByb3Rv",
            "Gh5nb29nbGUvcHJvdG9idWYvd3JhcHBlcnMucHJvdG8aHmVudm95L2FwaS92",
            "Mi9yb3V0ZS9yb3V0ZS5wcm90bxoYZW52b3kvdHlwZS9wZXJjZW50LnByb3Rv",
            "Ghd2YWxpZGF0ZS92YWxpZGF0ZS5wcm90bxoUZ29nb3Byb3RvL2dvZ28ucHJv",
            "dG8irAMKC0hlYWx0aENoZWNrEkEKEXBhc3NfdGhyb3VnaF9tb2RlGAEgASgL",
            "MhouZ29vZ2xlLnByb3RvYnVmLkJvb2xWYWx1ZUIKuunAAwWKAQIQARIUCghl",
            "bmRwb2ludBgCIAEoCUICGAESMwoKY2FjaGVfdGltZRgDIAEoCzIZLmdvb2ds",
            "ZS5wcm90b2J1Zi5EdXJhdGlvbkIEmN8fARKAAQofY2x1c3Rlcl9taW5faGVh",
            "bHRoeV9wZXJjZW50YWdlcxgEIAMoCzJXLmVudm95LmNvbmZpZy5maWx0ZXIu",
            "aHR0cC5oZWFsdGhfY2hlY2sudjIuSGVhbHRoQ2hlY2suQ2x1c3Rlck1pbkhl",
            "YWx0aHlQZXJjZW50YWdlc0VudHJ5EjIKB2hlYWRlcnMYBSADKAsyIS5lbnZv",
            "eS5hcGkudjIucm91dGUuSGVhZGVyTWF0Y2hlchpYCiFDbHVzdGVyTWluSGVh",
            "bHRoeVBlcmNlbnRhZ2VzRW50cnkSCwoDa2V5GAEgASgJEiIKBXZhbHVlGAIg",
            "ASgLMhMuZW52b3kudHlwZS5QZXJjZW50OgI4AUIEWgJ2MmIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.DurationReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, global::Envoy.Api.V2.Route.RouteReflection.Descriptor, global::Envoy.Type.PercentReflection.Descriptor, global::Validate.ValidateReflection.Descriptor, global::Gogoproto.GogoReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Envoy.Config.Filter.Http.HealthCheck.V2.HealthCheck), global::Envoy.Config.Filter.Http.HealthCheck.V2.HealthCheck.Parser, new[]{ "PassThroughMode", "Endpoint", "CacheTime", "ClusterMinHealthyPercentages", "Headers" }, null, null, new pbr::GeneratedClrTypeInfo[] { null, })
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class HealthCheck : pb::IMessage<HealthCheck> {
    private static readonly pb::MessageParser<HealthCheck> _parser = new pb::MessageParser<HealthCheck>(() => new HealthCheck());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<HealthCheck> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Envoy.Config.Filter.Http.HealthCheck.V2.HealthCheckReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HealthCheck() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HealthCheck(HealthCheck other) : this() {
      PassThroughMode = other.PassThroughMode;
      endpoint_ = other.endpoint_;
      CacheTime = other.cacheTime_ != null ? other.CacheTime.Clone() : null;
      clusterMinHealthyPercentages_ = other.clusterMinHealthyPercentages_.Clone();
      headers_ = other.headers_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HealthCheck Clone() {
      return new HealthCheck(this);
    }

    /// <summary>Field number for the "pass_through_mode" field.</summary>
    public const int PassThroughModeFieldNumber = 1;
    private static readonly pb::FieldCodec<bool?> _single_passThroughMode_codec = pb::FieldCodec.ForStructWrapper<bool>(10);
    private bool? passThroughMode_;
    /// <summary>
    /// Specifies whether the filter operates in pass through mode or not.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool? PassThroughMode {
      get { return passThroughMode_; }
      set {
        passThroughMode_ = value;
      }
    }

    /// <summary>Field number for the "endpoint" field.</summary>
    public const int EndpointFieldNumber = 2;
    private string endpoint_ = "";
    /// <summary>
    /// Specifies the incoming HTTP endpoint that should be considered the
    /// health check endpoint. For example */healthcheck*.
    /// Note that this field is deprecated in favor of
    /// :ref:`headers &lt;envoy_api_field_config.filter.http.health_check.v2.HealthCheck.headers>`.
    /// </summary>
    [global::System.ObsoleteAttribute]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Endpoint {
      get { return endpoint_; }
      set {
        endpoint_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "cache_time" field.</summary>
    public const int CacheTimeFieldNumber = 3;
    private global::Google.Protobuf.WellKnownTypes.Duration cacheTime_;
    /// <summary>
    /// If operating in pass through mode, the amount of time in milliseconds
    /// that the filter should cache the upstream response.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Duration CacheTime {
      get { return cacheTime_; }
      set {
        cacheTime_ = value;
      }
    }

    /// <summary>Field number for the "cluster_min_healthy_percentages" field.</summary>
    public const int ClusterMinHealthyPercentagesFieldNumber = 4;
    private static readonly pbc::MapField<string, global::Envoy.Type.Percent>.Codec _map_clusterMinHealthyPercentages_codec
        = new pbc::MapField<string, global::Envoy.Type.Percent>.Codec(pb::FieldCodec.ForString(10), pb::FieldCodec.ForMessage(18, global::Envoy.Type.Percent.Parser), 34);
    private readonly pbc::MapField<string, global::Envoy.Type.Percent> clusterMinHealthyPercentages_ = new pbc::MapField<string, global::Envoy.Type.Percent>();
    /// <summary>
    /// If operating in non-pass-through mode, specifies a set of upstream cluster
    /// names and the minimum percentage of servers in each of those clusters that
    /// must be healthy in order for the filter to return a 200.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, global::Envoy.Type.Percent> ClusterMinHealthyPercentages {
      get { return clusterMinHealthyPercentages_; }
    }

    /// <summary>Field number for the "headers" field.</summary>
    public const int HeadersFieldNumber = 5;
    private static readonly pb::FieldCodec<global::Envoy.Api.V2.Route.HeaderMatcher> _repeated_headers_codec
        = pb::FieldCodec.ForMessage(42, global::Envoy.Api.V2.Route.HeaderMatcher.Parser);
    private readonly pbc::RepeatedField<global::Envoy.Api.V2.Route.HeaderMatcher> headers_ = new pbc::RepeatedField<global::Envoy.Api.V2.Route.HeaderMatcher>();
    /// <summary>
    /// Specifies a set of health check request headers to match on. The health check filter will
    /// check a request’s headers against all the specified headers. To specify the health check
    /// endpoint, set the ``:path`` header to match on. Note that if the
    /// :ref:`endpoint &lt;envoy_api_field_config.filter.http.health_check.v2.HealthCheck.endpoint>`
    /// field is set, it will overwrite any ``:path`` header to match.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Envoy.Api.V2.Route.HeaderMatcher> Headers {
      get { return headers_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as HealthCheck);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(HealthCheck other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (PassThroughMode != other.PassThroughMode) return false;
      if (Endpoint != other.Endpoint) return false;
      if (!object.Equals(CacheTime, other.CacheTime)) return false;
      if (!ClusterMinHealthyPercentages.Equals(other.ClusterMinHealthyPercentages)) return false;
      if(!headers_.Equals(other.headers_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (passThroughMode_ != null) hash ^= PassThroughMode.GetHashCode();
      if (Endpoint.Length != 0) hash ^= Endpoint.GetHashCode();
      if (cacheTime_ != null) hash ^= CacheTime.GetHashCode();
      hash ^= ClusterMinHealthyPercentages.GetHashCode();
      hash ^= headers_.GetHashCode();
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
      if (passThroughMode_ != null) {
        _single_passThroughMode_codec.WriteTagAndValue(output, PassThroughMode);
      }
      if (Endpoint.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Endpoint);
      }
      if (cacheTime_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(CacheTime);
      }
      clusterMinHealthyPercentages_.WriteTo(output, _map_clusterMinHealthyPercentages_codec);
      headers_.WriteTo(output, _repeated_headers_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (passThroughMode_ != null) {
        size += _single_passThroughMode_codec.CalculateSizeWithTag(PassThroughMode);
      }
      if (Endpoint.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Endpoint);
      }
      if (cacheTime_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CacheTime);
      }
      size += clusterMinHealthyPercentages_.CalculateSize(_map_clusterMinHealthyPercentages_codec);
      size += headers_.CalculateSize(_repeated_headers_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(HealthCheck other) {
      if (other == null) {
        return;
      }
      if (other.passThroughMode_ != null) {
        if (passThroughMode_ == null || other.PassThroughMode != false) {
          PassThroughMode = other.PassThroughMode;
        }
      }
      if (other.Endpoint.Length != 0) {
        Endpoint = other.Endpoint;
      }
      if (other.cacheTime_ != null) {
        if (cacheTime_ == null) {
          cacheTime_ = new global::Google.Protobuf.WellKnownTypes.Duration();
        }
        CacheTime.MergeFrom(other.CacheTime);
      }
      clusterMinHealthyPercentages_.Add(other.clusterMinHealthyPercentages_);
      headers_.Add(other.headers_);
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
            bool? value = _single_passThroughMode_codec.Read(input);
            if (passThroughMode_ == null || value != false) {
              PassThroughMode = value;
            }
            break;
          }
          case 18: {
            Endpoint = input.ReadString();
            break;
          }
          case 26: {
            if (cacheTime_ == null) {
              cacheTime_ = new global::Google.Protobuf.WellKnownTypes.Duration();
            }
            input.ReadMessage(cacheTime_);
            break;
          }
          case 34: {
            clusterMinHealthyPercentages_.AddEntriesFrom(input, _map_clusterMinHealthyPercentages_codec);
            break;
          }
          case 42: {
            headers_.AddEntriesFrom(input, _repeated_headers_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code