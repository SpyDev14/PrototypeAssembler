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

            onFileAlreadyExsistOperationDropDown.Text = "Create with index";

            foreach (var keyPair in _onFileAlreadyExistDropDownVariants)
            {
                onFileAlreadyExsistOperationDropDown.Items.Add(keyPair.Key);
            }
        }

        Dictionary<string, OnFileAlreadyExist> _onFileAlreadyExistDropDownVariants;

        string _workFolderPath;
        string _outputPath;
        string _assembledFileName;
        string? _author;
        OnFileAlreadyExist _onFileAlreadyExistOperation;

        private void workFolderPathInputBox_TextChanged(object sender, EventArgs e)
            => _workFolderPath = workFolderPathInputBox.Text;
        private void chooseWorkFolderPathBtn_Click(object sender, EventArgs e)
        { 
            var dialogResult = workFolderBrowseDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
                workFolderPathInputBox.Text = workFolderBrowseDialog.SelectedPath;
        }

        private void outputFilePathInputBox_TextChanged(object sender, EventArgs e)
            => _outputPath = outputFilePathInputBox.Text;
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

        }
    }
}