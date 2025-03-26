namespace Content.SimpleUiShell
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Panel _main_container;
            messageLabel = new Label();
            compileBtn = new Button();
            authorInputBox = new TextBox();
            outputFileNameInputBox = new TextBox();
            chooseOuputFileFilderBtn = new Button();
            outputFilePathInputBox = new TextBox();
            chooseWorkFolderPathBtn = new Button();
            onFileAlreadyExsistOperationDropDown = new ComboBox();
            workFolderPathInputBox = new TextBox();
            workFolderBrowseDialog = new FolderBrowserDialog();
            outputFileFolderBrowseDialog = new FolderBrowserDialog();
            _main_container = new Panel();
            _main_container.SuspendLayout();
            SuspendLayout();
            // 
            // _main_container
            // 
            _main_container.Controls.Add(messageLabel);
            _main_container.Controls.Add(compileBtn);
            _main_container.Controls.Add(authorInputBox);
            _main_container.Controls.Add(outputFileNameInputBox);
            _main_container.Controls.Add(chooseOuputFileFilderBtn);
            _main_container.Controls.Add(outputFilePathInputBox);
            _main_container.Controls.Add(chooseWorkFolderPathBtn);
            _main_container.Controls.Add(onFileAlreadyExsistOperationDropDown);
            _main_container.Controls.Add(workFolderPathInputBox);
            _main_container.Dock = DockStyle.Fill;
            _main_container.Location = new Point(0, 0);
            _main_container.Margin = new Padding(10);
            _main_container.Name = "_main_container";
            _main_container.Padding = new Padding(10);
            _main_container.Size = new Size(284, 241);
            _main_container.TabIndex = 0;
            // 
            // messageLabel
            // 
            messageLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            messageLabel.AutoEllipsis = true;
            messageLabel.BackColor = SystemColors.Control;
            messageLabel.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            messageLabel.ForeColor = SystemColors.ControlDarkDark;
            messageLabel.Location = new Point(10, 165);
            messageLabel.Name = "messageLabel";
            messageLabel.Padding = new Padding(0, 2, 0, 3);
            messageLabel.Size = new Size(264, 34);
            messageLabel.TabIndex = 8;
            messageLabel.Text = "message";
            messageLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // compileBtn
            // 
            compileBtn.Dock = DockStyle.Bottom;
            compileBtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            compileBtn.Location = new Point(10, 199);
            compileBtn.Margin = new Padding(0);
            compileBtn.Name = "compileBtn";
            compileBtn.Size = new Size(264, 32);
            compileBtn.TabIndex = 7;
            compileBtn.Text = "Assemble";
            compileBtn.UseVisualStyleBackColor = true;
            compileBtn.Click += compileBtn_Click;
            // 
            // authorInputBox
            // 
            authorInputBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            authorInputBox.Location = new Point(10, 142);
            authorInputBox.Margin = new Padding(0);
            authorInputBox.Name = "authorInputBox";
            authorInputBox.PlaceholderText = "Author (optional)";
            authorInputBox.Size = new Size(264, 23);
            authorInputBox.TabIndex = 6;
            authorInputBox.TextChanged += authorInputBox_TextChanged;
            // 
            // outputFileNameInputBox
            // 
            outputFileNameInputBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            outputFileNameInputBox.Location = new Point(10, 76);
            outputFileNameInputBox.Margin = new Padding(0);
            outputFileNameInputBox.Name = "outputFileNameInputBox";
            outputFileNameInputBox.PlaceholderText = "Output file name*";
            outputFileNameInputBox.Size = new Size(264, 23);
            outputFileNameInputBox.TabIndex = 4;
            outputFileNameInputBox.TextChanged += outputFileNameInputBox_TextChanged;
            // 
            // chooseOuputFileFilderBtn
            // 
            chooseOuputFileFilderBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chooseOuputFileFilderBtn.Location = new Point(198, 43);
            chooseOuputFileFilderBtn.Margin = new Padding(0);
            chooseOuputFileFilderBtn.Name = "chooseOuputFileFilderBtn";
            chooseOuputFileFilderBtn.Size = new Size(76, 23);
            chooseOuputFileFilderBtn.TabIndex = 2;
            chooseOuputFileFilderBtn.Text = "Choose";
            chooseOuputFileFilderBtn.UseVisualStyleBackColor = true;
            chooseOuputFileFilderBtn.Click += chooseOuputFileFilderBtn_Click;
            // 
            // outputFilePathInputBox
            // 
            outputFilePathInputBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            outputFilePathInputBox.ForeColor = SystemColors.WindowText;
            outputFilePathInputBox.Location = new Point(10, 43);
            outputFilePathInputBox.Margin = new Padding(0);
            outputFilePathInputBox.Name = "outputFilePathInputBox";
            outputFilePathInputBox.PlaceholderText = "Output file path*";
            outputFilePathInputBox.Size = new Size(178, 23);
            outputFilePathInputBox.TabIndex = 3;
            outputFilePathInputBox.TextChanged += outputFilePathInputBox_TextChanged;
            // 
            // chooseWorkFolderPathBtn
            // 
            chooseWorkFolderPathBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chooseWorkFolderPathBtn.FlatStyle = FlatStyle.System;
            chooseWorkFolderPathBtn.Location = new Point(198, 10);
            chooseWorkFolderPathBtn.Margin = new Padding(0);
            chooseWorkFolderPathBtn.Name = "chooseWorkFolderPathBtn";
            chooseWorkFolderPathBtn.Size = new Size(76, 24);
            chooseWorkFolderPathBtn.TabIndex = 0;
            chooseWorkFolderPathBtn.Text = "Choose";
            chooseWorkFolderPathBtn.UseVisualStyleBackColor = true;
            chooseWorkFolderPathBtn.Click += chooseWorkFolderPathBtn_Click;
            // 
            // onFileAlreadyExsistOperationDropDown
            // 
            onFileAlreadyExsistOperationDropDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            onFileAlreadyExsistOperationDropDown.FormattingEnabled = true;
            onFileAlreadyExsistOperationDropDown.ImeMode = ImeMode.NoControl;
            onFileAlreadyExsistOperationDropDown.ItemHeight = 15;
            onFileAlreadyExsistOperationDropDown.Location = new Point(10, 109);
            onFileAlreadyExsistOperationDropDown.Name = "onFileAlreadyExsistOperationDropDown";
            onFileAlreadyExsistOperationDropDown.Size = new Size(264, 23);
            onFileAlreadyExsistOperationDropDown.TabIndex = 5;
            onFileAlreadyExsistOperationDropDown.SelectedIndexChanged += onFileAlreadyExsistOperationDropDown_SelectedIndexChanged;
            // 
            // workFolderPathInputBox
            // 
            workFolderPathInputBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            workFolderPathInputBox.Location = new Point(10, 10);
            workFolderPathInputBox.Margin = new Padding(0);
            workFolderPathInputBox.Name = "workFolderPathInputBox";
            workFolderPathInputBox.PlaceholderText = "Work folder path*";
            workFolderPathInputBox.Size = new Size(178, 23);
            workFolderPathInputBox.TabIndex = 1;
            workFolderPathInputBox.TextChanged += workFolderPathInputBox_TextChanged;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 241);
            Controls.Add(_main_container);
            MaximizeBox = false;
            MaximumSize = new Size(600, 356);
            MinimizeBox = false;
            MinimumSize = new Size(256, 265);
            Name = "MainWindow";
            Text = "Prototype Assembler";
            _main_container.ResumeLayout(false);
            _main_container.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox onFileAlreadyExsistOperationDropDown;
        private TextBox workFolderPathInputBox;
        private Button chooseWorkFolderPathBtn;
        private Button chooseOuputFileFilderBtn;
        private TextBox outputFilePathInputBox;
        private TextBox outputFileNameInputBox;
        private Button compileBtn;
        private TextBox authorInputBox;
        private FolderBrowserDialog workFolderBrowseDialog;
        private FolderBrowserDialog outputFileFolderBrowseDialog;
        private Label messageLabel;
    }
}
