#include <stdio.h>

int main() {
    int a, b, v; scanf_s("%d %d %d", &a, &b, &v);

    //int a = 100, b = 99, v = 1000000000;

    if (a == v) printf("1");
    else
    {
        int res = 0;
        for (int i = 1; res < v; i++, res += a-b)
        {
            //printf("%d] %d\n", i, res);
            if (res + a >= v)
            {
                printf("%d", i);
                    break;
            }
        }
    }
}