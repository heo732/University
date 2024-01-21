//---------------------------------------------------------------------------
#pragma hdrstop
#include "unitFunctions.h"
#pragma package(smart_init)

#include <Classes.hpp>
#include <math.h>
//---------------------------------------------------------------------------
int rozpodil_1_Poisson(double lambda)
{
        double z = (double) rand() / (double) RAND_MAX ;

        //
        double pi = exp(-lambda);
        //

        double s = pi;
        int nu = 0;

        while(z >= s)
        {
                nu++;

                //
                pi *= lambda / (double)nu;
                //
                
                s += pi;
        }

        return nu;
}
//---------------------------------------------------------------------------
int rozpodil_2_Binom(double p, double alpha)
{
        double z = (double) rand() / (double) RAND_MAX ;

        //
        if(p == 0)
                p = 0.1;
        double pi = exp(alpha*log(p));
        //

        double s = pi;
        int nu = 0;

        while(z >= s)
        {
                nu++;

                //
                pi *= (alpha+(double)nu-1) * (1-p) / (double)nu;
                //
                
                s += pi;
        }

        return nu;
}
//---------------------------------------------------------------------------
int rozpodil_3_Geometry(double p)
{
        double z = (double) rand() / (double) RAND_MAX ;

        //
        double pi = p;
        //

        double s = pi;
        int nu = 0;

        while(z >= s)
        {
                nu++;

                //
                pi *= (1-p);
                //
                
                s += pi;
        }

        return nu;
}
//---------------------------------------------------------------------------
int rozpodil_4_Binom(int n, double p)
{

        int nu = 0;

        for(int i = 0; i < n; i++)
        {
                double z = (double) rand() / (double) RAND_MAX ;
                if(z <= p)
                        nu++;
        }

        return nu;
}
//---------------------------------------------------------------------------
double rozpodil_5_Exp(double lambda)
{
        double y = (double)rand() / (double)RAND_MAX;
        if(y == 0)
                y = 0.000000000001;
        return -1.0 / lambda * log(y);
}
//---------------------------------------------------------------------------
double rozpodil_6_Pareto(double lambda, double alpha)
{
        double z = (double)rand() / (double)RAND_MAX;
        if(z == 0)
                z = 0.000000000001;
        return lambda * exp(-1.0/alpha*log(z)) - lambda;
}
//---------------------------------------------------------------------------
double rozpodil_7_Vidrizok(double a, double b)
{
        double z = (double)rand() / (double)RAND_MAX;
        return (b-a) * z + a;
}
//---------------------------------------------------------------------------
double rozpodil_8_Normal(double a, double sigma_2)
{
        int n = 12;
        double sum = 0;
        for(int i = 0; i < n; i++)
                sum += (double)rand() / (double)RAND_MAX;
        sum -= (double)n / 2.0;
        if(sigma_2 <= 0)
                sigma_2 = 100;
        return sum * sqrt(sigma_2) + a;
}
//---------------------------------------------------------------------------
double selectiveAverage(double* arr, int n)
{
        double sum = 0;
        for(int i = 0; i < n; i++)
                sum += arr[i];
        sum /= (double)n;
        return sum;
}
//---------------------------------------------------------------------------
double selectiveDispersion(double* arr, int n)
{
        double sum = 0;
        for(int i = 0; i < n; i++)
                sum += arr[i] * arr[i];
        sum /= (double)n;
        return sum - selectiveAverage(arr, n) * selectiveAverage(arr, n);
}
//---------------------------------------------------------------------------

