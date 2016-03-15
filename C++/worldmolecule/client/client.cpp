#include <sys/types.h>
#include <unistd.h>
#include <cstdlib>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <cstdio>
#include <iostream>
using namespace std;

char *buf = new char[1024];
char *answer = new char[1024];

int main()
{
    int sock;
    struct sockaddr_in addr;

    sock = socket(AF_INET, SOCK_STREAM, 0);
    if(sock < 0)
    {
        perror("socket");
        exit(1);
    }

    addr.sin_family = AF_INET;
    addr.sin_port = htons(3425); // или любой другой порт...
    cout << INADDR_LOOPBACK;
    addr.sin_addr.s_addr = htonl(INADDR_LOOPBACK);
    if(connect(sock, (struct sockaddr *)&addr, sizeof(addr)) < 0)
    {
        perror("connect");
        exit(2);
    }

    cin >> buf;
    for(int i = 1; i<10; i++)
    { 
	
        send(sock, buf, sizeof(buf), 0);
        recv(sock, answer, 1024, 0);
        cout << answer << " :твои полученные данные" << endl;
	sleep(2);
    }
    
    cout << "final \n";
    close(sock);

    return 0;
}
