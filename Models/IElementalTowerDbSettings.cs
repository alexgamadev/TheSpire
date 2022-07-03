namespace TheSpire.Models;

public interface IElementalTowerDbSettings
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
    string AscensionRunsCollection { get; set; }
    string AccountsCollection { get; set; };
}