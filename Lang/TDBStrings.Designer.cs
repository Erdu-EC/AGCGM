﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AGCGM.Lang {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TDBStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TDBStrings() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AGCGM.Lang.TDBStrings", typeof(TDBStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
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
        ///   Busca una cadena traducida similar a Accediendo a base de datos TDB Version = &quot;{0}&quot;..
        /// </summary>
        internal static string DATABASE_DETECTED {
            get {
                return ResourceManager.GetString("DATABASE_DETECTED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Fichero de base de datos XML vacio..
        /// </summary>
        internal static string DATABASE_FILE_EMPTY {
            get {
                return ResourceManager.GetString("DATABASE_FILE_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Fichero de base de datos XML no encontrado..
        /// </summary>
        internal static string DATABASE_FILE_MISSING {
            get {
                return ResourceManager.GetString("DATABASE_FILE_MISSING", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Formato de base de datos desconocido, no se pudo acceder a los datos..
        /// </summary>
        internal static string DATABASE_FORMAT_UNKNOWN {
            get {
                return ResourceManager.GetString("DATABASE_FORMAT_UNKNOWN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a wiitdb.xml.
        /// </summary>
        internal static string DATABASE_NAME {
            get {
                return ResourceManager.GetString("DATABASE_NAME", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No fue posible analizar la base de datos XML..
        /// </summary>
        internal static string DATABASE_NOT_ANALIZED {
            get {
                return ResourceManager.GetString("DATABASE_NOT_ANALIZED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Detectada base de datos desconocida..
        /// </summary>
        internal static string DATABASE_UNKNOWN_DETECTED {
            get {
                return ResourceManager.GetString("DATABASE_UNKNOWN_DETECTED", resourceCulture);
            }
        }
    }
}
