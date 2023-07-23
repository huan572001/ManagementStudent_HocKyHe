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
    public partial class FormMH : Form
    {

        int vitri = 0;
        private string flagOption;
        private string oldMaMonHoc = "";
        private string oldTenMonHoc = "";
        public FormMH()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_SV1);

        }

        private void FormMH_Load(object sender, EventArgs e)
        {
            dS_SV1.EnforceConstraints = false;
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.dS_SV1.MONHOC);

            this.lOPTINCHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTINCHITableAdapter.Fill(this.dS_SV1.LOPTINCHI);

            //if (Program.mGroup == "SV")
            //{

            //    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
            //}
            //else
            //{

            //    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;
            //}
        }
    }
}
