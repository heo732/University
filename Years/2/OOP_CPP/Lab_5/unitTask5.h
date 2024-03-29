//---------------------------------------------------------------------------
#ifndef unitTask5H
#define unitTask5H

#include <string>
#include <Classes.hpp>
#include <ExtCtrls.hpp>
#include <math.h>
using namespace std;
//---------------------------------------------------------------------------
class Human
{
        protected:

        bool _sex;
        TColor _eyesColor;
        TColor _hairColor;

        public:

        Human(bool sex, TColor eyesColor, TColor hairColor)
        {
                _sex = sex;
                _eyesColor = eyesColor;
                _hairColor = hairColor;
        }

        void drawHuman(TImage*& image, int left, int top, int width, int height)
        {
                float x0 = left + width/2;
                float y0 = top + height/2;

                float headWidth = width * 0.382;
                float hairLength = (_sex) ? headWidth * 0.15 : headWidth * 0.4;
                float mouthWidth = headWidth * 0.382;

                float bodyHeight = (_sex) ? height*0.382 : height*0.45;
                float bodyWidth = width * 0.382;

                float eyeWidth = headWidth * 0.2;
                float leftEyeX0 = x0 - eyeWidth*0.95;
                float eyesY0 = y0 - bodyHeight*0.6 - headWidth*0.618;
                float rightEyeX0 = x0 + eyeWidth*0.95;

                image->Canvas->Pen->Color = clBlack;
                image->Canvas->Brush->Color = clWhite;
                image->Canvas->Pen->Width = 3;

                //head
                image->Canvas->Ellipse(x0 - headWidth/2, y0 - bodyHeight*0.6 - headWidth,
                x0 + headWidth/2, y0 - bodyHeight*0.6);

                //mouth
                image->Canvas->MoveTo(x0 - mouthWidth*0.5, y0 - bodyHeight*0.6 - headWidth*0.2 - mouthWidth*0.1);
                image->Canvas->LineTo(x0 - mouthWidth*0.3, y0 - bodyHeight*0.6 - headWidth*0.2);
                image->Canvas->LineTo(x0 + mouthWidth*0.3, y0 - bodyHeight*0.6 - headWidth*0.2);
                image->Canvas->LineTo(x0 + mouthWidth*0.5, y0 - bodyHeight*0.6 - headWidth*0.2 - mouthWidth*0.1);

                //eyes
                image->Canvas->Pen->Color = _eyesColor;
                image->Canvas->Brush->Color = _eyesColor;
                image->Canvas->Ellipse(leftEyeX0 - eyeWidth/2, eyesY0 - eyeWidth/2,
                leftEyeX0 + eyeWidth/2, eyesY0 + eyeWidth/2);
                image->Canvas->Ellipse(rightEyeX0 - eyeWidth/2, eyesY0 - eyeWidth/2,
                rightEyeX0 + eyeWidth/2, eyesY0 + eyeWidth/2);
                image->Canvas->Pen->Color = clBlack;
                image->Canvas->Brush->Color = clBlack;
                image->Canvas->Ellipse(leftEyeX0 - eyeWidth/6, eyesY0 - eyeWidth/6,
                leftEyeX0 + eyeWidth/6, eyesY0 + eyeWidth/6);
                image->Canvas->Ellipse(rightEyeX0 - eyeWidth/6, eyesY0 - eyeWidth/6,
                rightEyeX0 + eyeWidth/6, eyesY0 + eyeWidth/6);

                //hair
                image->Canvas->Pen->Color = _hairColor;
                image->Canvas->MoveTo(x0, y0 - bodyHeight*0.6 - headWidth);
                image->Canvas->LineTo(x0, y0 - bodyHeight*0.6 - headWidth - hairLength);
                image->Canvas->MoveTo(x0, y0 - bodyHeight*0.6 - headWidth);
                image->Canvas->LineTo(x0 - hairLength/sqrt(2), y0 - bodyHeight*0.6 - headWidth - hairLength/sqrt(2));
                image->Canvas->MoveTo(x0, y0 - bodyHeight*0.6 - headWidth);
                image->Canvas->LineTo(x0 + hairLength/sqrt(2), y0 - bodyHeight*0.6 - headWidth - hairLength/sqrt(2));

                image->Canvas->Pen->Color = clBlack;
                if(_sex)
                {
                        //body
                        image->Canvas->MoveTo(x0, y0 + bodyHeight*0.4);
                        image->Canvas->LineTo(x0 - bodyWidth/2, y0 - bodyHeight*0.6);
                        image->Canvas->LineTo(x0 + bodyWidth/2, y0 - bodyHeight*0.6);
                        image->Canvas->LineTo(x0, y0 + bodyHeight*0.4);


                        //arms
                        float armHeight = bodyHeight*0.8;
                        float armWidth = armHeight*0.2;
                        float leftArmX0 = x0 - bodyWidth/2 - armWidth/2;
                        float rightArmX0 = x0 + bodyWidth/2 + armWidth/2;
                        float armY0 = y0 - bodyHeight*0.6 + armHeight/2;

                        image->Canvas->MoveTo(leftArmX0 + armWidth/2, armY0 - armHeight/2);
                        image->Canvas->LineTo(leftArmX0 - armWidth/2, armY0);
                        image->Canvas->LineTo(leftArmX0 + armWidth/2, armY0 + armHeight/2);

                        image->Canvas->MoveTo(rightArmX0 - armWidth/2, armY0 - armHeight/2);
                        image->Canvas->LineTo(rightArmX0 + armWidth/2, armY0);
                        image->Canvas->LineTo(rightArmX0 - armWidth/2, armY0 + armHeight/2);

                        //legs
                        float legHeight = bodyHeight*0.8;
                        float legWidth = bodyWidth*0.4;
                        float footLength = legWidth*0.4;
                        float legY0 = y0 + bodyHeight*0.4 + legHeight/2;
                        float leftLegX0 = x0 - legWidth/2;
                        float rightLegX0 = x0 + legWidth/2;

                        image->Canvas->MoveTo(leftLegX0 + legWidth/2, legY0 - legHeight/2);
                        image->Canvas->LineTo(leftLegX0 - legWidth/2, legY0 + legHeight/2);
                        image->Canvas->LineTo(leftLegX0 - legWidth/2 - footLength, legY0 + legHeight/2);

                        image->Canvas->MoveTo(rightLegX0 - legWidth/2, legY0 - legHeight/2);
                        image->Canvas->LineTo(rightLegX0 + legWidth/2, legY0 + legHeight/2);
                        image->Canvas->LineTo(rightLegX0 + legWidth/2 + footLength, legY0 + legHeight/2);
                }
                else
                {
                        //body
                        image->Canvas->MoveTo(x0 - bodyWidth/2, y0 + bodyHeight*0.4);
                        image->Canvas->LineTo(x0, y0 - bodyHeight*0.6);
                        image->Canvas->LineTo(x0 + bodyWidth/2, y0 + bodyHeight*0.4);
                        image->Canvas->LineTo(x0 - bodyWidth/2, y0 + bodyHeight*0.4);

                        //legs
                        float legHeight = bodyHeight*0.4;
                        float legWidth = bodyWidth*0.4;
                        float footLength = legWidth*0.4;
                        float legY0 = y0 + bodyHeight*0.4 + legHeight/2;
                        float leftLegX0 = x0 - legWidth/2;
                        float rightLegX0 = x0 + legWidth/2;

                        image->Canvas->MoveTo(leftLegX0 + legWidth/2 - footLength, legY0 - legHeight/2);
                        image->Canvas->LineTo(leftLegX0 - legWidth/2, legY0 + legHeight/2);
                        image->Canvas->LineTo(leftLegX0 - legWidth/2 - footLength, legY0 + legHeight/2);

                        image->Canvas->MoveTo(rightLegX0 - legWidth/2 + footLength, legY0 - legHeight/2);
                        image->Canvas->LineTo(rightLegX0 + legWidth/2, legY0 + legHeight/2);
                        image->Canvas->LineTo(rightLegX0 + legWidth/2 + footLength, legY0 + legHeight/2);

                        //arms
                        float armHeight = bodyHeight*1.1;
                        float armWidth = armHeight*0.15;
                        float leftArmX0 = x0 - armWidth/2;
                        float rightArmX0 = x0 + armWidth/2;
                        float armY0 = y0 - bodyHeight*0.6 + armHeight/2;
                        float handLength = footLength;

                        image->Canvas->MoveTo(leftArmX0 + armWidth/2, armY0 - armHeight/2);
                        image->Canvas->LineTo(leftArmX0 - armWidth/2, armY0);
                        image->Canvas->LineTo(leftArmX0 - armWidth/2 - handLength, armY0);

                        image->Canvas->MoveTo(rightArmX0 - armWidth/2, armY0 - armHeight/2);
                        image->Canvas->LineTo(rightArmX0 + armWidth/2, armY0);
                        image->Canvas->LineTo(rightArmX0 + armWidth/2 + handLength, armY0);

                }
        }

};
//---------------------------------------------------------------------------
class Employee : public Human
{
        protected:

