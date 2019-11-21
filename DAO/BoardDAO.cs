using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class BoardDAO: DAO
    {
        List<Board> boards = new List<Board>();

        public List<Board> GetAllBoardsFromUser(int userId)
        {
            con.Open();
            // where needs to be added
            string query = "SELECT * FROM Board WHERE UserId = @userid";
            List<Board> result = new List<Board>();

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.ExecuteNonQuery();

                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    Board board = new Board();
                    board.BoardId = read.GetInt32(0);
                    result.Add(board);
                }

                con.Close();

                return result;
            }
        }
        public Board GetBoard(int boardId)
        {
            TilesDAO til = new TilesDAO();
            PortDAO port = new PortDAO();
            Board returnBoard = new Board();
            con.Open();
            // where needs to be added
            string query = "SELECT * FROM Board WHERE Id= @Id";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add(new SqlParameter("@Id", boardId));
                //command.Parameters["Id"].Value = boardId;
                command.ExecuteNonQuery();
                SqlDataReader read = command.ExecuteReader();
               
                while (read.Read())
                {
                    read.GetInt32(0);
                    read.GetInt32(1);
                }

                con.Close();
                returnBoard.Tiles = til.GetAllTilesFromBoard(boardId); 
                returnBoard.Ports = port.GetAllPortsFromBoard(boardId); 
                return returnBoard;
               
                //daarna ga naar tiles en port en haal alle gegevens op
            }

        }
        public void InsertBoard(int userId)
        {
            //inserting board
            con.Open();

            string query =

                "INSERT INTO Board(UserId)";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@UserId", SqlDbType.Int);
                command.Parameters["board.UserId"].Value = userId;
    
                command.ExecuteNonQuery();

                con.Close();
            }
            
        }

        public void DeleteBoard(int boardId)
        {
            con.Open();

            string query = 
                "DELETE FROM Board WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["board.Id"].Value = boardId;

                command.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
