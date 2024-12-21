#include <stdio.h>

int main() {
    int a, b, v; scanf_s("%d %d %d", &a, &b, &v);

    if (a == v) printf("1");
    else if (v % (a - b) == 0)
    {
        printf("%d", (v - b) / (a - b) + 1);
    }
    else
    {
        printf("%d", v / (a - b) + 1);
    }
}