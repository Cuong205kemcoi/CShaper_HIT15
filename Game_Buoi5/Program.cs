using System;
using System.Collections.Generic;
using System.Text;

// Lớp trừu tượng Character
abstract class Character
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public int Damage { get; set; }
    public int RangeAttack { get; set; }

    public virtual void Move(char direction = ' ', int gridWidth = 0, int gridHeight = 0)
    {
        int newX = PosX, newY = PosY;

        switch (direction)
        {
            case 'W': newY--; break;
            case 'S': newY++; break;
            case 'A': newX--; break;
            case 'D': newX++; break;
        }

        // Kiểm tra vị trí hợp lệ
        if (newX >= 0 && newX < gridWidth && newY >= 0 && newY < gridHeight)
        {
            PosX = newX;
            PosY = newY;
        }
    }

    public void TakeDamage(int damage)
    {
        Console.WriteLine($"{GetType().Name} nhận {damage} sát thương!");
    }

    public virtual Character CheckRangeAttack(Tile[,] grid)
    {
        foreach (var tile in grid)
        {
            if (tile.IsOccupied() && tile.Character != this &&
                Math.Abs(tile.PosX - PosX) <= RangeAttack &&
                Math.Abs(tile.PosY - PosY) <= RangeAttack)
            {
                return tile.Character;
            }
        }
        return null;
    }

    public virtual void Attack(Tile[,] grid)
    {
        Character target = CheckRangeAttack(grid);
        if (target != null)
        {
            target.TakeDamage(Damage);
            Console.WriteLine($"{GetType().Name} tấn công {target.GetType().Name}!");
        }
    }
}

// Lớp Player
class Player : Character
{
    public Weapon CurrentWeapon { get; private set; }

    public Player()
    {
        CurrentWeapon = new Weapon();
        Damage = CurrentWeapon.Attack;
        RangeAttack = CurrentWeapon.RangeAttack;
        Console.WriteLine($"Vũ khí hiện tại: {CurrentWeapon.Name}");
    }
}

// Lớp Enemy
class Enemy : Character
{
    private Random random = new Random();

    public override void Move(char direction = ' ', int gridWidth = 0, int gridHeight = 0)
    {
        int randomDirection = random.Next(4);
        char[] directions = { 'W', 'A', 'S', 'D' };
        base.Move(directions[randomDirection], gridWidth, gridHeight);
    }
}

// Lớp Weapon
class Weapon
{
    public string Name { get; } = "Kiếm";
    public int Attack { get; } = 10;
    public int RangeAttack { get; } = 1;
}

// Lớp Tile
class Tile
{
    public Character Character { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }

    public bool IsOccupied()
    {
        return Character != null;
    }
}

// Lớp GridManager
class GridManager
{
    public int XWide { get; set; }
    public int YHigh { get; set; }
    public Tile[,] Tiles { get; set; }

    public GridManager(int xWide, int yHigh)
    {
        XWide = xWide;
        YHigh = yHigh;
        Tiles = new Tile[xWide, yHigh];
        for (int x = 0; x < xWide; x++)
        {
            for (int y = 0; y < yHigh; y++)
            {
                Tiles[x, y] = new Tile { PosX = x, PosY = y };
            }
        }
    }

    public void UpdateGrid(Player player, List<Enemy> enemies)
    {
        foreach (var tile in Tiles)
            tile.Character = null;

        Tiles[player.PosX, player.PosY].Character = player;
        foreach (var enemy in enemies)
            Tiles[enemy.PosX, enemy.PosY].Character = enemy;
    }
}

// Lớp GameManager
class GameManager
{
    private GridManager gridManager;
    private Player player;
    private List<Enemy> enemies = new List<Enemy>();
    private bool isPlayerTurn = true;

    public GameManager(int xWide, int yHigh, int numEnemies)
    {
        gridManager = new GridManager(xWide, yHigh);
        player = new Player { PosX = xWide / 2, PosY = yHigh / 2 };
        for (int i = 0; i < numEnemies; i++)
        {
            enemies.Add(new Enemy { PosX = i, PosY = i });
        }
        gridManager.UpdateGrid(player, enemies);
    }

    public void StartBattle()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Lượt của: " + (isPlayerTurn ? "Người chơi" : "Quái"));
            gridManager.UpdateGrid(player, enemies);

            if (isPlayerTurn)
                TurnPlayer();
            else
                TurnEnemy();

            isPlayerTurn = !isPlayerTurn;
            CheckWinOrLose();
        }
    }

    private void TurnPlayer()
    {
        Console.WriteLine("\nNhập hướng di chuyển (W/A/S/D):");
        char move = Console.ReadKey(intercept: true).KeyChar;
        player.Move(char.ToUpper(move), gridManager.XWide, gridManager.YHigh);
        player.Attack(gridManager.Tiles);
    }

    private void TurnEnemy()
    {
        foreach (var enemy in enemies)
        {
            enemy.Move(gridWidth: gridManager.XWide, gridHeight: gridManager.YHigh);
            enemy.Attack(gridManager.Tiles);
        }
    }

    private void CheckWinOrLose()
    {
        enemies.RemoveAll(e => !gridManager.Tiles[e.PosX, e.PosY].IsOccupied());

        if (enemies.Count == 0)
        {
            Console.WriteLine("Bạn đã thắng!");
            Environment.Exit(0);
        }

        if (!gridManager.Tiles[player.PosX, player.PosY].IsOccupied())
        {
            Console.WriteLine("Bạn đã thua!");
            Environment.Exit(0);
        }
    }
}

// Chương trình chính
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        GameManager game = new GameManager(5, 5, 3);
        game.StartBattle();
        Console.ReadKey();
    }
}
