#include <stdio.h>

int getdif(int n)
{
    if (n / 10 == 0) return 1;
    int res = n % 10 - n / 10 % 10;
    //printf("%d - %d = %d\n", n%10, n/10%10, res);
    return res;
}

int main()
{
    int x = 1000;
    if (x == 1000) x--;
    int cnt = 0;
    for (int i = 1; i <= x; i++)
    {
        int dif = getdif(i);
        if (i < 100 || dif == getdif(i / 10))
        {
            //printf("%d true\n", i);
            cnt++;
        }
    }
    
    printf("%d", cnt);
}

