
public class TankRequest
{
    public string matchId { get; set; }
    public int mapWidth { get; set; }
    public int mapHeight { get; set; }
    public int wallDamage { get; set; }
    public int tankDamage { get; set; }
    public int weaponDamage { get; set; }
    public int visibility { get; set; }
    public int weaponRange { get; set; }
    public You you { get; set; }
    public List<Enemy> enemies { get; set; }
    public List<Wall> walls { get; set; }
    public int suddenDeath { get; set; }
    public List<FireField> fire { get; set; }
}

public class Point 
{
    public int x { get; set; }
    public int y { get; set; }
}

public class You : Point
{
    public string direction { get; set; }
    public int strength { get; set; }
    public int ammo { get; set; }
    public string status { get; set; }
    public int targetRange { get; set; }
}

public class Enemy  : Point
{
    public string direction { get; set; }
    public int strength { get; set; }
    public int ammo { get; set; }
    public string status { get; set; }
}

public class Wall : Point
{
    public int strength { get; set; }
}

public class FireField  : Point
{
}

public class TankResponse
{
    public string command { get; set; }
}