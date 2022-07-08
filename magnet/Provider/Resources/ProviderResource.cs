namespace magnet.Provider.Resources;

public class ProviderResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ApiUrl { get; set; }
    public bool KeyRequired { get; set; }
    public string ApiKey { get; set; }
}