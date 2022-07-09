#include <stdio.h>
#include <malloc.h>

union student
{
    char letterGrade;
    int roundedGrade;
    float exactGrade;
} student, *STUDENT;

int main(int argc, char const *argv[])
{
    STUDENT = malloc(sizeof(student));

    STUDENT->exactGrade = 100;
    printf("Student exactGrade [%.02f]\n", STUDENT->exactGrade);
    printf("Student letterGrade [%c]\n", STUDENT->letterGrade);
    printf("Student roundedGrade [%d]\n", STUDENT->roundedGrade);
    STUDENT->letterGrade = 'A';
    printf("Student exactGrade [%02f]\n", STUDENT->exactGrade);
    printf("Student letterGrade [%c]\n", STUDENT->letterGrade);
    printf("Student roundedGrade [%d]\n", STUDENT->roundedGrade);
    STUDENT->roundedGrade = 99;
    printf("Student exactGrade [%.02f]\n", STUDENT->exactGrade);
    printf("Student letterGrade [%c]\n", STUDENT->letterGrade);
    printf("Student roundedGrade [%d]\n", STUDENT->roundedGrade);
    
    free(STUDENT);

    STUDENT = NULL;
    return 0;
}
