namespace Content.Core.Saver;

public class FileAlreadyExistsException : Exception
{
    public FileAlreadyExistsException() : base() {}

    public FileAlreadyExistsException(string? message) : base(message) { }

    public FileAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException) { }
}