        float _workday;

        public:

        Employee(bool sex, TColor eyesColor, TColor hairColor, float workday) :
        Human(sex, eyesColor, hairColor)
        {
                _workday = (workday>=0 && workday<=12) ? workday : 0;
        }

        void drawClock(TImage*& image, int x0, int y0, float radius)
        {
                float angle = _workday/12.0 * 360;
                angle = angle / 180.0 * M_PI;
                float x, y;
                x = radius * sin(angle);
                y = - radius * cos(angle);

                image->Canvas->Pen->Width = 3;
                image->Canvas->Pen->Color = clBlack;
                image->Canvas->Brush->Color = clWhite;
                image->Canvas->Ellipse(x0-radius, y0-radius, x0+radius, y0+radius);
                image->Canvas->MoveTo(x0, y0);
                image->Canvas->LineTo(x0, y0-radius);
                image->Canvas->MoveTo(x0, y0);
                image->Canvas->LineTo(x0+x, y0+y);

                image->Canvas->Brush->Color = clRed;
                if(_workday < 6)
                        image->Canvas->FloodFill((x0+x0+x0+x)/3.0, (y0+y0-radius+y0+y)/3.0, clBlack, fsBorder);
                else
                        image->Canvas->FloodFill((x0+x0+x0+radius)/3.0, (y0+y0-radius+y0+radius)/3.0, clBlack, fsBorder);

                float dashLength = radius / 9.0;
                image->Canvas->MoveTo(x0, y0 - radius - dashLength/3.0);
                image->Canvas->LineTo(x0, y0 - radius - dashLength/3.0 + dashLength);

                image->Canvas->MoveTo(x0 + radius + dashLength/3.0, y0);
                image->Canvas->LineTo(x0 + radius + dashLength/3.0 - dashLength, y0);

                image->Canvas->MoveTo(x0, y0 + radius + dashLength/3.0);
                image->Canvas->LineTo(x0, y0 + radius + dashLength/3.0 - dashLength);

                image->Canvas->MoveTo(x0 - radius - dashLength/3.0, y0);
                image->Canvas->LineTo(x0 - radius - dashLength/3.0 + dashLength, y0);
        }
};
//---------------------------------------------------------------------------
class Father : public Human
{
        protected:

        int _countChildren;

        public:

        Father(bool sex, TColor eyesColor, TColor hairColor, int countChildren) :
        Human(sex, eyesColor, hairColor)
        {
                _countChildren = (countChildren >= 0) ? countChildren : 0;
        }

        void drawChildren(TImage*& image, int left, int top, int width, int height)
        {
                bool startSex = _sex;
                int minWidth = 50;
                int minHeight = 131;
                int maxWidth = 150;
                int maxHeight = 393;

                for(int i = 0; i < _countChildren; i++)
                {
                        _sex = (((double)rand()/(double)RAND_MAX) <= 0.5) ? true : false;
                        drawHuman(image, rand()%(width-maxWidth), rand()%(height-maxHeight), minWidth + rand()%(maxWidth-minWidth), minHeight + rand()%(maxHeight-minHeight));
                }

                _sex = startSex;
        }
};
//---------------------------------------------------------------------------
class EmployeeFather : public Employee, public Father
{
        public:

        EmployeeFather(bool sex, TColor eyesColor, TColor hairColor, float workday, int countChildren) :
        Employee(sex, eyesColor, hairColor, workday),
        Father(sex, eyesColor, hairColor, countChildren)
        {}
};
//---------------------------------------------------------------------------
#endif
