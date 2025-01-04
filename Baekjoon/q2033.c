#include <stdio.h>

int main()
{
    int n; scanf_s("%d", &n);
    int v = 10;
    while (n > v)
    {
        //printf("%d\n", n%v/(v/10));
        //printf("%d\n", n);
        n = (n % v / (v / 10) < 5) ? n / v * v : (n / v + 1) * v;
        v *= 10;
    }
    printf("%d", n);
}

