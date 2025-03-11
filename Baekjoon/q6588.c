#include <stdio.h>

int isOddPrime(int a, int b)
{
    int res = 1;
    
    //printf("p: %d\n", p);
    for(int i=3; i*i<=b; i+=2)
    {
        if (i<a && a%i==0)
        {
            res=0; break;
        }
        if (b%i==0)
        {
            res=0; break;
        }
    }
    return res;
}

int main()
{
    for(int c = 0; c<100000; c++)
    //while(1)
    {
        int a = 0, b = 0;
        int n = 1000000;
        //int n; scanf("%d", &n);
        if(n==0) break;
        for(int i=3; i<n; i+=2)
        {
            if(isOddPrime(i, n-i))
            {
                a=i; b=n-i;
                break;
            }
        }
        if(a==0)
        {
            printf("Goldbach's conjecture is wrong.\n");
        }
        else
        {
            //printf("%d = %d + %d\n", n, a, b);
        }
    }
}
