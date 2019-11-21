using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class TilesDAO : DAO
    {

        public List<Tile> GetAllTilesFromBoard(int boardId)
        {
            con.Open();

            string query = "SELECT * FROM Tiles WHERE BoardId = @BoardId";
            List<Tile> result = new List<Tile>();

            using (SqlCommand command = new SqlCommand(query, con))
            {
                
                command.Parameters.Add("@BoardId", SqlDbType.Int);
                command.Parameters["@BoardId"].Value = boardId   ;
               
                SqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Tile tile = new Tile(Reader.GetInt32(1), Reader.GetString(2), Reader.GetInt32(3));
                   
                    // all tiles in list
                    result.Add(tile);
                }

                con.Close();

                return result;
            }
        }

        public void InsertTiles(List<Tile> tiles, int boardId)
        {
            //all tiles need to be filled
            foreach (Tile tile in tiles)
            {
                // adding all tiles in tiles with all their specification
                con.Open();
                string query =

                    "INSERT INTO Tiles (BoardId, TilePosition, Resource, Chip) " +
                    "VALUES(@Boardid, @Tileposition, @Resource, @chip)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@BoardId", SqlDbType.Int);
                    command.Parameters["board.Id"].Value = boardId;

                    command.Parameters.Add("@Tileposition", SqlDbType.Int);
                    command.Parameters["tile.id"].Value = tile.Position;

                    command.Parameters.Add("@Resource", SqlDbType.VarChar);
                    command.Parameters["tile.tilecategorie"].Value = tile.Resource;

                    command.Parameters.Add("@chip", SqlDbType.Int);
                    command.Parameters["tile.chip"].Value = tile.Chip;

                    command.ExecuteNonQuery();

                    con.Close();
                }
            }
        }

        public void DeleteTiles(int boardId)
        {
            //deleting al tiles from one board
            con.Open();
            string query =
            "DELETE * FROM Tiles Where BoardId = @BoardId";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@BoardId", SqlDbType.Int);
                command.Parameters["board.Id"].Value = boardId;

                command.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
