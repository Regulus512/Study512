#include <stdio.h>

int go(int s, int e, int t)
{
    if (s + t <= e) return s + t;
    t -= e - s;
    //printf("go %d -> %d t: %d\n", s, e, t);
    if (t / e % 2 == 0) return e - (t % e);
    else return t % e;
}

int main()
{
    int w = 6, h = 4, p = 5, q = 3, t=4;
    int x = go(p, w, t);
    int y = go(q, h, t);
    printf("%d %d", x, y);
}

