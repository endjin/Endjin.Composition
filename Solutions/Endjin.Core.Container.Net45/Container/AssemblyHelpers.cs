namespace Endjin.Core.Container
{
    #region Using statements

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    #endregion

    public class AssemblyHelpers
    {
        public static IEnumerable<Assembly> GetAssemblyList(string path)
        {
            var allAssemblies = Directory.GetFiles(path, "*.dll").Select(TryLoadAssembly).Where(a => a != null).ToList();
            allAssemblies.AddRange(Directory.GetFiles(path, "*.exe").Select(TryLoadAssembly).Where(a => a != null));
            return allAssemblies;
        }

        private static Assembly TryLoadAssembly(string name)
        {
            try
            {
                // Need to use Assembly.LoadFrom rather than Assembly.LoadFile otherwise you can end up with more than one
                // version of the same assembly loaded and some dependencies will not resolve (will raise exceptions).
                // See the following for details:
                // http://stackoverflow.com/questions/1477843/difference-between-loadfile-and-loadfrom-with-net-assemblies
                // http://stackoverflow.com/questions/1141787/invalidcastexception-when-serializing-and-deserializing
                // http://blogs.msdn.com/b/suzcook/archive/2003/05/29/57143.aspx
                return Assembly.LoadFrom(name);
            }
            catch (Exception ex)
            {   
                Debug.WriteLine(ex.Message);
            }

            return null;
        }
    }
}