﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientTicTacToe.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.TicTacToeWebServiceSoap")]
    public interface TicTacToeWebServiceSoap {
        
        // CODEGEN: Контракт генерации сообщений с именем HelloWorldResult из пространства имен http://tempuri.org/ не отмечен как обнуляемый
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        ClientTicTacToe.ServiceReference1.HelloWorldResponse HelloWorld(ClientTicTacToe.ServiceReference1.HelloWorldRequest request);
        
        // CODEGEN: Контракт генерации сообщений с именем firstName из пространства имен http://tempuri.org/ не отмечен как обнуляемый
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MyFirstWebMethod", ReplyAction="*")]
        ClientTicTacToe.ServiceReference1.MyFirstWebMethodResponse MyFirstWebMethod(ClientTicTacToe.ServiceReference1.MyFirstWebMethodRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public ClientTicTacToe.ServiceReference1.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(ClientTicTacToe.ServiceReference1.HelloWorldRequestBody Body) {
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
        public ClientTicTacToe.ServiceReference1.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(ClientTicTacToe.ServiceReference1.HelloWorldResponseBody Body) {
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
    public partial class MyFirstWebMethodRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="MyFirstWebMethod", Namespace="http://tempuri.org/", Order=0)]
        public ClientTicTacToe.ServiceReference1.MyFirstWebMethodRequestBody Body;
        
        public MyFirstWebMethodRequest() {
        }
        
        public MyFirstWebMethodRequest(ClientTicTacToe.ServiceReference1.MyFirstWebMethodRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class MyFirstWebMethodRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string firstName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string lastName;
        
        public MyFirstWebMethodRequestBody() {
        }
        
        public MyFirstWebMethodRequestBody(string firstName, string lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MyFirstWebMethodResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="MyFirstWebMethodResponse", Namespace="http://tempuri.org/", Order=0)]
        public ClientTicTacToe.ServiceReference1.MyFirstWebMethodResponseBody Body;
        
        public MyFirstWebMethodResponse() {
        }
        
        public MyFirstWebMethodResponse(ClientTicTacToe.ServiceReference1.MyFirstWebMethodResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class MyFirstWebMethodResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string MyFirstWebMethodResult;
        
        public MyFirstWebMethodResponseBody() {
        }
        
        public MyFirstWebMethodResponseBody(string MyFirstWebMethodResult) {
            this.MyFirstWebMethodResult = MyFirstWebMethodResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TicTacToeWebServiceSoapChannel : ClientTicTacToe.ServiceReference1.TicTacToeWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TicTacToeWebServiceSoapClient : System.ServiceModel.ClientBase<ClientTicTacToe.ServiceReference1.TicTacToeWebServiceSoap>, ClientTicTacToe.ServiceReference1.TicTacToeWebServiceSoap {
        
        public TicTacToeWebServiceSoapClient() {
        }
        
        public TicTacToeWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TicTacToeWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TicTacToeWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TicTacToeWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientTicTacToe.ServiceReference1.HelloWorldResponse ClientTicTacToe.ServiceReference1.TicTacToeWebServiceSoap.HelloWorld(ClientTicTacToe.ServiceReference1.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            ClientTicTacToe.ServiceReference1.HelloWorldRequest inValue = new ClientTicTacToe.ServiceReference1.HelloWorldRequest();
            inValue.Body = new ClientTicTacToe.ServiceReference1.HelloWorldRequestBody();
            ClientTicTacToe.ServiceReference1.HelloWorldResponse retVal = ((ClientTicTacToe.ServiceReference1.TicTacToeWebServiceSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientTicTacToe.ServiceReference1.MyFirstWebMethodResponse ClientTicTacToe.ServiceReference1.TicTacToeWebServiceSoap.MyFirstWebMethod(ClientTicTacToe.ServiceReference1.MyFirstWebMethodRequest request) {
            return base.Channel.MyFirstWebMethod(request);
        }
        
        public string MyFirstWebMethod(string firstName, string lastName) {
            ClientTicTacToe.ServiceReference1.MyFirstWebMethodRequest inValue = new ClientTicTacToe.ServiceReference1.MyFirstWebMethodRequest();
            inValue.Body = new ClientTicTacToe.ServiceReference1.MyFirstWebMethodRequestBody();
            inValue.Body.firstName = firstName;
            inValue.Body.lastName = lastName;
            ClientTicTacToe.ServiceReference1.MyFirstWebMethodResponse retVal = ((ClientTicTacToe.ServiceReference1.TicTacToeWebServiceSoap)(this)).MyFirstWebMethod(inValue);
            return retVal.Body.MyFirstWebMethodResult;
        }
    }
}