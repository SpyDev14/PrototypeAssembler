using Content.Core.Saver;
using Content.Core.Assembly;

namespace Content.SimpleUiShell
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            _onFileAlreadyExistDropDownVariants = new()
            {
                { "Overwrite" , OnFileAlreadyExist.Overwrite },
                { "Create with index" , OnFileAlreadyExist.CreateWithIndex},
                { "Throw exception", OnFileAlreadyExist.ThrowException }
            };
            onFileAlreadyExsistOperationDropDown.Text = "Throw exception";

            foreach (var keyPair in _onFileAlreadyExistDropDownVariants)
            {
                onFileAlreadyExsistOperationDropDown.Items.Add(keyPair.Key);
            }

            _requiredFields = [
                workFolderPathInputBox,
                outputFilePathInputBox,
                outputFileNameInputBox
            ];

            foreach (var field in _requiredFields)
            {
                _requiredEmptyFieldsDefaultBackColor.Add(field, field.BackColor);
            }

            //messageLabel.Visible = false;
            messageLabel.ForeColor = Color.Gray;
        }

        readonly Color _emptyRequiredFieldBackgroundColor
            = Color.FromArgb(255, 255, 230, 230);

        Dictionary<string, OnFileAlreadyExist> _onFileAlreadyExistDropDownVariants;
        Control[] _requiredFields;
        Dictionary<Control, Color> _requiredEmptyFieldsDefaultBackColor = [];

        string? _workFolderPath;
        string? _outputFolderPath;
        string? _assembledFileName;
        string? _author;
        OnFileAlreadyExist _onFileAlreadyExistOperation = OnFileAlreadyExist.ThrowException;


        private void ShowMessage(string message, Color? color = null)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            if (color == null)
                color = Color.Gray;

            if (!messageLabel.Visible)
                messageLabel.Visible = true;

            messageLabel.ForeColor = (Color)color;
            messageLabel.Text = message.Trim();
        }

        private void ShowErrorMessage(string message)
            => ShowMessage(message, Color.FromArgb(255, 220, 50, 50));

        private void HideMessage()
            => messageLabel.Visible = false;




        /*
         *   UI INTERACTION METHODS
         */

        private void workFolderPathInputBox_TextChanged(object sender, EventArgs e)
            => _workFolderPath = workFolderPathInputBox.Text;
        private void chooseWorkFolderPathBtn_Click(object sender, EventArgs e)
        { 
            var dialogResult = workFolderBrowseDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
                workFolderPathInputBox.Text = workFolderBrowseDialog.SelectedPath;
        }

        private void outputFilePathInputBox_TextChanged(object sender, EventArgs e)
            => _outputFolderPath = outputFilePathInputBox.Text;
        private void chooseOuputFileFilderBtn_Click(object sender, EventArgs e)
        {
            var dialogResult = outputFileFolderBrowseDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
                outputFilePathInputBox.Text = outputFileFolderBrowseDialog.SelectedPath;
        }


        private void outputFileNameInputBox_TextChanged(object sender, EventArgs e)
            => _assembledFileName = outputFileNameInputBox.Text;

        private void onFileAlreadyExsistOperationDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            _onFileAlreadyExistOperation
                = _onFileAlreadyExistDropDownVariants[onFileAlreadyExsistOperationDropDown.Text];
        }

        private void authorInputBox_TextChanged(object sender, EventArgs e)
            => _author = authorInputBox.Text;

        private void compileBtn_Click(object sender, EventArgs e)
        {
            int countOfEmptyRequiredFields = 0;
            foreach (var field in _requiredFields)
            {
                if (!string.IsNullOrWhiteSpace(field.Text))
                {
                    if (field.BackColor == _emptyRequiredFieldBackgroundColor)
                        field.BackColor = _requiredEmptyFieldsDefaultBackColor[field];

                    continue;
                }

                countOfEmptyRequiredFields++;
                field.BackColor = _emptyRequiredFieldBackgroundColor;
            }

            if (countOfEmptyRequiredFields > 0)
            {
                ShowErrorMessage(
                    countOfEmptyRequiredFields > 1 ?
                    "Several required fields are not filled in" :
                    "Required field is not filled in");
                return;
            }

            HideMessage();

            try
            {
                Core.Program.Execute(
                    new AssemblyData(_workFolderPath!) { Author = _author != null ? _author : null },
                    new SaveData(_outputFolderPath!, _assembledFileName!)
                    {
                        OnFileAlreadyExistOperation = _onFileAlreadyExistOperation
                    }
                );
            }
            catch (FileAlreadyExistsException)
            {
                ShowErrorMessage($"File already exists");
            }
            catch (DirectoryNotFoundException)
            {
                ShowErrorMessage($"The wrong path is specified");
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"ERROR ({ex.HResult}): {ex.Message}");
            }
        }
    }
}