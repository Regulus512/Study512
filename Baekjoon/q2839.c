#include <stdio.h>

int main() {
    int n; scanf_s("%d", &n);

    for (int i = 0; i * 3 <= n; i++)
    {
        for (int j = 0; j * 5 <= n; j++)
        {
            if (i * 3 + j * 5 == n)
            {
                //printf("3)%d + 5)%d = ", i, j);
                printf("%d", i + j);
                return 0;
            }
        }
    }

    printf("%d", -1);
}