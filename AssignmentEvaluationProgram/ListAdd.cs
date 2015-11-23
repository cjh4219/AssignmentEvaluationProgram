using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AssignmentEvaluationProgram
{
    public partial class ListAdd : Form
    {
        public ListAdd()
        {
            InitializeComponent();
            this.AcceptButton = addButton;
            this.CancelButton = cancelButton;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            double d = 0;

            if (!string.IsNullOrEmpty(fileName.Text) && (int.TryParse(point.Text, out i) || double.TryParse(point.Text, out d)))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("파일명(text)과 배점(number)을 확인해주세요");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
        }

        public string getFileName()
        {
            return fileName.Text;
        }

        public string getPoint()
        {
            return point.Text;
        }
    }
}
