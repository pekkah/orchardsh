using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;

namespace Heikura.Orchard.SyntaxHighlighter.Filters
{
    public class SyntaxHighlighterFilter : FilterProvider, IResultFilter {
        private readonly IResourceManager _resourceManager;

        public SyntaxHighlighterFilter(IResourceManager resourceManager) {
            _resourceManager = resourceManager;
        }

        public void OnResultExecuting(ResultExecutingContext filterContext) {
            _resourceManager.Require("script", ResourceManifest.CoreScript).AtHead();
            _resourceManager.Require("script", ResourceManifest.BrushCSharp).AtHead();
            _resourceManager.Require("script", ResourceManifest.BrushJScript).AtHead();

            _resourceManager.Require("stylesheet", ResourceManifest.CoreStyle).AtHead();
            _resourceManager.Require("stylesheet", ResourceManifest.ThemeDefault).AtHead();

            _resourceManager.RegisterHeadScript("<script type=\"text/javascript\">SyntaxHighlighter.all()</script>");
        }

        public void OnResultExecuted(ResultExecutedContext filterContext) {
        }
    }
}