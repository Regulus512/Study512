#include <stdio.h>

int isOddPrime(int n, int p)
{
    if (n == 3) return n;
    
    //printf("p: %d\n", p);
    for(int i=3; i<n && i<p; i+=2)
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
    //for(int n=6; n<=10; n+=2)
    {
        int n=1000000;
        int a = 0, b = 0, p = 3;
        int res = 1;
        for(; p*p<=n; p+=2);
        printf("p: %d\n", p);
        
        for(int i = 3; i <= n-3; i+=2, res=1)
        {
            for(int j=5; j<i&&j<p; j+=2)
            {
                if (i % j == 0)
                {
                    res = 0;
                    break;
                }
            }
            for(int j = p; 3<=j; j-=2)
            {
                if((n-i) % j == 0)
                {
                    res = 0;
                    break;
                }
            }
            printf("%d) %d, %d\n", res, i, n - i);
            if (res==1)
            {
                a = i;
                b = n - i;
                break;
            }
        }
        if (res)
            printf("%d = %d + %d\n", n, a, b);
        else
        {
            printf("%d's Goldbach's conjecture is wrong.\n", n);
            //break;
        }
        
    }
    
}

