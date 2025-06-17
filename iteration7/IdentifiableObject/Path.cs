namespace SwinAdventure;

public class Path : GameObject
{
    Location _destination;
    String _name;
    public Path(string[] ids, string name, string desc, Location destination) : base(ids, name, desc)
    {
        _name = name;
        _destination = destination;
    }

    public void PlayerMove(Player p)
    {
        p.Location = _destination;   
    }

    public string GetPathName
    {
        get { return _name; }
    }
    //property
    public Location Destination
    {
        get { return _destination; }
    }

}