using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class SudokuWindow : Form
    {
        Sudoku game;
        List<Button> buttons;

        public SudokuWindow()
        {
            InitializeComponent();
            game = new Sudoku();
            buttons = new List<Button>();
            fillButtons();
            game1();
            updateButtons();
        }

        void fillButtons()
            //Fills buttons collection with all the buttons, for updating them all later with for loops
        {
            buttons.Add(A1_1);
            buttons.Add(A1_2);
            buttons.Add(A1_3);
            buttons.Add(A2_1);
            buttons.Add(A2_2);
            buttons.Add(A2_3);
            buttons.Add(A3_1);
            buttons.Add(A3_2);
            buttons.Add(A3_3);
            buttons.Add(B1_4);
            buttons.Add(B1_5);
            buttons.Add(B1_6);
            buttons.Add(B2_4);
            buttons.Add(B2_5);
            buttons.Add(B2_6);
            buttons.Add(B3_4);
            buttons.Add(B3_5);
            buttons.Add(B3_6);
            buttons.Add(C1_7);
            buttons.Add(C1_8);
            buttons.Add(C1_9);
            buttons.Add(C2_7);
            buttons.Add(C2_8);
            buttons.Add(C2_9);
            buttons.Add(C3_7);
            buttons.Add(C3_8);
            buttons.Add(C3_9);
            buttons.Add(D4_1);
            buttons.Add(D4_2);
            buttons.Add(D4_3);
            buttons.Add(D5_1);
            buttons.Add(D5_2);
            buttons.Add(D5_3);
            buttons.Add(D6_1);
            buttons.Add(D6_2);
            buttons.Add(D6_3);
            buttons.Add(E4_4);
            buttons.Add(E4_5);
            buttons.Add(E4_6);
            buttons.Add(E5_4);
            buttons.Add(E5_5);
            buttons.Add(E5_6);
            buttons.Add(E6_4);
            buttons.Add(E6_5);
            buttons.Add(E6_6);
            buttons.Add(F4_7);
            buttons.Add(F4_8);
            buttons.Add(F4_9);
            buttons.Add(F5_7);
            buttons.Add(F5_8);
            buttons.Add(F5_9);
            buttons.Add(F6_7);
            buttons.Add(F6_8);
            buttons.Add(F6_9);
            buttons.Add(G7_1);
            buttons.Add(G7_2);
            buttons.Add(G7_3);
            buttons.Add(G8_1);
            buttons.Add(G8_2);
            buttons.Add(G8_3);
            buttons.Add(G9_1);
            buttons.Add(G9_2);
            buttons.Add(G9_3);
            buttons.Add(H7_4);
            buttons.Add(H7_5);
            buttons.Add(H7_6);
            buttons.Add(H8_4);
            buttons.Add(H8_5);
            buttons.Add(H8_6);
            buttons.Add(H9_4);
            buttons.Add(H9_5);
            buttons.Add(H9_6);
            buttons.Add(I7_7);
            buttons.Add(I7_8);
            buttons.Add(I7_9);
            buttons.Add(I8_7);
            buttons.Add(I8_8);
            buttons.Add(I8_9);
            buttons.Add(I9_7);
            buttons.Add(I9_8);
            buttons.Add(I9_9);
        }

        void gameSetup(int row, int column, int value)
        {
            game.entries[(column - 1) + (row - 1) * 9].value = value;
            game.RemovePossibilities(row, column, value);
        }

        void updateButtons()
        {
            for (int i = 0; i<81; i++)
            {
                
                buttons[i].Text = game.entries[i].value.ToString();
               
            }
        }

        void game1()
        {
            gameSetup(1, 1, 6);
            gameSetup(1, 2, 7);
            gameSetup(3, 1, 8);
            gameSetup(3, 2, 9);
            gameSetup(1, 5, 4);
            gameSetup(1, 6, 9);
            gameSetup(2, 6, 2);
            gameSetup(3, 6, 7);
            gameSetup(1, 8, 1);
            gameSetup(2, 9, 8);
            gameSetup(3, 8, 6);
            gameSetup(5, 1, 7);
            gameSetup(5, 2, 1);
            gameSetup(5, 3, 9);
            gameSetup(6, 2, 8);
            gameSetup(4, 4, 7);
            gameSetup(5, 4, 3);
            gameSetup(5, 6, 4);
            gameSetup(6, 6, 1);
            gameSetup(5, 7, 8);
            gameSetup(5, 8, 5);
            gameSetup(5, 9, 2);
            gameSetup(4, 8, 4);
            gameSetup(7, 2, 3);
            gameSetup(8, 1, 2);
            gameSetup(9, 2, 5);
            gameSetup(7, 4, 1);
            gameSetup(8, 4, 4);
            gameSetup(9, 4, 2);
            gameSetup(9, 5, 9);
            gameSetup(7, 8, 2);
            gameSetup(7, 9, 4);
            gameSetup(9, 8, 3);
            gameSetup(9, 9, 1);
        }
    }
}
