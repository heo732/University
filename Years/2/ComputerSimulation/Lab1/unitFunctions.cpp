//---------------------------------------------------------------------------
#pragma hdrstop
#include "unitFunctions.h"
#pragma package(smart_init)
#include <Classes.hpp>
#include <math.h>
//---------------------------------------------------------------------------
int rozpodil_1_Poisson(float lambda)
{
        float z = (float) rand() / (float) RAND_MAX ;

        //
        float pi = exp(-lambda);
        //

        float s = pi;
        int nu = 0;

        while(z >= s)
        {
                nu++;

                //
                pi *= lambda / (float)nu;
                //
                
                s += pi;
        }

        return nu;
}
//---------------------------------------------------------------------------
int rozpodil_2_Binom(float p, float alpha)
{
        float z = (float) rand() / (float) RAND_MAX ;

        //
        if(p == 0)
                p = 0.1;
        float pi = exp(alpha*log(p));
        //

        float s = pi;
        int nu = 0;

        while(z >= s)
        {
                nu++;

                //
                pi *= (alpha+(float)nu-1) * (1-p) / (float)nu;
                //
                
                s += pi;
        }

        return nu;
}
//---------------------------------------------------------------------------
int rozpodil_3_Geometry(float p)
{
        float z = (float) rand() / (float) RAND_MAX ;

        //
        float pi = p;
        //

        float s = pi;
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
int rozpodil_4_Binom(int n, float p)
{

        int nu = 0;

        for(int i = 0; i < n; i++)
        {
                float z = (float) rand() / (float) RAND_MAX ;
                if(z <= p)
                        nu++;
        }

        return nu;
}
//---------------------------------------------------------------------------
float rozpodil_5_Exp(float lambda)
{
        float y = (float)rand() / (float)RAND_MAX;
        if(y == 0)
                y = 0.000000000001;
        return -1.0 / lambda * log(y);
}
//---------------------------------------------------------------------------
float rozpodil_6_Pareto(float lambda, float alpha)
{
        float z = (float)rand() / (float)RAND_MAX;
        if(z == 0)
                z = 0.000000000001;
        return lambda * exp(-1.0/alpha*log(z)) - lambda;
}
//---------------------------------------------------------------------------
float rozpodil_7_Vidrizok(float a, float b)
{
        float z = (float)rand() / (float)RAND_MAX;
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
float selectiveAverage(float* arr, int n)
{
        float sum = 0;
        for(int i = 0; i < n; i++)
                sum += arr[i];
        sum /= (float)n;
        return sum;
}
//---------------------------------------------------------------------------
float selectiveDispersion(float* arr, int n)
{
        float sum = 0;
        for(int i = 0; i < n; i++)
                sum += arr[i] * arr[i];
        sum /= (float)n;
        return sum - selectiveAverage(arr, n) * selectiveAverage(arr, n);
}
//---------------------------------------------------------------------------
