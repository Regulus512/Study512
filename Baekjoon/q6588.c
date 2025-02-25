#include <stdio.h>

int isOddPrime(int a, int b, int p)
{
    int res = 1;
    
    //printf("p: %d\n", p);
    for(int i=3; i<p; i+=2)
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
    {
        int n = 1000000;
        int p = 3, res = 1;
        for(; p*p<n; p+=2);
        for(int i = 3; i <= n-3; i+=2)
        {
            res = isOddPrime(i, n-i, p);
            if (res)
            {
                break;
            }
        }
        if (res==0)
        {
            printf("Goldbach's conjecture is wrong.\n");
        }
        
    }
    
}

