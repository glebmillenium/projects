#include <stdio.h>
#include <math.h>
#include <omp.h>

int main() {
    const int N = 10000000;
    const double L = 1.0;
    const double h = L / N;
    const double x_0 = 0.0;
    double pi;
    double t_1, t_2; //временные интервалы
    int i;
    double sum = 0.0;
    t_1 = omp_get_wtime(); //начальный замер времени
#pragma omp parallel for reduction(+: sum) schedule(static)
    for (i = 0; i < N; ++i) {
        double x = x_0 + i * h + h / 2;
        sum += sqrt(1 - x * x);
    }
    t_2 = omp_get_wtime(); //начальный замер времени
    pi = sum * h * 4.0;
    printf("оmp_gеt_mаx_thrеаds(): %d\n", omp_get_max_threads());
    printf("timе: %f\n", t_2 - t_1);
    printf("pi ~ %f\n", pi);
    return 0;
}
