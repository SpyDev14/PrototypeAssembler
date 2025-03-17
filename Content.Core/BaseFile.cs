namespace Content.Core
{
    internal class BaseFile
    {
        public BaseFile(string content) => Content = content;

        public BaseFile(string content, string name)
        {
            Name = name;

            Content = content;
        }

        public string? Name { get; protected set; }

        public string Content { get; protected set; }

    }
}
