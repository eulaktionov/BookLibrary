using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp
{
    internal class AppMenu : MenuStrip
    {
        public Action<object> Open { get; init; }
        public Action Save { get; init; }
        public Action Close { get; init; }

        public AppMenu() => Items.AddRange(new ToolStripItem[]
        {
            new ToolStripMenuItem("&Формы", null, new ToolStripItem[]
            {
                new ToolStripMenuItem("&Авторы", null,
                (s, e) => Open?.Invoke(s)) { Tag = typeof(AuthorsForm) },
                new ToolStripSeparator(),
                new ToolStripMenuItem("&Сохранить", null,
                (s, e) => Save?.Invoke(), Keys.Control | Keys.S),
                new ToolStripSeparator(),
                new ToolStripMenuItem("&Выйти", null,
                (s, e) => Close?.Invoke())
            })
        });
    }
}
