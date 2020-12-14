#include <fstream>
#include <iostream>
#include <sstream>
#include <string>
#include "trajectory.h"

using namespace std; // Yeah, it's bad practice if your code has any girth really.

int main(int argc, char* argv[])
{
    // Should probably just stick in a vector instead
    // of double pointer shenanigans.
    Trajectory** trajs = new Trajectory*[5];

    trajs[0] = new Trajectory(1, 1);
    trajs[1] = new Trajectory(3, 1);
    trajs[2] = new Trajectory(5, 1);
    trajs[3] = new Trajectory(7, 1);
    trajs[4] = new Trajectory(1, 2);
    
    for (int x = 0; x < 5; x++)
    {
        // Inefficently re-reading from the file currently for
        // each trajectory analysis.
        ifstream iFile(argv[1]);
        string line;
        while (std::getline(iFile, line))
        {
            trajs[x]->AddRow(line);
        }
        iFile.close();
        cout << "Tree Counters for Comp. (" << trajs[x]->GetMoveX() << ", " << trajs[x]->GetMoveY() <<"): " << trajs[x]->TreeEncounters() << endl;
    }
    
}