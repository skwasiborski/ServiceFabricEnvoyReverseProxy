// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: envoy/config/filter/network/rate_limit/v2/rate_limit.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Envoy.Config.Filter.Network.RateLimit.V2 {

  /// <summary>Holder for reflection information generated from envoy/config/filter/network/rate_limit/v2/rate_limit.proto</summary>
  public static partial class RateLimitReflection {

    #region Descriptor
    /// <summary>File descriptor for envoy/config/filter/network/rate_limit/v2/rate_limit.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static RateLimitReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjplbnZveS9jb25maWcvZmlsdGVyL25ldHdvcmsvcmF0ZV9saW1pdC92Mi9y",
            "YXRlX2xpbWl0LnByb3RvEillbnZveS5jb25maWcuZmlsdGVyLm5ldHdvcmsu",
            "cmF0ZV9saW1pdC52MhomZW52b3kvYXBpL3YyL3JhdGVsaW1pdC9yYXRlbGlt",
            "aXQucHJvdG8aHmdvb2dsZS9wcm90b2J1Zi9kdXJhdGlvbi5wcm90bxoXdmFs",
            "aWRhdGUvdmFsaWRhdGUucHJvdG8aFGdvZ29wcm90by9nb2dvLnByb3RvIsYB",
            "CglSYXRlTGltaXQSHgoLc3RhdF9wcmVmaXgYASABKAlCCbrpwAMEcgIgARIZ",
            "CgZkb21haW4YAiABKAlCCbrpwAMEcgIgARJMCgtkZXNjcmlwdG9ycxgDIAMo",
            "CzIrLmVudm95LmFwaS52Mi5yYXRlbGltaXQuUmF0ZUxpbWl0RGVzY3JpcHRv",
            "ckIKuunAAwWSAQIIARIwCgd0aW1lb3V0GAQgASgLMhkuZ29vZ2xlLnByb3Rv",
            "YnVmLkR1cmF0aW9uQgSY3x8BQgRaAnYyYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Envoy.Api.V2.Ratelimit.RatelimitReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.DurationReflection.Descriptor, global::Validate.ValidateReflection.Descriptor, global::Gogoproto.GogoReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Envoy.Config.Filter.Network.RateLimit.V2.RateLimit), global::Envoy.Config.Filter.Network.RateLimit.V2.RateLimit.Parser, new[]{ "StatPrefix", "Domain", "Descriptors", "Timeout" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class RateLimit : pb::IMessage<RateLimit> {
    private static readonly pb::MessageParser<RateLimit> _parser = new pb::MessageParser<RateLimit>(() => new RateLimit());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RateLimit> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Envoy.Config.Filter.Network.RateLimit.V2.RateLimitReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RateLimit() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RateLimit(RateLimit other) : this() {
      statPrefix_ = other.statPrefix_;
      domain_ = other.domain_;
      descriptors_ = other.descriptors_.Clone();
      Timeout = other.timeout_ != null ? other.Timeout.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RateLimit Clone() {
      return new RateLimit(this);
    }

    /// <summary>Field number for the "stat_prefix" field.</summary>
    public const int StatPrefixFieldNumber = 1;
    private string statPrefix_ = "";
    /// <summary>
    /// The prefix to use when emitting :ref:`statistics &lt;config_network_filters_rate_limit_stats>`.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string StatPrefix {
      get { return statPrefix_; }
      set {
        statPrefix_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "domain" field.</summary>
    public const int DomainFieldNumber = 2;
    private string domain_ = "";
    /// <summary>
    /// The rate limit domain to use in the rate limit service request.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Domain {
      get { return domain_; }
      set {
        domain_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "descriptors" field.</summary>
    public const int DescriptorsFieldNumber = 3;
    private static readonly pb::FieldCodec<global::Envoy.Api.V2.Ratelimit.RateLimitDescriptor> _repeated_descriptors_codec
        = pb::FieldCodec.ForMessage(26, global::Envoy.Api.V2.Ratelimit.RateLimitDescriptor.Parser);
    private readonly pbc::RepeatedField<global::Envoy.Api.V2.Ratelimit.RateLimitDescriptor> descriptors_ = new pbc::RepeatedField<global::Envoy.Api.V2.Ratelimit.RateLimitDescriptor>();
    /// <summary>
    /// The rate limit descriptor list to use in the rate limit service request.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Envoy.Api.V2.Ratelimit.RateLimitDescriptor> Descriptors {
      get { return descriptors_; }
    }

    /// <summary>Field number for the "timeout" field.</summary>
    public const int TimeoutFieldNumber = 4;
    private global::Google.Protobuf.WellKnownTypes.Duration timeout_;
    /// <summary>
    /// The timeout in milliseconds for the rate limit service RPC. If not
    /// set, this defaults to 20ms.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Duration Timeout {
      get { return timeout_; }
      set {
        timeout_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RateLimit);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RateLimit other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (StatPrefix != other.StatPrefix) return false;
      if (Domain != other.Domain) return false;
      if(!descriptors_.Equals(other.descriptors_)) return false;
      if (!object.Equals(Timeout, other.Timeout)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (StatPrefix.Length != 0) hash ^= StatPrefix.GetHashCode();
      if (Domain.Length != 0) hash ^= Domain.GetHashCode();
      hash ^= descriptors_.GetHashCode();
      if (timeout_ != null) hash ^= Timeout.GetHashCode();
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
      if (StatPrefix.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(StatPrefix);
      }
      if (Domain.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Domain);
      }
      descriptors_.WriteTo(output, _repeated_descriptors_codec);
      if (timeout_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(Timeout);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (StatPrefix.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(StatPrefix);
      }
      if (Domain.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Domain);
      }
      size += descriptors_.CalculateSize(_repeated_descriptors_codec);
      if (timeout_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Timeout);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RateLimit other) {
      if (other == null) {
        return;
      }
      if (other.StatPrefix.Length != 0) {
        StatPrefix = other.StatPrefix;
      }
      if (other.Domain.Length != 0) {
        Domain = other.Domain;
      }
      descriptors_.Add(other.descriptors_);
      if (other.timeout_ != null) {
        if (timeout_ == null) {
          timeout_ = new global::Google.Protobuf.WellKnownTypes.Duration();
        }
        Timeout.MergeFrom(other.Timeout);
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
            StatPrefix = input.ReadString();
            break;
          }
          case 18: {
            Domain = input.ReadString();
            break;
          }
          case 26: {
            descriptors_.AddEntriesFrom(input, _repeated_descriptors_codec);
            break;
          }
          case 34: {
            if (timeout_ == null) {
              timeout_ = new global::Google.Protobuf.WellKnownTypes.Duration();
            }
            input.ReadMessage(timeout_);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code