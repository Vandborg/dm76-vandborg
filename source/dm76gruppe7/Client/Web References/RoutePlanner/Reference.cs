﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.17929.
// 
#pragma warning disable 1591

namespace Client.RoutePlanner {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap", Namespace="http://tempuri.org/")]
    public partial class Service1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback FindAdressOrLocationOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetMapImageOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDirectionsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service1() {
            this.Url = global::Client.Properties.Settings.Default.Client_RoutePlanner_Service1;
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
        public event FindAdressOrLocationCompletedEventHandler FindAdressOrLocationCompleted;
        
        /// <remarks/>
        public event GetMapImageCompletedEventHandler GetMapImageCompleted;
        
        /// <remarks/>
        public event GetDirectionsCompletedEventHandler GetDirectionsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FindAdressOrLocation", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] FindAdressOrLocation(string location, string country) {
            object[] results = this.Invoke("FindAdressOrLocation", new object[] {
                        location,
                        country});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void FindAdressOrLocationAsync(string location, string country) {
            this.FindAdressOrLocationAsync(location, country, null);
        }
        
        /// <remarks/>
        public void FindAdressOrLocationAsync(string location, string country, object userState) {
            if ((this.FindAdressOrLocationOperationCompleted == null)) {
                this.FindAdressOrLocationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFindAdressOrLocationOperationCompleted);
            }
            this.InvokeAsync("FindAdressOrLocation", new object[] {
                        location,
                        country}, this.FindAdressOrLocationOperationCompleted, userState);
        }
        
        private void OnFindAdressOrLocationOperationCompleted(object arg) {
            if ((this.FindAdressOrLocationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FindAdressOrLocationCompleted(this, new FindAdressOrLocationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetMapImage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] GetMapImage(string[] location, string country, int imageHeight, int imageWidth, bool showRoute) {
            object[] results = this.Invoke("GetMapImage", new object[] {
                        location,
                        country,
                        imageHeight,
                        imageWidth,
                        showRoute});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void GetMapImageAsync(string[] location, string country, int imageHeight, int imageWidth, bool showRoute) {
            this.GetMapImageAsync(location, country, imageHeight, imageWidth, showRoute, null);
        }
        
        /// <remarks/>
        public void GetMapImageAsync(string[] location, string country, int imageHeight, int imageWidth, bool showRoute, object userState) {
            if ((this.GetMapImageOperationCompleted == null)) {
                this.GetMapImageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMapImageOperationCompleted);
            }
            this.InvokeAsync("GetMapImage", new object[] {
                        location,
                        country,
                        imageHeight,
                        imageWidth,
                        showRoute}, this.GetMapImageOperationCompleted, userState);
        }
        
        private void OnGetMapImageOperationCompleted(object arg) {
            if ((this.GetMapImageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMapImageCompleted(this, new GetMapImageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDirections", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetDirections(string[] location, string country) {
            object[] results = this.Invoke("GetDirections", new object[] {
                        location,
                        country});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetDirectionsAsync(string[] location, string country) {
            this.GetDirectionsAsync(location, country, null);
        }
        
        /// <remarks/>
        public void GetDirectionsAsync(string[] location, string country, object userState) {
            if ((this.GetDirectionsOperationCompleted == null)) {
                this.GetDirectionsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDirectionsOperationCompleted);
            }
            this.InvokeAsync("GetDirections", new object[] {
                        location,
                        country}, this.GetDirectionsOperationCompleted, userState);
        }
        
        private void OnGetDirectionsOperationCompleted(object arg) {
            if ((this.GetDirectionsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDirectionsCompleted(this, new GetDirectionsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void FindAdressOrLocationCompletedEventHandler(object sender, FindAdressOrLocationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FindAdressOrLocationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FindAdressOrLocationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetMapImageCompletedEventHandler(object sender, GetMapImageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMapImageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetMapImageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetDirectionsCompletedEventHandler(object sender, GetDirectionsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDirectionsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDirectionsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591