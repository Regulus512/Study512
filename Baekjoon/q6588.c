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
    for(int n=6; n<=10; n+=2)
    {
        printf("[%d] ", n);
        //int n=100000;
        int p = 3, res = 0;
        int a = 0, b = 0;
        for(; p*p<n; p+=2);
        for(int i = 3; i <= n-3; i+=2)
        {
            
            for(int j=3; j<=p; j+=2)
            {
                if (i % j != 0)
                {
                    a = i;
                    printf("a = %d\n", a);
                }
                if((n-i)%j !=0)
                {
                    b = n - i;
                    printf("b = %d\n", b);
                }
            }


            /*
            if(res==0)
            {
                printf("Goldbach's conjecture is wrong.\n");
            }
            */
        }
        printf("\n");
    }
    
}

