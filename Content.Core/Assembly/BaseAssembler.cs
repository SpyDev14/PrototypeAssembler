﻿using Content.Core.Assembly.FileCollector;
using Content.Core.Assembly.FilePreparator;
using System.Text;

namespace Content.Core.Assembly;
internal class BaseAssembler : IAssembler
{
    public BaseAssembler(AssemblyData data, IFilePreparator filePreparator, IFileCollector fileCollector)
    {
        _data = data;
        _filePreparator = filePreparator;
        _fileCollector = fileCollector;
    }

    private readonly AssemblyData _data;
    private IFilePreparator _filePreparator;
    private IFileCollector _fileCollector;

    public AssembledFile AssembleFiles()
    {
        BaseFile[] filesForAssembling = _fileCollector.CollectFiles(_data.WorkFolderPath);
        List<PreparedFile> preparedFiles = [];

        StringBuilder stringBuilder = new();

        foreach (BaseFile fileForAssembling in filesForAssembling)
        {
            preparedFiles.Add(_filePreparator.PrepareFile(fileForAssembling));
        }

        stringBuilder.AppendLine($@"
# Prototype assembled with Prototype Assembler by SpyDev14
# github: https://github.com/SpyDev14/PrototypeAssembler
# Thanks for using!
");

        // combining files
        foreach (PreparedFile preparedFile in preparedFiles)
        {
            stringBuilder.AppendLine(preparedFile.ToString().Trim());
            stringBuilder.Append("\n");
        }

        return new AssembledFile(stringBuilder.ToString().Trim());
    }
}