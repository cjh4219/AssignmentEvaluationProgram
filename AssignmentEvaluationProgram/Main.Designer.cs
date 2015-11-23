namespace AssignmentEvaluationProgram
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileSelectButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.assessList = new System.Windows.Forms.ListBox();
            this.btn_list_delete = new System.Windows.Forms.Button();
            this.btn_list_add = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.folderSelectButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.userType = new System.Windows.Forms.ComboBox();
            this.eMailAddr = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.HWNo = new System.Windows.Forms.TextBox();
            this.courseName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openExcel = new System.Windows.Forms.OpenFileDialog();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label_intro = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_fileSelect = new System.Windows.Forms.Button();
            this.selectEvaluationFiles = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // fileSelectButton
            // 
            this.fileSelectButton.Location = new System.Drawing.Point(181, 229);
            this.fileSelectButton.Name = "fileSelectButton";
            this.fileSelectButton.Size = new System.Drawing.Size(92, 26);
            this.fileSelectButton.TabIndex = 40;
            this.fileSelectButton.Text = "찾아보기...";
            this.fileSelectButton.UseVisualStyleBackColor = true;
            this.fileSelectButton.Click += new System.EventHandler(this.excelFileOpen_HelpRequest);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 12);
            this.label8.TabIndex = 39;
            this.label8.Text = "명단 Excel 파일 선택(*)";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(153, 369);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(66, 23);
            this.btn_start.TabIndex = 38;
            this.btn_start.Text = "채점 시작";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.startButton_Click);
            // 
            // assessList
            // 
            this.assessList.FormattingEnabled = true;
            this.assessList.ItemHeight = 12;
            this.assessList.Location = new System.Drawing.Point(15, 287);
            this.assessList.Name = "assessList";
            this.assessList.Size = new System.Drawing.Size(257, 76);
            this.assessList.TabIndex = 37;
            // 
            // btn_list_delete
            // 
            this.btn_list_delete.Location = new System.Drawing.Point(73, 369);
            this.btn_list_delete.Name = "btn_list_delete";
            this.btn_list_delete.Size = new System.Drawing.Size(52, 23);
            this.btn_list_delete.TabIndex = 36;
            this.btn_list_delete.Text = "삭제";
            this.btn_list_delete.UseVisualStyleBackColor = true;
            this.btn_list_delete.Click += new System.EventHandler(this.listDelButton_Click);
            // 
            // btn_list_add
            // 
            this.btn_list_add.Location = new System.Drawing.Point(15, 369);
            this.btn_list_add.Name = "btn_list_add";
            this.btn_list_add.Size = new System.Drawing.Size(52, 23);
            this.btn_list_add.TabIndex = 35;
            this.btn_list_add.Text = "추가";
            this.btn_list_add.UseVisualStyleBackColor = true;
            this.btn_list_add.Click += new System.EventHandler(this.listAddButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "채점 세부 사항(*)";
            // 
            // folderSelectButton
            // 
            this.folderSelectButton.Location = new System.Drawing.Point(181, 197);
            this.folderSelectButton.Name = "folderSelectButton";
            this.folderSelectButton.Size = new System.Drawing.Size(92, 26);
            this.folderSelectButton.TabIndex = 33;
            this.folderSelectButton.Text = "찾아보기...";
            this.folderSelectButton.UseVisualStyleBackColor = true;
            this.folderSelectButton.Click += new System.EventHandler(this.folderDialog_HelpRequest);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "채점 폴더 경로 선택(*)";
            // 
            // userType
            // 
            this.userType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userType.FormattingEnabled = true;
            this.userType.Items.AddRange(new object[] {
            "Prof.",
            "T.A.",
            "기타"});
            this.userType.Location = new System.Drawing.Point(134, 86);
            this.userType.Name = "userType";
            this.userType.Size = new System.Drawing.Size(139, 20);
            this.userType.TabIndex = 31;
            // 
            // eMailAddr
            // 
            this.eMailAddr.Location = new System.Drawing.Point(134, 139);
            this.eMailAddr.Name = "eMailAddr";
            this.eMailAddr.Size = new System.Drawing.Size(139, 21);
            this.eMailAddr.TabIndex = 30;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(134, 112);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(139, 21);
            this.userName.TabIndex = 29;
            // 
            // HWNo
            // 
            this.HWNo.Location = new System.Drawing.Point(134, 59);
            this.HWNo.Name = "HWNo";
            this.HWNo.Size = new System.Drawing.Size(139, 21);
            this.HWNo.TabIndex = 28;
            // 
            // courseName
            // 
            this.courseName.Location = new System.Drawing.Point(134, 32);
            this.courseName.Name = "courseName";
            this.courseName.Size = new System.Drawing.Size(139, 21);
            this.courseName.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "점수 문의(E-mail)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "과제 번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "채점자 이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "채점자 구분";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "과목명";
            // 
            // openExcel
            // 
            this.openExcel.Filter = "Excel files (*.xls)|*.xls|Excel files (*.xlsx)|*.xlsx";
            // 
            // label_intro
            // 
            this.label_intro.AutoSize = true;
            this.label_intro.Location = new System.Drawing.Point(37, 9);
            this.label_intro.Name = "label_intro";
            this.label_intro.Size = new System.Drawing.Size(193, 12);
            this.label_intro.TabIndex = 41;
            this.label_intro.Text = "(*)가 있는 항목은 필수항목입니다.";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(225, 369);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(47, 23);
            this.btn_cancel.TabIndex = 42;
            this.btn_cancel.Text = "취소";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 12);
            this.label9.TabIndex = 32;
            this.label9.Text = "채점 파일 선택(중복가능)(*)";
            // 
            // btn_fileSelect
            // 
            this.btn_fileSelect.Location = new System.Drawing.Point(180, 166);
            this.btn_fileSelect.Name = "btn_fileSelect";
            this.btn_fileSelect.Size = new System.Drawing.Size(92, 26);
            this.btn_fileSelect.TabIndex = 33;
            this.btn_fileSelect.Text = "찾아보기...";
            this.btn_fileSelect.UseVisualStyleBackColor = true;
            this.btn_fileSelect.Click += new System.EventHandler(this.evaluationFileOpen_HelpRequest);
            // 
            // selectEvaluationFiles
            // 
            this.selectEvaluationFiles.Filter = "C files (*.c)|*.c|CPP files (*.cpp)|*.cpp";
            this.selectEvaluationFiles.Multiselect = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 396);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.label_intro);
            this.Controls.Add(this.fileSelectButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.assessList);
            this.Controls.Add(this.btn_list_delete);
            this.Controls.Add(this.btn_list_add);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_fileSelect);
            this.Controls.Add(this.folderSelectButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.userType);
            this.Controls.Add(this.eMailAddr);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.HWNo);
            this.Controls.Add(this.courseName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Assignment Evaluater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fileSelectButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.ListBox assessList;
        private System.Windows.Forms.Button btn_list_delete;
        private System.Windows.Forms.Button btn_list_add;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button folderSelectButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox userType;
        private System.Windows.Forms.TextBox eMailAddr;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox HWNo;
        private System.Windows.Forms.TextBox courseName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openExcel;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Label label_intro;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_fileSelect;
        private System.Windows.Forms.OpenFileDialog selectEvaluationFiles;
    }
}

