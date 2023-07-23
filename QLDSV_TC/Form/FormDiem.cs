using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class FormDiem : Form
    {
        public FormDiem()
        {
            InitializeComponent();
        }

        private void dANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //this.dANGKYBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.dS_SV1);

        }

        private void FormDiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_SV1.DANGKY' table. You can move, or remove it, as needed.
            //this.dANGKYTableAdapter.Fill(this.dS_SV1.DANGKY);
            //// TODO: This line of code loads data into the 'dS_SV1.DANGKY' table. You can move, or remove it, as needed.
            //this.dANGKYTableAdapter.Fill(this.dS_SV1.DANGKY);

        }

        private void dANGKYBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            //this.Validate();
            //this.dANGKYBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.dS_SV1);

        }
    }
}
