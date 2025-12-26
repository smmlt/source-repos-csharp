#pragma once
#include <fstream>

inline void Hello(std::ofstream& out)
{
    out << "file:\n" << __FILE__ << std::endl;
    out << "line\n" << __LINE__ << std::endl;
    out << "function: " << __FUNCTION__ << std::endl;
}
