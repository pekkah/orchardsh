using Orchard.UI.Resources;

namespace Heikura.Orchard.Modules.SyntaxHighlighter
{
    public class ResourceManifest : IResourceManifestProvider {
        public const string NamePrefix = "sh_";

        public const string CoreScript = NamePrefix + "script_core";
        public const string CoreStyle = NamePrefix + "style_core";

        // brushes
        public const string BrushCSharp = NamePrefix + "brush_csharp";
        public const string BrushJScript = NamePrefix + "brush_jscript";

        // themes
        public const string ThemeDefault = NamePrefix + "style_defaultTheme";

        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            // core scripts
            manifest.DefineScript(CoreScript).SetUrl("shCore.js");

            // define brush scripts 
            // TODO (pekkah): Define a admin UI for configuring which brushes are included
            manifest.DefineScript(BrushCSharp).SetUrl("shBrushCSharp.js");
            manifest.DefineScript(BrushJScript).SetUrl("shBrushJScript.js");

            // core styles
            manifest.DefineStyle(CoreStyle).SetUrl("shCore.css");

            // use default theme
            // TODO (pekkah): Define a admin UI for configuring the used theme
            manifest.DefineStyle(ThemeDefault).SetUrl("shThemeDefault.css");
        }
    }
}
