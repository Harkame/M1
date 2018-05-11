﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibrarianClient.LibraryManagerServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LibraryManagerServiceReference.ServiceSoap")]
    public interface ServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Authentificate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        LibrarianClient.LibraryManagerServiceReference.User Authentificate(int p_id, string p_password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AuthentificateAsLibrarian", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        LibrarianClient.LibraryManagerServiceReference.Librarian AuthentificateAsLibrarian(int p_id, string p_password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AuthentificateAsSubscriber", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        LibrarianClient.LibraryManagerServiceReference.Subscriber AuthentificateAsSubscriber(int p_id, string p_password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Disconnect", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void Disconnect(LibrarianClient.LibraryManagerServiceReference.User p_user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SearchBookByISBN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        LibrarianClient.LibraryManagerServiceReference.Book SearchBookByISBN(LibrarianClient.LibraryManagerServiceReference.User p_User, int p_isbn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SearchBooksByAuthor", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        LibrarianClient.LibraryManagerServiceReference.Book[] SearchBooksByAuthor(LibrarianClient.LibraryManagerServiceReference.User p_User, string p_author);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooks", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetBooks(LibrarianClient.LibraryManagerServiceReference.User p_user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCommands", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetCommands(LibrarianClient.LibraryManagerServiceReference.User p_user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBookDescription", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetBookDescription(LibrarianClient.LibraryManagerServiceReference.User p_user, int p_isbn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddBook", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool AddBook(LibrarianClient.LibraryManagerServiceReference.User p_librarian, string p_title, string p_author, int p_isbn, int p_stock, string p_editor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CommentBook", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool CommentBook(LibrarianClient.LibraryManagerServiceReference.User p_subscriber, int p_isbn, string p_description);
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Subscriber))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Librarian))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class User : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string passwordField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("ID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Comment : object, System.ComponentModel.INotifyPropertyChanged {
        
        private User userField;
        
        private string descriptionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public User User {
            get {
                return this.userField;
            }
            set {
                this.userField = value;
                this.RaisePropertyChanged("User");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Book : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string titleField;
        
        private string authorField;
        
        private int iSBNField;
        
        private int stockField;
        
        private string editorField;
        
        private Comment[] commentsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
                this.RaisePropertyChanged("Title");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Author {
            get {
                return this.authorField;
            }
            set {
                this.authorField = value;
                this.RaisePropertyChanged("Author");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int ISBN {
            get {
                return this.iSBNField;
            }
            set {
                this.iSBNField = value;
                this.RaisePropertyChanged("ISBN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int Stock {
            get {
                return this.stockField;
            }
            set {
                this.stockField = value;
                this.RaisePropertyChanged("Stock");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Editor {
            get {
                return this.editorField;
            }
            set {
                this.editorField = value;
                this.RaisePropertyChanged("Editor");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=5)]
        public Comment[] Comments {
            get {
                return this.commentsField;
            }
            set {
                this.commentsField = value;
                this.RaisePropertyChanged("Comments");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Subscriber : User {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Librarian : User {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServiceSoapChannel : LibrarianClient.LibraryManagerServiceReference.ServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceSoapClient : System.ServiceModel.ClientBase<LibrarianClient.LibraryManagerServiceReference.ServiceSoap>, LibrarianClient.LibraryManagerServiceReference.ServiceSoap {
        
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
        
        public LibrarianClient.LibraryManagerServiceReference.User Authentificate(int p_id, string p_password) {
            return base.Channel.Authentificate(p_id, p_password);
        }
        
        public LibrarianClient.LibraryManagerServiceReference.Librarian AuthentificateAsLibrarian(int p_id, string p_password) {
            return base.Channel.AuthentificateAsLibrarian(p_id, p_password);
        }
        
        public LibrarianClient.LibraryManagerServiceReference.Subscriber AuthentificateAsSubscriber(int p_id, string p_password) {
            return base.Channel.AuthentificateAsSubscriber(p_id, p_password);
        }
        
        public void Disconnect(LibrarianClient.LibraryManagerServiceReference.User p_user) {
            base.Channel.Disconnect(p_user);
        }
        
        public LibrarianClient.LibraryManagerServiceReference.Book SearchBookByISBN(LibrarianClient.LibraryManagerServiceReference.User p_User, int p_isbn) {
            return base.Channel.SearchBookByISBN(p_User, p_isbn);
        }
        
        public LibrarianClient.LibraryManagerServiceReference.Book[] SearchBooksByAuthor(LibrarianClient.LibraryManagerServiceReference.User p_User, string p_author) {
            return base.Channel.SearchBooksByAuthor(p_User, p_author);
        }
        
        public string GetBooks(LibrarianClient.LibraryManagerServiceReference.User p_user) {
            return base.Channel.GetBooks(p_user);
        }
        
        public string GetCommands(LibrarianClient.LibraryManagerServiceReference.User p_user) {
            return base.Channel.GetCommands(p_user);
        }
        
        public string GetBookDescription(LibrarianClient.LibraryManagerServiceReference.User p_user, int p_isbn) {
            return base.Channel.GetBookDescription(p_user, p_isbn);
        }
        
        public bool AddBook(LibrarianClient.LibraryManagerServiceReference.User p_librarian, string p_title, string p_author, int p_isbn, int p_stock, string p_editor) {
            return base.Channel.AddBook(p_librarian, p_title, p_author, p_isbn, p_stock, p_editor);
        }
        
        public bool CommentBook(LibrarianClient.LibraryManagerServiceReference.User p_subscriber, int p_isbn, string p_description) {
            return base.Channel.CommentBook(p_subscriber, p_isbn, p_description);
        }
    }
}
