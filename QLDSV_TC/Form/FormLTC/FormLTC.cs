using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class FormLTC : Form
    {
        private SqlConnection conn_publisher = new SqlConnection();
        int vitri = 0;
        string macn = "";

        public static string magv = "";
        public static string mamh = "";
        public FormLTC()
        {
            InitializeComponent();
        }

        private void lOPTINCHIBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.bdsLopTinChi.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.dS_SV1);

        }
        void loadGVcombobox()
        {
            DataTable dt = new DataTable();
            string cmd = "EXEC dbo.SP_LayDSGV";
            dt = Program.ExecSqlDataTable(cmd);
            BindingSource bdsgv = new BindingSource();
            bdsgv.DataSource = dt;

        }
        private void FormLTC_Load(object sender, EventArgs e)
        {
            loadGVcombobox();
            dS_SV1.EnforceConstraints = false;

            this.LOPTINCHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTINCHITableAdapter.Fill(this.dS_SV1.LOPTINCHI);

            this.DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.DANGKYTableAdapter.Fill(this.dS_SV1.DANGKY);


            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.dS_SV1.MONHOC);

            macn = ((DataRowView)bdsLopTinChi[0])["MAKHOA"].ToString();
            cbKhoa.DataSource = Program.bds_dspm;
            cbKhoa.DisplayMember = "TENKHOA";
            cbKhoa.ValueMember = "TENSERVER";
            cbKhoa.SelectedIndex = Program.mChinhanh;





            if (Program.mGroup == "KHOA")
            {
                cbKhoa.Enabled = false;
            }

        }

        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKhoa.DataSource = Program.bds_dspm;
            cbKhoa.DisplayMember = "TENKHOA";
            cbKhoa.ValueMember = "TENSERVER";
            if (cbKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.severname = cbKhoa.SelectedValue.ToString();
            if (cbKhoa.SelectedIndex != Program.mChinhanh)
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
                    loadGVcombobox();
                    this.LOPTINCHITableAdapter.Connection.ConnectionString = Program.connstr;
                    this.LOPTINCHITableAdapter.Fill(this.dS_SV1.LOPTINCHI);
                    this.DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.DANGKYTableAdapter.Fill(this.dS_SV1.DANGKY);
                    macn = ((DataRowView)bdsLopTinChi[0])["MAKHOA"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không được truy cập phòng kế toán ", "", MessageBoxButtons.OK);
                }

            }
        }
    }
}
