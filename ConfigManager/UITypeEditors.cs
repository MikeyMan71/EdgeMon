using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RuFramework.Config
{
    public class FileNamesEditor : UITypeEditor
    {
        private OpenFileDialog ofd;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context != null) && (provider != null))
            {
                IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)
                provider.GetService(typeof(IWindowsFormsEditorService));
                if (editorService != null)
                {
                    ofd = new OpenFileDialog();
                    ofd.Multiselect = false;
                    ofd.Filter = "Word|*.docx|All|*.*";
                    ofd.FileName = "";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        return ofd.FileNames;
                    }
                }
            }
            return base.EditValue(context, provider, value);
        }
    }
    #region Folder
    public class FolderNameEditorWithRootFolder : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = (string)value;
                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.SelectedPath;
            }
            return base.EditValue(context, provider, value);
        }
    }
    public class FolderNameEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = (string)value;
                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.SelectedPath;
            }
            return base.EditValue(context, provider, value);
        }
    }

    #endregion
    #region FileSelector
    /// <summary>
    /// Customer UITypeEditor that pops up a
    /// file selector dialog
    /// summary>
    public class FileSelectorTypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context == null || context.Instance == null)
                return base.GetEditStyle(context);
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService;

            if (context == null || context.Instance == null || provider == null)
                return value;


            try
            {
                // get the editor service, just like in windows forms
                editorService = (IWindowsFormsEditorService)
                   provider.GetService(typeof(IWindowsFormsEditorService));

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "All Files (*.*)|*.*";
                dlg.CheckFileExists = true;

                string filename = (string)value;
                if (!File.Exists(filename))
                    filename = null;
                dlg.FileName = filename;

                using (dlg)
                {
                    DialogResult res = dlg.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        filename = dlg.FileName;
                    }
                }
                return filename;

            }
            finally

            {
                editorService = null;
            }
        }
    } // class FileSelectorTypeEditor
    #endregion
    #region Guid
    /// <summary>A type editor for guids</summary>
    public class GuidUITypeEditor : UITypeEditor
    {
        /// <summary>display a modal form </summary>
        /// <param name="context">see documentation on ITypeDescriptorContext</param>
        /// <returns>the style of the editor</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        /// <summary>used to generate the guid</summary>
        /// <param name="context">see documentation on ITypeDescriptorContext</param>
        /// <param name="provider">see documentation on IServiceProvider</param>
        /// <param name="value">the value prior to editing</param>
        /// <returns>the new guid string after editing</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            return EditValue(value as string);
        }

        /// <summary>Generate the guid</summary>
        /// <param name="value">the value prior to editing</param>
        /// <returns>the new connection string after editing</returns>
        public string EditValue(string value)
        {
            return Guid.NewGuid().ToString().ToUpper();
        }
    }
    #endregion
    #region Multiline
    /// <summary>A type editor for multi line text</summary>
    public class MultiLineUITypeEditor : UITypeEditor
    {
        /// <summary>display a modal form </summary>
        /// <param name="context">see documentation on ITypeDescriptorContext</param>
        /// <returns>the style of the editor</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>used to multi line text</summary>
        /// <param name="context">see documentation on ITypeDescriptorContext</param>
        /// <param name="provider">see documentation on IServiceProvider</param>
        /// <param name="value">the value prior to editing</param>
        /// <returns>the new connection string after editing</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            return EditValue(value as string);
        }

        /// <summary>show the form for the multi line text</summary>
        /// <param name="value">the value prior to editing</param>
        /// <returns>the string after editing</returns>
        public string EditValue(string value)
        {
            EnterStringForm dialog = new EnterStringForm();

            dialog.MultiLine = true;

            // Necessary, otherwise the variable will only be displayed in one line.
            if (value != null) value = value.Replace("\n", "\r\n");
            dialog.SelectedString = value;
            // Without Select, all rows are selected
            dialog.Select();
            dialog.ShowDialog();

            return dialog.SelectedString;
        }
    }
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class EnterStringForm : Form
    {
        protected Button ButtonOk;
        protected Button ButtonCancel;
        protected TextBox StringEdit;
        protected bool multiLine;

        protected string selectedString;

        public EnterStringForm()
        {
            //Ru
            multiLine = false;

            InitializeComponent();
        }

        public EnterStringForm(string stringEditValue)
        {
            multiLine = false;

            InitializeComponent();

            if (stringEditValue != null)
            {
                StringEdit.Text = stringEditValue;
            }
        }

        private void InitializeComponent()
        {
            Text = "Enter String";
            ShowInTaskbar = false;

            ButtonOk = new Button();
            ButtonOk.Text = "Ok";
            ButtonOk.Location = new Point(0, 23);
            ButtonOk.FlatStyle = FlatStyle.System;
            ButtonOk.Click += new EventHandler(OnOk);
            Controls.Add(ButtonOk);

            ButtonCancel = new Button();
            ButtonCancel.Text = "Cancel";
            ButtonCancel.Location = new Point(ButtonOk.Width + 2, 23);

            ButtonCancel.FlatStyle = FlatStyle.System;
            Controls.Add(ButtonCancel);

            StringEdit = new TextBox();
            StringEdit.Location = new Point(0, 0);
            Controls.Add(StringEdit);
            StringEdit.Text = selectedString;
            StringEdit.Size = new Size(ButtonCancel.Width + 2 + ButtonOk.Width, 23);

            ClientSize = new Size(ButtonCancel.Width + 2 + ButtonOk.Width, 46);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;

            AcceptButton = ButtonOk;
            CancelButton = ButtonCancel;

            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = false;

            ButtonOk.Anchor = AnchorStyles.Bottom;
            ButtonCancel.Anchor = AnchorStyles.Bottom;
            StringEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            StartPosition = FormStartPosition.CenterParent;

            Activated += new EventHandler(IsActivated);
        }

        private void IsActivated(object sender, EventArgs e)
        {
            StringEdit.Focus();
        }

        public string SelectedString
        {
            get
            {
                return selectedString;
            }
            set
            {
                selectedString = value;
                StringEdit.Text = selectedString;
            }
        }

        public bool MultiLine
        {
            get
            {
                return multiLine;
            }
            set
            {
                if (multiLine != value)
                {
                    if (value)
                    {
                        // Make a multi line text box with scroll bar
                        StringEdit.Multiline = true;
                        StringEdit.ScrollBars = ScrollBars.Vertical;

                        // Make the dialog larger and resizable
                        ClientSize = new Size(400, 323);
                        FormBorderStyle = FormBorderStyle.SizableToolWindow;

                        // Make the enter key not confirm the dialog.
                        AcceptButton = null;
                    }
                    else
                    {
                        // Make a single line text box without scroll bar
                        StringEdit.Multiline = false;
                        StringEdit.ScrollBars = ScrollBars.None;

                        // Make the dialog small and not resizable
                        ClientSize = new Size(ButtonCancel.Width + 2 + ButtonOk.Width, 46);
                        FormBorderStyle = FormBorderStyle.FixedToolWindow;

                        // Make the enter key confirm the dialog again.
                        AcceptButton = ButtonOk;
                    }
                }

                multiLine = value;
            }
        }

        protected virtual void OnOk(object sender, EventArgs e)
        {
            selectedString = StringEdit.Text;
            DialogResult = DialogResult.OK;
        }
    }
    public class ExceptionForm : Form
    {
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label errorMessageLabel;
        private System.Windows.Forms.Button detailsButton;

        private string message;
        private Exception exception;

        public ExceptionForm(string msg, Exception ex)
        {
            message = msg;
            exception = ex;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Error";

            okButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            detailsButton = new System.Windows.Forms.Button();
            pictureBox = new System.Windows.Forms.PictureBox();
            errorLabel = new System.Windows.Forms.Label();
            errorMessageLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            okButton.Location = new System.Drawing.Point(160, 100);
            okButton.Name = "okButton";
            okButton.TabIndex = 0;
            okButton.Text = "OK";
            okButton.Click += new EventHandler(okButton_Click);
            AcceptButton = okButton;
            // 
            // cancelButton
            // 
            cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            cancelButton.Location = new System.Drawing.Point(240, 100);
            cancelButton.Name = "cancelButton";
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            CancelButton = cancelButton;
            // 
            // detailsButton
            // 
            detailsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            detailsButton.Location = new System.Drawing.Point(320, 100);
            detailsButton.Name = "detailsButton";
            detailsButton.TabIndex = 2;
            detailsButton.Text = "Details";
            detailsButton.Click += new EventHandler(detailsButton_Click);
            // 
            // pictureBox
            // 
            pictureBox.Location = new System.Drawing.Point(11, 11);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(40, 40);
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            Bitmap errorImage = new Bitmap(RuConfig.ConfigManager.ResourceConfig.ResourceManager.GetStream("error.png"));
            errorImage.MakeTransparent();
            pictureBox.Image = errorImage;
            // 
            // errorLabel
            // 
            errorLabel.Location = new System.Drawing.Point(64, 20);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new System.Drawing.Size(456, 40);
            errorLabel.TabIndex = 4;
            errorLabel.Text = message;
            // 
            // errorLabel
            // 
            errorMessageLabel.Location = new System.Drawing.Point(64, 60);
            errorMessageLabel.Name = "errorMessageLabel";
            errorMessageLabel.Size = new System.Drawing.Size(456, 40);
            errorMessageLabel.TabIndex = 4;
            errorMessageLabel.Text = "Error message: " + exception.Message;
            // 
            // ExceptionForm
            // 
            AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            ClientSize = new System.Drawing.Size(545, 134);
            Controls.Add(errorLabel);
            Controls.Add(errorMessageLabel);
            Controls.Add(pictureBox);
            Controls.Add(detailsButton);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExceptionForm";
            ShowInTaskbar = false;
            ResumeLayout(false);

            okButton.Focus();

            CenterToScreen();
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(exception.ToString(), "Exception Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
    #endregion

}
