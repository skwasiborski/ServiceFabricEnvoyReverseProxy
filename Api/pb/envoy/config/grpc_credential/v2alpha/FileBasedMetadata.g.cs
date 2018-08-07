// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: envoy/config/grpc_credential/v2alpha/file_based_metadata.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Envoy.Config.GrpcCredential.V2Alpha {

  /// <summary>Holder for reflection information generated from envoy/config/grpc_credential/v2alpha/file_based_metadata.proto</summary>
  public static partial class FileBasedMetadataReflection {

    #region Descriptor
    /// <summary>File descriptor for envoy/config/grpc_credential/v2alpha/file_based_metadata.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static FileBasedMetadataReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cj5lbnZveS9jb25maWcvZ3JwY19jcmVkZW50aWFsL3YyYWxwaGEvZmlsZV9i",
            "YXNlZF9tZXRhZGF0YS5wcm90bxIkZW52b3kuY29uZmlnLmdycGNfY3JlZGVu",
            "dGlhbC52MmFscGhhGhxlbnZveS9hcGkvdjIvY29yZS9iYXNlLnByb3RvIngK",
            "F0ZpbGVCYXNlZE1ldGFkYXRhQ29uZmlnEjIKC3NlY3JldF9kYXRhGAEgASgL",
            "Mh0uZW52b3kuYXBpLnYyLmNvcmUuRGF0YVNvdXJjZRISCgpoZWFkZXJfa2V5",
            "GAIgASgJEhUKDWhlYWRlcl9wcmVmaXgYAyABKAlCCVoHdjJhbHBoYWIGcHJv",
            "dG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Envoy.Api.V2.Core.BaseReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Envoy.Config.GrpcCredential.V2Alpha.FileBasedMetadataConfig), global::Envoy.Config.GrpcCredential.V2Alpha.FileBasedMetadataConfig.Parser, new[]{ "SecretData", "HeaderKey", "HeaderPrefix" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class FileBasedMetadataConfig : pb::IMessage<FileBasedMetadataConfig> {
    private static readonly pb::MessageParser<FileBasedMetadataConfig> _parser = new pb::MessageParser<FileBasedMetadataConfig>(() => new FileBasedMetadataConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<FileBasedMetadataConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Envoy.Config.GrpcCredential.V2Alpha.FileBasedMetadataReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FileBasedMetadataConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FileBasedMetadataConfig(FileBasedMetadataConfig other) : this() {
      SecretData = other.secretData_ != null ? other.SecretData.Clone() : null;
      headerKey_ = other.headerKey_;
      headerPrefix_ = other.headerPrefix_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FileBasedMetadataConfig Clone() {
      return new FileBasedMetadataConfig(this);
    }

    /// <summary>Field number for the "secret_data" field.</summary>
    public const int SecretDataFieldNumber = 1;
    private global::Envoy.Api.V2.Core.DataSource secretData_;
    /// <summary>
    /// Location or inline data of secret to use for authentication of the Google gRPC connection
    /// this secret will be attached to a header of the gRPC connection
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Envoy.Api.V2.Core.DataSource SecretData {
      get { return secretData_; }
      set {
        secretData_ = value;
      }
    }

    /// <summary>Field number for the "header_key" field.</summary>
    public const int HeaderKeyFieldNumber = 2;
    private string headerKey_ = "";
    /// <summary>
    /// Metadata header key to use for sending the secret data
    /// if no header key is set, "authorization" header will be used
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string HeaderKey {
      get { return headerKey_; }
      set {
        headerKey_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "header_prefix" field.</summary>
    public const int HeaderPrefixFieldNumber = 3;
    private string headerPrefix_ = "";
    /// <summary>
    /// Prefix to prepend to the secret in the metadata header
    /// if no prefix is set, the default is to use no prefix
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string HeaderPrefix {
      get { return headerPrefix_; }
      set {
        headerPrefix_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as FileBasedMetadataConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(FileBasedMetadataConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(SecretData, other.SecretData)) return false;
      if (HeaderKey != other.HeaderKey) return false;
      if (HeaderPrefix != other.HeaderPrefix) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (secretData_ != null) hash ^= SecretData.GetHashCode();
      if (HeaderKey.Length != 0) hash ^= HeaderKey.GetHashCode();
      if (HeaderPrefix.Length != 0) hash ^= HeaderPrefix.GetHashCode();
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
      if (secretData_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(SecretData);
      }
      if (HeaderKey.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(HeaderKey);
      }
      if (HeaderPrefix.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(HeaderPrefix);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (secretData_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(SecretData);
      }
      if (HeaderKey.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(HeaderKey);
      }
      if (HeaderPrefix.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(HeaderPrefix);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(FileBasedMetadataConfig other) {
      if (other == null) {
        return;
      }
      if (other.secretData_ != null) {
        if (secretData_ == null) {
          secretData_ = new global::Envoy.Api.V2.Core.DataSource();
        }
        SecretData.MergeFrom(other.SecretData);
      }
      if (other.HeaderKey.Length != 0) {
        HeaderKey = other.HeaderKey;
      }
      if (other.HeaderPrefix.Length != 0) {
        HeaderPrefix = other.HeaderPrefix;
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
            if (secretData_ == null) {
              secretData_ = new global::Envoy.Api.V2.Core.DataSource();
            }
            input.ReadMessage(secretData_);
            break;
          }
          case 18: {
            HeaderKey = input.ReadString();
            break;
          }
          case 26: {
            HeaderPrefix = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
