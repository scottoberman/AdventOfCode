#pragma once
#include <string>
#include <vector>

using namespace std;

class Trajectory
{
public:
    Trajectory(int moveX, int moveY);
    void AddRow(string row);
    int TreeEncounters();
    int GetMoveX() const;
    int GetMoveY() const;
private:
    vector<string> trajRows;
    int moveX, moveY;
};