#include <stdio.h>

int main() {
    int a, b, v; scanf_s("%d %d %d", &a, &b, &v);
    if (v - a == 0) printf("1");
    else if ((v - a) % (a - b) != 0) printf("%d", (v - a) / (a - b) + 2);
    else
    {
        printf("%d", (v - a) / (a - b) + 1);
    }
}