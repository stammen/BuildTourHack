namespace Microsoft.Knowzy.Common.Contracts
{
    public interface IConfigurationModel
    {
        string JsonFilePath { get; }
        string DataSourceUrl { get; }
    }
}