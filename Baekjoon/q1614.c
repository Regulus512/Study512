#include <stdio.h>

int main() {
    int n=5, cnt=1;
    long long res = 0;

    int v=-1;
    for(int i=1; ; i+=v, res++)
    {
        printf("%lld) %d",res, i);
        if(i == n)
        {
            printf("*");
            cnt--;
            if (cnt < 0)
            {
                printf("\n");
                break;
            }
        }
        if(i==1 || i==5) v*=-1;
        printf("\n");
    }
    
    printf("%lld", res);
}