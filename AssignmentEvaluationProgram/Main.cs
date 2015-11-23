using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Timers;

namespace AssignmentEvaluationProgram
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void evaluationFileOpen_HelpRequest(object sender, EventArgs e)
        {
            if (selectEvaluationFiles.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in selectEvaluationFiles.SafeFileNames)
                {
                    if (fileName.Substring(fileName.Length - 1, 1) == "c")
                    {
                        testCodeList.Add(fileName.Substring(0, fileName.Length-2) + ".exe");                        
                    }
                    else if (fileName.Substring(fileName.Length - 1, 1) == "p")
                    {
                        testCodeList.Add(fileName.Substring(0, fileName.Length - 4) + ".exe");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
                this.evaluationFileSelect = true;
            }
        }

        private void excelFileOpen_HelpRequest(object sender, EventArgs e)
        {
            if (openExcel.ShowDialog() == DialogResult.OK)
            {
                this.excelFileSelect = true;
            }
        }

        private void folderDialog_HelpRequest(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                this.folderSelect = true;
            }
        }

        private void listAddButton_Click(object sender, EventArgs e)
        {
            ListAdd dlg = new ListAdd();
            dlg.ShowDialog();

            if(dlg.DialogResult == DialogResult.OK)
            {
                String addComponent = dlg.getFileName() + ".assess, " + dlg.getPoint();
                assessList.Items.Add(addComponent);
            }
            else if (dlg.DialogResult == DialogResult.Cancel)
            {
            }
        }

        private void listDelButton_Click(object sender, EventArgs e)
        {
            if (assessList.SelectedIndex > -1)
            {
                assessList.Items.Remove(assessList.SelectedItem);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("삭제할 항목을 선택해주세요.");
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (this.excelFileSelect && this.folderSelect && this.evaluationFileSelect)
            {
                dirBuilder(folderDialog.SelectedPath.ToString());
                grading(openExcel.FileName, openExcel.SafeFileName);
                MessageBox.Show("Complete");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("채점파일 선택, 채점폴더 경로, 엑셀파일 선택을 확인해주세요");
            }
        }

        private void dirBuilder(string path)
        {
            string[] filePaths = Directory.GetFiles(path, "*.h");
            string[] AssessmentfilePaths = Directory.GetFiles(path + @"\Assessment", "*");

            foreach (string filePath in filePaths)
            {
                string[] words = filePath.Split('_');
                string[] move_file = words[0].Split('\\');

                if (!Directory.Exists(words[0]))
                {// 
                    Directory.CreateDirectory(words[0]);
                }
                string new_path = words[0] + "\\" + words[1] + "_" + words[2];
                File.Move(filePath, new_path);

                foreach (string file in AssessmentfilePaths)
                {
                    string fileExceptPath = file.Substring(path.Length);
                    string[] asessFile = fileExceptPath.Split('\\');
                    File.Copy(file, words[0] + "\\" + asessFile[2], true);
                }
            }
        }
        
        private void grading(string excelFilePath, string fileName)
        {
            List<Student> studentList = seekStudentList(excelFilePath, fileName);
            foreach (Student data in studentList)
            {
                if (decideSubmit(data.getStdNo()))
                {
                    data.setSubmit(true);
                    executeCompileTest(folderDialog.SelectedPath + "\\" + data.getStdNo(), 5, testCodeList);
                    makePoints(folderDialog.SelectedPath + "\\" + data.getStdNo(), data);
                }
                else
                {
                    data.setSubmit(false);
                }
            }
            writeExcel(studentList, excelFilePath, fileName);
        }

        private DataTable readExcel(string strFilePath, string sheetName)
        {
            object missing = System.Reflection.Missing.Value;

            string strProvider = string.Empty;

            if (sheetName.IndexOf(".xlsx") != -1)
            {
                sheetName = sheetName.Remove(sheetName.IndexOf(".xlsx"), 5);
                strProvider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + strFilePath + @";Extended Properties=Excel 12.0;";
            }
            else if (sheetName.IndexOf(".xls") != -1)
            {
                sheetName = sheetName.Remove(sheetName.IndexOf(".xls"), 4);
                strProvider = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + strFilePath + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
            }
            else
            {
                //error
            }
            // 엑셀 문서 내용 추출

            OleDbConnection excelConnection = new OleDbConnection(strProvider);
            excelConnection.Open();

            string strQuery = "SELECT * FROM [" + sheetName + "$]";

            OleDbCommand dbCommand = new OleDbCommand(strQuery, excelConnection);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(dbCommand);

            DataTable dTable = new DataTable();
            dataAdapter.Fill(dTable);



            dTable.Dispose();
            dataAdapter.Dispose();
            dbCommand.Dispose();

            excelConnection.Close();
            excelConnection.Dispose();

            return dTable;
        }

        private List<Student> seekStudentList(string strFilePath, string sheetName)
        {

            DataTable dTable = readExcel(strFilePath, sheetName);

            Regex reg = new Regex(@"^[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]*$");

            List<Student> studentList = new List<Student>();

            // dTable에 추출된 내용을 String으로 변환
            foreach (DataRow row in dTable.Rows)
            {

                foreach (DataColumn Col in dTable.Columns)
                {
                    if (reg.IsMatch(row[Col].ToString()))
                    {
                        Student stu = new Student();
                        stu.setStdNo(row[Col].ToString());
                        stu.setStdName(row[dTable.Columns[2]].ToString());                        
                        studentList.Add(stu);
                    }
                }
            }

            return studentList;
        }

        private bool decideSubmit(string stuNo)
        {
            if (Directory.Exists(folderDialog.SelectedPath + "\\" + stuNo))
                return true;
            else
                return false;
        }

        private void chec_child()
        {
        }

        private void executeCompileTest(string directoryPath, int time, List<string> testFiles)
        {
            Process bat = new Process();
            bat.StartInfo.WorkingDirectory = directoryPath;
            bat.StartInfo.FileName = directoryPath + "\\compile_test.bat";
            bat.StartInfo.RedirectStandardError = false;
            bat.StartInfo.RedirectStandardInput = false;
            bat.StartInfo.RedirectStandardOutput = false;
            bat.StartInfo.UseShellExecute = false;
            bat.StartInfo.CreateNoWindow = true;
            try
            {
                bat.Start();
                bat.WaitForExit();

                foreach (string file in testFiles)
                {
                    if (File.Exists(directoryPath + "\\" + file))
                    {
                        Process evaluation = new Process();
                        evaluation.StartInfo.WorkingDirectory = directoryPath;
                        evaluation.StartInfo.UseShellExecute = false;
                        evaluation.StartInfo.CreateNoWindow = true;
                        evaluation.StartInfo.FileName = directoryPath + "\\" + file;

                        try
                        {
                            evaluation.Start();
                            if (evaluation.WaitForExit(time * 1000) == false)
                            {
                                evaluation.Kill();
                            }                            
                        }
                        catch (System.Exception ex)
                        {
                            evaluation.Kill();
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }


        }

        private void makePoints(string path, Student student)
        {
            foreach (Object assessFile in assessList.Items)
            {
                string listMem = assessFile.ToString();
                string curFile = listMem.Substring(0, listMem.IndexOf(".assess, "));
                int curPoint = Int32.Parse(listMem.Substring(listMem.IndexOf(".assess, ") + 9));
                curFile = path + "\\" + curFile + ".assess";

                if (File.Exists(curFile))
                {
                    student.setPoint(student.getPoint() + curPoint);
                }
            }
        }
        
        private void writeExcel(List<Student> data, string strFilePath, string fileName)
        {
            object missing = System.Reflection.Missing.Value;

            string strProvider = string.Empty;

            if (fileName.IndexOf(".xlsx") != -1)
            {
                fileName = fileName.Remove(fileName.IndexOf(".xlsx"), 5);
                strProvider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + strFilePath + @";Extended Properties=Excel 12.0;";
            }
            else if (fileName.IndexOf(".xls") != -1)
            {
                fileName = fileName.Remove(fileName.IndexOf(".xls"), 4);
                strProvider = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + strFilePath + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
            }
            else
            {
                //error
            }

            OleDbConnection excelConnection = new OleDbConnection(strProvider);
            excelConnection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = excelConnection;   
            
            string sheetName;
            if (HWNo.Text.Length > 0)
            {
                sheetName = "Homework " + HWNo.Text;
            }
            else
            {
                sheetName = "Homework";
            }

            cmd.CommandText = "CREATE TABLE " + sheetName + " (학번 int, 이름 char(20), 제출여부 char(5), 점수 int)";
            try{
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(sheetName + " sheet가 이미 존재하므로 덮어씌웁니다.");
            }

            foreach (Student eachPerson in data)
            {
                string submit;
                if (eachPerson.getSubmit() == true)
                    submit = "Yes";
                else
                    submit = "No";

                cmd.CommandText = "INSERT INTO " + sheetName + " (학번, 이름, 제출여부, 점수) values ('"
                    + eachPerson.getStdNo().ToString() + "', '" + eachPerson.getStdName().ToString() + "', '"
                    + submit + "', '" + eachPerson.getPoint().ToString() + "')";
                cmd.ExecuteNonQuery();
            }

            excelConnection.Close();

        }

        private bool folderSelect = false;
        private bool excelFileSelect = false;
        private bool evaluationFileSelect = false;
        List<string> testCodeList = new List<string>();

        private class Student
        {
            private string stdNo;
            private string stdName;
            private bool submit;
            private double point;

            public string getStdNo()
            {
                return this.stdNo;
            }

            public string getStdName()
            {
                return this.stdName;
            }

            public bool getSubmit()
            {
                return this.submit;
            }

            public double getPoint()
            {
                return this.point;
            }

            public void setStdNo(string stdNo)
            {
                this.stdNo = stdNo;
            }

            public void setStdName(string stdName)
            {
                this.stdName = stdName;
            }

            public void setSubmit(bool submit)
            {
                this.submit = submit;
            }

            public void setPoint(double point)
            {
                this.point = point;
            }
        }

    }
}
