#include <sys/types.h>
#include <sys/socket.h>
#include <sys/time.h>
#include <netinet/in.h>
#include <stdio.h>
#include <cstring>

#include "WPServer.cpp"
#include "DBConnect.cpp"


using namespace std;

int main()
{  
    //getAddres();
    //getStartData(); // from mysql

    WPServer *p = new WPServer();
    p->start();

    return 0;
}
