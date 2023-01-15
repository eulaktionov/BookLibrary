using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LibLib;

namespace LibApp
{
    public partial class GridForm<T> : Form where T : IdName
    {
        DataGridView grid;
        IdNameList<T> list;

        public GridForm(IdNameList<T> list)
        {
            InitializeComponent();
            this.list = list;
            grid = new DataGridView();
            Load += GridForm_Load;
            Controls.Add(grid);
        }

        private void GridForm_Load(object? sender, EventArgs e)
        {
            grid.Dock = DockStyle.Fill;
            grid.DataSource = list;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns["Id"].ReadOnly = true;
            grid.Columns["Id"].HeaderText = "Код";
            grid.Columns["Id"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            grid.Columns["Id"].DisplayIndex = 0;
            grid.Columns["Name"].DisplayIndex = 1;
            grid.Columns["LastId"].Visible = false;
        }
    }
}
