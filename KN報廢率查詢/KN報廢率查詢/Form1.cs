using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace KN報廢率查詢
{
    public partial class Form1 : Form
    {
        DBAccessor Db = new DBAccessor();
        DBAccessor_SFC Db_sfc = new DBAccessor_SFC(); 
        DataTable Dt_1 = new DataTable();
        DataTable Dt_2 = new DataTable();
        DataTable Dt_merge;
        
        int Quantity = 0;
        DataTable Dt_deposit;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {            
            this.Cursor = Cursors.WaitCursor;//等待狀態游標
            
            dgvOutput.DataSource = null;
            dgvOutput.Refresh();
            Dt_1.Columns.Clear();
            Dt_2.Columns.Clear();

            string str = textBoxInput.Text.Trim(); 
            
            if (str=="")
            {
                MessageBox.Show("請輸入板號或是批號");
                return;
            }

            if (radioButtonLot.Checked)
            {
                string pattern = @"^\d{6}$";
                if (!Regex.IsMatch(str, pattern))
                {
                    MessageBox.Show("請輸入六位整數");
                    return;
                }
               
                Dt_1 = Db_sfc.GetValBy_wo_num(int.Parse(str));

                try
                {
                    object pcs_val = Dt_1.Rows[0]["Spnl_Pcs數"];
                    Dt_2 = Db.GetValBy_wo_num(int.Parse(str), int.Parse(pcs_val.ToString()));
                    StatusDisplay();
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                // 以關聯條件合併 DataTable
                var mergedData = from row1 in Dt_1.AsEnumerable()
                                 join row2 in Dt_2.AsEnumerable() on row1["wo_num"] equals row2["批號"]                                
                                 select row1.ItemArray.Concat(row2.ItemArray).ToArray();
                
                // 額外的 DataTable 來存儲合併的結果
                Dt_merge = new DataTable("MergedTable");

                //產生標頭(Dt_1)
                foreach (DataColumn column in Dt_1.Columns)
                {
                    Dt_merge.Columns.Add(column.ColumnName, column.DataType);
                }

                //產生標頭(Dt_2)
                foreach (DataColumn column in Dt_2.Columns)
                {
                    if (!Dt_merge.Columns.Contains(column.ColumnName))
                    {
                        Dt_merge.Columns.Add(column.ColumnName, column.DataType);
                    }
                }
                
                foreach (var dataRow in mergedData)
                {                    
                    Dt_merge.Rows.Add(dataRow);
                }

                Dt_merge.Columns.Remove("wo_num");                
                dgvOutput.DataSource = Dt_merge;                
                MessageBox.Show("查詢完畢");
                Quantity = 0;
            }

            if (radioButtonPartNoDate.Checked)
            {                
                dateTimePickerStart.MinDate = DateTimePicker.MinimumDateTime;
                dateTimePickerEnd.MaxDate = DateTime.Now;
                var startVal = dateTimePickerStart.Value;
                var endVal = dateTimePickerEnd.Value;                
                var start = startVal.ToString();
                var end = endVal.ToString();
                
                if (startVal > endVal)
                {
                    MessageBox.Show("起始日期不應於截止日期之後");
                    return;
                }
                
                Dt_1 = Db_sfc.GetValBy_part_number(str);
                Dt_deposit = new DataTable("DepositTable");
                
                try
                {
                    foreach (DataRow r in Dt_1.Rows)
                    {
                        object eng_num_val = r["工號"];
                        object pcs_val = r["Spnl_Pcs數"];
                        Dt_2 = Db.GetValBy_eng_num(eng_num_val.ToString(), start, end, int.Parse(pcs_val.ToString()));                        
                        Dt_deposit.Merge(Dt_2);
                        StatusDisplay();
                    }

                    //若Dt_1查無Rows，Dt_2仍需產生僅有標頭空表避免隱藏行出錯
                    if(Dt_1.Rows.Count == 0)
                    {                        
                        Dt_2.Columns.Add("partNo", typeof(string));
                        Dt_2.Columns.Add("批號", typeof(int));
                        Dt_2.Columns.Add("SpnlID", typeof(int));
                        Dt_2.Columns.Add("VI_Xout數", typeof(int));
                        Dt_2.Columns.Add("報廢率", typeof(float));
                        Dt_deposit.Merge(Dt_2);
                        StatusDisplay();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                // 以關聯條件合併 DataTable                
                var mergedData = from row1 in Dt_1.AsEnumerable()
                                 join row2 in Dt_deposit.AsEnumerable()
                                 on row1["工號"].ToString().ToLower() equals row2["partNo"].ToString().ToLower()
                                 select row1.ItemArray.Concat(row2.ItemArray).ToArray();
                
                // 額外的 DataTable 來存儲合併的結果
                Dt_merge = new DataTable("MergedTable");

                //產生標頭(Dt_1)
                foreach (DataColumn column in Dt_1.Columns)
                {
                    Dt_merge.Columns.Add(column.ColumnName, column.DataType);
                }

                //產生標頭(Dt_2)
                foreach (DataColumn column in Dt_deposit.Columns)
                {
                    if (!Dt_merge.Columns.Contains(column.ColumnName))
                    {
                        Dt_merge.Columns.Add(column.ColumnName, column.DataType);
                    }
                }
                
                foreach (var dataRow in mergedData)
                {
                    Dt_merge.Rows.Add(dataRow);
                }
                
                Dt_merge.Columns.Remove("partNo");
                dgvOutput.DataSource = Dt_merge;                
                MessageBox.Show("查詢完畢");
                Quantity = 0;
            }
            
            this.Cursor = Cursors.Default;//還原預設游標 
        }

        public void StatusDisplay()
        {
            Quantity++;
            QueryQuantityStatus.Text = Quantity + " / " + Dt_1.Rows.Count;
            if(Dt_1.Rows.Count == 0)
            {
                QueryQuantityStatus.Text = Quantity + " / 1";
            }
            statusStrip.Refresh();
        }

        private void buttonLotStockSubmit_Click(object sender, EventArgs e)
        {
            dgvDefectRate.DataSource = null;
            dgvDefectRate.Refresh();
            Dt_1.Columns.Clear();

            this.Cursor = Cursors.WaitCursor;//等待狀態游標

            string strLot = textBoxLot.Text.Trim();

            if (strLot == "")
            {
                MessageBox.Show("請輸入批號");
                return;
            }

            string pattern = @"^\d{6}$";
            if (!Regex.IsMatch(strLot, pattern))
            {
                MessageBox.Show("請輸入六位整數");
                return;
            }

            if (radioButtonIn.Checked)
            {
                Dt_1 = Db.GetDefectRateByLot(int.Parse(strLot), 1);
                Dt_merge = Dt_1;
                dgvDefectRate.DataSource = Dt_merge;
            }

            if (radioButtonOut.Checked)
            {
                Dt_1 = Db.GetDefectRateByLot(int.Parse(strLot), 0);
                Dt_merge = Dt_1;
                dgvDefectRate.DataSource = Dt_merge;
            }

            this.Cursor = Cursors.Default;//還原預設游標
        }

        public void Output()
        {            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv files (*.csv)|*.csv";

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;
                    StreamWriter streamWriter = new StreamWriter(path, false, Encoding.Default);
                    
                    // 寫入列名
                    foreach (DataColumn column in Dt_merge.Columns)
                    {
                        streamWriter.Write($"{column.ColumnName},");
                    }
                    streamWriter.WriteLine();

                    // 寫入資料
                    foreach (DataRow row in Dt_merge.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {                            
                            streamWriter.Write($"{item.ToString().Replace(",", "，")},");
                        }
                        streamWriter.WriteLine();
                    }

                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button7point5Output_Click(object sender, EventArgs e)
        {
            if (dgvOutput.DataSource == null)
            {
                MessageBox.Show("目前並無已查詢可供輸出資料");
                return;
            }
            Output();
        }

        private void buttonDefectRateOutput_Click(object sender, EventArgs e)
        {
            if (dgvDefectRate.DataSource == null)
            {
                MessageBox.Show("目前並無已查詢可供輸出資料");
                return;
            }
            Output();
        }
    }
}
