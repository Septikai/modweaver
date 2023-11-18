using System;
using System.IO;
using modweaver.core;

namespace modweaver.preload {
    public static class ModweaverEnvironment
    {
        public static string doorstopTargetAssembly { get; private set; }
        
        public static string doorstopManagedAssemblies { get; private set; }
        
        public static string doorstopGameExecutable { get; private set; }
        
        public static string[] doorstopDllSearchDirs { get; private set; }

        internal static void getVars()
        {
            doorstopTargetAssembly = Environment.GetEnvironmentVariable("DOORSTOP_INVOKE_DLL_PATH");
            doorstopManagedAssemblies = Environment.GetEnvironmentVariable("DOORSTOP_MANAGED_FOLDER_DIR");
            doorstopGameExecutable = Environment.GetEnvironmentVariable("DOORSTOP_PROCESS_PATH");
            string searchDirs = Environment.GetEnvironmentVariable("DOORSTOP_DLL_SEARCH_DIRS");
            string[] array;
            if (searchDirs == null)
                array = null;
            else
                array = searchDirs.Split(Path.PathSeparator);
            if (array == null)
                array = Array.Empty<string>();
            doorstopDllSearchDirs = array;

            Paths.modweaverDir = doorstopGameExecutable;
            Paths.libsDir = Path.Combine(Paths.modweaverDir, "libs");
        }
    }
}