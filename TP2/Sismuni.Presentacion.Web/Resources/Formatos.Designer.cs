﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sismuni.Presentacion.Web.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Formatos {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Formatos() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Sismuni.Presentacion.Web.Resources.Formatos", typeof(Formatos).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}{1}.
        /// </summary>
        public static string CodigoPago {
            get {
                return ResourceManager.GetString("CodigoPago", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #0.00.
        /// </summary>
        public static string Decimal {
            get {
                return ResourceManager.GetString("Decimal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to dd/MM/yyyy.
        /// </summary>
        public static string FechaCorta {
            get {
                return ResourceManager.GetString("FechaCorta", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to MM/dd/yyyy.
        /// </summary>
        public static string FechaCortaUS {
            get {
                return ResourceManager.GetString("FechaCortaUS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to dd/MM/yyyy HH:mm:ss.
        /// </summary>
        public static string FechaHora {
            get {
                return ResourceManager.GetString("FechaHora", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to dd/MM/yyyy HH:mm.
        /// </summary>
        public static string FechaHoraCorta {
            get {
                return ResourceManager.GetString("FechaHoraCorta", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to yyyy_MM_dd.
        /// </summary>
        public static string FechaLog {
            get {
                return ResourceManager.GetString("FechaLog", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to yyyy-mm-dd.
        /// </summary>
        public static string FechaSistema {
            get {
                return ResourceManager.GetString("FechaSistema", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 0{0}000{1}.
        /// </summary>
        public static string PreCodigoPago {
            get {
                return ResourceManager.GetString("PreCodigoPago", resourceCulture);
            }
        }
    }
}