using DevExpress.Xpo;
using KF.Services;
using Survey.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Survey.DBTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var settings = Survey.DBTool.Properties.Settings.Default;
            BL.AppSettings.DataContextConnectionSettings = new BL.ConnectionSettings() { DataSource = settings.server, InitialCatalog = settings.db };
        }



        #region CreateDataLayer
        private void CreateDataLayer()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string conn = DevExpress.Xpo.DB.MSSqlConnectionProvider.GetConnectionString(BL.AppSettings.DataContextConnectionSettings.DataSource, BL.AppSettings.DataContextConnectionSettings.InitialCatalog);
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(conn, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
                MessageBox.Show("Data Layer Created Successfully!!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Can not create data layer\n" + e.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private static void UpdateSchema()
        {
            XpoDefault.Session.UpdateSchema(typeof(Model.User).Assembly);
            XpoDefault.Session.CreateObjectTypeRecords();
        }
        #endregion

        #region cmdUpdateSchema_Click
        private void cmdUpdateSchema_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XpoDefault.DataLayer == null) CreateDataLayer();
                UpdateSchema();


                //var str = System.IO.File.ReadAllText("../../All.sql");

                //string[] arr = str.Split(';');

                //foreach (string cmd in arr)
                //{
                //    var strtemp = cmd.Replace("\r", " ");
                //    strtemp = strtemp.Replace("\n", " ");

                //    int res = XpoDefault.Session.ExecuteNonQuery(strtemp);
                //}



                MessageBox.Show("Database schema Created Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not create the Database schema\n" + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion

        #region cmdCreateDefaultData_Click
        private void cmdCreateDefaultData_Click(object sender, EventArgs e)
        {
            try
            {

                UserEnv env = new UserEnv() { langCode = "he" };
                var us = new UserSession(BL.DataManager.GetDBContext(), env);

                var msgs = Seed.CreateDefaultData(us);

                if (!msgs.hasAnyError)
                    MessageBox.Show("success!!!");

                else MessageBox.Show("An arror occurred");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        } 
        #endregion
    }
}
