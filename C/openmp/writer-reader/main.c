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
#include <time.h>
#include <stdlib.h>
#include <pthread.h>

int number_reader = 0;
int number_writer = 0;

int time_for_write = 1;
int time_pause_read = 1;
int time_for_reade = 1;
int time_pause_write = 1;

const float RAND_MAX_F = RAND_MAX;

float get_rand() {
    return rand() / RAND_MAX_F;
}

float get_rand_range(const float min, const float max) {
    return get_rand() * (max - min) + min;
}

void start_reade(pthread_mutex_t mutex[], int count_mutex) {
    int j;
#pragma omp critical
    {
        j = ++number_reader;
    }
    int choose_writer;
    double time_reade;
    double pause_read;
    while (1) {
        choose_writer = 1 + rand() % count_mutex;
        time_reade = get_rand_range(time_for_reade / 2, time_for_reade * 1.5);
        printf("Читатель №%d хочет прочитать книгу писателя №%d\n", j, choose_writer);
        pthread_mutex_lock(&mutex[choose_writer - 1]);
        printf("Читатель №%d начал читать книгу писателя №%d. Это займет %.2f сек\n",
                j, choose_writer, time_reade);
        usleep(time_reade * 1000000);
        printf("Читатель №%d закончил читать книгу писателя №%d\n", j, choose_writer);
        pthread_mutex_unlock(&mutex[choose_writer - 1]);
        pause_read = get_rand_range(time_pause_read / 2, time_pause_read * 1.5);
        usleep(pause_read * 1000000);
    }
}

void start_write(pthread_mutex_t mutex[]) {
    int k;
#pragma omp critical
    {
        k = ++number_writer;
    }
    double time_write;
    time_write = get_rand_range(time_for_write / 2, time_for_write * 1.5);
    printf("Писатель №%d начал писать книгу. Это займет %.2f сек\n",
            k, time_write);
    usleep(time_write * 1000000);
    printf("Писатель №%d закончил писать книгу\n", k);
    pthread_mutex_unlock(&mutex[k - 1]);
    double pause_write = get_rand_range(time_pause_write / 2, time_pause_write * 1.5);
    usleep(pause_write * 1000000);
    while (1) {
        time_write = get_rand_range(time_for_write / 2, time_for_write * 1.5);
        pthread_mutex_lock(&mutex[k - 1]);
        printf("Писатель №%d начал писать книгу. Это займет %.2f сек\n",
                k, time_write);
        usleep(time_write * 1000000);
        printf("Писатель №%d закончил писать книгу\n", k);
        pthread_mutex_unlock(&mutex[k - 1]);
        double pause_write = get_rand_range(time_pause_write / 2, time_pause_write * 1.5);
        usleep(pause_write * 1000000);
    }
}

/**
 * main
 * 
 * @param argc
 * @param argv
 * @return 
 */
int main(int argc, char** argv) {
    int n = 0;
    srand(time(NULL));

    int N, M;

    printf("Введите число писателей: ");
    scanf("%d", &M);

    printf("Введите число читателей: ");
    scanf("%d", &N);

    printf("Введите среднее время (сек) на создание новой книги писателем: ");
    scanf("%d", &time_for_write);

    printf("Средняя пауза (сек) между созданием новой книги писателем: ");
    scanf("%d", &time_pause_write);

    printf("Введите среднее время (сек) на чтение книги читателем: ");
    scanf("%d", &time_for_reade);

    printf("Средняя пауза (сек) на чтение новой книги читателем: ");
    scanf("%d", &time_pause_read);

    pthread_mutex_t mutex[M];
    for (int k = 0; k < M; k++) {
        pthread_mutex_init(&mutex[k], NULL);
        pthread_mutex_lock(&mutex[k]);
    }
    //omp_set_dynamic(0);
    int i = 0;
    number_reader = 0;
    number_writer = 0;
#pragma omp parallel num_threads(N + M)
    {
#pragma omp critical
        {
            i++;
        }
        if (i <= M) {
            start_write(&mutex);
        } else {
            start_reade(&mutex, M);
        }
    }
    return 0;
}

