using DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Logic
{
    public static class BoardLogic
    {
        public static int[] Chips = new int[] { 3, 5, 6, 8, 2, 11, 10,  10, 5, 12, 4, 9, 8, 3, 6, 4, 9, 11 };
        public static int[] Tiles = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17};
        public static string[] Resources = new string[] { "lumber", "sheep", "lumber", "wheat", "lumber", "brick", "sheep", "brick", "lumber", "ore", "wheat", "sheep", "brick", "wheat", "ore", "wheat", "sheep", "ore" };
        public static int[][] adjecent = new int[][]
        {
        new int[]{ 1, 3, 4},
        new int[]{ 0, 2, 4, 5},
        new int[]{ 1, 5, 6},
        new int[]{ 0, 4, 7, 8},
        new int[]{ 0, 1, 3, 5, 8, 9},
        new int[]{ 1, 2, 4, 6, 9, 10},
        new int[]{ 2, 5, 10, 11},
        new int[]{ 3, 8, 12 },
        new int[]{ 3, 4, 7, 9, 12, 13 },
        new int[]{ 4, 5, 8, 10, 13, 14 },
        new int[]{ 5, 6, 9, 11, 14, 15 },
        new int[]{ 6, 10, 15 },
        new int[]{ 7, 8, 13, 16 },
        new int[]{ 8, 9, 12, 14, 16, 17 },
        new int[]{ 9, 10, 13, 15, 17, 18 },
        new int[]{ 10, 11, 14, 18 },
        new int[]{ 12, 13, 17 },
        new int[]{ 13, 14, 16, 18 },
        new int[]{ 14, 15, 17 }
        };
        private static HashSet<int> exclude = new HashSet<int>();
        private static Random rng = new Random();


        public static Board Normal()
        {
            Board board = new Board();
            List<Tile> tiles = CreateNewEmptyTileList();
            board.Tiles = FillTiles(tiles);
            AddDesert(board);
            return board;
        }

        public static Board PseudoRandom()
        {
            Board board = new Board();

            bool check = false;
            while(check == false)
            {
                List<Tile> tiles = CreateNewEmptyTileList();
                RandomizeTiles(tiles);
                board.Tiles = tiles;
                AddRandomDesert(board);
                check = CheckRedTiles(board.Tiles);
            }
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
        public static List<Tile> FillPseudoRandomTiles(List<Tile> tiles)
        {
            
            RandomizeTiles(tiles);
            
            //bool check = CheckRedTiles(tiles);
            //while (check == false)
            //{
            //    RandomizeTiles(tiles);
                
            //    check = CheckRedTiles(tiles);
                
            //}
            return tiles;
            
        }
        public static void RandomizeTiles(List<Tile> tiles)
        {            
            tiles = SetChips(tiles, shuffle(Chips));
            tiles = SetResources(tiles, shuffle(Resources));
            
        }
        public static List<Tile> FillRandomTiles(List<Tile> tiles)
        {
            tiles = SetChips(tiles, shuffle (Chips));
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
        public static bool CheckRedTiles(List<Tile> tiles)
        {
            for (int x = 0; x < tiles.Count; x++)
            {
                if ((tiles[x].Chip == 6 || tiles[x].Chip == 8) && CompareRedWithAdjecents(tiles, x) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CompareRedWithAdjecents(List<Tile> tiles, int index)
        {
            foreach (int p in adjecent[index])
            {
                if (tiles[p].Chip == 6 || tiles[p].Chip == 8)
                {
                    return false;
                }
            }
            return true;
        }
        /****************************************************
        * Position                                          *
        * ------------------------------------------------- *
        * Return Value: Void                                *
        * Description:                                      *
        * Removes Adjacent Tiles from possible useable      *  
        * positions list                                    *
        * State: Bleeding                                   *
        *****************************************************/
        public static List<Tile> Position(List<Tile> tiles)
        {
            foreach (Tile tile in tiles)
            {
                if (tile.Chip == 8 || tile.Chip == 6)
                {
                    PositionRed(tile);
                }
                else
                {
                    PositionRest(tile);
                }
            }
            return tiles;
        }
        /****************************************************
        * PositionRed                                       *
        * ------------------------------------------------- *
        * Return Value: Void                                *
        * Description:                                      *
        * Position Tiles in board if they are an 8 or an 6  *
        * State: Bleeding                                   *
        *****************************************************/
        private static void PositionRed(Tile tile)
        {
            List<int> emptyPositions = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18
            };
            List<int> placeable = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18
            };
            int[] redTiles = { 6, 6, 8, 8 };
            for (int i = 0; i <= redTiles.Length; i++)
            {
                int newPosition = GetNewPositionValue();
                tile.Position = newPosition;
                emptyPositions.Remove(newPosition);
                placeable.Remove(newPosition);
                RemoveAdjacent(placeable, newPosition);
            }
        }
        /****************************************************
        * RemoveAdjecent                                    *
        * ------------------------------------------------- *
        * Return Value: Void                                *
        * Description:                                      *
        * Removes Adjacent Tiles from possible useable      *  
        * positions list                                    *
        * State: Bleeding                                   *
        *****************************************************/
        private static void RemoveAdjacent(List<int> placeable, int position)
        {
            foreach (int x in adjecent[position])
            {
                if (!placeable.Contains(x)) placeable.Remove(x);
             
                if (!exclude.Contains(x)) exclude.Add(x);
            }
        }
        /****************************************************
        * Place Rest                                        *
        * ------------------------------------------------- *
        * Return Value: Void                                *
        * Description:                                      *
        * Give Tile it's position                           *
        * State: Bleeding                                   *
        *****************************************************/
        private static void PositionRest(Tile tile)
        {
            tile.Position = GetNewPositionValue();
        }
        /****************************************************
        * GetNewPositionValue                               *
        * ------------------------------------------------- *
        * Return Value: Int32                               *
        * Description:                                      *
        * Returns the next possible Position within the     *
        * board, checking which PLAIN position has been     *
        * used already to give a new position               *
        * State: Bleeding                                   *
        *****************************************************/
        private static int GetNewPositionValue()
        {
            var range = Enumerable.Range(0, 18).Where(i => !exclude.Contains(i));
            int index = rng.Next(0, 18 - exclude.Count);
            int finalValue = range.ElementAt(index);
            exclude.Add(finalValue);    
            return finalValue;
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
            for(int i = 0; i< chips.Length; i++)
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
            
            Tile tile = new Tile(7,"desert");
            board.Tiles.Insert(rng.Next(18),tile);
        }
        public static void AddRandomDesert(List<Tile> tiles)
        {

            Tile tile = new Tile(7, "desert");
            tiles.Insert(rng.Next(18), tile);
        }

        public static void AddDesert(Board board)
        {
            Tile tile = new Tile(7, "desert");
            board.Tiles.Insert(9, tile);
        }
    }
}
