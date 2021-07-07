using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Nav */
using System.Runtime.InteropServices;
/* Add child form */
using DesktopApp.ChildForm;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            /* Nav */
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            /* Open Child Form */
            lblTabName.Text = "Dashboard";
            this.pnlFormLoader.Controls.Clear();
            Dashboard FrmDashboard_Vrb = new Dashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnDataTable_Click(object sender, EventArgs e)
        {
            /* Nav */
            pnlNav.Height = btnDataTable.Height;
            pnlNav.Top = btnDataTable.Top;
            pnlNav.Left = btnDataTable.Left;
            btnDataTable.BackColor = Color.FromArgb(46, 51, 73);

            /* Open Child Form */
            lblTabName.Text = "Data Table";
            this.pnlFormLoader.Controls.Clear();
            DataTables FrmDataTables_Vrb = new DataTables() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDataTables_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmDataTables_Vrb);
            FrmDataTables_Vrb.Show();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            /* Nav */
            pnlNav.Height = btnSetting.Height;
            pnlNav.Top = btnSetting.Top;
            pnlNav.Left = btnSetting.Left;
            btnSetting.BackColor = Color.FromArgb(46, 51, 73);

            /* Open Child Form */
            lblTabName.Text = "Setting";
            this.pnlFormLoader.Controls.Clear();
            Setting FrmSetting_Vrb = new Setting() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmSetting_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmSetting_Vrb);
            FrmSetting_Vrb.Show();
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnDataTable_Leave(object sender, EventArgs e)
        {
            btnDataTable.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSetting_Leave(object sender, EventArgs e)
        {
            btnSetting.BackColor = Color.FromArgb(24, 30, 54);
        }
    }
}
