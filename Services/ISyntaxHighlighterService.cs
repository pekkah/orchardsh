using System;
using System.Linq;
using System.Collections.Generic;
using Heikura.Orchard.Modules.SyntaxHighlighter.Models;
using Heikura.Orchard.Modules.SyntaxHighlighter.Records;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;

namespace Heikura.Orchard.Modules.SyntaxHighlighter.Services
{
    public interface ISyntaxHighlighterService : IDependency {
        IEnumerable<string> GetSupportedThemes();
        void SetCurrentTheme(string themeName);
        string GetCurrentTheme();
    }

    public class SyntaxHighlighterService : ISyntaxHighlighterService
    {
        private readonly IRepository<SyntaxHighlighterSettingsRecord> _repository;

        public SyntaxHighlighterService(IRepository<SyntaxHighlighterSettingsRecord> repository) {
            _repository = repository;
        }

        public IEnumerable<string> GetSupportedThemes() {
            // todo (pekka): maybe these could be loaded by using Directory?
            var themes = new List<string>() {
                "shThemeDefault.css",
                "shThemeDjango.css",
                "shThemeEclipse.css",
                "shThemeEmacs.css",
                "shThemeFadeToGrey.css",
                "shThemeMDUltra.css",
                "shThemeMidnight.css",
                "shThemeRDark.css"
            };

            return themes;
        }

        public void SetCurrentTheme(string themeName) {
            var current = _repository.Table.SingleOrDefault();

            if (current == null) {
                current = new SyntaxHighlighterSettingsRecord();
                _repository.Create(current);
            }

            current.CurrentThemeName = themeName;
        }

        public string GetCurrentTheme() {
            var current = _repository.Table.SingleOrDefault();

            if (current == null) {
                return "shThemeDefault.css";
            }

            return current.CurrentThemeName;
        }
    }
}