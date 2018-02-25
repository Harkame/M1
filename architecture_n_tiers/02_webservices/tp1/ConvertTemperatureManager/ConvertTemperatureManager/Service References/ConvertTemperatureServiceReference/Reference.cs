﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConvertTemperatureManager.ConvertTemperatureServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.webserviceX.NET/", ConfigurationName="ConvertTemperatureServiceReference.ConvertTemperatureSoap")]
    public interface ConvertTemperatureSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/ConvertTemp", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        double ConvertTemp(double Temperature, ConvertTemperatureManager.ConvertTemperatureServiceReference.TemperatureUnit FromUnit, ConvertTemperatureManager.ConvertTemperatureServiceReference.TemperatureUnit ToUnit);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2556.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.webserviceX.NET/")]
    public enum TemperatureUnit {
        
        /// <remarks/>
        degreeCelsius,
        
        /// <remarks/>
        degreeFahrenheit,
        
        /// <remarks/>
        degreeRankine,
        
        /// <remarks/>
        degreeReaumur,
        
        /// <remarks/>
        kelvin,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ConvertTemperatureSoapChannel : ConvertTemperatureManager.ConvertTemperatureServiceReference.ConvertTemperatureSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConvertTemperatureSoapClient : System.ServiceModel.ClientBase<ConvertTemperatureManager.ConvertTemperatureServiceReference.ConvertTemperatureSoap>, ConvertTemperatureManager.ConvertTemperatureServiceReference.ConvertTemperatureSoap {
        
        public ConvertTemperatureSoapClient() {
        }
        
        public ConvertTemperatureSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConvertTemperatureSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConvertTemperatureSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConvertTemperatureSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double ConvertTemp(double Temperature, ConvertTemperatureManager.ConvertTemperatureServiceReference.TemperatureUnit FromUnit, ConvertTemperatureManager.ConvertTemperatureServiceReference.TemperatureUnit ToUnit) {
            return base.Channel.ConvertTemp(Temperature, FromUnit, ToUnit);
        }
    }
}
