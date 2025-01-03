#include <stdio.h>

int gcd(int a, int b)
{
    while(b!=0)
    {
        int v = a%b;
        a = b;
        b = v;
        //printf("%d %d\n", a, b);
    }
    return a;
}

int main() {
    int n; scanf_s("%d", &n);
    for(int i=0; i<n; i++)
    {
        int a, b; scanf_s("%d %d", &a, &b);
        int g=gcd(a,b);
        //printf("gcd: %d\n", g);
        //printf("lcm: %d\n", a/g*b/g*g);
        printf("%d %d\n", a/g*b/g*g, g);
    }
}