#include <stdio.h>



int isOddPrime(int n)
{
    int p=3;
    for(;p<n; p+=2);
    
    //printf("p: %d\n", p);
    for(int i=3; i<p; i+=2)
    {
        if(n%i==0) return 0;
    }
    return 1;
}


int main()
{
    while(1)
    {
        int a = 0, b = 0;
        int n; scanf_s("%d", &n);
        if(n==0) break;
        for(int i=3; i<n; i+=2)
        {
            if(isOddPrime(i) && isOddPrime(n-i))
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
            printf("%d = %d + %d\n", n, a, b);
        }
    }
    
    
    
}

