namespace Samples.Specifications.Tests.EndToEnd.Domain.CodedUI
{
    internal interface IExecutableContainer
    {
        string Path { get; }
    }

    class ExecutableContainer : IExecutableContainer
    {
        public string Path => "Samples.Specifications.Client.Launcher.exe";
    }
}
