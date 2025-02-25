#include <stdio.h>

int isOddPrime(int n, int p)
{
    if (n == 3) return n;
    
    //printf("p: %d\n", p);
    for(int i=3; i<n/2 && i<p; i+=2)
    {
        if (n % i == 0)
        {
            //printf("%d is divided by %d\n", n, i);
            return 0;
        }
    }
    return n;
}

int main()
{
    
    for(int i = 0; i<100000; i++)
    //for(int n=100; n<=150; n+=2)
    {
        int n=1000000;
        
        int a = 0, b = 0, p = 3;
        for(; p*p<=n; p+=2);
        //printf("p: %d\n", p);
        
        for(int i = 3; i <= n-3; i+=2)
        {
            a = isOddPrime(i, p); b = isOddPrime(n - i, p);
            if (0 < a && 0 < b)
            {
                break;
            }
        }
        if (0 < a && 0 < b){}
            //printf("%d = %d + %d\n", n, a, b);
        else
        {
            printf("%d's Goldbach's conjecture is wrong.\n", n);
            //break;
        }
        
    }
    
}

