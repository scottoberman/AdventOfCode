#include "trajectory.h"

Trajectory::Trajectory(int moveX, int moveY)
{
    // Components that make up the slope
    this->moveX = moveX;
    this->moveY = moveY;
}

void Trajectory::AddRow(string row)
{
    trajRows.push_back(row);
}

int Trajectory::TreeEncounters()
{
    // Start top left corner
    int x = 0;
    int y = 0;

    int treeEncounters = 0;

    char treeChar = '#';

    // Assuming that starting point is always devoid of trees.
    while (y + moveY < trajRows.size())
    {
        x += moveX;
        y += moveY;
        char trajLocationChar = trajRows[y].at(x % (trajRows[y].size()));
        if (trajLocationChar == treeChar)
            treeEncounters++;

    }

    return treeEncounters;
}

int Trajectory::GetMoveX() const
{
    return moveX;
}
int Trajectory::GetMoveY() const
{
    return moveY;
}