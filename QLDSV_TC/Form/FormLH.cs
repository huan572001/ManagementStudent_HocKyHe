using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
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
    public partial class FormLH : Form
    {
        int vitri = 0;
        Stack undoList = new Stack();
        string macn = "";
        private string _flagOptionLop;
        private string _oldMaLop = "";
        private string _oldTenLop = "";
        public FormLH()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLOP.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_SV1);

        }

        private void FormLH_Load(object sender, EventArgs e)
        {
            dS_SV1.EnforceConstraints = false;

            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.dS_SV1.LOP);

            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.dS_SV1.SINHVIEN);
            /*  macn = ((DataRowView)bdsLOP[0])["MAKHOA"].ToString();*/
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "KHOA")
            {
                cmbKhoa.Enabled = false;
            }


        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.bds_dspm.Filter = "TENKHOA not LIKE 'Phòng Kế Toán%'";
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            if (cmbKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.severname = cmbKhoa.SelectedValue.ToString();
            if (cmbKhoa.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            }
            else
            {
                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.dS_SV1.LOP);

                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.SINHVIENTableAdapter.Fill(this.dS_SV1.SINHVIEN);


            }
            macn = ((DataRowView)bdsLOP[0])["MAKHOA"].ToString();
        }
    }
}
