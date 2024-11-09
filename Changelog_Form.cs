using System;
using System.IO;
using System.Windows.Forms;

namespace EdgeMon
{

    public class TextFileViewer : Form
    {
        private TextBox cl_textbox;
      
        public TextFileViewer()
        {
            InitializeComponent();
            LoadTextFile("changelog.txt");
        }
        private void LoadTextFile(string filePath)
        {
            try
            {
                string text = File.ReadAllText(filePath);
                cl_textbox.Text = text;
                cl_textbox.SelectionStart = cl_textbox.TextLength;
            }
            catch (Exception ex)
            {
               
            }
        }

        private void InitializeComponent()
        {
            this.cl_textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cl_textbox
            // 
            this.cl_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cl_textbox.Location = new System.Drawing.Point(0, 0);
            this.cl_textbox.Multiline = true;
            this.cl_textbox.Name = "cl_textbox";
            this.cl_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cl_textbox.Size = new System.Drawing.Size(885, 671);
            this.cl_textbox.TabIndex = 0;
            // 
            // TextFileViewer
            // 
            this.ClientSize = new System.Drawing.Size(885, 671);
            this.Controls.Add(this.cl_textbox);
            this.Name = "TextFileViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

