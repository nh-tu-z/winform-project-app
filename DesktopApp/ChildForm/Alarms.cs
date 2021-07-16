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

namespace DesktopApp.ChildForm
{
    public partial class Alarms : Form
    {
        MongoClientSettings mongoSettings = new MongoClientSettings();
        MongoClient client = new MongoClient();

        private string _projectId;
        public Alarms(string projectId)
        {
            InitializeComponent();

            /**/
            _projectId = projectId;

            #region Inital Data Grid
            /* Inital Data Grid */
            dGVDigitalAlarms.BorderStyle = BorderStyle.None;
            dGVDigitalAlarms.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dGVDigitalAlarms.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dGVDigitalAlarms.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dGVDigitalAlarms.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dGVDigitalAlarms.BackgroundColor = Color.White;

            dGVDigitalAlarms.EnableHeadersVisualStyles = false;
            dGVDigitalAlarms.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dGVDigitalAlarms.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dGVDigitalAlarms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dGVAnalogAlarms.BorderStyle = BorderStyle.None;
            dGVAnalogAlarms.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dGVAnalogAlarms.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dGVAnalogAlarms.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dGVAnalogAlarms.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dGVAnalogAlarms.BackgroundColor = Color.White;

            dGVAnalogAlarms.EnableHeadersVisualStyles = false;
            dGVAnalogAlarms.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dGVAnalogAlarms.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dGVAnalogAlarms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            #endregion

            /**/
            mongoSettings.Server = new MongoServerAddress("localhost", 27017);
            /* Show Data */
            var digitalAlertData = getDigitalAlert("dalerts");
            var analogAlertData = getAnalogAlert("aalerts");

            showDigitalAlarmData(ref digitalAlertData);
            showAnalogAlarmData(ref analogAlertData);
        }

        private void showDigitalAlarmData(ref List<DigitalAlert> dataIn)
        {
            foreach (var item in dataIn)
            {
                int i = 0;
                int ord = dGVDigitalAlarms.Rows.Add();
                dGVDigitalAlarms.Rows[ord].Cells[i++].Value = ord + 1;
                dGVDigitalAlarms.Rows[ord].Cells[i++].Value = item.tagname;
                dGVDigitalAlarms.Rows[ord].Cells[i++].Value = convertDigitalState(item.value);
                dGVDigitalAlarms.Rows[ord].Cells[i++].Value = item.timestamps.ToLocalTime();
            }
        }

        private void showAnalogAlarmData(ref List<AnalogAlert> dataIn)
        {
            foreach (var item in dataIn)
            {
                int i = 0;
                int ord = dGVAnalogAlarms.Rows.Add();
                dGVAnalogAlarms.Rows[ord].Cells[i++].Value = ord + 1;
                dGVAnalogAlarms.Rows[ord].Cells[i++].Value = item.tagname;
                dGVAnalogAlarms.Rows[ord].Cells[i++].Value = item.value;
                dGVAnalogAlarms.Rows[ord].Cells[i++].Value = item.state;
                dGVAnalogAlarms.Rows[ord].Cells[i++].Value = item.timestamps.ToLocalTime();
            }
        }
        private List<DigitalAlert> getDigitalAlert(string collectionName)
        {
            var collection = client.GetDatabase("project").GetCollection<DigitalAlert>(collectionName);
            return collection.AsQueryable<DigitalAlert>().ToList();
        }
        private List<AnalogAlert> getAnalogAlert(string collectionName)
        {
            var collection = client.GetDatabase("project").GetCollection<AnalogAlert>(collectionName);
            return collection.AsQueryable<AnalogAlert>().ToList();
        }
        private string convertDigitalState(string stateIn)
        {
            return stateIn == "1" ? "ON" : "OFF";
        }
    }

    public class DigitalAlert
    {
        public ObjectId id { get; set; }
        public string device_id { get; set; }
        public string tagname { get; set; }
        public string value { get; set; }
        public BsonDateTime timestamps { get; set; }
        public BsonDateTime createdAt { get; set; }
        public BsonDateTime updatedAt { get; set; }
        public int __v { get; set; }
    }
    public class AnalogAlert
    {
        public ObjectId id { get; set; }
        public string device_id { get; set; }
        public string tagname { get; set; }
        public int value { get; set; }
        public string state { get; set; }
        public BsonDateTime timestamps { get; set; }
        public BsonDateTime createdAt { get; set; }
        public BsonDateTime updatedAt { get; set; }
        public int __v { get; set; }
    }
}
