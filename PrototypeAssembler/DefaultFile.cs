namespace PrototypeAssembler.Shared
{
    internal class DefaultFile
    {
        public DefaultFile(string content) => Content = content;

        public DefaultFile(string content, string name)
        {
            Name = name;

            Content = content;
        }

        public string? Name { get; protected set; }

        public string Content { get; protected set; }

    }
}
