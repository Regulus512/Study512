#include <stdio.h>

int main() {
    int n; scanf_s("%d", &n);
    long long sum = 0L;
    for(int i = 1; i < n; i++)
    {
        //printf("%d\n", n*i+i);
        sum += (long long)n*i+i;
    }
    printf("%lld", sum);
}