﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.17929
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication3.LibraryWebServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LibraryWebServiceReference.LibraryWebServiceSoap")]
    public interface LibraryWebServiceSoap {
        
        // CODEGEN : La génération du contrat de message depuis le nom d'élément testResult de l'espace de noms http://tempuri.org/ n'est pas marqué nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/test", ReplyAction="*")]
        ConsoleApplication3.LibraryWebServiceReference.testResponse test(ConsoleApplication3.LibraryWebServiceReference.testRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class testRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="test", Namespace="http://tempuri.org/", Order=0)]
        public ConsoleApplication3.LibraryWebServiceReference.testRequestBody Body;
        
        public testRequest() {
        }
        
        public testRequest(ConsoleApplication3.LibraryWebServiceReference.testRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class testRequestBody {
        
        public testRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class testResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="testResponse", Namespace="http://tempuri.org/", Order=0)]
        public ConsoleApplication3.LibraryWebServiceReference.testResponseBody Body;
        
        public testResponse() {
        }
        
        public testResponse(ConsoleApplication3.LibraryWebServiceReference.testResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class testResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string testResult;
        
        public testResponseBody() {
        }
        
        public testResponseBody(string testResult) {
            this.testResult = testResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface LibraryWebServiceSoapChannel : ConsoleApplication3.LibraryWebServiceReference.LibraryWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LibraryWebServiceSoapClient : System.ServiceModel.ClientBase<ConsoleApplication3.LibraryWebServiceReference.LibraryWebServiceSoap>, ConsoleApplication3.LibraryWebServiceReference.LibraryWebServiceSoap {
        
        public LibraryWebServiceSoapClient() {
        }
        
        public LibraryWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LibraryWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LibraryWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LibraryWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsoleApplication3.LibraryWebServiceReference.testResponse ConsoleApplication3.LibraryWebServiceReference.LibraryWebServiceSoap.test(ConsoleApplication3.LibraryWebServiceReference.testRequest request) {
            return base.Channel.test(request);
        }
        
        public string test() {
            ConsoleApplication3.LibraryWebServiceReference.testRequest inValue = new ConsoleApplication3.LibraryWebServiceReference.testRequest();
            inValue.Body = new ConsoleApplication3.LibraryWebServiceReference.testRequestBody();
            ConsoleApplication3.LibraryWebServiceReference.testResponse retVal = ((ConsoleApplication3.LibraryWebServiceReference.LibraryWebServiceSoap)(this)).test(inValue);
            return retVal.Body.testResult;
        }
    }
}
