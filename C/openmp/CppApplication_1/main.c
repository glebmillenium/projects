/* 
 * File:   main.cpp
 * Author: glebmillenium
 *
 * Created on 22 октября 2017 г., 22:45
 */

#include <stdio.h>
#include <math.h>
#include <omp.h>
#include <unistd.h>

void start_reade(int N, int M)
{
    while(1)
    {
        printf("1\n");
        usleep(1000000);
    }
}

void start_write(int M)
{
    while(1)
    {
        printf("2\n");
        usleep(1000000);
    }
}

/*
 * 
 */
int main(int argc, char** argv) {
    int n = 0;

    int N, M;
    
    printf("Введите число писателей: ");
    scanf("%d", &M);
    
    printf("Введите число читателей: ");
    scanf("%d", &N);
    
    omp_set_num_threads(20);
    #pragma omp parallel sections
    {
       #pragma omp section
        start_write(M);

       #pragma omp section
        start_reade(N, M);
    }
    return 0;
}

