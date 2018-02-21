﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManager.LibraryManagerServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Subscriber", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Subscriber : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int a_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string a_passwordField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int a_id {
            get {
                return this.a_idField;
            }
            set {
                if ((this.a_idField.Equals(value) != true)) {
                    this.a_idField = value;
                    this.RaisePropertyChanged("a_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string a_password {
            get {
                return this.a_passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.a_passwordField, value) != true)) {
                    this.a_passwordField = value;
                    this.RaisePropertyChanged("a_password");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LibraryManagerServiceReference.ServiceSoap")]
    public interface ServiceSoap {
        
        // CODEGEN: Generating message contract since element name HelloWorldResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        LibraryManager.LibraryManagerServiceReference.HelloWorldResponse HelloWorld(LibraryManager.LibraryManagerServiceReference.HelloWorldRequest request);
        
        // CODEGEN: Generating message contract since element name p_password from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Authentificate", ReplyAction="*")]
        LibraryManager.LibraryManagerServiceReference.AuthentificateResponse Authentificate(LibraryManager.LibraryManagerServiceReference.AuthentificateRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public LibraryManager.LibraryManagerServiceReference.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(LibraryManager.LibraryManagerServiceReference.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public LibraryManager.LibraryManagerServiceReference.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(LibraryManager.LibraryManagerServiceReference.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AuthentificateRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Authentificate", Namespace="http://tempuri.org/", Order=0)]
        public LibraryManager.LibraryManagerServiceReference.AuthentificateRequestBody Body;
        
        public AuthentificateRequest() {
        }
        
        public AuthentificateRequest(LibraryManager.LibraryManagerServiceReference.AuthentificateRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AuthentificateRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int p_id;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string p_password;
        
        public AuthentificateRequestBody() {
        }
        
        public AuthentificateRequestBody(int p_id, string p_password) {
            this.p_id = p_id;
            this.p_password = p_password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AuthentificateResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AuthentificateResponse", Namespace="http://tempuri.org/", Order=0)]
        public LibraryManager.LibraryManagerServiceReference.AuthentificateResponseBody Body;
        
        public AuthentificateResponse() {
        }
        
        public AuthentificateResponse(LibraryManager.LibraryManagerServiceReference.AuthentificateResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AuthentificateResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public LibraryManager.LibraryManagerServiceReference.Subscriber AuthentificateResult;
        
        public AuthentificateResponseBody() {
        }
        
        public AuthentificateResponseBody(LibraryManager.LibraryManagerServiceReference.Subscriber AuthentificateResult) {
            this.AuthentificateResult = AuthentificateResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServiceSoapChannel : LibraryManager.LibraryManagerServiceReference.ServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceSoapClient : System.ServiceModel.ClientBase<LibraryManager.LibraryManagerServiceReference.ServiceSoap>, LibraryManager.LibraryManagerServiceReference.ServiceSoap {
        
        public ServiceSoapClient() {
        }
        
        public ServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LibraryManager.LibraryManagerServiceReference.HelloWorldResponse LibraryManager.LibraryManagerServiceReference.ServiceSoap.HelloWorld(LibraryManager.LibraryManagerServiceReference.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            LibraryManager.LibraryManagerServiceReference.HelloWorldRequest inValue = new LibraryManager.LibraryManagerServiceReference.HelloWorldRequest();
            inValue.Body = new LibraryManager.LibraryManagerServiceReference.HelloWorldRequestBody();
            LibraryManager.LibraryManagerServiceReference.HelloWorldResponse retVal = ((LibraryManager.LibraryManagerServiceReference.ServiceSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LibraryManager.LibraryManagerServiceReference.AuthentificateResponse LibraryManager.LibraryManagerServiceReference.ServiceSoap.Authentificate(LibraryManager.LibraryManagerServiceReference.AuthentificateRequest request) {
            return base.Channel.Authentificate(request);
        }
        
        public LibraryManager.LibraryManagerServiceReference.Subscriber Authentificate(int p_id, string p_password) {
            LibraryManager.LibraryManagerServiceReference.AuthentificateRequest inValue = new LibraryManager.LibraryManagerServiceReference.AuthentificateRequest();
            inValue.Body = new LibraryManager.LibraryManagerServiceReference.AuthentificateRequestBody();
            inValue.Body.p_id = p_id;
            inValue.Body.p_password = p_password;
            LibraryManager.LibraryManagerServiceReference.AuthentificateResponse retVal = ((LibraryManager.LibraryManagerServiceReference.ServiceSoap)(this)).Authentificate(inValue);
            return retVal.Body.AuthentificateResult;
        }
    }
}
