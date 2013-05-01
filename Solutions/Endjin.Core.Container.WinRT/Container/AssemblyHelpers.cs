namespace Endjin.Core.Container
{
    #region Using statements

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    #endregion

    public class AssemblyHelpers
    {
        public static async Task<IEnumerable<Assembly>> GetAssemblyList(params Type[] markerTypes)
        {
            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            var assemblies = new List<Assembly>();
            foreach (var file in (await folder.GetFilesAsync()).Where(file => file.FileType == ".dll" || file.FileType == ".exe"))
            {
                try
                {
                    var filename = file.Name.Substring(0, file.Name.Length - file.FileType.Length);
                    var name = new AssemblyName { Name = filename };
                    var asm = Assembly.Load(name);
                    assemblies.Add(asm);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return assemblies;
        }        
    }
}