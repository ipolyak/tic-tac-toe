﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Этот исходный текст был создан автоматически: Microsoft.VSDesigner, версия: 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace TicTacToeClient.GameService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="TicTacToeWebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class TicTacToeWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CreateGameOperationCompleted;
        
        private System.Threading.SendOrPostCallback JoinToGameOperationCompleted;
        
        private System.Threading.SendOrPostCallback ExitFromGameOperationCompleted;
        
        private System.Threading.SendOrPostCallback WaitOpponentOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendCommandGameOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReceiveCommandOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public TicTacToeWebService() {
            this.Url = global::TicTacToeClient.Properties.Settings.Default.TicTacToeClient_GameService_TicTacToeWebService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event CreateGameCompletedEventHandler CreateGameCompleted;
        
        /// <remarks/>
        public event JoinToGameCompletedEventHandler JoinToGameCompleted;
        
        /// <remarks/>
        public event ExitFromGameCompletedEventHandler ExitFromGameCompleted;
        
        /// <remarks/>
        public event WaitOpponentCompletedEventHandler WaitOpponentCompleted;
        
        /// <remarks/>
        public event SendCommandGameCompletedEventHandler SendCommandGameCompleted;
        
        /// <remarks/>
        public event ReceiveCommandCompletedEventHandler ReceiveCommandCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CreateGame", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int CreateGame(string player_name) {
            object[] results = this.Invoke("CreateGame", new object[] {
                        player_name});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void CreateGameAsync(string player_name) {
            this.CreateGameAsync(player_name, null);
        }
        
        /// <remarks/>
        public void CreateGameAsync(string player_name, object userState) {
            if ((this.CreateGameOperationCompleted == null)) {
                this.CreateGameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateGameOperationCompleted);
            }
            this.InvokeAsync("CreateGame", new object[] {
                        player_name}, this.CreateGameOperationCompleted, userState);
        }
        
        private void OnCreateGameOperationCompleted(object arg) {
            if ((this.CreateGameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateGameCompleted(this, new CreateGameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/JoinToGame", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int JoinToGame(string player_name) {
            object[] results = this.Invoke("JoinToGame", new object[] {
                        player_name});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void JoinToGameAsync(string player_name) {
            this.JoinToGameAsync(player_name, null);
        }
        
        /// <remarks/>
        public void JoinToGameAsync(string player_name, object userState) {
            if ((this.JoinToGameOperationCompleted == null)) {
                this.JoinToGameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnJoinToGameOperationCompleted);
            }
            this.InvokeAsync("JoinToGame", new object[] {
                        player_name}, this.JoinToGameOperationCompleted, userState);
        }
        
        private void OnJoinToGameOperationCompleted(object arg) {
            if ((this.JoinToGameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.JoinToGameCompleted(this, new JoinToGameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ExitFromGame", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ExitFromGame(int group, string player_name) {
            object[] results = this.Invoke("ExitFromGame", new object[] {
                        group,
                        player_name});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ExitFromGameAsync(int group, string player_name) {
            this.ExitFromGameAsync(group, player_name, null);
        }
        
        /// <remarks/>
        public void ExitFromGameAsync(int group, string player_name, object userState) {
            if ((this.ExitFromGameOperationCompleted == null)) {
                this.ExitFromGameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExitFromGameOperationCompleted);
            }
            this.InvokeAsync("ExitFromGame", new object[] {
                        group,
                        player_name}, this.ExitFromGameOperationCompleted, userState);
        }
        
        private void OnExitFromGameOperationCompleted(object arg) {
            if ((this.ExitFromGameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExitFromGameCompleted(this, new ExitFromGameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/WaitOpponent", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string WaitOpponent(int group) {
            object[] results = this.Invoke("WaitOpponent", new object[] {
                        group});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void WaitOpponentAsync(int group) {
            this.WaitOpponentAsync(group, null);
        }
        
        /// <remarks/>
        public void WaitOpponentAsync(int group, object userState) {
            if ((this.WaitOpponentOperationCompleted == null)) {
                this.WaitOpponentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnWaitOpponentOperationCompleted);
            }
            this.InvokeAsync("WaitOpponent", new object[] {
                        group}, this.WaitOpponentOperationCompleted, userState);
        }
        
        private void OnWaitOpponentOperationCompleted(object arg) {
            if ((this.WaitOpponentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.WaitOpponentCompleted(this, new WaitOpponentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendCommandGame", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SendCommandGame(int group, int row, int col, string player_name) {
            object[] results = this.Invoke("SendCommandGame", new object[] {
                        group,
                        row,
                        col,
                        player_name});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SendCommandGameAsync(int group, int row, int col, string player_name) {
            this.SendCommandGameAsync(group, row, col, player_name, null);
        }
        
        /// <remarks/>
        public void SendCommandGameAsync(int group, int row, int col, string player_name, object userState) {
            if ((this.SendCommandGameOperationCompleted == null)) {
                this.SendCommandGameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendCommandGameOperationCompleted);
            }
            this.InvokeAsync("SendCommandGame", new object[] {
                        group,
                        row,
                        col,
                        player_name}, this.SendCommandGameOperationCompleted, userState);
        }
        
        private void OnSendCommandGameOperationCompleted(object arg) {
            if ((this.SendCommandGameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendCommandGameCompleted(this, new SendCommandGameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ReceiveCommand", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReceiveCommand(int group, string player_name) {
            object[] results = this.Invoke("ReceiveCommand", new object[] {
                        group,
                        player_name});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ReceiveCommandAsync(int group, string player_name) {
            this.ReceiveCommandAsync(group, player_name, null);
        }
        
        /// <remarks/>
        public void ReceiveCommandAsync(int group, string player_name, object userState) {
            if ((this.ReceiveCommandOperationCompleted == null)) {
                this.ReceiveCommandOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReceiveCommandOperationCompleted);
            }
            this.InvokeAsync("ReceiveCommand", new object[] {
                        group,
                        player_name}, this.ReceiveCommandOperationCompleted, userState);
        }
        
        private void OnReceiveCommandOperationCompleted(object arg) {
            if ((this.ReceiveCommandCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReceiveCommandCompleted(this, new ReceiveCommandCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void CreateGameCompletedEventHandler(object sender, CreateGameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateGameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateGameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void JoinToGameCompletedEventHandler(object sender, JoinToGameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class JoinToGameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal JoinToGameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void ExitFromGameCompletedEventHandler(object sender, ExitFromGameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExitFromGameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExitFromGameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void WaitOpponentCompletedEventHandler(object sender, WaitOpponentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class WaitOpponentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal WaitOpponentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void SendCommandGameCompletedEventHandler(object sender, SendCommandGameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendCommandGameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendCommandGameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void ReceiveCommandCompletedEventHandler(object sender, ReceiveCommandCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReceiveCommandCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReceiveCommandCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591