using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Reflection;

namespace MySqlBackupAll
{
    public partial class Form1 : Form
    {
        BackgroundWorker bw1 = new BackgroundWorker();

        int count = 0;
        string folder = "";
        DateTime timeProcessStart = DateTime.Now;
        bool hasError = false;
        string errmsg = "";
        string constr = "";
        string task = "restore";

        public Form1()
        {
            InitializeComponent();
            bw1.WorkerReportsProgress = true;
            bw1.DoWork += Bw1_DoWork;
            bw1.RunWorkerCompleted += Bw1_RunWorkerCompleted;
            bw1.ProgressChanged += Bw1_ProgressChanged;
        }

        private void Bw1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            txtProgress.AppendText(e.UserState + "");
            txtProgress.Select(txtProgress.Text.Length - 1, 0);
            txtProgress.ScrollToCaret();
        }

        private void Bw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DateTime timeProcessEnd = DateTime.Now;

            var timeTotal = timeProcessEnd - timeProcessStart;

            this.SuspendLayout();

            txtProgress.Text = txtProgress.Text + "\r\nProcess End at " + timeProcessEnd.ToString("yyyy-MM-dd HH:mm:ss ffff") + "\r\n\r\nTotal time elapsed: " + string.Format("{0} h {1} m {2} s {3} ms \r\n\r\n", timeTotal.Hours, timeTotal.Minutes, timeTotal.Seconds, timeTotal.Milliseconds);

            if (hasError)
            {
                txtProgress.AppendText("\r\nError:\r\n\r\n");
                txtProgress.AppendText(errmsg);
            }

            txtProgress.Select(txtProgress.Text.Length - 1, 0);
            txtProgress.ScrollToCaret();

            this.ResumeLayout();
            this.PerformLayout();

            EnableDisableButtons(true);
            MessageBox.Show(task + " Process completed");
        }

        private void Bw1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (task == "restore")
                {
                    DoRestore();
                }
                else
                {
                    RunScripts(task);
                }
            }
            catch (Exception ex)
            {
                hasError = true;
                errmsg = ex.ToString();
            }
        }

        void DoRestore()
        {
            string[] files = Directory.GetFiles(folder);

            DateTime timeProcessStart = DateTime.Now;

            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 0;

                    foreach (string file in files)
                    {
                        try
                        {
                            string db = "openmrs_" + Path.GetFileNameWithoutExtension(file);

                            DateTime dateStart = DateTime.Now;

                            string appendText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  Restore " + db + "....";
                            bw1.ReportProgress(0, appendText);

                            cmd.CommandText = "create database if not exists `" + db + "`";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = $"use `{db}`";
                            cmd.ExecuteNonQuery();

                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                mb.ImportFromFile(file);
                            }

                            DateTime dateEnd = DateTime.Now;

                            var timeElapsed = dateEnd - dateStart;

                            appendText = $" completed ({timeElapsed.Hours} h {timeElapsed.Minutes} m {timeElapsed.Seconds} s {timeElapsed.Milliseconds} ms)\r\n";
                            bw1.ReportProgress(0, appendText);
                        }
                        catch(Exception ex)
                        {
                            bw1.ReportProgress(0, ex.Message + "\r\n");
                        }

                        count++;
                    }

                    conn.Close();
                }
            }
        }

        void RunScripts(string task)
        {
            DataTable dt = ExecuteQuery("select SCHEMA_NAME as db_name from information_schema.SCHEMATA where SCHEMA_NAME like 'openmrs%';");

            DateTime timeProcessStart = DateTime.Now;

            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 0;

                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            string db = dr["db_name"].ToString();

                            DateTime dateStart = DateTime.Now;

                            string appendText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  " + task + " " + db + "....";
                            bw1.ReportProgress(0, appendText);

                            cmd.CommandText = $"use `{db}`";
                            cmd.ExecuteNonQuery();

                            string path = "";

                            if (task == "initialize")
                            {
                                path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"scripts\kenyaemr_initialize_dbs.sql");
                            }
                            else if (task == "deidentify")
                            {
                                path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"scripts\kenyaemr_deidentify.sql");
                            }
                            else if (task == "refresh")
                            {
                                path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"scripts\kenyaemr_refresh_tables.sql");
                            }
                            else if (task == "mastertable")
                            {
                                path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"scripts\kenyaemr_create_master_list.sql");
                            }

                            cmd.CommandText = File.ReadAllText(path).Replace('\n', ' ');
                            cmd.ExecuteNonQuery();

                            DateTime dateEnd = DateTime.Now;

                            var timeElapsed = dateEnd - dateStart;

                            appendText = $" completed ({timeElapsed.Hours} h {timeElapsed.Minutes} m {timeElapsed.Seconds} s {timeElapsed.Milliseconds} ms)\r\n";
                            bw1.ReportProgress(0, appendText);
                        }
                        catch (Exception ex)
                        {
                            bw1.ReportProgress(0, ex.Message + "\r\n");
                        }

                        count++;
                    }

                    conn.Close();
                }
            }
        }

        bool LoadData()
        {
            GC.Collect();
            hasError = false;
            errmsg = "";
            folder = lbFolder.Text;
            constr = txtConnStr.Text;
            count = 0;
            timeProcessStart = DateTime.Now;
            txtProgress.Text = "Start at " + timeProcessStart.ToString("yyyy-MM-dd HH:mm:ss ffff") + "\r\n\r\n";
            this.Refresh();

            if (constr.Length == 0)
            {
                MessageBox.Show("Connection string is not set. Cannot continue.");
                return false;
            }

            return true;
        }

        private void btRestore_Click(object sender, EventArgs e)
        {
            if (lbFolder.Text.Length == 0)
            {
                MessageBox.Show("Folder is not set");
                return;
            }

            if (!Directory.Exists(lbFolder.Text))
            {
                MessageBox.Show("Selected folder is not existed.");
                return;
            }

            if (!LoadData())
            {
                return;
            }

            task = "restore";
            EnableDisableButtons(false);
            bw1.RunWorkerAsync();
        }

        private void EnableDisableButtons(bool isenable)
        {
            btRestore.Enabled = isenable;
            btnDeidentify.Enabled = isenable;
            btnInitialize.Enabled = isenable;
            btnRefreshETL.Enabled = isenable;
            btSetFolder.Enabled = isenable;
            btnMasterTable.Enabled = isenable;
        }

        private void btSetFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                lbFolder.Text = fb.SelectedPath;
            }
        }

        DataTable GetTable(MySqlCommand cmd, string sql)
        {
            cmd.CommandText = sql;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private DataTable ExecuteQuery(string sQuery)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(constr);
                MySqlCommand command = new MySqlCommand(sQuery, conn);
                command.CommandTimeout = 0;
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataSet dataset = new DataSet();
                DataTable dt;

                adapter.Fill(dataset);
                dt = dataset.Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            constr = txtConnStr.Text;
            task = "initialize";
            EnableDisableButtons(false);
            bw1.RunWorkerAsync();
        }

        private void btnDeidentify_Click(object sender, EventArgs e)
        {
            constr = txtConnStr.Text;
            task = "deidentify";
            EnableDisableButtons(false);
            bw1.RunWorkerAsync();
        }

        private void btnRefreshETL_Click(object sender, EventArgs e)
        {
            constr = txtConnStr.Text;
            task = "refresh";
            EnableDisableButtons(false);
            bw1.RunWorkerAsync();
        }

        private void btnMasterTable_Click(object sender, EventArgs e)
        {
            constr = txtConnStr.Text;
            task = "mastertable";
            EnableDisableButtons(false);
            bw1.RunWorkerAsync();
        }
    }
}