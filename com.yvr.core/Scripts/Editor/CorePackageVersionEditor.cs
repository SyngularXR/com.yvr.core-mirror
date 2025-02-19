using UnityEditor;
using UnityEditor.Compilation;
using YVR.Utilities.Editor;

namespace YVR.Core.Editor
{
    public class CorePackageVersionEditor
    {
        [InitializeOnLoadMethod]
        private static void Init()
        {
            CompilationPipeline.compilationFinished -= OnCompilationFinished;
            CompilationPipeline.compilationFinished += OnCompilationFinished;
        }

        private static void OnCompilationFinished(object obj)
        {
            var assembly = typeof(YVRManager).Assembly;
            PackageVersionEditor.SaveVersionInfo(assembly);
        }
    }

}


