﻿namespace Content.Core.Assembly;
internal class AssemblyData(string workFolderPath)
{
    public string WorkFolderPath { get; private set; } = workFolderPath;

    public string? Author { get; set; }
}