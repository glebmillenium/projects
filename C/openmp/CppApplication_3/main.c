/* 
 * File:   main.cpp
 * Author: glebmillenium
 *
 * Created on 22 октября 2017 г., 22:45
 */

#include <stdio.h>
#include <time.h>
#include <stdlib.h>
#include <math.h>
#include <omp.h>

const float RAND_MAX_F = RAND_MAX;
float get_rand() {
    return rand() / RAND_MAX_F;
}

float get_rand_range(const float min, const float max) {
    return get_rand() * (max - min) + min;
}

/*
 * 
 */
int main(int argc, char** argv) {
    double expectedValue1 = 0;
    int count1 = 0;
    double expectedValue2 = 0;
    int count2 = 0;
    int i, j;
    int sizeArray;
    double t_1, t_2;
    printf("Введите размерность квадратной матрицы A: "); // выводим сообщение
    scanf("%d", &sizeArray);     // вводим значения переменной y
    srand(time(NULL));
    
    double *A = (double *) malloc(sizeof(double) * sizeArray * sizeArray);
    for(i = 0; i < sizeArray; i++)
    {
        for(j = 0; j < sizeArray; j++)
        {
            *(A + i * sizeArray + j) = get_rand_range(-100, 100);
            //printf("%f\n", *(A + i * sizeArray + j));
        }
    }
    
    t_1 = omp_get_wtime();
    for (i = 0; i < sizeArray; i++) {
        if(*(A+i*sizeArray+i) >= 0)
        {
            expectedValue1 += *(A + i * sizeArray + i);
            count1++;

        } 
        if(*(A + i * sizeArray + sizeArray - i - 1) < 0)
        {
            expectedValue2 += *(A + i * sizeArray + sizeArray - i - 1);
            count2++;
        }
    }
    t_2 = omp_get_wtime();
    printf("Без OpenMP:\n  Сумма векторов положительных чисел по главной диагонали: %f\n"
            "  Сумма векторов отрицательных чисел по побочной диагонали: %f\n", 
            expectedValue1/count1, expectedValue2/count2);
    printf("timе: %f\n", t_2 - t_1);
    


    expectedValue1 = 0.0;
    expectedValue2 = 0.0;
    count1 = 0;
    count2 = 0;

    t_1 = omp_get_wtime();
    #pragma omp parallel for reduction(+: expectedValue1, count1, expectedValue2, count2) shared(A) private(i)
    for (i = 0; i < sizeArray; i++) {
        if(*(A+i*sizeArray+i) >= 0)
        {
            expectedValue1 += *(A + i * sizeArray + i);
            count1++;
        } 
        if(*(A + i * sizeArray + sizeArray - i - 1) < 0)
        {
            expectedValue2 += *(A + i * sizeArray + sizeArray - i - 1);
            count2++;
        }
    }

    t_2 = omp_get_wtime();
    
    printf("C OpenMP:\n  Сумма векторов положительных чисел по главной диагонали: %f\n"
            "  Сумма векторов отрицательных чисел по побочной диагонали: %f\n", 
            expectedValue1/count1, expectedValue2/count2);
    printf("timе: %f\n", t_2 - t_1);
    
    return 0;
}