using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace IFM.Views.CRM
{
    public partial class view_CRM_01_003 : Form
    {

        public view_CRM_01_003()
        {
            InitializeComponent();
        }
        DataTable dt;
        readonly string sqlusername = "select user_name, user_cd from m_user  order by user_cd";
        //readonly string sqldelete = "delete from t_salary where 1=1  and ";
        string name_;
        string toemail_;
        string datetime_;
        string filename_;
        // string user_name = "";// ClsVariables.App.UserName;
        private void view_CRM_01_003_Load(object sender, EventArgs e)
        {
            GetCombox();
            dt = new DataTable();
            LoadData(ClsSession.App.UserName);
        }
        void GetCombox()
        {
            try
            {
                dt = new DataTable();
                Class.mysqlconnection con = new Class.mysqlconnection();
                con.sqlDataAdapterFillDatatable(sqlusername, ref dt);
                if (dt.Rows.Count == 0) return;
                var y = (from r in dt.AsEnumerable()
                         select r["user_name"]).Distinct().ToList();
                foreach (var y1 in y)
                { cbm_username.Items.Add(y1); }

                //get value current month
                cbm_month.SelectedItem = DateTime.Now.ToString("MM");
                //get value current year
                cbm_year.SelectedItem = DateTime.Now.ToString("yyyy");
                cbm_username.SelectedItem = ClsSession.App.UserName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        void LoadData(string user_name)
        {
            try
            {
                StringBuilder sqlLoad = new StringBuilder();
                sqlLoad.Append(@"
                select user_name, (SELECT  DISTINCT (user_email) from m_user where user_name  ='" + user_name + @"') as email,
                month,year,dayofmonth,basicsalary_month,actual_workedday,sub_basicsalary_month, bonussalary_month,
                actual_money_basicsalary,actual_money_lunch,actual_numberoflunch,
                CASE (dayofmonth -" + nud_annual_leave.Value + @"-ROUND(actual_workedday,0))
	                WHEN 0 THEN  t2.attendancesalary_month
	                WHEN 1 THEN  (t2.attendancesalary_month/5)*4
	                WHEN 2 THEN  (t2.attendancesalary_month/5)*3
	                WHEN 3 THEN  (t2.attendancesalary_month/5)*2
	                WHEN 4 THEN  (t2.attendancesalary_month/5)*1
	                ELSE 0
                END AS money_attendancesalary,
                numberofmission_L1,
                numberofmission_L2,
                numberofmission_L3,
                numberofmission_L4,
                numberofmission_L5,
                money_sum_mission,
                numberhoursOT1,money_OT1,numberhoursOT2,money_OT2,money_OT1+money_OT2 as money_OT,money_get,insurance_status,
                actual_money_basicsalary + actual_money_lunch + money_sum_mission as actualgetNo_OT,
                actual_money_basicsalary + actual_money_lunch + money_sum_mission+ money_OT1+money_OT2  as actualget_OT,
                if(insurance_status ='True', (sub_basicsalary_month  )*0.105,0 ) as MoneyInsuranceNo_OT
                from 
                (
                select t1.user_name,t1.month,t1.year,t1.dayofmonth,t1.basicsalary_month,t1.actual_workedday,  t1.sub_basicsalary_month, t1.bonussalary_month, t1.attendancesalary_month,
                ROUND((t1.basicsalary_month/t1.dayofmonth)*t1.actual_workedday,0) as actual_money_basicsalary,
                total_havelunch*money_lunch as actual_money_lunch ,total_havelunch as  actual_numberoflunch,
                total_numberofmission_L1 as numberofmission_L1,
                total_numberofmission_L2 as numberofmission_L2,
                total_numberofmission_L3 as numberofmission_L3,
                total_numberofmission_L4 as numberofmission_L4,
                total_numberofmission_L5 as numberofmission_L5,
                total_numberofmission_L1*money_numberofmission_L1 + total_numberofmission_L2*money_numberofmission_L2
                + total_numberofmission_L3*money_numberofmission_L3 + total_numberofmission_L4*money_numberofmission_L4
                + total_numberofmission_L5*money_numberofmission_L5 as money_sum_mission,
                numberhoursOT1,
                numberhoursOT1 * ROUND((t1.basicsalary_month/t1.dayofmonth/8),0)*1.5 as money_OT1,
                numberhoursOT2,
                numberhoursOT2 * ROUND((t1.basicsalary_month/t1.dayofmonth/8),0)*2 as money_OT2,
                money_get,insurance_status
                from
                (
                select
                a.user_name as user_name ,
                min(a.month_) as month ,
                a.year_ as year ,
                " + nud_workMonth.Value + @" as dayofmonth,
                (select basicsalary_month+ bonussalary from m_salary ms where user_name  ='" + user_name + @"') as basicsalary_month,
                (select basicsalary_month from m_salary ms where user_name  ='" + user_name + @"') as sub_basicsalary_month,
                (select bonussalary from m_salary ms where user_name  ='" + user_name + @"') as bonussalary_month,
                (select DISTINCT(money_attendance) from m_salary ms where user_name  ='" + user_name + @"') as attendancesalary_month,
                sum(a.day_keeping) as actual_workedday,
                sum(a.overtime1) as numberhoursOT1,
                sum(a.overtime2) as numberhoursOT2,
                sum(a.total_hour_) as total_hour,
                SUM(a.have_lunch) AS total_havelunch,
                (select DISTINCT money_value from m_money_sub WHERE item_money = 'have_lunch') as money_lunch,
                sum(a.numberofmission_L1) as total_numberofmission_L1,
                (select DISTINCT money_value from m_money_sub WHERE item_money like '%L1:%') as money_numberofmission_L1,
                sum(a.numberofmission_L2) as total_numberofmission_L2,
                (select DISTINCT money_value from m_money_sub WHERE item_money like '%L2:%') as money_numberofmission_L2,
                sum(a.numberofmission_L3) as total_numberofmission_L3,
                (select DISTINCT money_value from m_money_sub WHERE item_money like '%L3:%') as money_numberofmission_L3,
                sum(a.numberofmission_L4) as total_numberofmission_L4,
                (select DISTINCT money_value from m_money_sub WHERE item_money like '%L4:%') as money_numberofmission_L4,
                sum(a.numberofmission_L5) as total_numberofmission_L5,
                (select DISTINCT money_value from m_money_sub WHERE item_money like '%L5:%') as money_numberofmission_L5,
                (SELECT ifnull(sum(money_value),0) from t_get_money WHERE  1=1 and u_get = '" + user_name + @"' and status = 'No Need' and MONTH (d_create) <=" + cbm_month.SelectedItem.ToString() + @"  and YEAR (d_create) =" + cbm_year.SelectedItem.ToString() + @") as money_get,
                (select DISTINCT(money_insurance) from m_salary ms where user_name  = '" + user_name + @"') as insurance_status
                from 
                (
                select 
                user_name ,
                MAX(have_lunch) as have_lunch,
                DAY (startdate_keeping)as day_,MONTH (startdate_keeping) as month_, YEAR (startdate_keeping) as year_, ");
                if (cbm_typeSalary.Text == "Tháng")
                {
                    sqlLoad.Append(@"
                    if(sum(total_keeping) >=9 and  max(WEEKDAY(startdate_keeping)) <6 , sum(total_keeping)-9, 0) as overtime1,
                    if(max(WEEKDAY(startdate_keeping)) =6, sum(total_keeping),0) as overtime2,
                    if(sum(total_keeping) >=9 and max(WEEKDAY(startdate_keeping)) <6, 1,if(max(WEEKDAY(startdate_keeping)) >5, 0,sum(total_keeping)/8)) as day_keeping,");
                }
                else if (cbm_typeSalary.Text == "Giờ")
                {
                    sqlLoad.Append(@"
                    if (sum(total_keeping) >= 9, sum(total_keeping) - 9, 0) as overtime1,
                    0 as overtime2,
                    if (sum(total_keeping) >= 9 , 1,sum(total_keeping) / 8) as day_keeping,");
                }
                sqlLoad.Append(@"
                    sum(total_keeping) as total_hour_,
                    if(max(SUBSTRING(type_mission,1,2))='L1',1,0) as numberofmission_L1,
                    if(max(SUBSTRING(type_mission,1,2))='L2',1,0) as numberofmission_L2,
                    if(max(SUBSTRING(type_mission,1,2))='L3',1,0) as numberofmission_L3,
                    if(max(SUBSTRING(type_mission,1,2))='L4',1,0) as numberofmission_L4,
                    if(max(SUBSTRING(type_mission,1,2))='L5',1,0) as numberofmission_L5
                    from t_TimeKeeping ttk  where ttk.user_name  = '" + user_name + @"'
                    GROUP  by  DAY (startdate_keeping),MONTH (startdate_keeping), YEAR (startdate_keeping),user_name,WEEKDAY(startdate_keeping)
                    )a WHERE 1=1
                    -- and a.day_ >=" + nud_startday.Value + @" and  a.day_ <=" + nud_endday.Value + @"
                    -- and a.month_ = '" + cbm_month.SelectedItem.ToString() + @"'               
                     and ((a.day_ >=" + nud_startday.Value + @" and   a.month_ = '" + (int.Parse(cbm_month.SelectedItem.ToString()) - 1) + @"')
                     or (a.day_ <=" + nud_endday.Value + @" and   a.month_ = '" + (int.Parse(cbm_month.SelectedItem.ToString())) + @"'))
                    and a.year_ = '" + cbm_year.SelectedItem.ToString() + @"'
                    )t1
                    )t2
                    ");

                Class.mysqlconnection con = new Class.mysqlconnection();
                con.sqlDataAdapterFillDatatable(sqlLoad.ToString(), ref dt);
                gc_main.DataSource = dt;
                lbl_rowscount.Text = "Rows Count: " + gv_main.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void cbm_username_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            LoadData(cbm_username.Text);
        }
        bool checkcondition()
        {
            if (cbm_username.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            LoadData(cbm_username.Text);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
        }
        private void btn_save_Click(object sender, EventArgs e)
        {

        }
        void savedb()
        {
            dt.AcceptChanges();
            if (dt.Rows.Count == 0) return;
            Class.mysqlconnection con = new Class.mysqlconnection();
            //Functions function = new Functions();
            foreach (DataRow rowdt in dt.Rows)
            {
                if (rowdt["ID"].ToString() == "")
                {
                    StringBuilder sqlinsert = new StringBuilder();
                    sqlinsert.Append(@"INSERT INTO m_salary
                                    (user_name, basicsalary_month, money_insurance, u_update, d_update, u_create, d_create)
                                    VALUES("
                                    );

                    sqlinsert.Append("'" + rowdt["user_name"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["basicsalary_month"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["money_insurance"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["u_update"].ToString() + "',");
                    sqlinsert.Append("CURRENT_TIMESTAMP,");
                    sqlinsert.Append("'" + ClsSession.App.UserName + "',");
                    sqlinsert.Append("CURRENT_TIMESTAMP");
                    sqlinsert.Append(")");
                    con.sqlExecuteScalarString(sqlinsert.ToString());
                }
                else
                {
                    StringBuilder sqlupdate = new StringBuilder();
                    sqlupdate.Append(@"UPDATE m_salary set ");
                    sqlupdate.Append("user_name = '" + rowdt["user_name"].ToString() + "',");
                    sqlupdate.Append("basicsalary_month = '" + rowdt["basicsalary_month"].ToString() + "',");
                    sqlupdate.Append("money_insurance = '" + rowdt["money_insurance"].ToString() + "',");
                    sqlupdate.Append("u_update = '" + ClsSession.App.UserName + "',");
                    sqlupdate.Append("d_update = CURRENT_TIMESTAMP");
                    sqlupdate.Append(" where 1=1 and ID = " + rowdt["ID"].ToString() + "");
                    con.sqlExecuteScalarString(sqlupdate.ToString());
                }
            }
            MessageBox.Show("Action Successful", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // LoadData(false);
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "output.xlsx";
                gc_main.ExportToXlsx(path);
                Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void btn_exporttemplate_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count < 1) return;
            try
            {
                name_ = "";
                toemail_ = "";
                datetime_ = "";
                filename_ = "";

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet; //sheet 2                          
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(@"E:\C#\Git\IFM\SalaryTemplate.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                //Add data in Sheet 1
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1
                xlWorkSheet.Cells[4, 4] = gv_main.GetRowCellValue(0, "month") + "-" + gv_main.GetRowCellValue(0, "year"); //D4
                xlWorkSheet.Cells[5, 4] = DateTime.Now.ToString("yyyyMMdd HH:mm:ss"); //D5
                xlWorkSheet.Cells[6, 4] = gv_main.GetRowCellValue(0, "user_name");  //D6

                xlWorkSheet.Cells[8, 5] = gv_main.GetRowCellValue(0, "basicsalary_month");  //E8
                xlWorkSheet.Cells[9, 5] = gv_main.GetRowCellValue(0, "dayofmonth");  //E9

                xlWorkSheet.Cells[13, 5] = gv_main.GetRowCellValue(0, "actual_workedday");  //E13
                xlWorkSheet.Cells[14, 5] = gv_main.GetRowCellValue(0, "actual_money_basicsalary");  //E14

                xlWorkSheet.Cells[16, 5] = gv_main.GetRowCellValue(0, "numberhoursOT1");  //E16
                xlWorkSheet.Cells[17, 5] = gv_main.GetRowCellValue(0, "money_OT1");  //E17
                xlWorkSheet.Cells[18, 5] = gv_main.GetRowCellValue(0, "numberhoursOT2");  //E18
                xlWorkSheet.Cells[19, 5] = gv_main.GetRowCellValue(0, "money_OT2");  //E19
                xlWorkSheet.Cells[20, 5] = gv_main.GetRowCellValue(0, "money_OT");  //E20


                xlWorkSheet.Cells[23, 5] = gv_main.GetRowCellValue(0, "actual_numberoflunch");  //E23
                xlWorkSheet.Cells[24, 5] = gv_main.GetRowCellValue(0, "actual_money_lunch");  //E24

                xlWorkSheet.Cells[27, 5] = gv_main.GetRowCellValue(0, "numberofmission_L1");  //E27
                xlWorkSheet.Cells[29, 5] = gv_main.GetRowCellValue(0, "numberofmission_L2");  //E29
                xlWorkSheet.Cells[31, 5] = gv_main.GetRowCellValue(0, "numberofmission_L3");  //E31
                xlWorkSheet.Cells[33, 5] = gv_main.GetRowCellValue(0, "numberofmission_L4");  //E33
                xlWorkSheet.Cells[35, 5] = gv_main.GetRowCellValue(0, "numberofmission_L5");  //E35
                xlWorkSheet.Cells[36, 5] = gv_main.GetRowCellValue(0, "money_sum_mission");  //E36

                xlWorkSheet.Cells[39, 5] = gv_main.GetRowCellValue(0, "actualgetNo_OT");  //E39
                xlWorkSheet.Cells[40, 5] = gv_main.GetRowCellValue(0, "actualget_OT");  //E40

                xlWorkSheet.Cells[43, 5] = gv_main.GetRowCellValue(0, "sub_basicsalary_month");  //E43
                xlWorkSheet.Cells[44, 5] = gv_main.GetRowCellValue(0, "MoneyInsuranceNo_OT");  //E44

                xlWorkSheet.Cells[47, 5] = gv_main.GetRowCellValue(0, "money_attendancesalary");  //E47
                xlWorkSheet.Cells[48, 5] = gv_main.GetRowCellValue(0, "money_get");  //E48
                xlWorkSheet.Cells[49, 5] = txt_bonusadd.Text;  //E49

                xlWorkSheet.Cells[54, 2] = txt_Note.Text;  //E54
                xlWorkBook.SaveAs(@"E:\C#\Salary Monthly\" + gv_main.GetRowCellValue(0, "month") + "_" + gv_main.GetRowCellValue(0, "user_name") + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                      misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                MessageBox.Show("Excel file created, you can find in the folder Salary Monthly ", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Workbooks.Open(@"E:\C#\Salary Monthly\" + gv_main.GetRowCellValue(0, "month") + "_" + gv_main.GetRowCellValue(0, "user_name") + ".xlsx");
                xlApp.Visible = true;
                name_ = gv_main.GetRowCellValue(0, "user_name").ToString();
                toemail_ = gv_main.GetRowCellValue(0, "email").ToString();
                datetime_ = gv_main.GetRowCellValue(0, "month") + "-" + gv_main.GetRowCellValue(0, "year");
                filename_ = gv_main.GetRowCellValue(0, "month") + "_" + gv_main.GetRowCellValue(0, "user_name") + ".xlsx";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void btn_sendemail_Click(object sender, EventArgs e)
        {
            sendemail(name_, toemail_, datetime_, filename_);
        }
        private void sendemail(string name, string toemail, string datetime, string filename)
        {
            string Moneyfilename = "PayGetMoney_" + (int.Parse(cbm_month.SelectedItem.ToString())-1) + "_" + cbm_username.Text + ".xlsx";
            String SendMailFrom = "info@ifmsolutionsvn.com";
            String SendMailTo = toemail;
            String ccMail = "ifm@ifmsolutionsvn.com";
            String SendMailSubject = "Bảng Lương Tháng " + datetime + "";
            string htmlString = @"Dear " + name + @"

                 Cảm ơn vì Bạn đã làm việc chăm chỉ!
                 Và đây là thành quả của bạn tháng này, Lương tháng: " + datetime + @"
                 Xin hãy xem file đính kèm.
                 Vì đây là email tự động, xin hãy kiểm tra file đính kèm và liên hệ với phòng nhân sự qua email: long.thanhle@ifmsolutionsvn.com
                    
              Xin cảm ơn.
                    ---HR-IFM---
              IFM SOLUTIONS., Ltd 
              Mobile: +84 869 123 964| E-mail: info@ifmsolutionsvn.com
              Address: 30/11 Hoang Huu Nam, Long Thanh My, Thu Duc City, Ho Chi Minh City.
              Website: http://ifmsolutionsvn.com
                    ---Thank---

                     ";
            String SendMailBody = htmlString;
            try
            {
                SmtpClient SmtpServer = new SmtpClient("mail93156.maychuemail.com", 25)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                MailMessage email = new MailMessage
                {
                    // START
                    From = new MailAddress(SendMailFrom)
                };
                email.To.Add(SendMailTo);
                email.CC.Add(ccMail);
                email.Subject = SendMailSubject;
                email.Body = SendMailBody;
                var attachment = new Attachment(@"E:\C#\Salary Monthly\" + filename);
                var Moneyattachment = new Attachment(@"E:\C#\Salary Monthly\" + Moneyfilename);
                email.Attachments.Add(attachment);
                email.Attachments.Add(Moneyattachment);
                //END
                SmtpServer.Timeout = 10000;
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(SendMailFrom, "longifm@123");
                SmtpServer.Send(email);

                MessageBox.Show("Sent Email", "Sending Email");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void btn_exportMoney_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            //  string sqlgetpay = "SELECT * from t_get_money WHERE  1=1 and u_get = '" + cbm_username.Text + "' and status = 'No' and MONTH (d_create) <=" + cbm_month.SelectedItem.ToString() +  "  and YEAR (d_create) =" + cbm_year.SelectedItem.ToString() +"";
            string sqlgetpay = @"SELECT max(ID) as ID,'Tổng' as content,sum(money_value)as Money,max(u_get),max(u_pay), 'NA' as type_content, 'NA' as project_name,now() as d_get,'No' as status,now() as d_create
                from t_get_money WHERE  1=1 and u_get = '" + cbm_username.Text + "' and status = 'No'" +
                " and ((MONTH (d_create) =" + cbm_month.SelectedItem.ToString() + " and day (d_create) <=" + nud_endday.Value + " )" +
                " or (MONTH (d_create) =" + (int.Parse(cbm_month.SelectedItem.ToString()) - 1) + " and day (d_create) >=" + nud_startday.Value + " ))" +
                " and YEAR (d_create) =" + cbm_year.SelectedItem.ToString() +""+
                " union " +
                "SELECT ID,content,money_value,u_get,u_pay, type_content,project_name,d_get,status, d_create " +
                "from t_get_money WHERE  1=1 and u_get = '" + cbm_username.Text + "' and status = 'No'" +
                " and ((MONTH (d_create) =" + cbm_month.SelectedItem.ToString() + " and day (d_create) <="+ nud_endday.Value + " )" +
                " or (MONTH (d_create) =" + (int.Parse(cbm_month.SelectedItem.ToString())-1) + " and day (d_create) >=" + nud_startday.Value + " ))" +
                " and YEAR (d_create) =" + cbm_year.SelectedItem.ToString() + "";
            Class.mysqlconnection con = new Class.mysqlconnection();
            con.sqlDataAdapterFillDatatable(sqlgetpay.ToString(), ref tbl);
            string filename = "PayGetMoney_" + (int.Parse(cbm_month.SelectedItem.ToString())-1) + "_" + cbm_username.Text + ".xlsx";
            string excelFilePath = @"E:\C#\Salary Monthly\" + filename;
            try
            {
                if (tbl == null || tbl.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook 
                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();

                // single worksheet
                Excel._Worksheet workSheet = excelApp.ActiveSheet;

                // column headings
                for (var i = 0; i < tbl.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                }

                // rows
                for (var i = 0; i < tbl.Rows.Count; i++)
                {
                    // to do: format datetime values before printing
                    for (var j = 0; j < tbl.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                    }
                }

                // check file path
                if (!string.IsNullOrEmpty(excelFilePath))
                {
                    try
                    {
                        workSheet.SaveAs(excelFilePath);
                        excelApp.Quit();
                        MessageBox.Show("Excel file saved!");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                            + ex.Message);
                    }
                }
                else
                { // no file path is given
                    excelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
}
