#include <stdio.h>

int isOddPrime(int n)
{
    if (n == 3) return n;
    int p = 3;
    for(; p*p<n; p+=2);
    //printf("p: %d\n", p);
    for(int i=3; i<=p; i+=2)
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
    
    //for(int i = 0; i<100000; i++)
    for(int n=6; n<=100; n+=2)
    {
        //int n=100000;
        int a = 0, b = 0;
        for(int i = 3; i <= n-3; i+=2)
        {
            a = isOddPrime(i); b = isOddPrime(n - i);
            if (0 < a && 0 < b)
            {
                break;
            }
        }
        if (0 < a && 0 < b)
            printf("%d = %d + %d\n", n, a, b);
        else
        {
            printf("Goldbach's conjecture is wrong.\n");
            break;
        }
            
    }
    
}

