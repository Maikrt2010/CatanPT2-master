using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public static class BigBoardLogic
    {
        public static int[] Chips = new int[] { 3, 5, 6, 8, 2, 11, 10, 10, 5, 12, 4, 9, 8, 3, 6, 4, 9, 11, 3, 5, 6, 8, 2, 11, 10, 10, 5, 12, 4, 9, 8, 3, 6, 4, 9, 11 };
        public static int[] Tiles = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34 };
        public static string[] Resources = new string[] { "lumber", "sheep", "lumber", "wheat", "lumber", "brick", "sheep", "brick", "lumber", "ore", "wheat", "sheep", "brick", "wheat", "ore", "wheat", "sheep", "ore", "lumber", "sheep", "lumber", "wheat", "lumber", "brick", "sheep", "brick", "lumber", "ore", "wheat", "sheep", "brick", "wheat", "ore", "wheat", "sheep", "ore" };

        private static Random rng = new Random();
        public static Board Normal()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            board.Tiles = FillTiles(tiles);
            AddDesert(board);
            return board;
        }

        public static Board Random()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            board.Tiles = FillRandomTiles(tiles);
            AddRandomDesert(board);
            return board;

        }
        public static Board RandomChips()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            board.Tiles = FillRandomChipsTiles(tiles);
            AddDesert(board);
            return board;
        }

        public static Board RandomResources()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            board.Tiles = FillRandomResourceTiles(tiles);
            AddRandomDesert(board);
            return board;
        }

        public static List<Tile> CreateNewEmptyTileList()
        {
            List<Tile> tileList = new List<Tile>();
            foreach (int tile in Tiles)
            {
                tileList.Add(new Tile());
            }
            return tileList;
        }
        public static List<Tile> FillRandomTiles(List<Tile> tiles)
        {
            tiles = SetChips(tiles, shuffle(Chips));
            tiles = SetResources(tiles, shuffle(Resources));
            return tiles;
        }
        public static List<Tile> FillRandomResourceTiles(List<Tile> tiles)
        {
            tiles = SetChips(tiles, (Chips));
            tiles = SetResources(tiles, shuffle(Resources));
            return tiles;
        }
        public static List<Tile> FillRandomChipsTiles(List<Tile> tiles)
        {
            tiles = SetChips(tiles, shuffle(Chips));
            tiles = SetResources(tiles, (Resources));
            return tiles;
        }
        public static List<Tile> FillTiles(List<Tile> tiles)
        {
            tiles = SetChips(tiles, Chips);
            tiles = SetResources(tiles, Resources);
            return tiles;
        }
        public static string[] shuffle(string[] array)
        {
            return array.OrderBy(x => rng.Next()).ToArray();
        }

        public static int[] shuffle(int[] array)
        {
            return array.OrderBy(x => rng.Next()).ToArray();
        }

        public static List<Tile> SetResources(List<Tile> tiles, string[] resources)
        {
            for (int i = 0; i < resources.Length; i++)
            {
                tiles[i].Resource = resources[i];
            }
            return tiles;
        }

        public static List<Tile> SetChipsPseudoRandom(List<Tile> tiles, int[] chips)
        {
            for (int i = 0; i < chips.Length; i++)
            {
                tiles[i].Chip = chips[i];
            }
            return tiles.ToList();
        }
        public static List<Tile> SetChips(List<Tile> tiles, int[] chips)
        {
            for (int i = 0; i < chips.Length; i++)
            {
                tiles[i].Chip = chips[i];
            }
            return tiles.ToList();
        }

        public static void AddRandomDesert(Board board)
        {

            Tile tile = new Tile(7, "desert");
            board.Tiles.Insert(rng.Next(37), tile);
        }

        public static void AddDesert(Board board)
        {
            Tile tile = new Tile(7, "desert");
            Tile tile1 = new Tile(7, "desert");
            board.Tiles.Insert(19, tile);
            board.Tiles.Insert(25, tile);

            
        }




    }
}
