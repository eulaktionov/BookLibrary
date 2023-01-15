using LibLib;
using static LibApp.Properties.Resources;

namespace LibApp
{
    public partial class MainForm : Form
    {
        string fileName = "Lib.xml";
        LibSerializer serializer;

        AppMenu menu;
        Lib lib;

        public MainForm()
        {
            InitializeComponent();

            try
            {
                serializer = new LibSerializer(fileName);
                lib = serializer.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                lib = new Lib();
            }

            MakeControls();
            SetForm();

            Load += MainForm_Load;
            FormClosed += (s, e) => Save();
        }

        void MakeControls()
        {
            menu = new()
            {
                Close = () => Close(),
                Open = ShowChildForm,
                Save = Save
            };
            Controls.Add(menu);
        }

        void SetForm()
        {
            (Text, Icon) = (AppTitle, AppIcon);
            IsMdiContainer = true;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            //SignForm form = new SignForm(shop.Customers);
            //if(form.ShowDialog() == DialogResult.Cancel)
            //{
            //    Close();
            //}
        }

        void Save()
        {
            try
            {
                serializer.Save(lib);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void ShowChildForm(object? menuCommand)
        {
            ToolStripMenuItem command = menuCommand as ToolStripMenuItem;
            var form = MdiChildren.FirstOrDefault(f => f.Tag == command);
            if(form == null)
            {
                string title = command.Text.Replace("&", string.Empty);
                form = (command.Tag as Type).Name switch
                {
                    "AuthorsForm" => new AuthorsForm(lib.Authors)
                    { Text = title }
                };
                form.MdiParent = this;
                form.Tag = command;
                form.Show();
            }
            if(form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            form.Activate();
        }
    }
}