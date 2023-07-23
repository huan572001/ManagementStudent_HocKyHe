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
    public partial class FormSV : Form
    {

        int vitri = 0;
        string macn = "";
        private string _flagOptionSinhVien;
        private string _oldMaSV;
        public FormSV()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLOP.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS_SV1);

        }

        private void FormSV_Load(object sender, EventArgs e)
        {
            dS_SV1.EnforceConstraints = false;

            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.dS_SV1.LOP);

            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.dS_SV1.SINHVIEN);

            this.DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.DANGKYTableAdapter.Fill(this.dS_SV1.DANGKY);



            macn = ((DataRowView)bdsLOP[0])["MAKHOA"].ToString();
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
            // Program.bds_dspm.Filter = "TENKHOA not LIKE 'Phòng Kế Toán%'";
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
             //cmbKhoa.SelectedIndex = 1;
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
                try
                {
                    this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.LOPTableAdapter.Fill(this.dS_SV1.LOP);

                    this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.SINHVIENTableAdapter.Fill(this.dS_SV1.SINHVIEN);

                    this.DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.DANGKYTableAdapter.Fill(this.dS_SV1.DANGKY);


                    macn = ((DataRowView)bdsLOP[0])["MAKHOA"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không được truy cập phòng kế toán ", "", MessageBoxButtons.OK);
                }

            }
        }
    }
}
