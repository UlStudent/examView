using examBusinessLogic.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace examView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly BackUpAbstractLogic _backUpAbstractLogic;
        public FormMain(BackUpAbstractLogic backUpAbstractLogic)
        {
            InitializeComponent();
            _backUpAbstractLogic = backUpAbstractLogic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormComponents>();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReport>();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (_backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        _backUpAbstractLogic.CreateArchive(fbd.SelectedPath);
                        MessageBox.Show("Бекап создан", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
