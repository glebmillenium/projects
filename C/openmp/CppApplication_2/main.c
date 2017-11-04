/* 
 * File:   main.cpp
 * Author: glebmillenium
 *
 * Created on 22 октября 2017 г., 22:45
 */

#include <stdio.h>
#include <math.h>
#include <omp.h>

/*
 * 
 */
int main(int argc, char** argv) {
    int sum = 0;
    int i;
    int sizeVector;
    double t_1, t_2;
    printf("Введите размерность векторов A и B: "); // выводим сообщение
    scanf("%d", &sizeVector);     // вводим значения переменной y

    
    int* A = (int *) malloc(sizeof(int) * sizeVector);
    int* B = (int *) malloc(sizeof(int) * sizeVector);
    for(i = 0; i < sizeVector; i++)
    {
        *(A + i) = i;
        *(B + i) = i;
    }
    
    t_1 = omp_get_wtime();
    #pragma omp parallel for reduction(+: sum) schedule(static)
    for (i = 0; i < sizeVector; i++) {
        sum += (*(A + i)) * (*(B + i));
    }
    t_2 = omp_get_wtime();
    printf("оmp_gеt_mаx_thrеаds(): %d\n", omp_get_max_threads());
    printf("Произведение векторов равно: %d\n", sum);
    printf("timе: %f\n", t_2 - t_1);

    return 0;
}