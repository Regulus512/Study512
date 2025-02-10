#include <stdio.h>

int count(int n, int cnt)
{
    long long res = 0;

    int v = -1;
    for (int i = 1; ; i += v, res++)
    {
        //printf("%lld) %d", res, i);
        if (i == n)
        {
            //printf("*");
            cnt--;
            if (cnt < 0)
            {
                //printf("\n");
                break;
            }
        }
        if (i == 1 || i == 5) v *= -1;
        //printf("\n");
    }

    printf("count: %lld\n", res);
}


int main() {
    long long n=2, cnt=3;
    long long res = 0;

    switch (n)
    {
        case 1:
        case 5:
            res = 8 * cnt + (n - 1);
            break;
        case 2:
        case 3:
        case 4:
            res = (cnt % 2 == 0) ? 4 * cnt + (n - 1) : 4 * cnt + (10 - n) - 1;
            break;
    }
    printf("switch: %lld\n", res);
    count(n, cnt);
}