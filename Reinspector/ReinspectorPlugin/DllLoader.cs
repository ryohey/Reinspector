using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace ReinspectorPlugin
{
    class DllLoader
    {
        private Dictionary<string, Assembly> assemblies = new Dictionary<string, Assembly>();

        public DllLoader()
        {
            AppDomain.CurrentDomain.AssemblyLoad += (s, e) =>
            {
                Debug.Log($"AssemblyLoad: {s} {e.LoadedAssembly.FullName}");
            };

            AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
            {
                Debug.Log($"AssemblyResolve: {s} {e.Name}");
                var assemblyName = new AssemblyName(e.Name);

                var path = $"{assemblyName.Name}.dll";

                if (assemblies.ContainsKey(path))
                {
                    return assemblies[path];
                }

                Debug.LogError($"Failed to AssemblyResolve: {path}");

                return null;
            };
        }

        public void LoadDll(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError($"DLL not found: {path}");
                return;
            }

            try
            {
                var asm = Assembly.LoadFile(path);
                assemblies.Add(path, asm);

                Debug.Log($"Assembly loaded {path}");
            }
            catch (Exception e)
            {
                Debug.LogError(e.GetType().FullName);
                Debug.LogError(e.Message);
            }
        }
    }
}
