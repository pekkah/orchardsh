using Orchard.Data.Migration;

namespace Heikura.Orchard.Modules.SyntaxHighlighter {
    public class ThemesDataMigration : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("SyntaxHighlighterSettingsRecord",
             table => table
                 .Column<int>("Id", column => column.PrimaryKey().Identity())
                 .Column<string>("CurrentThemeName", column => column.WithDefault("shThemeDefault.css").WithLength(100))
             );

            SchemaBuilder.CreateTable("SyntaxHighlighterThemeRecord",
                table => table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("ThemeName", column => column.WithLength(100))
                    .Column<string>("Author", column => column.WithLength(40))
                );

            return 1;
        }
    }
}