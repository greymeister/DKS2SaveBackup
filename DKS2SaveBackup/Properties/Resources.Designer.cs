﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DKS2SaveBackup.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DKS2SaveBackup.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DARKSII0000.sl2.
        /// </summary>
        internal static string DARK_SOULS_2_SAVE_FILE {
            get {
                return ResourceManager.GetString("DARK_SOULS_2_SAVE_FILE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \AppData\Roaming\DarkSoulsII\.
        /// </summary>
        internal static string DARK_SOULS_2_SAVEDIR {
            get {
                return ResourceManager.GetString("DARK_SOULS_2_SAVEDIR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to HKEY_CURRENT_USER\\DKS2SaveBackup.
        /// </summary>
        internal static string REG_KEY_NAME {
            get {
                return ResourceManager.GetString("REG_KEY_NAME", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NUMBER_OF_SAVES.
        /// </summary>
        internal static string REG_VALUE_NAME {
            get {
                return ResourceManager.GetString("REG_VALUE_NAME", resourceCulture);
            }
        }
    }
}
