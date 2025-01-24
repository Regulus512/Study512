#include <stdio.h>

int v100 = 0;
int v10 = 0;
int v5 = 0;

int count(int n)
{
	v100 = 0; v10 = 0; v5 = 0;
	int cnt = 0;
	for(int i=1; i<=n; i++)
	{
		if      (i%100==0) {cnt+=2; v100+=1;}
		else if (i%10==0)  {cnt+=1; v10+=1;}
		else if (i%5==0)   {
			/*while(i)
			{
				printf("%d", i);
				cnt+=1; i/=5;
				v5+=1;
			}*/
		}
	}
	return cnt;
}

int main()
{
	for(int i = 0; i <= 500; i++)
	{
		printf("%d) (v100)%d+(v10)%d+(v5)%d = %d\n",i, v100, v10, v5, count(i));
	}
	
}