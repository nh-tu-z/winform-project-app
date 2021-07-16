using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Connect MongoDB */
using MongoDB.Bson;
using MongoDB.Driver;
/* Json */
using Newtonsoft.Json.Linq;

namespace DesktopApp.ChildForm
{
    public partial class DataTables : Form
    {
        private static string _projectId;
        MongoClientSettings mongoSettings = new MongoClientSettings();
        MongoClient client = new MongoClient();

        public DataTables()
        {
            InitializeComponent();
            /* Nav */
            pnlNavTable.Width = btnSum.Width;
            pnlNavTable.Top = btnSum.Bottom;
            pnlNavTable.Left = btnSum.Left;
            /* Inital Data Grid */
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            /**/
            mongoSettings.Server = new MongoServerAddress("localhost", 27017);
        }
        public DataTables(string projectId)
        {
            InitializeComponent();
            /* Nav */
            pnlNavTable.Width = btnSum.Width;
            pnlNavTable.Top = btnSum.Bottom;
            pnlNavTable.Left = btnSum.Left;
            /* Inital Data Grid */
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            /**/
            _projectId = projectId;
            mongoSettings.Server = new MongoServerAddress("localhost", 27017);
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            /* Clear DataGrid */
            dataGridView1.Rows.Clear();

            /* Nav */
            pnlNavTable.Width = btnSum.Width;
            pnlNavTable.Top = btnSum.Bottom;
            pnlNavTable.Left = btnSum.Left;

            /* Show Data */
            var data = getCabinetData("cabinphasesummaries");
            showDataOnGrid(ref data);
        }

        private void btnPhase1_Click(object sender, EventArgs e)
        {
            /* Clear DataGrid */
            dataGridView1.Rows.Clear();

            /* Nav */
            pnlNavTable.Width = btnPhase1.Width;
            pnlNavTable.Top = btnPhase1.Bottom;
            pnlNavTable.Left = btnPhase1.Left;

            /* Show Data */
            var data = getCabinetData("cabinphaseones");
            showDataOnGrid(ref data);
        }

        private void btnPhase2_Click(object sender, EventArgs e)
        {
            /* Clear DataGrid */
            dataGridView1.Rows.Clear();

            /* Nav */
            pnlNavTable.Width = btnPhase2.Width;
            pnlNavTable.Top = btnPhase2.Bottom;
            pnlNavTable.Left = btnPhase2.Left;

            /* Show Data */
            var data = getCabinetData("cabinphasetwos");
            showDataOnGrid(ref data);
        }

        private void btnPhase3_Click(object sender, EventArgs e)
        {
            /* Clear DataGrid */
            dataGridView1.Rows.Clear();

            /* Nav */
            pnlNavTable.Width = btnPhase3.Width;
            pnlNavTable.Top = btnPhase3.Bottom;
            pnlNavTable.Left = btnPhase3.Left;

            /* Show Data */
            var data = getCabinetData("cabinphasethrees");
            showDataOnGrid(ref data);
        }

        /* chua check 2 project khac nhau */
        private List<CabinPhase> getCabinetData(string collectionName)
        {
            var collection = client.GetDatabase("project").GetCollection<CabinPhase>(collectionName);
            return collection.AsQueryable<CabinPhase>().ToList();
        }
        private void showDataOnGrid(ref List<CabinPhase> dataIn)
        {
            foreach (var item in dataIn)
            {
                int i = 0;
                int ord = dataGridView1.Rows.Add();
                dataGridView1.Rows[ord].Cells[i++].Value = ord + 1;
                dataGridView1.Rows[ord].Cells[i++].Value = item.samples["VLN"];
                dataGridView1.Rows[ord].Cells[i++].Value = item.samples["VLL"];
                dataGridView1.Rows[ord].Cells[i++].Value = item.samples["I"];
                dataGridView1.Rows[ord].Cells[i++].Value = item.samples["KW"];
                dataGridView1.Rows[ord].Cells[i++].Value = item.samples["KVAR"];
                dataGridView1.Rows[ord].Cells[i++].Value = item.samples["KVA"];
                dataGridView1.Rows[ord].Cells[i++].Value = item.samples["PF"];
                dataGridView1.Rows[ord].Cells[i++].Value = item.samples["timeStamp"].ToLocalTime();
            }
        }

    }

    public class Users
    {
        public ObjectId id { get; set; }
        public string role { get; set; }
        public bool isVerified { get; set; }
        public BsonDouble project_id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public BsonDateTime createdAt { get; set; }
        public BsonDateTime updatedAt { get; set; }
        public int __v { get; set; }
    }

    public class CabinPhase
    {
        public ObjectId id { get; set; }
        public string device_id { get; set; }
        public int nsample { get; set; }
        public BsonDocument samples { get; set; }
        public BsonDateTime createdAt { get; set; }
        public BsonDateTime updatedAt { get; set; }
        public int __v { get; set; }
    }
}
