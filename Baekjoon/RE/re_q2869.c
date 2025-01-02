#include <stdio.h>

int main() {
    int a,b,v; scanf("%d %d %d", &a, &b, &v);
    
    int day = (v-a)/(a-b);
    //printf("day: %d\n", day);
    int hei = (a-b)*day;
    //printf("hei: %d\n", hei);
    
    day += (v-hei>a)? 2 : 1;
    printf("%d", day);
}