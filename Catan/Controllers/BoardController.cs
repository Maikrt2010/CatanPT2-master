using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Models;

namespace Catan.Controllers
{
    public class BoardController : Controller
    {
        public IActionResult BoardDisplay()
        {
            Board board = BoardLogic.PseudoRandom();
            return View(board);
        }

        public IActionResult BigBoardTest()
        {
            Board board = BigBoardLogic.Normal(); //there needs to be a function for bigBoard!
            return View(board);
        }

        public IActionResult BoardTest()
        {
            Board board = BoardLogic.PseudoRandom();
            return View(board);
        }

        public IActionResult RandomChips()
        {
            Board board = BoardLogic.RandomChips();
            return View("BoardDisplay",board);
        }

        public IActionResult RandomResources()
        {
            Board board = BoardLogic.RandomResources();
            return View("BoardDisplay",board);
        }
        public IActionResult Random()
        {
            Board board = BoardLogic.Random();
            return View("BoardDisplay", board);
        }
    }
}