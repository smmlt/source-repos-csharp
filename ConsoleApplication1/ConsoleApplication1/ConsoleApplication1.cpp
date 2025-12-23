#include <iostream>
#include <time.h>
using namespace std;

struct Position
{
    int row;
    int col;
};

class FifteenPuzzle
{
private:
    int N;
    int** board;
    Position empty_tile;  // Позиция пустой клетки
    int moves;
    time_t start_time;

    
    void print_board()
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (board[i][j] == 0)
                    cout << "[   ]";  // Пустая клетка
                else
                {
                    if (board[i][j] < 10)
                    {
                        cout << "  " << board[i][j] << "  ";
                    }
                    else
                    {
                        cout << "  " << board[i][j] << "  ";
                    }
                }
            }
            cout << endl;
        }
    }

    bool is_solved()
    {
        int num = 1;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (i == N - 1 && j == N - 1)
                    return board[i][j] == 0;
                if (board[i][j] != num++)
                    return false;
            }
        }
        return true;
    }

    void shuffle_board()
    {
        int* tiles = new int[N * N];
        for (int i = 0; i < N * N; i++)
        {
            tiles[i] = i;
        }

        srand(time(0));

        for (int i = 0; i < N * N; i++)
        {
            int j = rand() % (N * N);
            swap(tiles[i], tiles[j]);  // Перемешиваем числа
        }

        int k = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                board[i][j] = tiles[k++];  // Заполняем доску перемешанными клетками
                if (board[i][j] == 0)
                    empty_tile = { i, j };  // Запоминаем позицию пустой клетки
            }
        }
        delete[] tiles;
    }

    
    bool move_tile(int x, int y)
    {
        int ex = empty_tile.row, ey = empty_tile.col;
        if ((abs(ex - x) == 1 && ey == y) || (abs(ey - y) == 1 && ex == x)) // abs() возвращает число со знаком "+"
        {
            swap(board[ex][ey], board[x][y]);  // Меняем местами пустую клетку и выбраную клетку
            empty_tile = { x, y };
            return true;
        }
        return false;
    }

public:
    FifteenPuzzle(int size) : N(size), moves(0)
    {
        board = new int* [N];
        for (int i = 0; i < N; i++)
        {
            board[i] = new int[N];
        }
        shuffle_board();
        start_time = time(0);
    }

    
    ~FifteenPuzzle() { delete[] board; }

    void play()
    {
        print_board();

        while (!is_solved())
        {
            int x, y;
            cout << "Enter tile to move (row col): ";
            cin >> x >> y;

            if (move_tile(x, y)) 
            {
                moves++;
                print_board();
            }
            else 
            {
                cout << "Invalid move!" << endl;
            }
        }

        time_t endTime = time(0);
        double yourTime = difftime(endTime, start_time);
        cout << "Congratulations! You solved the puzzle in " << moves << " moves and " << yourTime << " seconds." << endl;
    }
};


int main()
{
    int size;
    cout << "Enter the size of the board (3 for 3x3, 4 for 4x4): ";
    cin >> size;
    if (size < 3 || size > 4) 
    {
        cout << "Invalid size! Defaulting to 4x4." << endl;
        size = 4;
    }

    FifteenPuzzle game(size);
    game.play();
}
