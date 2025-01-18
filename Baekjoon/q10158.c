#include <stdio.h>

int go(int t, int s, int e)
{
    t -= e - s;
    printf("go %d -> %d t: %d\n", s, e, t);
    if (t / e % 2 == 0) return e - (t % e);
    else return t % e;
}

int main()
{
    int t = 4, p = 5, q = 3, w = 6, h = 4;
    int x = go(t, p, w);
    int y = go(t, q, h);
    printf("%d, %d", x, y);
}

