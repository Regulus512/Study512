#include <stdio.h>


int main()
{
	int a, b, c, d, e;
	scanf_s("%d %d %d %d %d", &a, &b, &c, &d, &e);
	
	if(a<1||b<1||c<1||d<1||e<1||
		a>100||b>100||c>100||d>100||e>100)
	{
		printf("(error) input can be 1~100");
		return;
	}

	for (int i = 1; 1; i++)
	{
		int count = (i%a==0) + (i%b==0) + (i%c==0) + (i%d==0) + (i%e== 0);
		//printf("%d] %d\n",i, count);
		if (count >= 3)
		{
			printf("%d", i);
			break;
		}
	}
	
}