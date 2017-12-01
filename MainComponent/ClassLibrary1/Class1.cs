using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;
using System.ComponentModel.Design;

using System.Windows.Forms.Design.Behavior;

using EnvDTE;
using EnvDTE80;

namespace ClassLibrary1
{
    public class ProjectInfoComponent : UserControl
    {
        //Буфер для отображения сообщений
        private ListBox logBox;
        //Конструктор
        public ProjectInfoComponent()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            logBox = new ListBox();
            SuspendLayout();

            logBox.Dock = DockStyle.Fill;
            logBox.Location = new Point(0, 0);
            logBox.Name = "logList";
            logBox.Size = new Size(200, 95);
            logBox.TabIndex = 0;

            Controls.Add(logBox);
            Name = "LogComponent";
            Size = new Size(200, 100);
            ResumeLayout(false);
        }

        public override ISite Site
        {
            get
            {
                return base.Site;
            }
            set {
                base.Site = value;
                prepareInformation();
            }
        }


        private void prepareInformation()
        {
            if (base.Site == null)
                return;
            ProjectItem pi = (ProjectItem)Site.GetService(typeof(ProjectItem));
            DoLog($"форма {pi?.Name}");
            DoLog($"имя документа {pi?.Document?.FullName}");
        }

        private void DoLog(string text)
        {
            logBox.Items.Add(text);
            logBox.SelectedIndex = logBox.Items.Count - 1;
        }
    }
}
