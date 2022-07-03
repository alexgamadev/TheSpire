namespace TheSpire.Models;

public class ElementalTowerDbSettings : IElementalTowerDbSettings
{
    public string ConnectionString { get; set; } = "";
    public string DatabaseName { get; set; } = "";
    public string AscensionRunsCollection { get; set; } = "";
    public string AccountsCollection { get; set; } = "";
}